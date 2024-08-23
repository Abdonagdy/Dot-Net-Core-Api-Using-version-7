using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("UserReview")]
    public class UserReview
    {
        public int Id { get; set; }
        [Range(0, 5)]
        public int? RatingValue { get; set; }
        [MaxLength(200), MinLength(7)]
        public string Comment{ get; set; }
        public DateTime? Date { get; set; }

        public Boolean Published { get; set; }

        //relation with user
        [ForeignKey("User")]
        public int? userdId { get; set; }
        public virtual User? User { get; set; }

        //relation with Product
        [ForeignKey("Product")]
        public long ProdcutId { get; set; }

        public virtual Product Product { get; set; }

        public UserReview(DateTime date, int user, Boolean published,long product, string comment, int? ratingValue = null )
        {
            RatingValue = ratingValue;
            Comment = comment;
            Date = date;
            userdId = user;
            ProdcutId = product;
            Published = published;

        }
        public UserReview() : this(DateTime.Now, 0,false,0, null!)
        {

        }
    }
}
