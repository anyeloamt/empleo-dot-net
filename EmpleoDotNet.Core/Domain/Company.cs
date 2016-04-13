using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Core.Domain
{
    public class Company : EntityBase
    {
        public string CompanyName { get; set; }

        public string CompanyUrl { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyLogoUrl { get; set; }

        public int? UserProfileId { get; set; }

        #region Navigation properties

        public List<JobOpportunity> JobOpportunities { get; set; }

        public UserProfile UserProfile { get; set; }

        #endregion
    }
}
