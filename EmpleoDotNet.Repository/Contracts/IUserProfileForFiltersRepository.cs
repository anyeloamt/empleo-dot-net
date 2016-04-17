using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Repository.Contracts
{
    public interface IUserProfileForFiltersRepository
    {
        UserProfile GetByUserId(string userId);
    }
}
