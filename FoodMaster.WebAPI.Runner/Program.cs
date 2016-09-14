using System;
using FoodMaster.WebApi;
using Microsoft.Owin.Hosting;

namespace FoodMaster.WebAPI.Runner
{
    public class Program
    {
        public static void Main(string[] args)
        {
			string baseAddress = "http://localhost:9000/";

			// Start OWIN host 
			using (WebApp.Start<Startup>(baseAddress))
	        {
		        Console.WriteLine("Server started on " + baseAddress);
				Console.ReadLine();
			}

		}
    }
}
