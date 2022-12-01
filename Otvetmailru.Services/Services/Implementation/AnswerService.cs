using AutoMapper;
using Otvetmailru.Entity.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Implementation;

public class AnswerService : IAnswerService
{

    private readonly IRepository<Answer> _answerRepository;
    private readonly IMapper _mapper;
    
    public AnswerService(IRepository<Answer> answerRepository, IMapper mapper)
    {
        this._answerRepository=answerRepository;
        this._mapper = mapper;
    }

    public void DeleteAnswer(Guid id)
    {
        var answerToDelete = _answerRepository.GetById(id);
        if (answerToDelete == null)
        {
            throw new Exception("Answer not found");
        }
        _answerRepository.Delete(answerToDelete);
    }


    public AnswerModel CreateAnswer(CreateAnswerModel createAnswerModel)
    {
        Answer answer = _mapper.Map<Answer>(createAnswerModel);
        return _mapper.Map<AnswerModel>(_answerRepository.Save(answer));
    }

    public AnswerModel GetAnswer(Guid id)
    {
        var answer =_answerRepository.GetById(id);
        return _mapper.Map<AnswerModel>(answer);
    }

    public PageModel<AnswerPreviewModel> GetAnswer(int limit = 20, int offset = 0)
    {
        var answer =_answerRepository.GetAll();
        int totalCount =answer.Count();
        var chunk=answer.OrderBy(x=>x.AmountOfLikes)
            .Skip(offset)
            .Take(limit);

        return new PageModel<AnswerPreviewModel>()
        {
            Items = _mapper.Map<IEnumerable<AnswerPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public AnswerModel UpdateAnswer(Guid id, UpdateAnswerModel answer)
    {
        var existingAnswer = _answerRepository.GetById(id);
        if (existingAnswer == null)
        {
            throw new Exception("Answer not found");
        }
        existingAnswer.TextAnswer = answer.TextAnswer;
        existingAnswer = _answerRepository.Save(existingAnswer);
        return _mapper.Map<AnswerModel>(existingAnswer);
    }
}