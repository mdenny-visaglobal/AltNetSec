using IdentityModel.Client;

namespace ConsoleApp
{
	public static class TokenService
	{
		public static TokenResponse GetClientToken()
		{
			var client = new TokenClient(
				"https://localhost:44304/core/connect/token",
				"console",
				"console-secret");

			return client.RequestClientCredentialsAsync("api")
				.Result;
		}
	}
}