using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class RecipieNutritionalType
    {
        public long ID { get; set; }
        public NutritionalType NutrionalType { get; set; }

        public float NutrionalValue { get; set; }
    }
}
