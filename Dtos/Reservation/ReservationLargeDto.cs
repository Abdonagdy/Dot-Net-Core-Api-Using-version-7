using Domian;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Reservation
{
    public class ReservationLargeDto
    {
        public int ResId { get; set; }
        //Globalization


        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? tofromHours { get; set; }

        public long? ReversionNumber { get; set; }
        public bool? isav { get; set; }
        public string? revnumber { get; set; }
        public long? braId { get; set; }
        public string? Maintaence { get; set; }




    }
}
