using System.ComponentModel.DataAnnotations;

namespace Domian
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        public List<Answer>? Answers { get; set; }
    }
}
