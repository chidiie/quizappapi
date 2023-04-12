using Microsoft.Extensions.DependencyInjection;
using QuizApp.LoggerService;
using QuizApp.Repository.Interfaces;
using QuizApp.Repository.Repository;
using QuizApp.Services.Services;
using QuizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Infrastructure.AutoMapper;
using MicroOrm.Dapper.Repositories;
using System.Data;
using Microsoft.Extensions.Configuration;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data.SqlClient;

namespace QuizApp.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IOptionService, OptionService>();
            services.AddTransient<IQuestionService, QuestionService>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IOptionRepository, OptionRepository>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperInitializer));
        }

        public static void ConfigureSqlDatabase(this IServiceCollection services)
        {
            services.AddTransient<IDbConnection>(prov => new SqlConnection(prov.GetService<IConfiguration>().GetConnectionString("sqlConnection")));
            services.AddTransient(typeof(ISqlGenerator<>), typeof(SqlGenerator<>));
            services.AddTransient(typeof(DapperRepository<>));
        }
    }
}
