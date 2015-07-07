using IntercomDotNet.Resources;

namespace IntercomDotNet
{
    public class IntercomClient
    {
        public const string ApiRoot = "https://api.intercom.io/";

        public static IntercomClient GetClient(string appid, string apiKey)
        {
            var client = new Client
                             {
                                 UserName = appid,
                                 Password = apiKey,
                                 ApiRoot = ApiRoot
                             };

            return new IntercomClient(
                new Users(client, "users"),
                new Notes(client, "notes"),
                new Tags(client, "tags"),
                new Events(client, "events"));
        }

        private IntercomClient(Users users, Notes notes, Tags tags, Events events)
        {
            Users = users;
            Notes = notes;
            Tags = tags;
            Events = events;
        }

        public Users Users { get; private set; }
        public Notes Notes { get; private set; }
        public Tags Tags { get; private set; }
        public Events Events { get; private set; }
    }
}
