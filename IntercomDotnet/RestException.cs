using System;
using RestSharp;

namespace intercom_dotnet
{
    public class RestException : Exception
    {
        public IRestResponse Response { get; set; }
    }
}
