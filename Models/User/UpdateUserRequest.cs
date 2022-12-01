using FluentValidation;
using FluentValidation.Results;

namespace Otvetmailru.WebAPI.Models;

public class UpdateUserRequest
{
    #region Model

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string SecondName { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.LastName)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x => x.SecondName)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateUserRequestExtension
{
    public static ValidationResult Validate(this UpdateUserRequest model)
    {
        return new UpdateUserRequest.Validator().Validate(model);
    }
}