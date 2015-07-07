namespace IntercomDotNet.Resources
{
    using RestSharp;

    public class Notes : Resource
    {
        public Notes(Client client, string baseUrl) : base(client, baseUrl)
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

        public dynamic Get(string email = null, int? userId = null)
        {
            return Client.Execute(BaseUrl, Method.GET, request =>
                {
                    if (email != null)
                        request.AddParameter("email", email);

                    if (userId != null)
                        request.AddParameter("user_id", userId.Value);
                });
        }

        public dynamic Get(int noteId)
        {
            return Client.Execute(BaseUrl + "/{id}", Method.GET, request =>
                {
                    request.AddUrlSegment("id", noteId.ToString());
                });
        }
    }
}