using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    public class PurseOrderHomalla
    {

        public int id { get; set; } // رقم الامر

        [MinLength(3), MaxLength(200)]
        public string? Description { get; set; } //الوصف

        [MinLength(3), MaxLength(200)]
        public string? Email { get; set; } // الايميل

        [MinLength(3), MaxLength(200)]
        public string? Address { get; set; } // العنوان

        [MinLength(3), MaxLength(200)]

        public string? ClientName { get; set; } // اسم العميل

        [MinLength(3), MaxLength(200)]

        public string? ClientNumber { get; set; } // اسم العميل

        public string? Hekal { get; set; }  // رقم الهيكل

        public string? MordName { get; set; } // اسم العميل

        [MinLength(3), MaxLength(200)]

        public string? CarName { get; set; } // اسم السياره

        public string? CarNumber { get; set; } // رقم اللوحة

        public string? paymentMethod { get; set; } //طريقة الدفع 

        public string? Username { get; set; }

        public string? userPhone { get; set; }

        public string? UserFName { get; set; }


        public DateTime Date { get; set; } // تاريخ

        public ICollection<KemiaOrderHomolla>? kemiaOrders { get; set; }

        public DependHomolla? DependHomolla { get; set; }

        public PurseOrderHomalla(string? des, string? email, string? address, string? clientname, string? clientnumber, string? mname, string? car, string? carN, string? paymment, string? hekal, string? username , string? u, string? p)
        {
            Description = des;
            Email = email;
            Address = address;
            ClientName = clientname;
            ClientNumber = clientnumber;
            Hekal = hekal;
            MordName = mname;
            CarName = car;
            CarNumber = carN;
            paymentMethod = paymment;
            Date = DateTime.Now;
            Username = username;
            userPhone = p;
            UserFName = u;
            kemiaOrders = new List<KemiaOrderHomolla>();
        }


        public PurseOrderHomalla() : this(null, null, null, null, null, null, null, null, null, null, null,null,null)
        {

        }
    }
}
