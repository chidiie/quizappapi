using AutoMapper;
using QuizApp.Domain.DTOs;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Infrastructure.AutoMapper
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Question, CreateQuestionDTO>().ReverseMap();
            CreateMap<Question, GetQuestionDTO>().ReverseMap();
        }
    }
}
