using AutoMapper;
using Otvetmailru.Entity.Models;
using Otvetmailru.Entities.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public class QuestionService : IQuestionService
{
    private readonly IRepository<Question> _questionRepository;
    private readonly IMapper _mapper;
    public QuestionService(IRepository<Question> questionRepository, IMapper mapper)
    {
        this._questionRepository=questionRepository;
        this._mapper = mapper;
    }

    public void DeleteQuestion(Guid id)
    {
        Question questionToDelete;
        questionToDelete = _questionRepository.GetById(id);
        if (questionToDelete == null)
        {
            throw new Exception("Question not found");
        }
        _questionRepository.Delete(questionToDelete);
    }

    public QuestionModel CreateQuestion(CreateQuestionModel questionModel)
    {
        Question question = _mapper.Map<Question>(questionModel);
        return _mapper.Map<QuestionModel>(_questionRepository.Save(question));
    }

    public QuestionModel GetQuestion(Guid id)
    {
        var question =_questionRepository.GetById(id);
        return _mapper.Map<QuestionModel>(question);
    }

    public PageModel<QuestionPreviewModel> GetQuestion(int limit = 20, int offset = 0)
    {
        var question =_questionRepository.GetAll();
        int totalCount =question.Count();
        var chunk=question.OrderBy(x=>x.Category)
            .Skip(offset)
            .Take(limit);

        return new PageModel<QuestionPreviewModel>()
        {
            Items = _mapper.Map<IEnumerable<QuestionPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public QuestionModel UpdateQuestion(Guid id, UpdateQuestionModel question)
    {
        var existingQuestion = _questionRepository.GetById(id);
        if (existingQuestion == null)
        {
            throw new Exception("Question not found");
        }
        existingQuestion.QuestionText = question.QuestionText;
        existingQuestion.Category = question.Category;
        existingQuestion.AdditionInfo = question.AdditionInfo;

        existingQuestion = _questionRepository.Save(existingQuestion);
        return _mapper.Map<QuestionModel>(existingQuestion);
    }
}