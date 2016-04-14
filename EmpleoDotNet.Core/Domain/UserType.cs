using System.ComponentModel.DataAnnotations;

namespace EmpleoDotNet.Core.Domain
{
    public enum UserType
    {
        [Display(Name = "Empresa")]
        Company,

        [Display(Name = "Candidato")]
        Applicant
    }
}