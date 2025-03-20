using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Company;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.Company.Commands
{
    public record UpdateEmployeeCommand(UpdateEmployeeDto Dto) : IRequest;
    class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IValidator<UpdateEmployeeDto> validator;
        private readonly IStaffRepository staffRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserIdentityService userIdentityService;

        public UpdateEmployeeCommandHandler(IValidator<UpdateEmployeeDto> validator,
            IStaffRepository staffRepository,
            IUnitOfWork unitOfWork,
            IUserIdentityService userIdentityService)
        {
            this.validator = validator;
            this.staffRepository = staffRepository;
            this.unitOfWork = unitOfWork;
            this.userIdentityService = userIdentityService;
        }
        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var userId = await staffRepository.UpdateStaffInfoAsync(request.Dto, cancellationToken);

            var staff = await staffRepository.Get(u => u.CompanyUserId == userId)
                .Include(b => b.Bank)
                .FirstOrDefaultAsync();

            if (staff is null)
            {
                var newStaff = new Domain.Models.Staff
                {
                    Bank = new Domain.Models.StaffBank
                    {
                        AccountNumber = request.Dto.AccountNumber ?? "",
                        BankName = request.Dto.BankName ?? ""
                    },
                    ChnNumber = request.Dto.ChnNumber,
                    CompanyUserId = userId,
                    CompanyId = userIdentityService.CompanyId,
                    CscsNumber = request.Dto.CscsNumber,
                    StaffDepartment = request.Dto.StaffDepartment,
                    StaffCode = request.Dto.StaffCode,
                    StaffGrade = request.Dto.StaffGrade,
                    StaffStatus = Domain.Models.Categories.StaffStatus.ACTIVE
                };

                await staffRepository.AddAsync(newStaff);
            }
            else
            {
                if (staff!.Bank is null)
                {
                    staff.Bank = new Domain.Models.StaffBank
                    {
                        AccountNumber = request.Dto.AccountNumber ?? "",
                        BankName = request.Dto.BankName ?? ""
                    };
                }
                else
                {
                    staff.Bank.AccountNumber = request.Dto.AccountNumber ?? "";
                    staff.Bank.BankName = request.Dto.BankName ?? "";
                }
            }


            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
