using AutoMapper;
using SHL.Application.DTO.Company.Request;
using SHL.Application.DTO.Company.Response;

namespace SHL.Application.MappingProfiles
{
    public class SHLMappingProfile : Profile
    {
        public SHLMappingProfile()
        {
            //Portfolio
            CreateMap<CreatePortfolioDto, Domain.Models.Portfolio>();
            CreateMap<UpdatePortfolioDto, Domain.Models.Portfolio>();
            CreateMap<ReadPortfolioDto, Domain.Models.Portfolio>().ReverseMap();

            //COMPANY
            CreateMap<CreateCompanyDto, Domain.Models.Company>();
            CreateMap<UpdateCompanyDto, Domain.Models.Company>();
            CreateMap<ReadCompanyDto, Domain.Models.Company>().ReverseMap();

            //OptionPoolHolder
            CreateMap<CreateOptionHolderDto, Domain.Models.OptionHolder>();
            CreateMap<UpdateOptionHolderDto, Domain.Models.OptionHolder>();
            CreateMap<ReadOptionHolderDto, Domain.Models.OptionHolder>().ReverseMap();

            //Contact
            CreateMap<CreateContactDto, Domain.Models.Contact>();
            CreateMap<UpdateContactDto, Domain.Models.Contact>();
            CreateMap<ReadContactDto, Domain.Models.Contact>().ReverseMap();

            //STAFF
            CreateMap<CreateStaffDto, Domain.Models.Staff>();
            CreateMap<UpdateStaffDto, Domain.Models.Staff>();
            CreateMap<ReadStaffDto, Domain.Models.Staff>().ReverseMap();

            //OptionPool
            CreateMap<CreateOptionPoolDto, Domain.Models.OptionPool>();
            CreateMap<UpdateOptionPoolDto, Domain.Models.OptionPool>();
            CreateMap<ReadOptionPoolDto, Domain.Models.OptionPool>().ReverseMap();

          
            //Subscription
            CreateMap<CreateSubscriptionDto, Domain.Models.Subscription>();
            CreateMap<UpdateSubscriptionDto, Domain.Models.Subscription>();
            CreateMap<ReadSubscriptionDto, Domain.Models.Subscription>().ReverseMap();

            //OptionHolderSignature
            CreateMap<CreateOptionHolderSignatureDto, Domain.Models.OptionHolderSignature>();
            CreateMap<UpdateOptionHolderSignatureDto, Domain.Models.OptionHolderSignature>();
            CreateMap<ReadOptionHolderSignatureDto, Domain.Models.OptionHolderSignature>().ReverseMap();

            //Invitation
            CreateMap<CreateInvitationDto, Domain.Models.Invitation>();
            CreateMap<UpdateInvitationDto, Domain.Models.Invitation>();
            CreateMap<ReadInvitationDto, Domain.Models.Invitation>().ReverseMap();

            //Grant
            CreateMap<CreateGrantDto, Domain.Models.Grant>();
            CreateMap<UpdateGrantDto, Domain.Models.Grant>();
            CreateMap<ReadGrantDto, Domain.Models.Grant>().ReverseMap();

            //OptionPoolApproval
            CreateMap<CreateOptionPoolApprovalDto, Domain.Models.OptionPoolApproval>();
            CreateMap<UpdateOptionPoolApprovalDto, Domain.Models.OptionPoolApproval>();
            CreateMap<ReadOptionPoolApprovalDto, Domain.Models.OptionPoolApproval>().ReverseMap();

            //Token
            CreateMap<CreateTokenDto, Domain.Models.Token>();
            CreateMap<UpdateTokenDto, Domain.Models.Token>();
            CreateMap<ReadTokenDto, Domain.Models.Token>().ReverseMap();
     
            //UploadedDocument
            CreateMap<CreateUploadedDocumentDto, Domain.Models.UploadedDocument>();
            CreateMap<UpdateUploadedDocumentDto, Domain.Models.UploadedDocument>();
            CreateMap<ReadUploadedDocumentDto, Domain.Models.UploadedDocument>().ReverseMap();

            //PayoutAccount
            CreateMap<CreatePayoutAccountDto, Domain.Models.PayoutAccount>();
            CreateMap<UpdatePayoutAccountDto, Domain.Models.PayoutAccount>();
            CreateMap<ReadPayoutAccountDto, Domain.Models.PayoutAccount>().ReverseMap();

            //EmploymentDetail
            CreateMap<CreateEmploymentDetailDto, Domain.Models.EmploymentDetail>();
            CreateMap<UpdateEmploymentDetailDto, Domain.Models.EmploymentDetail>();
            CreateMap<ReadEmploymentDetailDto, Domain.Models.EmploymentDetail>().ReverseMap();

            //OptionPool
            CreateMap<CreateOptionPoolDto, Domain.Models.OptionPool>();
            CreateMap<UpdateOptionPoolDto, Domain.Models.OptionPool>();
            CreateMap<ReadOptionPoolDto, Domain.Models.OptionPool>().ReverseMap();

            //Grant
            CreateMap<CreateGrantDto, Domain.Models.Grant>();
            CreateMap<UpdateGrantDto, Domain.Models.Grant>();
            CreateMap<ReadGrantDto, Domain.Models.Grant>().ReverseMap(); 

            //VestingSchedule
            CreateMap<CreateVestingScheduleDto, Domain.Models.VestingSchedule>();
            CreateMap<UpdateVestingScheduleDto, Domain.Models.VestingSchedule>();
            CreateMap<ReadVestingScheduleDto, Domain.Models.VestingSchedule>().ReverseMap(); 

            //VestingSchedule
            CreateMap<CreateSurveyDto, Domain.Models.Survey>();
            CreateMap<UpdateSurveyDto, Domain.Models.Survey>();
            CreateMap<ReadSurveyDto, Domain.Models.Survey>().ReverseMap(); 
            
            //PoolDocument
            CreateMap<CreatePoolDocumentDto, Domain.Models.PoolDocument>();
            CreateMap<UpdatePoolDocumentDto, Domain.Models.PoolDocument>();
            CreateMap<ReadPoolDocumentDto, Domain.Models.PoolDocument>().ReverseMap();
            
            //Shareholder
            CreateMap<CreateShareholderDto, Domain.Models.Shareholder>();
            CreateMap<UpdateShareholderDto, Domain.Models.Shareholder>();
            CreateMap<ReadShareholderDto, Domain.Models.Shareholder>().ReverseMap();
        }
    }
}