using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMaster.Common;
using FoodMaster.Common.Entities;

namespace FoodMaster.Model
{
    public interface IStorage<T>
    {
        Task Store(IEnumerable<T> items);
        Task<IEnumerable<T>> GetItems();
    }

    public class ComponentsStorage : IStorage<Component>
    {
        private readonly IIsolatedStorageHelper _isolatedStorageHelper;
        private const string StorageFile = "FoodMasterComponents.dat";

        public ComponentsStorage(IIsolatedStorageHelper isolatedStorageHelper)
        {
            _isolatedStorageHelper = isolatedStorageHelper;
        }

        public Task Store(IEnumerable<Component> items)
        {
            return _isolatedStorageHelper.Write(StorageFile, items);
        }

        public Task<IEnumerable<Component>> GetItems()
        {
            return _isolatedStorageHelper.Read<Component>(StorageFile);
        }
    }

	public class DishStorage : IStorage<Dish>
	{
		private readonly IIsolatedStorageHelper _isolatedStorageHelper;
		private const string StorageFile = "FoodMasterDishes.dat";

		public DishStorage(IIsolatedStorageHelper isolatedStorageHelper)
		{
			_isolatedStorageHelper = isolatedStorageHelper;
		}

		public Task Store(IEnumerable<Dish> items)
		{
			return _isolatedStorageHelper.Write(StorageFile, items);
		}

		public Task<IEnumerable<Dish>> GetItems()
		{
			return _isolatedStorageHelper.Read<Dish>(StorageFile);
		}
	}
}
