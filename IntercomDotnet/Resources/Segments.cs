using RestSharp;

namespace IntercomDotNet.Resources
{
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
            return Client.Execute(BaseUrlWithId, Method.GET, request =>
                {
                    request.AddUrlSegment("id", id.ToString());
                });
        }
    }
}