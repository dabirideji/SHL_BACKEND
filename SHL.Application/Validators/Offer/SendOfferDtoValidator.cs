using FluentValidation;
using SHL.Application.DTO.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.Offer
{
  public  class SendOfferDtoValidator:AbstractValidator<SendOfferDto>
    {
        public SendOfferDtoValidator()
        {
            RuleFor(c => c.OfferIds)
                .NotEmpty();
        }
    }
}
