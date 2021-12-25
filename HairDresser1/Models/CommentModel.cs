using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDresser1.Models
{
    public class CommentModel
    {
        public string ID { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string HairDresserID { get; set; }
    }
}
