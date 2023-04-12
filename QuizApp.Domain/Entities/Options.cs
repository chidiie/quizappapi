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
    [Table("Options")]
    public class Options
    {
        [Key, Identity]
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public int QuestionId { get; set; }
    }
}
