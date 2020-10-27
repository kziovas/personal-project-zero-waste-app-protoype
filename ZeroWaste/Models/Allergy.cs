using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Allergy
    {
        public long ID { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }

        public List<Keyword> Keywords { get; set; }
    }
}
