using QuizApp.Domain.DTOs;
using QuizApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<Response> AddQuestionsAndOptions(CreateQuestionDTO model);
        Task<Response> GetQuestionById(int questionId);
        Task<Response> GetAllQuestions();
        Task<Response> AnswerQuestion(int questionId, string answer);

    }
}
