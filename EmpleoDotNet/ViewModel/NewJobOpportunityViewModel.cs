using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.ViewModel
{
    /// <summary>
    /// ViewModel para crear una vacante nueva
    /// </summary>
    public class NewJobOpportunityViewModel
    {
        [Required(ErrorMessage = "El campo titulo es requerido."), StringLength(int.MaxValue)]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La localidad es requerida")]
        public int SelectedLocationId { get; set; }

        public SelectList Locations { get; set; }

        [Required(ErrorMessage = "Debe elegir una categoria.")]
        [Display(Name = "Categoria")]
        public JobCategory Category { get; set; }

        [Required(ErrorMessage = "Debe especificar al menos un requisito."), StringLength(int.MaxValue)]
        [Display(Name = "Requisitos para aplicar")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo como aplicar es requerido"), StringLength(int.MaxValue)]
        [Display(Name = "Cómo Aplicar")]
        public string HowToApply { get; set; }

        public bool IsRemote { get; set; }

        [Required(ErrorMessage = "La Localidad es Requerida")]
        public string LocationName { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationPlaceId { get; set; }

        [Display(Name = "Tipo")]
        public JobType JobType { get; set; }

        public Core.Domain.JobOpportunity ToEntity()
            => new Core.Domain.JobOpportunity
            {
                Title = Title,
                Category = Category,
                Description = Description,
                PublishedDate = DateTime.Now,
                IsRemote = IsRemote,
                JobType = JobType,
                HowToApply = HowToApply,
                JobOpportunityLocation = new JobOpportunityLocation
                {
                    Latitude = LocationLatitude,
                    Longitude = LocationLongitude,
                    Name = LocationName,
                    PlaceId = LocationPlaceId
                }
            };
    }
}