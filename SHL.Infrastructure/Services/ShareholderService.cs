using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Application.Utils.DTO;
using SHL.Application.DTO.ShareHoder;
using SHL.Application.IServices;
using SHL.Application.Repositories;

namespace SHL.Infrastructure.Services
{
    public class ShareholderService:IShareholderService
    {
        private readonly IShareholderRepository _repository;

        public ShareholderService(IShareholderRepository repository)
        {
            _repository = repository;
        }

        public VerifyInviteDTO GetShareholder(string email, long companyId)
        {
            return _repository.FetchShareholder(email, companyId);
        }

        public VerifyInviteDTO GetShareholderByPhoneNo(string phoneNo, long companyId)
        {
            return _repository.FetchShareholderByPhoneNo(phoneNo, companyId);
        }

        public List<VerifyInviteDTO> GetShareholders(List<string> emails)
        {
            return _repository.FetchShareholders(emails);
        }

        public ShareholderUpdateFormDto GetShareholderInfo(string email)
        {
            return _repository.FetchShareholderInfo(email);
        }

        public ShareholderProfileDTO GetShareholderProfile(string email)
        {
            return _repository.FetchShareholderProfile(email);
        }

        public List<SharesDTO> GetMyShares(string email)
        {
            return _repository.FetchMyShares(email);
        }
    }

}
