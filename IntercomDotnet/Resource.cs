namespace IntercomDotNet
{
    public abstract class Resource
    {
        protected string BaseUrl { get; private set; }

        protected string BaseUrlWithId
        {
            get
            {
                return string.Format("{0}/{{id}}", BaseUrl);
            }
        }

        public Client Client { get; private set; }

        protected Resource(Client client, string baseUrl)
        {
            Client = client;
            BaseUrl = baseUrl;
        }
    }
}
