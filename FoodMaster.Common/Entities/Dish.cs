using System.Collections.Generic;

namespace FoodMaster.Common.Entities
{
	public class Dish
	{
		public string Name { get; set; }
		public IList<Component> Components { get; set; }

		public Dish()
		{
			Components = new List<Component>();
		}
	}
}
