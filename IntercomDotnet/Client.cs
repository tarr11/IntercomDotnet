using System.Net;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntercomDotNet
{
    public class Client
    {
        private const string ErrorNotSuccessCode = "Did not get a success code (200, 201 or 202) from API server";

        public string ApiRoot { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public double GetUnixTimestamp(DateTime inputTime)
        {
            return (inputTime - new DateTime(1970, 1, 1).ToUniversalTime()).TotalSeconds;
        }

        public dynamic Execute(string resource, Method method, Action<RestRequest> decorator)
        {
            var client = GetRestClient();
            var request = new RestRequest(method)
                {
                    Resource = resource
                };
            decorator(request);
            var response = client.Execute(request);

            // Check for a special case of a rate limited 
            if ((int) response.StatusCode == (int) ExtraHttpStatusCodes.TooManyRequests)
            {
                throw new RestRateLimitException(response);
            }
            
            try
            {
                // See if the response was a successful one - if now, we throw an error
                if (response.StatusCode != HttpStatusCode.OK && 
                    response.StatusCode != HttpStatusCode.Accepted &&
                    response.StatusCode != HttpStatusCode.Created)
                {
                    throw new Exception(ErrorNotSuccessCode);
                }

                return JsonConvert.DeserializeObject<dynamic>(response.Content);
            }
            catch (Exception e)
            {
                throw new RestException(response, e.Message);
            }
        }

        public RestClient GetRestClient()
        {
            var client = new RestClient(ApiRoot)
                {
                    Authenticator = new HttpBasicAuthenticator(UserName, Password)
                };

            return client;
        }

        public async Task<dynamic> ExecuteAsync(string resource, Method method, Action<RestRequest> decorator)
        {
            var client = GetRestClient();
            var request = new RestRequest(method)
                {
                    Resource = resource
                };
            decorator(request);
            return await ExecuteTaskAsync(client, request, new CancellationToken());
        }

        public async Task<dynamic> ExecuteTaskAsync(RestClient client, RestRequest request,
                                                    CancellationToken cancellationToken)
        {
            var taskCompletionSource = new TaskCompletionSource<dynamic>();

            var asyncHandle = client.ExecuteAsync(
                request, r =>
                    {
                        try
                        {
                            if (r.ErrorException != null)
                            {
                                taskCompletionSource.SetException(r.ErrorException);
                                return;
                            }
                            if (r.StatusCode != HttpStatusCode.OK && 
                                r.StatusCode != HttpStatusCode.Created &&
                                r.StatusCode != HttpStatusCode.Accepted)
                            {
                                taskCompletionSource.SetException(new RestException(r, ErrorNotSuccessCode));
                                return;
                            }

                            var result = JsonConvert.DeserializeObject<dynamic>(r.Content);
                            taskCompletionSource.SetResult(result);
                        }
                        catch (Exception ex)
                        {
                            taskCompletionSource.SetException(ex);
                        }
                    });

            using (cancellationToken.Register(asyncHandle.Abort))
            {
                return await taskCompletionSource.Task;
            }
        }

    }
}
