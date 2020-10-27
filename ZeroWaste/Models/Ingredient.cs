using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Ingredient
    {
        public long ID { get; set; }
        public string Title { get; set; }

        public List<Keyword> OtherNames { get; set; }

        public string Type { get; set; }

        public string PictureLink { get; set; }

        public List<Keyword> Keywords { get; set; }
    }
}
