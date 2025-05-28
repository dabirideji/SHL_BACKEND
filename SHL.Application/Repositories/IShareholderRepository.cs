using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Application.Utils.DTO;
using SHL.Application.DTO.ShareHoder;

namespace SHL.Application.Repositories
{
    public interface IShareholderRepository
    {
        VerifyInviteDTO FetchShareholder(string email, long companyId);
        VerifyInviteDTO FetchShareholderByPhoneNo(string phoneNo, long companyId);
        List<VerifyInviteDTO> FetchShareholders(List<string> emails);
        ShareholderUpdateFormDto FetchShareholderInfo(string email);
        ShareholderProfileDTO FetchShareholderProfile(string email);
        List<SharesDTO> FetchMyShares(string email);
    }
}
