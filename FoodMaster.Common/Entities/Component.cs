using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodMaster.Common.Entities
{
    [DataContract]
    public class Component
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Nutrition NutritionValue { get; set; }
    }


}
