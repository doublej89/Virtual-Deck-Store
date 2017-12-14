using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualDeckStore.Models
{
    [Bind(Exclude = "Id")]
    public class CustomerOrder
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
  
        //[Required(ErrorMessage = "Email Address is required")]
        //[DisplayName("Email Address")]

        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        //    ErrorMessage = "Email is is not valid.")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }
     
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        [ScaffoldColumn(false)]
        public Decimal Amount { get; set; }

        [ScaffoldColumn(false)]
        public string CustomerUserName { get; set; }

    }
}