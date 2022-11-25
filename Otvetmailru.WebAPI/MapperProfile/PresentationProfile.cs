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
    }
}