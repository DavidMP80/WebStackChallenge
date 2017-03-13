using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Performance.Rest.Models.Request
{
    public class UrlRequestModel
    {
        public UrlRequestModel()
        {
            
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int Repetition { get; set; }
    }
}