using Otvetmailru.Services.Models;
namespace Otvetmailru.Services.Abstract;

public interface IQuizService
{
    QuizModel GetQuiz(Guid id);

    QuizModel UpdateQuiz(Guid id, UpdateQuizModel quiz);

    void DeleteQuiz(Guid id);

    PageModel<QuizPreviewModel> GetQuiz(int limit = 20, int offset = 0);
}