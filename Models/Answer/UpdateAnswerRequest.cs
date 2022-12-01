using FluentValidation;
using FluentValidation.Results;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class UpdateAnswerRequest
{
    #region Model
    
    public string TextAnswer  { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateAnswerRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TextAnswer)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateAnswerRequestExtension
{
    public static ValidationResult Validate(this UpdateAnswerRequest model)
    {
        return new UpdateAnswerRequest.Validator().Validate(model);
    }
}