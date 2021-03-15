using FluentValidation;
using ProjectManager.Core.RepositoryInterface;
using ProjectManager.Infrastructure;
using ProjectManager.Web.WebApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectManager.Web.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator(IUnitOfWork unitOfWork)
        {
            /* Required fields */
            RuleFor(u => u.Email).NotEmpty().WithMessage(u => ResponseCodes.RequiredField(nameof(u.Email)));
            RuleFor(u => u.UserName).NotEmpty().WithMessage(u => ResponseCodes.RequiredField(nameof(u.UserName)));
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(u => ResponseCodes.RequiredField(nameof(u.FirstName)));
            RuleFor(u => u.LastName).NotEmpty().WithMessage(u => ResponseCodes.RequiredField(nameof(u.LastName)));
            RuleFor(u => u.Password).NotEmpty().WithMessage(u => ResponseCodes.RequiredField(nameof(u.Password)));

            /* Length rules */
            RuleFor(user => user.FirstName).MinimumLength(2).When(u => !string.IsNullOrEmpty(u.FirstName)).WithMessage(u => ResponseCodes.LengthError(nameof(u.FirstName), true, 2));
            RuleFor(user => user.LastName).MinimumLength(2).When(u => !string.IsNullOrEmpty(u.LastName)).WithMessage(u => ResponseCodes.LengthError(nameof(u.LastName), true, 2));
            RuleFor(user => user.UserName).MinimumLength(2).When(u => !string.IsNullOrEmpty(u.UserName)).WithMessage(u => ResponseCodes.LengthError(nameof(u.UserName), true, 2));
            RuleFor(u => u.Password).MinimumLength(8).When(u => !string.IsNullOrEmpty(u.Password)).WithMessage(u => ResponseCodes.LengthError(nameof(u.Password), true, 8));

            RuleFor(user => user.FirstName).MaximumLength(60).When(u => !string.IsNullOrEmpty(u.FirstName)).WithMessage(u => ResponseCodes.LengthError(nameof(u.FirstName), false, 255));
            RuleFor(user => user.LastName).MaximumLength(60).When(u => !string.IsNullOrEmpty(u.LastName)).WithMessage(u => ResponseCodes.LengthError(nameof(u.LastName), false, 255));
            RuleFor(user => user.UserName).MaximumLength(255).When(u => !string.IsNullOrEmpty(u.UserName)).WithMessage(u => ResponseCodes.LengthError(nameof(u.UserName), false, 255));

            RuleFor(u => u.ConfirmPassword).Equal(r => r.Password).WithMessage(ResponseCodes.MUST_BE_EQUAL_PASSWORDS);

            /* Regex rules */
            RuleFor(u => u.Email)
                .Matches(Constants.EMAIL_REGEX, RegexOptions.IgnoreCase)
                .When(u => !string.IsNullOrEmpty(u.Email))
                .WithMessage(u => ResponseCodes.InvalidValue(nameof(u.Email)));
            RuleFor(u => u.Password)
                .Matches(Constants.PASSWORD_REGEX)
                .When(u => !string.IsNullOrEmpty(u.Password))
                .WithMessage(u => $"{ResponseCodes.InvalidValue(nameof(u.Password))} {ResponseCodes.PASSWORD_RULES}");
            RuleFor(u => u.FirstName)
                .Matches(Constants.NAME_REGEX)
                .When(u => !string.IsNullOrEmpty(u.FirstName))
                .WithMessage(u => $"{ResponseCodes.InvalidValue(nameof(u.FirstName))}");
            RuleFor(u => u.LastName)
                .Matches(Constants.NAME_REGEX)
                .When(u => !string.IsNullOrEmpty(u.LastName))
                .WithMessage(u => $"{ResponseCodes.InvalidValue(nameof(u.LastName))}");

            /* Custom rules */
            RuleFor(u => u.Email).Custom((value, context) =>
            {
                if (unitOfWork.Users.Any(u => u.Email == value))
                {
                    context.AddFailure(context.PropertyName, ResponseCodes.EMAIL_ALREADY_REGISTERED);
                }
            });
            RuleFor(u => u.UserName).Custom((value, context) =>
            {
                if (unitOfWork.Users.Any(u => u.UserName == value))
                {
                    context.AddFailure(context.PropertyName, ResponseCodes.EMAIL_ALREADY_REGISTERED);
                }
            });
            RuleFor(u => u.DateOfBirth).Custom((value, context) =>
            {
                if (DateTime.Now <= value)
                {
                    context.AddFailure(context.PropertyName, ResponseCodes.INVALID_DATE_OF_BIRTH);
                }
            });
        }
    }
}
