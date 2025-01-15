using FluentValidation;

namespace TasksManager.Models;

public class TaskValidator : AbstractValidator<Task>
{
    public TaskValidator()
    {
        RuleFor(task => task.Title).NotEmpty().WithMessage("Title is required");
        // RuleFor(task => task.DueDate).GreaterThan(DateTime.Now).WithMessage("Due date must be greater than today");
    }
}