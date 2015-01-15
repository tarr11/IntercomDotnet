using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace intercom_dotnet
{
    /// <summary>
    /// Specific exception class which also parses rate limiting information from the server if a 429 is received
    /// </summary>
    public class RestRateLimitException : RestException
    {
        public const string XRateLimitReset = "X-RateLimit-Reset";
        public const string XRateLimitLimit = "X-RateLimit-Limit";
        public const string XRateLimitRemaining = "X-RateLimit-Remaining";

        public RestRateLimitException(IRestResponse response, string extraInfo = null) : base(response, extraInfo)
        {
            // Read rate limit header information from the response
            RateLimitExpiresUnix = ReadProperty(response.Headers, XRateLimitReset);
            RateLimitExpires =
                ((new DateTime(1970, 1, 1)) + TimeSpan.FromSeconds(RateLimitExpiresUnix))
                    .ToUniversalTime();

            RateLimitLimit = ReadProperty(response.Headers, XRateLimitLimit);
            RateLimitRemaining = ReadProperty(response.Headers, XRateLimitRemaining);
        }

        /// <summary>
        /// Helper function to read the value of the parameter and convert to int - if failed to read, then return default of 0
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="headerName"></param>
        /// <returns></returns>
        private static int ReadProperty(IEnumerable<Parameter> parameters, string headerName)
        {
            var header = parameters.SingleOrDefault(x => x.Name.ToLower() == headerName.ToLower());
            int value;

            if (header != null && int.TryParse(header.Value.ToString(), out value))
            {
                return value;
            }

            return 0;
        }

        public int RateLimitExpiresUnix { get; private set; }
        public DateTime RateLimitExpires { get; private set; }
        public int RateLimitLimit { get; private set; }
        public int RateLimitRemaining { get; private set; }

        public override string Message
        {
            get
            {
                return
                    string.Format(
                        "Status code: {0}\nRate Limit / Remaining: {1} / {2}\nRate Limit Expires: {3} ({4})\nResponse Status: {5}\nResponse Content: {6}{7}",
                        StatusCode, RateLimitLimit, RateLimitRemaining, RateLimitExpires, RateLimitExpiresUnix,
                        Response.StatusDescription, Response.Content,
                        // Print any extra info
                        string.IsNullOrEmpty(ExtraInfo) ? string.Empty : "\nExtra Info: " + ExtraInfo);
            }
        }
    }
}
