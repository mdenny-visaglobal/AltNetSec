using System;
using System.Net.Http;
using IdentityModel.Client;

namespace ConsoleApp
{
	public static class ApiCaller
	{
		public static void CallApi()
		{
			var client = new HttpClient();
			Console.WriteLine(client.GetStringAsync("http://localhost:7820").Result);
		}

		public static void CallApi(TokenResponse response)
		{
			var client = new HttpClient();
			client.SetBearerToken(response.AccessToken);

			Console.WriteLine(client.GetStringAsync("http://localhost:7820").Result);
		}
	}
}