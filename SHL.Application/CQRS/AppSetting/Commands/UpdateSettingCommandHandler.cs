using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.AppSetting;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.AppSetting.Commands
{
    public record UpdateSettingCommand(UpdateSettingDto Dto) : IRequest<Domain.Models.AppSetting?>;
    class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, Domain.Models.AppSetting?>
    {
        private readonly IAppSettingRepository appSettingRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateSettingCommandHandler(IAppSettingRepository appSettingRepository,
            IUnitOfWork unitOfWork)
        {
            this.appSettingRepository = appSettingRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Domain.Models.AppSetting?> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            var settings = await appSettingRepository.Get()
                .FirstOrDefaultAsync();

            if (settings is not null)
            {
                settings.CanEmployeeTransferShares = request.Dto.CanEmployeeTransferShares;
                settings.AllowIncentive = request.Dto.AllowIncentive;
                settings.ToggleRsuEquityType = request.Dto.ToggleRsuEquityType;
                settings.ToggleOptionsEquityType = request.Dto.ToggleOptionsEquityType;
                settings.ToggleSharePlan = request.Dto.ToggleSharePlan;
                settings.ExerciseRequestTaxValue = request.Dto.ExerciseRequestTax;
                settings.UpdatedAt = DateTime.Now;

                await unitOfWork.SaveChangesAsync(cancellationToken);

                return settings;
            }

            return null;
        }
    }
}
