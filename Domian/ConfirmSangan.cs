using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class ConfirmSangan
    {
        public int id { get; set; }

        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Car { get; set; }
        public string?  City { get; set; }

        public string? Region { get; set; }

        public string? Model { get; set;}

        public string? EngineType { get; set; }

        public string? ModelYearCar { get; set; }

        public string? DisstanceService { get; set; }

        public string? Year { get; set; }

        public string? Distance { get; set; }
        public string? CarNamesh { get; set; }

        public double? Totalprice { get; set; }  
      
        public double? Tax { get; set; }


        public ICollection<ServiceConfirmSangan> SelectedServices { get; set; }

        //[ForeignKey("AppointmentReversion")]
        //public int? AppointmentReversionid { get; set; }
        //public AppointmentReversion? AppointmentReversion  { get; set; }

        public ConfirmSangan(string f , string l , string p , string e ,string m ,string car  ,string y , string eg , string d,double TT, double T)
        {
            Fname = f;
            Lname = l;
            PhoneNumber = p;
            Email = e;
            Model = m;
            CarNamesh = car;
            Year = y;
            Distance = d;
            EngineType = eg;
            ModelYearCar = y;
           // AppointmentReversionid = r;
            Totalprice = TT;
            Tax = T;
            SelectedServices = new List<ServiceConfirmSangan>();

        }
        public ConfirmSangan() : this(null!, null!, null!, null!, null!, null!, null!, null!,null!,0,0) { }

    }
}
