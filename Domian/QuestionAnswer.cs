using System.ComponentModel.DataAnnotations;

namespace Domian
{
    public class QuestionAnswer
    {
        public int Id { get; set; }

        public string? Note { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }

        public int? AnswerId { get; set; }
        public Answer? Answer { get; set; }

    
        public int? ResponseId { get; set; }
        public Response? Response { get; set; }
    }
}
