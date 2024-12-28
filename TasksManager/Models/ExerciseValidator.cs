using FluentValidation;

namespace TasksManager.Models;

public class ExerciseValidator : AbstractValidator<Exercise>
{
    public ExerciseValidator()
    {
        RuleFor(ex => ex.Essence).NotEmpty().WithMessage("Essence is required");
        RuleFor(task => task.Date).NotEmpty().WithMessage("Start time must not be empty")
            .GreaterThan(DateTime.Now).WithMessage("Start date must be greater than today");
        RuleFor(ex => ex.TaskId).NotEmpty().WithMessage("Appropriate task is required");

    }
}