namespace IntercomDotNet.Resources
{
    using RestSharp;

    public class Segments : Resource
    {
        public Segments(Client client) : base(client, "segments")
        {
        }

        public dynamic List()
        {
            return Client.Execute(BaseUrl, Method.GET, request => { });
        }

        public dynamic Get(int id)
        {
            return Client.Execute(BaseUrl + "/{id}", Method.GET, request =>
                {
                    request.AddUrlSegment("id", id.ToString());
                });
        }
    }
}