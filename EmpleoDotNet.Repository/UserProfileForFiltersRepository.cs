using System;
using System.Data.Entity;
using System.Linq;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.Repository
{
    public class UserProfileForFiltersRepository : IUserProfileForFiltersRepository
    {
        protected DbSet<UserProfile> DbSet;

        public UserProfileForFiltersRepository(EmpleadoForFilterContext context)
        {
            DbSet = context.UserProfile;
        }

        public UserProfile GetByUserId(string userId)
        {
            return DbSet
                .Include(x => x.Companies.Select(c => c.JobOpportunities.Select(s => s.JobOpportunityLikes)))
                .FirstOrDefault(x => x.UserId == userId);
        }
    }
}