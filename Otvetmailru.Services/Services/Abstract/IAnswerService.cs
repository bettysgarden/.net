using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public interface IAnswerService
{
    AnswerModel CreateAnswer(CreateAnswerModel createAnswerModel);

    AnswerModel GetAnswer(Guid id);

    AnswerModel UpdateAnswer(Guid id, UpdateAnswerModel answer);

    void DeleteAnswer(Guid id);

    PageModel<AnswerPreviewModel> GetAnswer(int limit = 20, int offset = 0);
}