using MicroOrm.Dapper.Repositories.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    [Table("Questions")]
    public class Question
    {
        [Key, Identity]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        [NotMapped]
        public List<string> Options { get; set; }
        public string OptionString { get; set; }
        public string AnswerText { get; set; }
    }
}
