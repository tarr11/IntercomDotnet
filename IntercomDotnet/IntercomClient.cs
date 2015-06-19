using IntercomDotNet.Resources;

namespace IntercomDotNet
{
    public class IntercomClient
    {
        public const string ApiRoot = "https://api.intercom.io/";

        public IntercomClient(string appid, string apikey, Users users, Notes notes, Tags tags, Events events)
        {
            ApiKey = apikey;
            AppId = appid;
            Users = users;
            Notes = notes;
            Tags = tags;
            Events = events;
        }

        public static IntercomClient GetClient(string appid, string apiKey)
        {
            var client = new Client
                {
                    UserName = appid,
                    Password = apiKey,
                    ApiRoot = ApiRoot
                };

            return new IntercomClient(appid, apiKey,
                                      new Users(client),
                                      new Notes(client),
                                      new Tags(client),
                                      new Events(client)
                );
        }

        public string ApiKey { get; private set; }
        public string AppId { get; private set; }

        public Users Users { get; private set; }
        public Notes Notes { get; private set; }
        public Tags Tags { get; private set; }
        public Events Events { get; private set; }
    }
}
