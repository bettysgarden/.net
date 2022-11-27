using AutoMapper;
using Otvetmailru.Entities.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Otvetmailru.Services.Models;
using Otvetmailru.Services.MapperProfile;

namespace Otvetmailru.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        // mapper
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IAttachmentsService, AttachmentsService>();
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<ILikesService, LikesService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuizService, QuizService>();
    }
}