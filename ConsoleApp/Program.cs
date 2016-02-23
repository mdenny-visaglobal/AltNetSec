using System;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			ApiCaller.CallApi(TokenService.GetClientToken());
			Console.WriteLine("Press Enter to Exit");
			Console.ReadLine();
		}
	}
}