using FluentValidation;
using SHL.Application.DTO.VestedShareTransfer;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.VestedShareTransfer
{
   public class SendToBrokerDtoValidator:AbstractValidator<SendToBrokerDto>
    {
        public SendToBrokerDtoValidator(IBrokerRepository brokerRepository)
        {
            RuleFor(c => c.VestedSharedRequestIds)
                .NotEmpty();

            RuleFor(c => c.BrokerId)
                .NotEmpty();

            RuleFor(c => c)
               .CustomAsync(async (model, context, ct) =>
               {                 
                   var broker = await brokerRepository.GetByIdAsync(model.BrokerId);
                   if (broker is null)
                   {
                       context.AddFailure(nameof(model.BrokerId), "Invalid broker");
                   }
               });
        }
    }
}
