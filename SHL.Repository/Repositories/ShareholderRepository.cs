using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSL.Application.Utils.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SHL.Application.DTO.ShareHoder;
using SHL.Application.Repositories;

namespace SHL.Repository.Repositories
{

    public class ShareholderRepository : IShareholderRepository
    {
        private readonly EstockDbContext _context;
        private readonly ILogger<ShareholderRepository> logger;

        public ShareholderRepository(EstockDbContext context,
            ILogger<ShareholderRepository> logger)
        {
            _context = context;
            this.logger = logger;
        }

        public VerifyInviteDTO FetchShareholder(string email, long companyId)
        {
            if (string.IsNullOrEmpty(email)) return null;

            var result = (from s in _context.VwShareHolders
                          from r in _context.vwT_reg.Where(x => x.regcode == s.regcode).DefaultIfEmpty()
                          from c in _context.vwT_reg_name.Where(x => x.coy_no == r.coy_no).DefaultIfEmpty()
                          where (c.coy_no == companyId || companyId == 0) && s.email == email
                          select new VerifyInviteDTO
                          {
                              CompanyId = r.coy_no.GetValueOrDefault(),
                              acctno = s.Acctno,
                              FirstName = s.first_nm,
                              LastName = s.last_nm,
                              OtherName = s.middle_nm,
                              EmailTo = s.email,
                              BVN = s.bvn,
                              Holder_type = s.typer,
                              Phone_no = s.phone,
                              Email_Verified = s.email_verif.GetValueOrDefault()
                          }).FirstOrDefault();

            return result;
        }
        public VerifyInviteDTO FetchShareholderByPhoneNo(string phoneNo, long companyId)
        {
            if (string.IsNullOrEmpty(phoneNo)) return null;

            var usr = (from s in _context.VwShareHolders
                       from r in _context.vwT_reg.Where(x => x.regcode == s.regcode).DefaultIfEmpty()
                       from c in _context.vwT_reg_name.Where(x => x.coy_no == r.coy_no).DefaultIfEmpty()
                       where (c.coy_no == companyId || companyId == 0) && (s.phone == phoneNo || s.mobile == phoneNo)
                       select new VerifyInviteDTO
                       {
                           CompanyId = r.coy_no.GetValueOrDefault(),
                           acctno = s.Acctno,
                           FirstName = s.first_nm,
                           LastName = s.last_nm,
                           OtherName = s.middle_nm,
                           EmailTo = s.email,
                           BVN = s.bvn,
                           Holder_type = s.typer,
                           Phone_no = s.phone,
                           Email_Verified = s.email_verif.GetValueOrDefault()
                       }).FirstOrDefault();

            return usr;
        }

        public List<VerifyInviteDTO> FetchShareholders(List<string> emails)
        {
            try
            {
                if (!emails.Any()) return null;

                var users = (from s in _context.VwShareHolders
                             from r in _context.vwT_reg.Where(x => x.regcode == s.regcode).DefaultIfEmpty()
                             from c in _context.vwT_reg_name.Where(x => x.coy_no == r.coy_no).DefaultIfEmpty()
                             where emails.Any(e => e == s.email)
                             select new VerifyInviteDTO
                             {
                                 CompanyId = r.coy_no.GetValueOrDefault(),
                                 acctno = s.Acctno,
                                 FirstName = s.first_nm,
                                 LastName = s.last_nm,
                                 OtherName = s.middle_nm,
                                 EmailTo = s.email,
                                 BVN = s.bvn,
                                 Holder_type = s.typer,
                                 Phone_no = s.phone,
                                 Email_Verified = s.email_verif.GetValueOrDefault()
                             }).OrderBy(x => Guid.NewGuid()).AsEnumerable().DistinctBy(x => x.EmailTo.ToLower()).ToList();

                return users;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in FetchShareholders for Emails: {Emails}", string.Join(", ", emails));
                return null;
            }
        }

        public ShareholderUpdateFormDto FetchShareholderInfo(string email)
        {
            var result = new ShareholderUpdateFormDto();
            try
            {
                if (string.IsNullOrEmpty(email)) return result;

                result = (from s in _context.VwShareHolders
                          where s.email == email && !string.IsNullOrWhiteSpace(s.email)
                          select new ShareholderUpdateFormDto
                          {
                              FirstName = s.first_nm,
                              LastName = s.last_nm,
                              Email = s.email,
                              Sex = s.sex,
                              dob = s.dob == null ? DateTime.Now : s.dob.GetValueOrDefault(),
                              bvn = s.bvn,
                              Phone_no = s.mobile,
                              next_of_kin = s.nextofkin
                          }).OrderBy(x => Guid.NewGuid()).DistinctBy(x => x.Email.ToLower()).FirstOrDefault();

                return result ?? new ShareholderUpdateFormDto();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in FetchShareholderInfo for Email: {Email}", email);
                return result;
            }
        }

        public ShareholderProfileDTO FetchShareholderProfile(string email)
        {
            var result = new ShareholderProfileDTO();
            try
            {
                if (string.IsNullOrEmpty(email)) return result;

                result = (from s in _context.VwShareHolders
                          join r in _context.vwT_reg on s.regcode.GetValueOrDefault() equals r.regcode
                          join c in _context.vwT_reg_name on r.coy_no equals c.coy_no
                          where s.email == email && !string.IsNullOrWhiteSpace(s.email)
                          select new ShareholderProfileDTO
                          {
                              FirstName = s.first_nm,
                              LastName = s.last_nm,
                              MiddleName = s.middle_nm,
                              Email = s.email,
                              Gender = s.sex == "M" ? "Male" : "Female",
                              DateOfBirth = s.dob.GetValueOrDefault().ToString("dd-MM-yyyy"),
                              Address = s.addr1,
                              BVN = s.bvn,
                              NIN = "",
                              PhoneNumber = s.mobile,
                              SharesData = FetchMyShares(email)
                          }).OrderBy(x => Guid.NewGuid()).DistinctBy(x => x.Email.ToLower()).FirstOrDefault();

                return result ?? new ShareholderProfileDTO();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in FetchShareholderProfile for Email: {Email}", email);
                return result;
            }
        }

        public List<SharesDTO> FetchMyShares(string email)
        {
            var result = new List<SharesDTO>();
            try
            {
                if (string.IsNullOrEmpty(email)) return result;

                result = (from sh in _context.VwShareHolders
                          join reg in _context.vwT_reg on sh.regcode.GetValueOrDefault() equals reg.regcode
                          join reg_name in _context.vwT_reg_name on reg.coy_no equals reg_name.coy_no
                          where sh.email == email
                          select new SharesDTO
                          {
                              CompanyName = reg_name.coy_name,
                              TotalShares = (from a in _context.VwTUnitsses
                                             join s in _context.VwShareHolders on a.regcode equals s.regcode
                                             join r in _context.vwT_reg on s.regcode.GetValueOrDefault() equals r.regcode
                                             where s.email == email && a.acctno == s.Acctno && r.coy_no == reg_name.coy_no
                                             select Convert.ToDecimal(a.units)).Sum()
                          }).AsEnumerable().DistinctBy(x => x.CompanyName.ToLower()).ToList();

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in FetchMyShares for Email: {Email}", email);
                return result;
            }
        }
    }

}
