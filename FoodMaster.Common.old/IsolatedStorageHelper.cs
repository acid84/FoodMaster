using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodMaster.Common
{
	public interface IIsolatedStorageHelper
	{
		Task Write<T>(string fileName, IEnumerable<T> content) where T : class;
		Task<IEnumerable<T>> Read<T>(string fileName) where T : class;
	}

	public class IsolatedStorageHelper : IIsolatedStorageHelper
	{
		public async Task Write<T>(string fileName, IEnumerable<T> content) where T : class
		{
			IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
			var mode = !isoStore.FileExists(fileName) ? FileMode.CreateNew : FileMode.Truncate;

			using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, mode, isoStore))
			{
				using (StreamWriter writer = new StreamWriter(isoStream))
				{
					var jsonString = JsonConvert.SerializeObject(content);
					await writer.WriteAsync(jsonString);
				}
			}
		}

		public async Task<IEnumerable<T>> Read<T>(string fileName) where T : class
		{
			IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
			if (!isoStore.FileExists(fileName))
			{
				return new List<T>();
			}
			
			using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Open, isoStore))
			{
				using (StreamReader reader = new StreamReader(isoStream))
				{
					var jsonString = await reader.ReadToEndAsync();
					return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
				}
			}
		}
	}
}
