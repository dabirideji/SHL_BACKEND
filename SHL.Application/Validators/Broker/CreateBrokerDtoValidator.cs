using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Broker;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Broker
{
    public class CreateBrokerDtoValidator : AbstractValidator<CreateBrokerDto>
    {
        public CreateBrokerDtoValidator(IBrokerRepository brokerRepository)
        {
            RuleFor(c => c.Address)
                .NotEmpty();

            RuleFor(c => c.ContactPerson)
               .NotEmpty();

            RuleFor(c => c.PhoneNumber)
               .NotEmpty();

            RuleFor(c => c.EmailAddress)
               .EmailAddress()
               .NotEmpty();

            RuleFor(c => c.BrokerName)
                .NotEmpty();

            RuleFor(c => c)
                .CustomAsync(async (model, context, ct) =>
                {
                    var brokerExist = await brokerRepository.Get(g => g.BrokerName == model.BrokerName && g.EmailAddress == model.EmailAddress && g.PhoneNumber == model.PhoneNumber)
                    .AnyAsync();

                    if (brokerExist)
                    {
                        context.AddFailure(nameof(model.BrokerName), "Broker already exist");
                    }
                });
        }
    }
}
