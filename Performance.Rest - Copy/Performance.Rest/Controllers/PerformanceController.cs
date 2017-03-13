
namespace Performance.Rest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Web.Http;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Performance.Rest.Models.Request;
    using Performance.Rest.Models.Response;

    public class PerformanceController : ApiController
    {
        [HttpPost]
        public string GetResponseTime(UrlRequestModel request)
        {
            var responses = this.GetResponseTimes(request);
            
            var response = JsonConvert.SerializeObject(responses, new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                                DateParseHandling = DateParseHandling.None
                            });
            
            return response;
        }

        private UrlResponseTimeModel GetResponseTimes(UrlRequestModel request)
        {
            var response = new UrlResponseTimeModel();

            response.Id = request.Id;
            response.Name = request.Name;
            response.Url = request.Url;
            response.Repetition = request.Repetition;

            response.ResponseTimesAmericas = new List<double>();
            response.ResponseTimesEurope = new List<double>();
            response.ResponseTimesAsia = new List<double>();

            for (int rep = 0; rep < request.Repetition; rep++)
            {
                response.ResponseTimesAmericas.Add(this.GetResponseTimes(request.Url));
                response.ResponseTimesEurope.Add(this.GetResponseTimes(request.Url));
                response.ResponseTimesAsia.Add(this.GetResponseTimes(request.Url));
            }

            response.ResponseTimeAverage = this.GetAverageTimes(response);

            return response;
        }

        private double GetResponseTimes(string url)
        {
            return new Random().NextDouble() * 10;

            //var pingSender = new Ping();

            ////pingSender.PingCompleted += PingSender_PingCompleted;

            ////// Create a buffer of 32 bytes of data to be transmitted.
            ////string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            ////byte[] buffer = Encoding.ASCII.GetBytes(data);

            //// Set options for transmission:
            //// The data can go through 64 gateways or routers
            //// before it is destroyed, and the data packet
            //// cannot be fragmented.
            //PingOptions options = new PingOptions(64, true);

            ////pingSender.SendAsync(url, 2, buffer, options);
            //var reply = pingSender.Send(url);

            //double response = 0;

            //if (reply.Status == IPStatus.Success)
            //{
            //    response = double.Parse(reply.RoundtripTime.ToString());
            //}

            //return response;
        }

        private void PingSender_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            
        }

        private double GetAverageTimes(UrlResponseTimeModel responseTimes)
        {
            var averages = new List<double>
                               {
                                   responseTimes.ResponseTimesAmericas.Average(),
                                   responseTimes.ResponseTimesEurope.Average(),
                                   responseTimes.ResponseTimesAsia.Average()
                               };
            return averages.Average();
        }
    }
}