using FluentValidation;
using FluentValidation.Results;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.WebAPI.Models;


    public class UpdateAtachmentsRequest
    {
        #region Model
    
        public string Name  { get; set; }

        #endregion

        #region Validator

        public class Validator : AbstractValidator<UpdateAtachmentsRequest>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .MaximumLength(255).WithMessage("Length must be less than 256");
            }
        }

        #endregion
    }

    public static class UpdateAtachmentsRequestExtension
    {
        public static ValidationResult Validate(this UpdateAtachmentsRequest model)
        {
            return new UpdateAtachmentsRequest.Validator().Validate(model);
        }
    }
