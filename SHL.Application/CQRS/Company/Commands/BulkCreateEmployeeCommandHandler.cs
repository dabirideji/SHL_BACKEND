using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SHL.Application.DTO.Company;
using SHL.Application.IServices;
using SHL.Application.Models;
using SHL.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SHL.Application.CQRS.Company.Commands
{
    public record BulkCreateEmployeeCommand(BulkCreateEmployeeDto Dto):IRequest;
    class BulkCreateEmployeeCommandHandler : IRequestHandler<BulkCreateEmployeeCommand>
    {
        private readonly ILogger<BulkCreateEmployeeCommandHandler> logger;
        private readonly IExcelProcessor excelProcessor;
        private readonly IBulkEmployeeChannel bulkEmployeeChannel;
        private readonly IUserIdentityService userIdentityService;
        private readonly ICompanyUserRepository companyUserRepository;
        private readonly IConfiguration configuration;

        public BulkCreateEmployeeCommandHandler(ILogger<BulkCreateEmployeeCommandHandler> logger, IExcelProcessor excelProcessor,
            IBulkEmployeeChannel bulkEmployeeChannel,
            IUserIdentityService userIdentityService,
            ICompanyUserRepository companyUserRepository,
            IConfiguration configuration)
        {
            this.logger = logger;
            this.excelProcessor = excelProcessor;
            this.bulkEmployeeChannel = bulkEmployeeChannel;
            this.userIdentityService = userIdentityService;
            this.companyUserRepository = companyUserRepository;
            this.configuration = configuration;
        }
        public async Task Handle(BulkCreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            List<IdentityError> _errors = new();
            var employees =  excelProcessor.ReadBulkEmployeeFromExcel(request.Dto.File.OpenReadStream(),userIdentityService.CompanyId);
            foreach (var item in employees)
            {
                try
                {
                   
                    // Process the item
                    logger.LogInformation($"registering staff with email: {item.EmailAddress}");
                    var staffModel = new StaffModel
                    {
                        CompanyId = item.CompanyId,
                        Designation = item.Designation,
                        EmailAddress = item.EmailAddress,
                        EmployeeId = item.EmployeeId,
                        EmploymentDate = item.EmploymentDate,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber,
                        StaffCode = item.EmployeeId,
                        StaffDepartment = item.Department,
                        StaffGrade = item.Grade

                    };
                    (IdentityResult Status, Domain.Models.CompanyUser User) registrationResult = await companyUserRepository!.CreateStaffWithoutPasswordAsync(staffModel);

                    if (registrationResult.Status.Succeeded)
                    {
                        //Save claims
                        var claims = new List<Claim>
                                        {
                                            new Claim(ClaimTypes.NameIdentifier,registrationResult.User.Id),
                                            new Claim(ClaimTypes.Email,registrationResult.User.Email!),
                                            new Claim(ClaimTypes.GivenName,item.FirstName!),
                                            new Claim(ClaimTypes.Surname,item.LastName!),
                                            new Claim("companyid",item.CompanyId.ToString())
                                        };

                        if (!string.IsNullOrEmpty(item.PhoneNumber))
                            new Claim(ClaimTypes.MobilePhone, item.PhoneNumber!);

                        _ = await companyUserRepository.AddUserClaimsAsync(registrationResult.User, claims);

                        //send email
                        var token = await companyUserRepository.GeneratePasswordResetTokenAsync(item.EmailAddress, cancellationToken);

                        var baseUrl = configuration!["FrontendBaseUrl"]!;

                        await companyUserRepository.SendStaffOnboardingLinkAsync(baseUrl, item.EmailAddress, token.Item2, cancellationToken);
                    }
                    else
                    {
                        foreach (var error in registrationResult.Status.Errors)
                        {
                            _errors.Add(error);
                        }
                    }

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "");
                }
            }
        
        
            if(_errors.Count > 0)
            {
                var errors = new List<ValidationFailure>();
                foreach (var error in _errors)
                {
                    errors.Add(new ValidationFailure(error.Code, error.Description));
                }

                throw new FluentValidation.ValidationException(errors);
            }
        }
    }
}
