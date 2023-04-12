using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Models
{
    public class ErrorResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }

        public override string ToString()
        {
            return $"{ResponseCode} - {ResponseDescription}";
        }
    }
}
