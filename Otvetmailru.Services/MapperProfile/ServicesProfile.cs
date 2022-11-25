using AutoMapper;
using Otvetmailru.Entities.Models;
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
    }
}