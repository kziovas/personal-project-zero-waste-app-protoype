using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Recipie
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public int ExecTime { get; set; } //minutes

        public int PrepTime { get; set; } //minutes

        public int Portions { get; set; } 

        public string PictureLink1 { get; set; }

        public string PictureLink2 { get; set; }

        public int Simplicity { get; set; }

        public List<Keyword> Keywords { get; set; }


        [MaxLength]
        public int PreparationMethod { get; set; }

        public List<RecipieIngredient> Ingredients { get; set; }

        public List<RecipieNutritionalType> NutrionalTypes { get; set; }







    }
}
