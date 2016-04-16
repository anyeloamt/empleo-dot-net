using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.ViewModel.Account
{
    public class PersonalizeCompanyInfoViewModel
    {
        public int Id { get; set; }

        public int UserProfileId { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es requerido."), StringLength(50)]
        [Display(Name = "Nombre")]
        public string CompanyName { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "La dirección Web de la compañia debe ser un Url válido.")]
        [Display(Name = "Sitio Web (opcional)")]
        public string CompanyUrl { get; set; }

        [Required(ErrorMessage = "El campo correo electrónico es requerido"), StringLength(int.MaxValue), EmailAddress(ErrorMessage = "Correo electrónico inválido.")]
        [Display(Name = "Correo electrónico"),]
        public string CompanyEmail { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El logo de la compañía debe ser un Url válido.")]
        [Display(Name = "Logo (opcional)")]
        public string CompanyLogoUrl { get; set; }

        [Display(Name = "Descripción (opcional)")]
        public string CompanyDescription { get; set; }

        [StringLength(int.MaxValue), Phone(ErrorMessage = "El teléfono de la compañía debe ser válido.")]
        [Display(Name = "Teléfono (opcional)")]
        public string CompanyPhone { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El video debe ser un Url válido.")]
        [Display(Name = "Video (opcional)")]
        public string CompanyVideoUrl { get; set; }

        #region Social

        [StringLength(int.MaxValue), Url(ErrorMessage = "El perfil de Facebook debe ser un Url válido.")]
        [Display(Name = "Perfil de Facebook (opcional)")]
        public string FacebookProfile { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El perfil de Tiwtter debe ser un Url válido.")]
        [Display(Name = "Perfil de Tiwtter (opcional)")]
        public string TwitterProfile { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El perfil de LinkedIn debe ser un Url válido.")]
        [Display(Name = "Perfil de LinkedIn (opcional)")]
        public string LinkedInProfile { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El perfil de Instagram debe ser un Url válido.")]
        [Display(Name = "Perfil de Instagram (opcional)")]
        public string InstagramProfile { get; set; }

        [StringLength(int.MaxValue), Url(ErrorMessage = "El perfil de Youtube debe ser un Url válido.")]
        [Display(Name = "Perfil de Youtube (opcional)")]
        public string YoutubeProfile { get; set; }

        #endregion

        public Company ToEntity()
        {
            return new Company
            {
                Id = Id,
                UserProfileId = UserProfileId,
                CompanyName = CompanyName,
                CompanyUrl = CompanyUrl,
                CompanyEmail = CompanyEmail,
                CompanyLogoUrl = CompanyLogoUrl,
                CompanyDescription = CompanyDescription,
                CompanyPhone = CompanyPhone,
                CompanyVideoUrl = CompanyVideoUrl,
                FacebookProfile = FacebookProfile,
                TwitterProfile = TwitterProfile,
                InstagramProfile = InstagramProfile,
                YoutubeProfile = YoutubeProfile,
                LinkedInProfile = LinkedInProfile
            };
        }
    }
}