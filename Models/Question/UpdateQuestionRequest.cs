using FluentValidation;
using FluentValidation.Results;

using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;


public class UpdateQuestionRequest
{
    #region Model
    public string QuestionText { get; set; }
    public string AdditionInfo  { get; set; }
    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateQuestionRequest>
    {
        public Validator()
        {
            RuleFor(x => x.QuestionText)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.AdditionInfo)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateQuestionRequestExtension
{
    public static ValidationResult Validate(this UpdateQuestionRequest model)
    {
        return new UpdateQuestionRequest.Validator().Validate(model);
    }
}