using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class ZWMember
    {
        public long ID { get; set; }
        public string Title { get; set; }

        public string Email { get; set; }

        public DateTime DoB{ get; set; }

        public string Gender { get; set; }

        public List<Keyword> PreferencesKeywords { get; set; }

        public List<Allergy> Allergies { get; set; }

        public List<Ingredient> FavoriteIngredients { get; set; }

        public List<Recipie> FavoriteRecipies { get; set; }

        public List<Recipie> TestedRecipies { get; set; }

        public string PictureLink { get; set; }
    }
}
