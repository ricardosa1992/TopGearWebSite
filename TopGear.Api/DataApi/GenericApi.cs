using System;
using System.Configuration;
using System.Net.Http;

namespace TopGear.Api.DataApi
{
    public class GenericApi
    {
        protected GenericApi() { }

        protected static readonly string Token = ConfigurationManager.AppSettings["Token"];
        protected static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"])
        };
    }
}
