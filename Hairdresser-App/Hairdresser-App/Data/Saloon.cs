using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdresser_App.Data
{
    public class Saloon
    {
        public int ID { get; set; }
        public string SName { get; set; }
        public string SAdress { get; set; }        
        public byte[] SImg { get; set; }
        public byte[] Img { get; set; }
    }
}
