using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.ExcerciseRequest;
using SHL.Application.Repositories;

namespace SHL.Application.Validators.ExcerciseRequest
{
    public class ChangeRequestStatusDtoValidator : AbstractValidator<ChangeRequestStatusDto>
    {
        string[] Status = ["Approved", "Declined"];
        public ChangeRequestStatusDtoValidator(IExcerciseRequestRepository excerciseRequest)
        {
            RuleFor(c => c.ExerciseRequestId)
                .NotEmpty();

            //RuleFor(c => c.Status)
            //    .Must(c => !Status.Any(s => string.Equals(s, c, StringComparison.OrdinalIgnoreCase)))
            //    .WithMessage("Status must be Approved or Declined");

            RuleFor(c => c)
                .Custom((model, context) =>
                {
                    var status = Status.Any(c => string.Equals(model.Status, c, StringComparison.OrdinalIgnoreCase));
                    if (!status)
                    {
                        context.AddFailure(nameof(model.Status), "Status must be Approved or Declined");
                    }
                });

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    //var request = await excerciseRequest.Get(u => u.Id == model.ExerciseRequestId)
                    //.AsNoTracking()
                    //.FirstOrDefaultAsync();

                    //if (request is null)
                    //{
                    //    context.AddFailure(nameof(model.ExerciseRequestId), "Invalid excercise request");
                    //    return;
                    //}

                    if (string.Equals("Declined", model.Status, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(model.DeclineReason))
                    {
                        context.AddFailure(nameof(model.DeclineReason), "Kindly provide a decline reason for a Declined status");
                    }
                });
        }
    }
}
