using FluentValidation;
using FluentValidation.Results;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;

public class UpdateQuizRequest
{
    #region Model
    public string TextQuiz { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateQuizRequest>
    {
        public Validator()
        {
            RuleFor(x => x.TextQuiz)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateQuizRequestExtension
{
    public static ValidationResult Validate(this UpdateQuizRequest model)
    {
        return new UpdateQuizRequest.Validator().Validate(model);
    }
}