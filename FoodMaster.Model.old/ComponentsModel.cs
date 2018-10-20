using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Threading.Tasks;
using FoodMaster.Common.Entities;

namespace FoodMaster.Model
{
    public class ComponentsModel
    {
        private readonly IStorage<Component> _componentsStorage;

        public ComponentsModel(IStorage<Component> componentsStorage)
        {
            _componentsStorage = componentsStorage;
        }

        public async Task AddComponentAsync(Component component)
        {
            var items = await _componentsStorage.GetItems();
            var list = items.ToList();
            list.Add(component);

            await _componentsStorage.Store(list);
        }

        public async Task<Component> GetComponentAsync(string name)
        {
            var items = await _componentsStorage.GetItems();
	        return items.FirstOrDefault(x => x.Name == name);
        }

        public Task<IEnumerable<Component>> GetAllComponentsAsync()
        {
	        return _componentsStorage.GetItems();
        }

	    public async Task DeleteComponent(string name)
	    {
			var items = await _componentsStorage.GetItems();
			var list = items.ToList();
		    var item = list.FirstOrDefault(x => x.Name == name);

		    if (item == null)
		    {
			    throw new Exception("Item not found");
		    }

			list.Remove(item);
			await _componentsStorage.Store(list);
		}

	    public async Task UpdateComponentAsync(string name, Component newComponent)
	    {
			var items = await _componentsStorage.GetItems();
			var list = items.ToList();
			var currentComponent = list.FirstOrDefault(x => x.Name == name);

			if (currentComponent == null)
			{
				throw new Exception("Item not found");
			}

		    list.Remove(currentComponent);
			list.Add(newComponent);

		    await _componentsStorage.Store(list);
	    }
    }
}
