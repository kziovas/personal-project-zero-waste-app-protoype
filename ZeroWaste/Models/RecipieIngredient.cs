using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class RecipieIngredient
    {
        public long ID { get; set; }
        public Ingredient Ingredient { get; set; }
        public float Amount { get; set; }

        public string Unit { get; set; }
    }
}
