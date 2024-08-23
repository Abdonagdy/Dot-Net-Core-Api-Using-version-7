using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Comment
{
    public class CommentMinimalDTO
    {
        public int id { get; set; }

        public string? text { get; set; }
        public string? Comment { get; set; }
        
        public  DateTime? Date { get; set; }
        public string? Name { get; set; }
    }
}
