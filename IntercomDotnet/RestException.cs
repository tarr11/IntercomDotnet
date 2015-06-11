using System;
using RestSharp;

namespace intercom_dotnet
{
    public class RestException : Exception
    {
        public int StatusCode { get; protected set; }
        public IRestResponse Response { get; protected set; }
        public string ExtraInfo { get; protected set; }

        public RestException(IRestResponse response, string extraInfo = null)
        {
            StatusCode = (int)response.StatusCode;
            Response = response;
            ExtraInfo = extraInfo;
        }

        public virtual bool IsRateLimited
        {
            get { return StatusCode == (int)ExtraHttpStatusCodes.TooManyRequests; }
        }

        public override string Message
        {
            get
            {
                return string.Format("Status code: {0}\nResponse Status: {1}\nResponse Content: {2}", StatusCode,
                                     Response.StatusDescription, Response.Content);
            }
        }
    }
}
