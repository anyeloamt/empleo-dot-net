using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Data.TableConfigurations
{
    public class CompanyTableConfiguration : TableConfiguration<Company>
    {
        public CompanyTableConfiguration()
        {
            Property(x => x.CompanyName).HasMaxLength(150).IsRequired();
            Property(x => x.CompanyEmail).IsRequired();
            Property(x => x.CompanyLogoUrl).IsOptional();
            Property(x => x.CompanyUrl).IsOptional();
            Property(x => x.CompanyPhone).IsOptional().HasMaxLength(60);
            Property(x => x.CompanyDescription).IsOptional().HasMaxLength(int.MaxValue);
            Property(x => x.CompanyVideoUrl).IsOptional();
            Property(x => x.FacebookProfile).IsOptional();
            Property(x => x.TwitterProfile).IsOptional();
            Property(x => x.InstagramProfile).IsOptional();
            Property(x => x.YoutubeProfile).IsOptional();
            Property(x => x.UserProfileId).IsRequired();

            // Configure one to one relationship
            HasRequired(x => x.UserProfile).WithOptional(x => x.Company);
        }
    }
}
