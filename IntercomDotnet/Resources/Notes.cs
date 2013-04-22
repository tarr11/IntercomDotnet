using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intercom_dotnet.Resources {
	public class Notes : Resource {

		public Notes(Client client)
			: base(client) {
		}

		public dynamic Post(object hash) {
			return Client.Execute("notes", Method.POST, (request) => {
				request.RequestFormat = DataFormat.Json;
				request.AddBody(hash);
			});
		}


	}
}
