using FluentValidation;
using MediatR;
using SHL.Application.DTO.Broker;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Broker.Commands
{
    public record CreateBrokerCommand(CreateBrokerDto Dto) :IRequest;
    class CreateBrokerCommandHandler : IRequestHandler<CreateBrokerCommand>
    {
        private readonly IValidator<CreateBrokerDto> validator;
        private readonly IBrokerRepository brokerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateBrokerCommandHandler(IValidator<CreateBrokerDto> validator,
            IBrokerRepository brokerRepository,
            IUnitOfWork unitOfWork)
        {
            this.validator = validator;
            this.brokerRepository = brokerRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateBrokerCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            await brokerRepository.AddAsync(new Domain.Models.Broker
            {
                Address = request.Dto.Address,
                BrokerName = request.Dto.BrokerName,
                ContactPerson = request.Dto.ContactPerson,
                EmailAddress = request.Dto.EmailAddress,
                PhoneNumber = request.Dto.PhoneNumber
            });

            await unitOfWork.SaveChangesAsync();
        }
    }
}
