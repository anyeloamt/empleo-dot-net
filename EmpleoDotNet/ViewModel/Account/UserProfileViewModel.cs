using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.ViewModel.Account
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Correo")]
        public string Email { get; set; }

        public bool IsProfileCompleted { get; set; }

        public UserProfileType UserProfileType { get; set; }

        [Display(Name = "Compañía")]
        public string CompanyName { get; set; }

        [Display(Name = "Sitio Web")]
        public string CompanyUrl { get; set; }

        [Display(Name = "Correo electrónico"),]
        public string CompanyEmail { get; set; }

        [Display(Name = "Logo")]
        public string CompanyLogoUrl { get; set; }

        [Display(Name = "Descripción")]
        public string CompanyDescription { get; set; }

        [Display(Name = "Teléfono")]
        public string CompanyPhone { get; set; }

        [Display(Name = "Video")]
        public string CompanyVideoUrl { get; set; }

        #region Social

        [Display(Name = "Perfil de Facebook")]
        public string FacebookProfile { get; set; }

        [Display(Name = "Perfil de Twitter")]
        public string TwitterProfile { get; set; }

        [Display(Name = "Perfil de LinkedIn")]
        public string LinkedInProfile { get; set; }

        [Display(Name = "Perfil de Instagram")]
        public string InstagramProfile { get; set; }

        [Display(Name = "Perfil de Youtube")]
        public string YoutubeProfile { get; set; }

        public List<Core.Domain.JobOpportunity> JobOpportunities { get; set; }

        #endregion

        public static UserProfileViewModel FromModel(UserProfile user)
        {
            if (user.UserProfileType == UserProfileType.Company)
            {
                var company = user.Companies.FirstOrDefault() ?? new Company();

                return new UserProfileViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    UserId = user.UserId,
                    UserProfileType = user.UserProfileType,
                    IsProfileCompleted = user.IsProfileCompleted,

                    CompanyLogoUrl = company.CompanyLogoUrl,
                    CompanyEmail = company.CompanyEmail,
                    CompanyName = company.CompanyName,
                    CompanyDescription = company.CompanyDescription,
                    CompanyPhone = company.CompanyPhone,
                    CompanyUrl = company.CompanyUrl,
                    CompanyVideoUrl = company.CompanyVideoUrl,

                    LinkedInProfile = company.LinkedInProfile,
                    FacebookProfile = company.FacebookProfile,
                    InstagramProfile = company.InstagramProfile,
                    TwitterProfile = company.TwitterProfile,
                    YoutubeProfile = company.YoutubeProfile,
                    JobOpportunities = company.JobOpportunities
                };
            }

            return new UserProfileViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserId = user.UserId,
                UserProfileType = user.UserProfileType,
                IsProfileCompleted = user.IsProfileCompleted
            };
        }
    }
}