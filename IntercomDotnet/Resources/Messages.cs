using RestSharp;

namespace IntercomDotNet.Resources
{
    public class Messages : Resource
    {
        public Messages(Client client) : base(client, "messages")
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute(BaseUrl, Method.POST, request =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Post(string messageType, string subject, string body, string template, string fromAdminId, string toUserId)
        {
            return Client.Execute(BaseUrl, Method.POST, request =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(new
                    {
                        message_type = messageType,
                        subject = subject,
                        body = body,
                        template = template,
                        from = new
                        {
                            type = "admin",
                            id = fromAdminId
                        },
                        to = new
                        {
                            type = "user",
                            user_id = toUserId
                        }
                    });
                });
        }

        /// <summary>
        /// User or Contact Initiated Conversation
        /// </summary>
        /// <param name="fromUserId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public dynamic Post(string fromUserId,string body)
        {
            return Client.Execute(BaseUrl, Method.POST, request =>
            {
                request.RequestFormat = DataFormat.Json;
                request.AddBody(new
                {
                    body = body,
                    from = new { 
                      type = "user",
                      user_id = fromUserId
                    }
                });
            });
        }





    }
}
