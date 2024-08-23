using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dtos.Account
{
    public class ForgotPasswordModelResult
    {
       // [Required, EmailAddress, Display(Name = "Registered Email Address")]
        public string Result { get; set; }
        //public bool EmailSent { get; set; }
    }
}
