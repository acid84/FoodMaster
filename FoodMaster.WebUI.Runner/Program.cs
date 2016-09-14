using System;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace FoodMaster.WebUI.Runner
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var url = "http://localhost:8080";
			//var options = new FileServerOptions
			//{
			//	EnableDirectoryBrowsing = true,
			//	EnableDefaultFiles = true,
			//	DefaultFilesOptions = { DefaultFileNames = { "index.html" } },
			//	FileSystem = new PhysicalFileSystem(@"D:\Kod\FoodMaster\FoodMaster.WebUI")
			//};

			var options = new FileServerOptions
			{
				RequestPath = new PathString("/app"),
				FileSystem = new PhysicalFileSystem("app"),
				EnableDefaultFiles = true,
				EnableDirectoryBrowsing = false
			};
			//options.DefaultFilesOptions.DefaultFileNames.Add("app/index.html");


			WebApp.Start(url, builder => builder.UseFileServer(options));
			Console.WriteLine("Listening at " + url);
			Console.ReadLine();
		}
	}
}
