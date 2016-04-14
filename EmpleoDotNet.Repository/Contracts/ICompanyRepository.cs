using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.Repository.Contracts
{
    public interface ICompanyRepository
    {
        Company GetCompanyByUserId(string userId);
    }
}