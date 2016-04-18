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
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(EmpleadoContext context) : base(context)
        {
        }

        public UserProfile GetByUserId(string userId)
        {
            return DbSet
                .Include(x => x.Companies.Select(c => c.JobOpportunities.Select(s => s.JobOpportunityLikes)))
                .Include(x => x.Companies.Select(c => c.JobOpportunities.Select(s => s.JobOpportunityLocation)))
                .FirstOrDefault(x => x.UserId == userId);
        }

        public void Update(UserProfile userProfile)
        {
            Context.Entry(userProfile).State = EntityState.Modified;
        }
    }
}
