using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoneMyHair.Models
{
    public class SaloonModels
    {

        public string ID { get; set; }
        public string SaloonName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string SaloonOwner { get; set; }
        public string Password { get; set; }
        public string SaloonAdress { get; set; }
        public byte[] Images { get; set; }

    }
    public class HairdresserModel
    {
        public string ID { get; set; }
        public string HairdresserName { get; set; }
        public string HairdresserSurname { get; set; }
        public int HairdresserPhoneNumber { get; set; }
        public string HairdresserEmail { get; set; }
        public string HairdresserDescription { get; set; }
        public string HairdresserComments { get; set; }
        public DateTime CommentTime { get; set; }
        

    }
}