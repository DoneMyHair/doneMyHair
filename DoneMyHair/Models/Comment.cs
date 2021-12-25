using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoneMyHair.Models
{
    public class Comment
    {
        public string ID { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        public string SaloonID { get; set; }

    }
}