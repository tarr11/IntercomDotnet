IntercomDotnet
==============
Wrapper for Intercom.io API for .NET

A lightweight wrapper around the intercom API based on RestSharp.

{{{
				string apikey = "";
				string appid = "";
				var client = IntercomClient.GetClient(appid, apikey);
				var users = client.Users.Get();
				var newuser = client.Users.Post(new { email = "test@test.com" });
}}}






