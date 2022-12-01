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
        
        #region Question

        CreateMap<QuestionModel, QuestionResponse>();
        CreateMap<UpdateQuestionRequest, UpdateQuestionModel>();
        CreateMap<QuestionPreviewModel, QuestionPreviewResponse>();
        CreateMap<CreateQuestionRequest, CreateQuestionModel>();


        #endregion
        
        #region Likes
        
        CreateMap<LikesModel, LikesResponse>();
        CreateMap<UpdateLikesRequest, UpdateLikesModel>();
        CreateMap<LikesPreviewModel, LikesPreviewResponse>();
        CreateMap<CreateLikesRequest, CreateLikesModel>();

        
        #endregion

        #region Attachments

        CreateMap<AttachmentsModel, AttachmentsResponse>();
        CreateMap<UpdateAtachmentsRequest, UpdateAttachmentsModel>();
        CreateMap<AttachmentsPreviewModel, AttachmentsPreviewResponse>();
        CreateMap<CreateAttachmentsRequest, CreateAttachmentsModel>();


        #endregion
        
        #region Answer

        CreateMap<AnswerModel, AnswerResponse>();
        CreateMap<UpdateAnswerRequest, UpdateAnswerModel>();
        CreateMap<AnswerPreviewModel, AnswerPreviewResponse>();
        CreateMap<CreateAnswerRequest, CreateAnswerModel>();


        #endregion
    }
}