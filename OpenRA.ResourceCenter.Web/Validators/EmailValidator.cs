using FluentValidation;
using OpenRA.ResourceCenter.Web.Dtos;

namespace OpenRA.ResourceCenter.Web.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator() {
            RuleFor(email => email.EmailAddress).NotNull();
            RuleFor(email => email.EmailAddress).EmailAddress();
            
            RuleFor(email => email.Subject).NotNull();
            RuleFor(email => email.Subject).MaximumLength(200);
            
            RuleFor(email => email.Message).NotNull();
            RuleFor(email => email.Message).MaximumLength(2000);
        }
    }
}