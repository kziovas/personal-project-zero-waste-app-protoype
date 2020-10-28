using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class News
    {
        public long ID { get; set; }
        public string Title { get; set; }

        public DateTime PublicationDate { get; set; }

        [MaxLength]
        public int MainText { get; set; }

        public string PictureLink { get; set; }

        public List<Keyword> Keywords { get; set; }
    }
}
