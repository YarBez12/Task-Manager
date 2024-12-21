using FluentValidation;

namespace TasksManager.Models;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Username must be between 3 and 100 characters")
            .MaximumLength(70).WithMessage("Username must be between 3 and 70 characters");
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");
    }
}