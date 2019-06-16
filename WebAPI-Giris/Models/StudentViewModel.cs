using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Giris.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardId { get; set; }
        public  StandardViewModel Standard { get; set; }
        public virtual AddressViewModel Address { get; set; }
    }
}