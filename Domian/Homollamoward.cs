using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domian
{
    public class moward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string mordnum { get; set; }
        public string mordname { get; set;}

      
        public moward(string num , string n)
        {
            mordnum = num;
            mordname = n;
        }

        public moward():this(null,null)
        { }
    }
}
