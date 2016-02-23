using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityServer.IdSvr
{
	public class Clients
	{
		public static IEnumerable<Client> Get()
		{
			return new[]
			{
				new Client
				{
					ClientName = "Aurelia Client",
					ClientId = "js",
					Enabled = true,
					Flow = Flows.Implicit,
					RedirectUris = new List<string>
					{
						"http://localhost:9000/popup.html",
						"http://localhost:9000/silent-renew.html",
						"http://localhost:9000/#/callback?"
					},
					PostLogoutRedirectUris = new List<string>
					{
						"http://localhost:9000"
					},
					AllowedCorsOrigins = new List<string>
					{
						"http://localhost:9000"
					},
					AllowAccessToAllScopes = true,
					AccessTokenLifetime = 3600
				},
				new Client
				{
					ClientName = "Console App",
					ClientId = "console",
					Enabled = true,
					Flow = Flows.ClientCredentials,
					AccessTokenType = AccessTokenType.Reference,
					ClientSecrets = new List<Secret>
					{
						new Secret("console-secret".Sha256())
					},
					AllowedScopes = new List<string>
					{
						"api"
					}
				}
			};
		}
	}
}