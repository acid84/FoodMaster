using System.Runtime.Serialization;

namespace FoodMaster.Common.Entities
{
	[DataContract]
    public class Component
    {
        [DataMember]
        public string Name { get; set; }

		[DataMember]
		public string Type { get; set; }

		[DataMember]
        public Nutrition NutritionValue { get; set; }
    }

	public class DishComponent : Component
	{
		public int Ammount { get; set; }

		public Nutrition DishComponentNutritionValue
		{
			get
			{
				Nutrition calculatedNutrition= new Nutrition();
				calculatedNutrition.Carbs = NutritionValue.Carbs * Ammount;
				calculatedNutrition.Fat = NutritionValue.Fat * Ammount;
				calculatedNutrition.Fiber = NutritionValue.Fiber;
				calculatedNutrition.Kcal = NutritionValue.Kcal;

				return calculatedNutrition;
			}
		}
	}

}
