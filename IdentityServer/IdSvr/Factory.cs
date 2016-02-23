using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Services.InMemory;

namespace IdentityServer.IdSvr
{
	public class Factory
	{
		public static IdentityServerServiceFactory Configure()
		{
			var factory = new IdentityServerServiceFactory();

			var scopeStore = new InMemoryScopeStore(Scopes.Get());
			factory.ScopeStore = new Registration<IScopeStore>(resolver => scopeStore);

			var clientStore = new InMemoryClientStore(Clients.Get());
			factory.ClientStore = new Registration<IClientStore>(resolver => clientStore);

			factory.CorsPolicyService = new Registration<ICorsPolicyService>(new DefaultCorsPolicyService {AllowAll = true});

			return factory;
		}
	}
}