using QuizApp.Domain.Entities;
using QuizApp.Domain.DTOs;
using QuizApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QuizApp.Domain.Models;
using QuizApp.LoggerService;
using QuizApp.Services.Interfaces;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace QuizApp.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;

        public QuestionService(IQuestionRepository repository, IOptionRepository optionRepository,
            IMapper mapper, ILoggerManager loggerManager)
        {
            _repository = repository;
            _optionRepository = optionRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        public async Task<Response> AddQuestionsAndOptions(CreateQuestionDTO model)
        {
            //string json = JsonConvert.SerializeObject();
            var response = new Response(false);
            try
            {
                var question = _mapper.Map<Question>(model);
                var options = question.Options;
                string json = JsonConvert.SerializeObject(options);
                question.OptionString = json;
                await _repository.AddAsync(question);

                

                //foreach (var item in question.Options)
                //{
                //    var option = new Options
                //    {
                //        OptionText = item,
                //        QuestionId = question.QuestionId
                //    };

                //    await _optionRepository.AddAsync(option);
                //}

                response.IsSuccessful = true;
                response.Data = "Question Added Successful";
                return response;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"{ex.Message} + {ex.StackTrace}");

                response.Error = new ErrorResponse
                {
                    ResponseCode = "99",
                    ResponseDescription = ex.Message
                };
                response.IsSuccessful = false;
                return response;
            }
        }

        public async Task<Response> GetQuestionById(int questionId)
        {
            var response = new Response(false);
            var question = await _repository.GetByIdAsync(questionId);
            if(question == null)
            {
                response.Error = new ErrorResponse
                {
                    ResponseDescription = "Question Doesn't Exist",
                    ResponseCode = "99"
                };
                return response;
            }

            else
            {
                var optionString = question.OptionString;
                
                //var getquestion = _mapper.Map<GetQuestionDTO>(question);
                //var newList = new List<string>();
                var newList = JsonConvert.DeserializeObject<List<string>>(optionString);
                question.Options = newList;

                //var options = await _optionRepository.GetAllAsync(x => x.QuestionId == questionId);
                //var optionsList = options.ToList();

                //foreach (var item in optionsList)
                //{
                //    newList.Add(item.OptionText);
                //}
                //question.Options = newList;
                var getquestion = _mapper.Map<GetQuestionDTO>(question);
                response.IsSuccessful = true;
                response.Data = getquestion;
                return response;

            }
        }

        public async Task<Response> GetAllQuestions()
        {
            var response = new Response(false);
            var questions = await _repository.GetAllAsync();
            if (questions == null)
            {
                response.Error = new ErrorResponse
                {
                    ResponseDescription = "Question Doesn't Exist",
                    ResponseCode = "99"
                };
                return response;
            }
            else
            {
                foreach (var item in questions)
                {
                    var optionString = item.OptionString;
                    var newList = JsonConvert.DeserializeObject<List<string>>(optionString);
                    item.Options = newList;
                }
                var getAllQuestions = _mapper.Map<List<GetQuestionDTO>>(questions);

                response.IsSuccessful = true;
                response.Data = getAllQuestions;
                return response;

            }
            
        }

        public async Task<Response> AnswerQuestion(int questionId, string answer)
        {
            var response = new Response(false);
            var question = await _repository.GetByIdAsync(questionId);
            if (question == null)
            {
                response.Error = new ErrorResponse
                {
                    ResponseDescription = "Question Doesn't Exist",
                    ResponseCode = "99"
                };
                return response;
            }

            else
            {
                if(question.AnswerText.ToLower() == answer.ToLower())
                {
                    response.IsSuccessful = true;
                    response.Data = "Answer Correct";
                    return response;
                }

                else
                {
                    response.IsSuccessful = true;
                    response.Data = "Answer Wrong";
                    return response;
                }
            }
        }
        
    }
}
