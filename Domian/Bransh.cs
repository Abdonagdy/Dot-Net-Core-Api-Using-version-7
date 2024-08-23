using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domian
{
    public class Bransh
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long brannum { get; set; }


        public string? Braname { get; set; }

        public string? Branickname { get; set; }

        public string? Phone { get; set; }

        public  string?  Location  { get; set; }

        public string? Email { get; set; }

        //   public IFormFile? ImageFile { get; set; }
        public string? ImageURL { get; set; }

        public string? From { get; set; }

        public string? To { get; set; }

        public bool IsAvctive { get; set; }
        public IEnumerable<AppointmentReversion>? appointmentReversions { get; set; }

        public IEnumerable<Response>? Responses { get; set; }

        public IEnumerable<Employee>? Employees { get; set; }

        public IEnumerable<BranchService>? branchServices { get; set; }


        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User? User { get; set; }


        public Bransh():this(0,null!, false,null!,null!,null!,null!,null!,0) { }
        public Bransh(long brnum, string Name, bool isavctive, string nname ,string p , string l,string f ,string t,int userid)
        {
            Braname = Name;
            brannum = brnum;
            IsAvctive = isavctive;
            Branickname = nname;
            From = f;
            To = t;
            Phone = p;
            Location = l;
            UserId=userid;
            // ImageFile = imageFile;
            appointmentReversions = new List<AppointmentReversion>();
            branchServices = new List<BranchService>();

        }
    }
}