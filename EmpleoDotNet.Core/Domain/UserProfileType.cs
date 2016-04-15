using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Core.Domain
{
    public enum UserProfileType
    {
        [Display(Name = "Empresa")]
        Company,

        [Display(Name = "Candidato")]
        Applicant
    }
}