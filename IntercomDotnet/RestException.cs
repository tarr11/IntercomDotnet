using System;
using System.Net;
using RestSharp;

namespace intercom_dotnet
{
    public class RestException : Exception
    {
        public int StatusCode { get; private set; }
        public IRestResponse Response { get; private set; }

        public RestException(int statusCode, IRestResponse response)
        {
            StatusCode = statusCode;
            Response = response;
        }

        public RestException(IRestResponse response)
        {
            Response = response;
        }

        public bool IsRateLimited
        {
            get { return StatusCode == 429; }
        }
    }
}
