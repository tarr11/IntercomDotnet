using intercom_dotnet;
using System;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string apikey = "";
                string appid = "";
                var client = IntercomClient.GetClient(appid, apikey);
                //var user = client.Users.Get();
                var newuser = client.Users.Post(new {email = "test@test.com"});
                var messages = client.MessageThreads.Get(email: "test@test.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
