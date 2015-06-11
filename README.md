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

Please feel free to add support for more endpoints. As I have time I will try to implement some more as well.
The old endpoints which were previously supported in the v1 edition of this library have been marked obsolete
and will throw exceptions. These will be removed ASAP and more features implemented.