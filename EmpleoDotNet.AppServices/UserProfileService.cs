using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Repository.Contracts;

namespace EmpleoDotNet.AppServices
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public UserProfile GetByUserId(string userId)
        {
            return _userProfileRepository.GetByUserId(userId);
        }

        public void CompleteProfile(UserProfile model, UserProfileType userProfileType)
        {
            model.UserProfileType = userProfileType;

            model.IsProfileCompleted = true;

            Update(model);
        }

        public void Update(UserProfile model)
        {
            _userProfileRepository.Update(model);

            _userProfileRepository.SaveChanges();
        }
    }
}
