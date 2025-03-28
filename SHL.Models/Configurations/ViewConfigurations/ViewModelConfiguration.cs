using System;
using System.Collections.Generic;
using System.Text;
using CSL.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSL.Models.Configurations.ViewConfigurations
{

    public class ViewTPriceConfiguration : IEntityTypeConfiguration<vwTprice>
    {
        public void Configure(EntityTypeBuilder<vwTprice> b)
        {
            b.Property(u => u.symbol).IsRequired(false);
            b.Property(u => u.csi).IsRequired(false);
            b.Property(u => u.asset).IsRequired(false);
            b.Property(u => u.nse_symbol).IsRequired(false);
            b.ToTable("vwTprice");
        }
    }

    public class ViewTUnitssConfiguration : IEntityTypeConfiguration<vwT_unitss>
    {
        public void Configure(EntityTypeBuilder<vwT_unitss> b)
        {
            b.Property(u => u.agent).IsRequired(false);
            b.Property(u => u.annotate).IsRequired(false);
            b.Property(u => u.brok_verified).IsRequired(false);
            b.Property(u => u.category_desc).IsRequired(false);
            b.Property(u => u.chg_who).IsRequired(false);
            b.Property(u => u.claimedby).IsRequired(false);
            b.Property(u => u.desc_trans).IsRequired(false);
            b.Property(u => u.xfer_no).IsRequired(false);
            b.Property(u => u.who).IsRequired(false);
            b.Property(u => u.storage_no).IsRequired(false);
            b.Property(u => u.stop_narr).IsRequired(false);
            b.Property(u => u.oldcertnumb).IsRequired(false);
            b.Property(u => u.narr).IsRequired(false);
            b.Property(u => u.main).IsRequired(false);
            b.Property(u => u.groupr).IsRequired(false);
            b.ToTable("vwT_unitss");
        }
    }

    public class ViewShareAccountConfiguration : IEntityTypeConfiguration<vwShareholderAccount>
    {
        public void Configure(EntityTypeBuilder<vwShareholderAccount> b)
        {
            b.Property(u => u.Phone_no).IsRequired(false);
            b.Property(u => u.SecType).IsRequired(false);
            b.Property(u => u.Name).IsRequired(false);
            b.ToTable("vwShareholderAccount");
        }
    }

    //


    public class ViewShareholderConfiguration : IEntityTypeConfiguration<vwShareHolders>
    {
        public void Configure(EntityTypeBuilder<vwShareHolders> b)
        {
            b.Property(u => u.agent).IsRequired(false);
            b.Property(u => u.title).IsRequired(false);
            b.Property(u => u.last_nm).IsRequired(false);
            b.Property(u => u.first_nm).IsRequired(false);
            b.Property(u => u.middle_nm).IsRequired(false);
            b.Property(u => u.sex).IsRequired(false);
            b.Property(u => u.addr1).IsRequired(false);
            b.Property(u => u.addr2).IsRequired(false);
            b.Property(u => u.addr3).IsRequired(false);
            b.Property(u => u.st).IsRequired(false);
            b.Property(u => u.orig_st).IsRequired(false);
            b.Property(u => u.typer).IsRequired(false);
            b.Property(u => u.phone).IsRequired(false);
            b.Property(u => u.fax).IsRequired(false);
            b.Property(u => u.email).IsRequired(false);
            b.Property(u => u.mobile).IsRequired(false);
            b.Property(u => u.who).IsRequired(false);
            b.Property(u => u.narr).IsRequired(false);
            b.Property(u => u.narration1).IsRequired(false);
            b.Property(u => u.chn).IsRequired(false);
            b.Property(u => u.chn_acct).IsRequired(false);
            b.Property(u => u.chn_member).IsRequired(false);
            b.Property(u => u.oldaccountno).IsRequired(false);
            b.Property(u => u.maiden).IsRequired(false);
            b.Property(u => u.mand_acct).IsRequired(false);
            b.Property(u => u.nextofkin).IsRequired(false);
            b.Property(u => u.deceased).IsRequired(false);
            b.Property(u => u.divcard).IsRequired(false);
            b.Property(u => u.curr_code).IsRequired(false);
            b.Property(u => u.e_account_no).IsRequired(false);
            b.Property(u => u.caution_ref).IsRequired(false);
            b.Property(u => u.bighold_branch).IsRequired(false);
            b.ToTable("vwShareHolders");
        }
    }


}
