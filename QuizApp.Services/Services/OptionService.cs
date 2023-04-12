using QuizApp.Repository.Interfaces;
using QuizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _repository;

        public OptionService(IOptionRepository repository)
        {
            _repository = repository;
        }
    }
}
