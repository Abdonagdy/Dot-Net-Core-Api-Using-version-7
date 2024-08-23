using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domian
{
    public class AppointmentReversion
    {
        public int Id { get; set; }
        //Globalization

        public string?  UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public  string tofromHours { get; set; }

         public string?  Maintaence { get; set; }

        public string Date { get; set; }
        public bool isav { get; set; }

        public string? revnumber { get; set; }

        public string? BranchName { get; set; }

        [ForeignKey("Bransh")]

        public long? braId { get; set; }


        //[ForeignKey("ConfirmSangan")]
        //public int? ConfirmSanganid { get; set; }
        //public ConfirmSangan? ConfirmSangan { get; set; }
        public virtual Bransh? Bransh { get; set; }

        public AppointmentReversion(string tofrom,string date ,int b,bool isa,string?r=null,string? name=null ,string? email=null,string? phone=null , string? br = null)
        {
               tofromHours = tofrom;
               Date = date;
               braId = b;
               isav = isa;
               revnumber = r;
               UserName = name;
               Email = email;
               PhoneNumber = phone;
               BranchName = br;
               //ConfirmSanganid = c;
         }


        public AppointmentReversion():this(null!,null!,0,true)
        { }
     




    }
}
