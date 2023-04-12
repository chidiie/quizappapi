using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Domain.DTOs;
using QuizApp.Services.Interfaces;

namespace QuizApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await _questionService.GetQuestionById(questionId);
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDTO model)
        {
            var question = await _questionService.AddQuestionsAndOptions(model);
            return Ok(question);
        }

        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var allQuestions = await _questionService.GetAllQuestions();
            return Ok(allQuestions);
        }

        [HttpPost("AnswerQuestion")]
        public async Task<IActionResult> AnswerQuestion(int questionId, string answer)
        {
            var answerQuestion = await _questionService.AnswerQuestion(questionId, answer);
            return Ok(answerQuestion);
        }
    }
}
