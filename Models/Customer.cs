using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobLogic.Models
{
   
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
    public class Response
    {
        public static string ContentType { get; internal set; }
        public string type { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
        public int DataId { get; set; }
        public int DataId2 { get; set; }

    }
}
