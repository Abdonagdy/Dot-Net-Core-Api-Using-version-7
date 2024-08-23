using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Reservation
{
    public class ReservationMinimalDto
    {
        public int id { get; set; }
        public string? Message { get; set; }
        public string? TofromHours { get; set; }

        public string? Revnumber { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }


        public string? Branshname { get; set; }

    }
}
