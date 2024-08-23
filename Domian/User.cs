using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("User")]
    public class User:IdentityUser<int>
    {
        //public long Id { get; set; }

        [MaxLength(100), MinLength(3)]
        public string Fname { get; set; }
        [MaxLength(100), MinLength(3)]
        public string Lname { get; set; }

        public string? ReferralCode { get; set; }

        public string? UrlReferralCode { get; set; }
        public DateTime? CreateAcount { get; set; }
        //collection of UserReviews 

        public virtual IEnumerable<UserReview>? UserReviews { get; set; }


        //collection of UserReviews 
        public virtual IEnumerable<Points>? Points { get; set; }

        //relation with user
        public virtual ICollection<Role> Roles { get; set; }
        //relation with UserPaymetMethods

        public virtual IEnumerable<UserPaymetMethod>? UserPaymetMethods { get; set; }
        //relation with Cart

        public virtual IEnumerable<Cart>? Carts { get; set; }



        //collection of Orders 
        // public virtual ICollection<Order> Orders { get; set; }

        //relation with UserAddresses

        public virtual IEnumerable<UserAddress>? UserAddresses { get; set; }



        //relation with AppointmentReversion
        public virtual IEnumerable<AppointmentReversion>? appointmentReversions { get; set; }


        //relation with Wishlist
        public virtual IEnumerable<WishList>? WishLists { get; set; }

        public User(string fname,string lname,DateTime dateTime,string re)
        {

        
            Fname = fname;
            Lname = lname;
            CreateAcount = dateTime;
            UrlReferralCode=re;
            UserReviews = new List<UserReview>();
            Roles = new List<Role>();
            UserPaymetMethods = new List<UserPaymetMethod>();
            Carts = new List<Cart>();
            UserAddresses = new List<UserAddress>();
            appointmentReversions = new  List<AppointmentReversion>();
            WishLists = new List<WishList>();
            Points = new List<Points>();

        }



        public User() : this(null!, null!,DateTime.Now,null!)
        {


        }
    }
}
