using AutoMapper;
using Otvetmailru.WebAPI.Models;
using Otvetmailru.Services.Models;

namespace Otvetmailru.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>();
        CreateMap<UpdateUserRequest, UpdateUserModel>();
        CreateMap<UserPreviewModel, UserPreviewResponse>();

        #endregion
        
        #region Quiz

        CreateMap<QuizModel, QuizResponse>();
        CreateMap<UpdateQuizRequest, UpdateQuizModel>();
        CreateMap<QuizPreviewModel, QuizPreviewResponse>();

        #endregion
        
        #region Question

        CreateMap<QuestionModel, QuestionResponse>();
        CreateMap<UpdateQuestionRequest, UpdateQuestionModel>();
        CreateMap<QuestionPreviewModel, QuestionPreviewResponse>();

        #endregion
        
        #region Likes
        
        CreateMap<LikesModel, LikesResponse>();
        CreateMap<UpdateLikesRequest, UpdateLikesModel>();
        CreateMap<LikesPreviewModel, LikesPreviewResponse>();
        
        #endregion
        
        #region Comments

        CreateMap<CommentsModel, CommentsResponse>();
        CreateMap<UpdateCommentsRequest, UpdateCommentsModel>();
        CreateMap<CommentsPreviewModel, CommentsPreviewResponse>();

        #endregion
        
        #region Attachments

        CreateMap<AttachmentsModel, AttachmentsResponse>();
        CreateMap<UpdateAtachmentsRequest, UpdateAttachmentsModel>();
        CreateMap<AttachmentsPreviewModel, AttachmentsPreviewResponse>();

        #endregion
        
        #region Answer

        CreateMap<AnswerModel, AnswerResponse>();
        CreateMap<UpdateAnswerRequest, UpdateAnswerModel>();
        CreateMap<AnswerPreviewModel, AnswerPreviewResponse>();

        #endregion
    }
}