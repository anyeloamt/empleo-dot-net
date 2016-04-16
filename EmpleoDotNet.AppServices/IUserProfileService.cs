using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.AppServices
{
    public interface IUserProfileService
    {
        UserProfile GetByUserId(string userId);

        void CompleteProfile(UserProfile model, UserProfileType userProfileType);

        void Update(UserProfile userProfile);
    }
}