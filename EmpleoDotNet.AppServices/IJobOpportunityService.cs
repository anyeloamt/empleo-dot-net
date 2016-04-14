using System.Collections.Generic;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Core.Dto;
using PagedList;

namespace EmpleoDotNet.AppServices
{
    public interface IJobOpportunityService
    {
        void CreateNewJobOpportunity(JobOpportunity jobOpportunity, string userId);
        List<JobOpportunity> GetCompanyRelatedJobs(int id, int companyId);
        IPagedList<JobOpportunity> GetAllJobOpportunitiesPagedByFilters(JobOpportunityPagingParameter parameter);
        JobOpportunity GetJobOpportunityById(int? id);
        void UpdateViewCount(int id);
        List<JobCategoryCountDto> GetMainJobCategoriesCount();
    }
}