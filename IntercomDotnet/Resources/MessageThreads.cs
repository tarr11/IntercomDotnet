using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intercom_dotnet.Resources {
	public class MessageThreads : Resource {
		
		public MessageThreads(Client client)
			: base(client) {
		}

		public dynamic Get(int? user_id = null, string email= null, int? thread_id= null, string current_url = null ) {
			return Client.Execute("users/message_threads", Method.GET, (request) => {

				if (thread_id != null)
					request.AddParameter("thread_id", thread_id);

				if (email != null)
					request.AddParameter("email", email);

				if (user_id != null)
					request.AddParameter("user_id", user_id.Value);

				if (current_url != null)
					request.AddParameter("current_url", current_url);
			});
		}

		public dynamic Post(object hash) {
			return Client.Execute("users/message_threads", Method.POST, (request) => {
				request.RequestFormat = DataFormat.Json;
				request.AddBody(hash);
			});
		}

		public dynamic Put(object hash) {
			return Client.Execute("users/message_threads", Method.PUT, (request) => {
				request.RequestFormat = DataFormat.Json;
				request.AddBody(hash);
			});
		}

	}
}
