using Nancy;
using Nancy.Security;

namespace Api
{
	public class QuoteModule : NancyModule
	{
		public QuoteModule()
		{
			this.RequiresMSOwinAuthentication();

			Get["/"] = parameters => QuoteRepository.GetRandomQuote();
		}
	}
}