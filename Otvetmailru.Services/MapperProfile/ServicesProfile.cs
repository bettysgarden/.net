using AutoMapper;
using Otvetmailru.Entities.Models;
using Otvetmailru.Entity.Models;
using Otvetmailru.Services.Models;

namespace Otvetmailru.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap(); 
        CreateMap<User, UserPreviewModel>()
            .ForMember(x => x.FullName, y => y.MapFrom(u => $"{u.LastName} {u.FirstName} {u.SecondName}"));

        #endregion
        
        #region Answers
        CreateMap<Answer, AnswerModel>().ReverseMap();
        CreateMap<Answer, AnswerPreviewModel>();
        #endregion
        
        #region Attachments
        CreateMap<Attachments, AttachmentsModel>().ReverseMap(); 
        CreateMap<Attachments, AnswerPreviewModel>(); 

        #endregion       
        
        #region Comments
        CreateMap<Comments, CommentsModel>().ReverseMap(); 
        CreateMap<Comments, CommentsPreviewModel>(); 

        #endregion
        
                
        #region Likes
        CreateMap<Likes, LikesModel>().ReverseMap(); 
        CreateMap<Likes, LikesPreviewModel>();
        #endregion
        
        #region Question
        CreateMap<Question, QuestionModel>().ReverseMap(); 
        CreateMap<Question, QuestionPreviewModel>();
        #endregion
        
        #region Quiz
        CreateMap<Quiz, QuizModel>().ReverseMap(); 
        CreateMap<Quiz, QuizPreviewModel>();
        #endregion

    }
}