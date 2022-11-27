using FluentValidation;
using FluentValidation.Results;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;


public class UpdateLikesRequest
{
    #region Model
    
    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateLikesRequest>
    {
        public Validator()
        {

        }
    }

    #endregion
}

public static class UpdateLikesRequestExtension
{
    public static ValidationResult Validate(this UpdateLikesRequest model)
    {
        return new UpdateLikesRequest.Validator().Validate(model);
    }
}