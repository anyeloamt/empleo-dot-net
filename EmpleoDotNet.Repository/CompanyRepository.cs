using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Data;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(EmpleadoContext context) : base(context)
        {
        }

        public Company GetCompanyByUserId(string userId)
        {
            return DbSet
                .Include(x => x.UserProfile)
                .FirstOrDefault(x => x.UserProfile.UserId == userId);
        }
    }
}
