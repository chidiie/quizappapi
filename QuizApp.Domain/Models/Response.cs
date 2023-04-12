using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Models
{
    public class Response
    {
        public Response(bool isSuccess)
        {
            IsSuccessful = isSuccess;
        }
        public dynamic Data { get; set; }
        public ErrorResponse Error { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
