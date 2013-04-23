IntercomDotnet
==============
Wrapper for Intercom.io API for .NET

A lightweight wrapper around the intercom API based on RestSharp.

Install via nuget 

	Install-Package intercom-dotnet


Create a client and then get some users, etc

	string apikey = "";
	string appid = "";
	var client = IntercomClient.GetClient(appid, apikey);
	var users = client.Users.Get();
	var newuser = client.Users.Post(new { email = "test@test.com" });







