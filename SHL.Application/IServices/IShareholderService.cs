using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Application.Utils.DTO;
using SHL.Application.DTO.ShareHoder;

namespace SHL.Application.IServices
{
    public interface IShareholderService
    {
        VerifyInviteDTO GetShareholder(string email, long companyId);
        VerifyInviteDTO GetShareholderByPhoneNo(string phoneNo, long companyId);
        List<VerifyInviteDTO> GetShareholders(List<string> emails);
        ShareholderUpdateFormDto GetShareholderInfo(string email);
        ShareholderProfileDTO GetShareholderProfile(string email);
        List<SharesDTO> GetMyShares(string email);
    }

}
