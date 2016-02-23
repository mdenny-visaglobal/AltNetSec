using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof (Api.Startup))]

namespace Api
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// Allow all origins
			app.UseCors(CorsOptions.AllowAll);

			// Wire token validation
			app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
			{
				Authority = "https://localhost:44304/core",

				// For access to the introspection endpoint
				ClientId = "api",
				ClientSecret = "api-secret",
				RequiredScopes = new[] { "api" }
			});
			
			app.UseNancy();
		}
	}
}