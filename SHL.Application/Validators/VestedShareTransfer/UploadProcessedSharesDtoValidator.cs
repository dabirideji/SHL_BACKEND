using FluentValidation;
using SHL.Application.DTO.VestedShareTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.Validators.VestedShareTransfer
{
    public class UploadProcessedSharesDtoValidator:AbstractValidator<UploadProcessedSharesDto>
    {
        public UploadProcessedSharesDtoValidator()
        {
            RuleFor(c => c.File)
                .NotEmpty();
        }
    }
}
