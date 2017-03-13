using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Performance.Rest.Models.Response
{
    public class UrlResponseTimeModel
    {

        public UrlResponseTimeModel()
        {
            
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int Repetition { get; set; }

        public double ResponseTimeAverage { get; set; }

        public ICollection<double> ResponseTimesAmericas { get; set; }

        public ICollection<double> ResponseTimesEurope { get; set; }

        public ICollection<double> ResponseTimesAsia { get; set; }

    }
}