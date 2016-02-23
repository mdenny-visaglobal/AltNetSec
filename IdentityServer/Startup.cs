using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityManager.Configuration;
using IdentityServer.IdMgr;
using IdentityServer.IdSvr;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (IdentityServer.Startup))]

namespace IdentityServer
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			//app.Map("/core",
			//	core =>
			//	{
			//		core.UseIdentityServer(new IdentityServerOptions
			//		{
			//			SiteName = "Identity Crisis Demo",
			//			SigningCertificate = LoadCertificate(),
			//			Factory = new IdentityServerServiceFactory()
			//				.UseInMemoryUsers(HardCodedUsers.Get())
			//				.UseInMemoryClients(Clients.Get())
			//				.UseInMemoryScopes(Scopes.Get())
			//		});
			//	});

			var connectionString = "MembershipReboot";

			app.Map("/core", core =>
			{
				var idSvrFactory = Factory.Configure();
				idSvrFactory.ConfigureCustomUserService(connectionString);

				var options = new IdentityServerOptions
				{
					SiteName = "Identity Crisis Demo",

					SigningCertificate = LoadCertificate(),
					Factory = idSvrFactory
				};

				core.UseIdentityServer(options);
			});

			app.Map("/admin", adminApp =>
			{
				var factory = new IdentityManagerServiceFactory();
				factory.Configure(connectionString);

				adminApp.UseIdentityManager(new IdentityManagerOptions()
				{
					Factory = factory
				});
			});
		}

		private X509Certificate2 LoadCertificate()
		{
			return new X509Certificate2(
				Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Config\idsrv3test.pfx"),
				"idsrv3test");
		}
	}
}