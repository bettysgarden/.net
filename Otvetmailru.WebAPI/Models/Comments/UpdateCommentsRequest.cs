using FluentValidation;
using FluentValidation.Results;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;


public class UpdateCommentsRequest
{
    #region Model
    public string TextComment  { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateCommentsRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TextComment)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateCommentsRequestExtension
{
    public static ValidationResult Validate(this UpdateCommentsRequest model)
    {
        return new UpdateCommentsRequest.Validator().Validate(model);
    }
}