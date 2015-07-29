using IntercomDotNet;
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
                var newuser = client.Users.Post(new { email = "test@test.com" });

                //client.Events.Post("test_event", DateTime.Now, "userid", new { });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
