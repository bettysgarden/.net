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
        CreateMap<CreateAnswerModel, Answer>();

        #endregion
        
        #region Attachments
        CreateMap<Attachments, AttachmentsModel>().ReverseMap(); 
        CreateMap<Attachments, AnswerPreviewModel>(); 
        CreateMap<CreateAttachmentsModel, Attachments>();


        #endregion

        #region Likes
        CreateMap<Likes, LikesModel>().ReverseMap(); 
        CreateMap<Likes, LikesPreviewModel>();
        CreateMap<CreateLikesModel, Likes>();

        #endregion
        
        #region Question
        CreateMap<Question, QuestionModel>().ReverseMap(); 
        CreateMap<Question, QuestionPreviewModel>();
        CreateMap<CreateQuestionModel, Question>();

        #endregion
        

    }
}