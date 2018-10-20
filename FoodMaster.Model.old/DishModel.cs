using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMaster.Common.Entities;

namespace FoodMaster.Model
{
	public class DishModel
	{
		private readonly IStorage<Dish> _dishStorage;
		public DishModel(IStorage<Dish> dishStorage)
		{
			_dishStorage = dishStorage;
		}

		public async Task AddDishAsync(Dish dish)
		{
			var items = await _dishStorage.GetItems();
			var list = items.ToList();
			list.Add(dish);

			await _dishStorage.Store(list);
		}

		public async Task<Dish> GetDishAsync(string name)
		{
			var items = await _dishStorage.GetItems();
			return items.FirstOrDefault(x => x.Name == name);
		}

		public Task<IEnumerable<Dish>> GetAllDishesAsync()
		{
			return _dishStorage.GetItems();
		}

		public async Task UpdateDishAsync(string name, Dish newDish)
		{
			var items = await _dishStorage.GetItems();
			var list = items.ToList();
			var currentComponent = list.FirstOrDefault(x => x.Name == name);

			if (currentComponent == null)
			{
				throw new Exception("Item not found");
			}

			list.Remove(currentComponent);
			list.Add(newDish);

			await _dishStorage.Store(list);
		}


		public async Task DeleteDishAsync(string name)
		{
			var items = await _dishStorage.GetItems();
			var list = items.ToList();
			var item = list.FirstOrDefault(x => x.Name == name);

			if (item == null)
			{
				throw new Exception("Item not found");
			}

			list.Remove(item);
			await _dishStorage.Store(list);
		}


	}
}
