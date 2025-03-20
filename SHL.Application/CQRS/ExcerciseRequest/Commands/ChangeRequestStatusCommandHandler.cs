using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.ExcerciseRequest;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.ExcerciseRequest.Commands
{
    public record ChangeRequestStatusCommand(ChangeRequestStatusDto Dto) :IRequest;
    class ChangeRequestStatusCommandHandler : IRequestHandler<ChangeRequestStatusCommand>
    {
        private readonly IValidator<ChangeRequestStatusDto> validator;
        private readonly IExcerciseRequestRepository excerciseRequestRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChangeRequestStatusCommandHandler(IValidator<ChangeRequestStatusDto> validator,
            IExcerciseRequestRepository excerciseRequestRepository,
            IUnitOfWork unitOfWork)
        {
            this.validator = validator;
            this.excerciseRequestRepository = excerciseRequestRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(ChangeRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var status = (Domain.Enums.ExcerciseRequest)Enum.Parse(typeof(Domain.Enums.ExcerciseRequest), request.Dto.Status);
            var excerciseRequests = await excerciseRequestRepository.Get(e=> request.Dto.ExerciseRequestId.Contains(e.Id))
                .ToListAsync();

            foreach (var excerciseRequest in excerciseRequests)
            {
                excerciseRequest!.Status = status.ToString();
                excerciseRequest.DeclineReason = request.Dto.DeclineReason;
                excerciseRequest.UpdatedAt = DateTime.Now;
            }            

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
