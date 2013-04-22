using intercom_dotnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest {
	class Program {
		static void Main(string[] args) {
			try {
				string apikey = "";
				string appid = "";
				var client = IntercomClient.GetClient(appid, apikey);
				var user = client.Users.Get();
				var newuser = client.Users.Post(new { email = "test@test.com" });
				var messages = client.MessageThreads.Get(email: "test@test.com");
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}

		}
	}
}
