namespace intercom_dotnet
{
    public abstract class Resource
    {
        public Client Client { get; set; }

        protected Resource(Client client)
        {
            Client = client;
        }
    }
}
