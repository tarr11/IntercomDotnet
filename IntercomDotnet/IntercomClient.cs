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
                new Users(client),
                new Notes(client),
                new Tags(client),
                new Events(client),
                new Segments(client),
                new Companies(client),
                new Messages(client),
                new Conversations(client));
        }

        private IntercomClient(Users users, Notes notes, Tags tags, Events events, Segments segments, Companies companies, Messages messages, Conversations conversation)
        {
            Users = users;
            Notes = notes;
            Tags = tags;
            Events = events;
            Segments = segments;
            Companies = companies;
            Messages = messages;
            Conversations = conversation;
        }

        public Users Users { get; private set; }
        public Notes Notes { get; private set; }
        public Tags Tags { get; private set; }
        public Events Events { get; private set; }
        public Segments Segments { get; private set; }
        public Companies Companies { get; private set; }
        public Messages Messages { get; private set; }
        public Conversations Conversations { get; private set; }
    }
}
