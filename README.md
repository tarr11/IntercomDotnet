# IntercomDotnet

Wrapper for Intercom.io API for .NET

This is now targeted towards the [Intercom API v2](https://doc.intercom.io/api/)

A lightweight wrapper around the intercom API based on RestSharp.

## Install via nuget 

	Install-Package intercom-dotnet

## Usage example

	string apikey = "";
	string appid = "";
	var client = IntercomClient.GetClient(appid, apikey);
	var users = client.Users.Get();
	var newuser = client.Users.Post(new { email = "test@test.com" });

## Supported features

* [Users](https://doc.intercom.io/api/#users)
* [Events](https://doc.intercom.io/api/#events)
* [Companies](https://doc.intercom.io/api/#companies)
* [Tags](https://doc.intercom.io/api/#tags)
* [Segments](https://doc.intercom.io/api/#segments)
* [Notes](https://doc.intercom.io/api/#notes)
