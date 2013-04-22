using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intercom_dotnet {
	public abstract class Resource {
		public Client Client { get; set; }
		public Resource(Client client) {
			this.Client = client;
		}

	}
}
