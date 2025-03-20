using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SHL.Application.DTO.Staff;
using SHL.Application.Interfaces.GenericRepositoryPattern;
using SHL.Application.IServices;
using SHL.Application.Repositories;

namespace SHL.Application.CQRS.Staff.Commands
{
    public record EditProfileCommand(EditProfileDto Dto) : IRequest;
    class EditProfileCommandHandler : IRequestHandler<EditProfileCommand>
    {
        private readonly IValidator<EditProfileDto> validator;
        private readonly IStaffRepository staffRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserIdentityService userIdentityService;
        private readonly ICompanyUserRepository companyUserRepository;

        public EditProfileCommandHandler(IValidator<EditProfileDto> validator,
            IStaffRepository staffRepository,
            IUnitOfWork unitOfWork,
            IUserIdentityService userIdentityService,
            ICompanyUserRepository companyUserRepository)
        {
            this.validator = validator;
            this.staffRepository = staffRepository;
            this.unitOfWork = unitOfWork;
            this.userIdentityService = userIdentityService;
            this.companyUserRepository = companyUserRepository;
        }
        public async Task Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await validator.ValidateAsync(request.Dto);
            if (validatorResult.Errors.Count > 0)
                throw new FluentValidation.ValidationException(validatorResult.Errors);

            var user = await companyUserRepository.Get(u => u.Id == userIdentityService.SubjectId)
                .FirstOrDefaultAsync(cancellationToken);

            var staff = await staffRepository.Get(s => s.CompanyUserId == userIdentityService.SubjectId)
                .Include(s => s.Bank)
                .FirstOrDefaultAsync();

            if (user is null) return;

            user.PhoneNumber = request.Dto.PhoneNumber;

            if (staff is null)
            {
                var newStaff = new Domain.Models.Staff
                {
                    Bank = new Domain.Models.StaffBank
                    {
                        AccountNumber = request.Dto.AccountNumber ?? "",
                        BankName = request.Dto.BankName ?? "",
                        AccountName = request.Dto.AccountName ?? ""
                    },
                    ChnNumber = request.Dto.ChnNumber,
                    CompanyUserId = user.Id,
                    CompanyId = userIdentityService.CompanyId,
                    CscsNumber = request.Dto.CscsNumber,
                    StaffDepartment = "",
                    StaffCode = "",
                    StaffGrade = "",
                    StaffStatus = Domain.Models.Categories.StaffStatus.ACTIVE
                };
                await staffRepository.AddAsync(newStaff);
            }
            else
            {
                staff.CscsNumber = request.Dto.CscsNumber;
                staff.ChnNumber = request.Dto.ChnNumber;
                if (staff.Bank == null)
                {
                    staff.Bank = new Domain.Models.StaffBank
                    {
                        AccountName = request.Dto.AccountName ?? "",
                        AccountNumber = request.Dto.AccountNumber ?? "",
                        BankName = request.Dto.BankName ?? ""
                    };
                }
                else
                {
                    staff.Bank.AccountName = request.Dto.AccountName ?? "";
                    staff.Bank.AccountNumber = request.Dto.AccountNumber ?? "";
                    staff.Bank.BankName = request.Dto.BankName ?? "";
                }
            }


            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
