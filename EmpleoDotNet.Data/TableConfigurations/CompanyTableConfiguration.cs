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
            Property(x => x.CompanyPhone).IsOptional().HasMaxLength(60);
            Property(x => x.UserProfileId).IsOptional();
        }
    }
}
