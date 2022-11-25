using Otvetmailru.Services.Models;
namespace Otvetmailru.Services.Abstract;

public interface IQuestionService
{
    QuestionModel GetQuestion(Guid id);

    QuestionModel UpdateQuestion(Guid id, UpdateQuestionModel Question);

    void DeleteQuestion(Guid id);

    PageModel<QuestionPreviewModel> GetQuestion(int limit = 20, int offset = 0);
}