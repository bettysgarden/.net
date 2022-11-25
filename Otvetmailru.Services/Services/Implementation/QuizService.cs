using AutoMapper;
using Otvetmailru.Entity.Models;
using Otvetmailru.Entities.Models;
using Otvetmailru.Repository;
using Otvetmailru.Services.Abstract;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.Abstract;

public class QuizService : IQuizService
{
    private readonly IRepository<Quiz> _quizRepository;
    private readonly IMapper _mapper;
    public QuizService(IRepository<Quiz> quizRepository, IMapper mapper)
    {
        this._quizRepository=quizRepository;
        this._mapper = mapper;
    }

    public void DeleteQuiz(Guid id)
    {
        var quizToDelete =_quizRepository.GetById(id);
        if (quizToDelete == null)
        {
            throw new Exception("Quiz not found");
        }
        _quizRepository.Delete(quizToDelete);
    }

    public QuizModel GetQuiz(Guid id)
    {
        var quiz =_quizRepository.GetById(id);
        return _mapper.Map<QuizModel>(quiz);
    }

    public PageModel<QuizPreviewModel> GetQuiz(int limit = 20, int offset = 0)
    {
        var quiz =_quizRepository.GetAll();
        int totalCount =quiz.Count();
        var chunk=quiz.OrderBy(x=>x.FinishDate)
            .Skip(offset)
            .Take(limit);

        return new PageModel<QuizPreviewModel>()
        {
            Items = _mapper.Map<IEnumerable<QuizPreviewModel>>(quiz),
            TotalCount = totalCount
        };
    }

    public QuizModel UpdateQuiz(Guid id, UpdateQuizModel quiz)
    {
        var existingQuiz = _quizRepository.GetById(id);
        if (existingQuiz == null)
        {
            throw new Exception("Quiz not found");
        }
        existingQuiz = _quizRepository.Save(existingQuiz);
        return _mapper.Map<QuizModel>(existingQuiz);
    }
}