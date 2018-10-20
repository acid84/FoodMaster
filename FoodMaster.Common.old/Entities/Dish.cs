using System.Collections.Generic;

namespace FoodMaster.Common.Entities
{
	public class Dish
	{
		public string Name { get; set; }
		public IList<DishComponent> Components { get; set; }

		public Dish()
		{
			Components = new List<DishComponent>();
		}
	}
}
