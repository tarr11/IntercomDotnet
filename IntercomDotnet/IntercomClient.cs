using intercom_dotnet.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intercom_dotnet
{
    public class IntercomClient 
    {
			public const string apiRoot = "https://api.intercom.io/v1/";

			public IntercomClient(string appid, string apikey, Users users, Impressions impressions, MessageThreads messageThreads, Notes notes, Tags tags) 
			{
				this.ApiKey = apikey;
				this.AppId = appid;
				this.Users = users;
				this.Impressions = impressions;
				this.MessageThreads = messageThreads;
				this.Notes = notes;
				this.Tags = tags;
			}

			public static IntercomClient GetClient(string appid, string apiKey) {
				Client client = new Client{ UserName = appid, Password = apiKey, ApiRoot = apiRoot};
				return new IntercomClient(appid, apiKey, 
					new Users(client),
					new Impressions(client),
					new MessageThreads(client),
					new Notes(client),
					new Tags(client)
					);
			}

			public Client Client {get;set;}

			public string ApiKey { get; set; }
			public string AppId { get; set; }

			public Users Users { get; set; }
			public Notes Notes { get; set; }
			public Impressions Impressions { get; set; }
			public MessageThreads MessageThreads { get; set; }
			public Tags Tags { get; set; }
			

    }
}
