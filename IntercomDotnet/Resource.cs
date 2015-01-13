namespace intercom_dotnet
{
    public abstract class Resource
    {
        public Client Client { get; private set; }

        protected Resource(Client client)
        {
            Client = client;
        }
    }
}
