using System.ComponentModel.DataAnnotations;

namespace Domian
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Number { get; set; }


        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
