using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    public class Response
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "يجب عليك ملء اسم الفنى.")]
        public string NameOfTec { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء الفرع.")]
        public string NameOfBran { get; set; }
        //[Required(ErrorMessage = "يجب عليك ملء القسم.")]
        //public string NameOfDept { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء الشهر.")]
        public string NameOfMonth { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء السنة.")]
        public string NameOfYear { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء ملاحظات إضافية.")]
        public string Note1 { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء مواطن القوى لدى الفنى.")]
        public string Note2 { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء مواطن الضعف ,والحلول لتطويرها.")]
        public string Note3 { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء ملاحظات المقيم/المدير.")]
        public string Note4 { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء عدد السيارات الرجيع شهرياً.")]
        public string NumOfCarReturn { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء إجمالى الدخل الخاص بالفنى شهرياً.")]
        public string Total { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء عدد ايام غياب الفنى شهرياً.")]
        public string Atenduce { get; set; }
        [Required(ErrorMessage = "يجب عليك ملء توقيع مهندس الورشة.")]
        public  string Signature {get; set; }
        [Required(ErrorMessage = "يجب عليك ملء توقيع مدير الفرع.")]
        public string Signature2 { get; set; }
        public List<QuestionAnswer>? QuestionAnswers { get; set; } = new List<QuestionAnswer>();


        [ForeignKey("Bransh")]
        public long? braId { get; set; }
        public virtual Bransh? Bransh { get; set; }

        [ForeignKey("Employee")]
        public long? EmpId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
