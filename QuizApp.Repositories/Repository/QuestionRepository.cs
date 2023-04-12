using MicroOrm.Dapper.Repositories;
using QuizApp.Domain.Entities;
using QuizApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Repository.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DapperRepository<Question> repo) : base(repo)
        {

        }
    }
}
