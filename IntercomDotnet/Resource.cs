namespace IntercomDotNet
{
    public abstract class Resource
    {
        protected string BaseUrl { get; private set; }

        public Client Client { get; private set; }

        protected Resource(Client client, string baseUrl)
        {
            Client = client;
            BaseUrl = baseUrl;
        }
    }
}
