using System;
using System.ComponentModel.DataAnnotations;
using EmpleoDotNet.Core.Domain;

namespace EmpleoDotNet.ViewModel.JobOpportunity
{
    public class Wizard
    {
        [Required(ErrorMessage = "El campo título es requerido."), StringLength(int.MaxValue)]
        [Display(Name = "Título. ¿Qué estás buscando?")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La Localidad es requerida")]
        [Display(Name = "Localidad")]
        public string LocationName { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationPlaceId { get; set; }

        [Required(ErrorMessage = "Debes elegir una categoría.")]
        [Display(Name = "Categoría")]
        public JobCategory Category { get; set; }

        [Display(Name = "Tipo")]
        public JobType JobType { get; set; }

        [Required(ErrorMessage = "Debes especificar al menos un requisito."), StringLength(int.MaxValue)]
        [Display(Name = "Requisitos para aplicar")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo como aplicar es requerido"), StringLength(int.MaxValue)]
        [Display(Name = "Cómo Aplicar")]
        public string HowToApply { get; set; }

        [Display(Name= "¿Es un puesto remoto?")]
        public bool IsRemote { get; set; }

        [Display(Name= "¿Usas algún tipo de control de versiones? (Git, Subversion)")]
        public bool HasSourceControl { get; set; }

        [Display(Name= "¿Puedes hacer pases a producción en un solo paso?")]
        public bool HasOneStepBuilds { get; set; }

        [Display(Name = "¿Compilas el producto diariamente?")]
        public bool HasDailyBuilds { get; set; }

        [Display(Name = "¿Tienen una base de datos de bugs?")]
        public bool HasBugDatabase { get; set; }

        [Display(Name = "¿Corriges los bugs antes de añadir más código?")]
        public bool HasBusFixedBeforeProceding { get; set; }

        [Display(Name = "¿Tienes una planificación actualizada?")]
        public bool HasUpToDateSchedule { get; set; }

        [Display(Name = "¿Tienes un documento de especificaciones?")]
        public bool HasSpec { get; set; }

        [Display(Name = "¿Están los programadores en un lugar tranquilo?")]
        public bool HasQuiteEnvironment { get; set; }

        [Display(Name = "¿Utilizas las mejores herramientas que puedes comprar?")]
        public bool HasBestTools { get; set; }

        [Display(Name = "¿Tienes gente para probar los productos?")]
        public bool HasTesters { get; set; }

        [Display(Name = "¿Haces escribir código a los nuevos candidatos en las entrevistas?")]
        public bool HasWrittenTest { get; set; }

        [Display(Name = "¿Haces pruebas de usabilidad 'de vestíbulo'?")]
        public bool HasHallwayTests { get; set; }


        public Core.Domain.JobOpportunity ToEntity()
        {
            var entity = new Core.Domain.JobOpportunity
            {
                Title = Title,
                Category = Category,
                Description = Description,
                PublishedDate = DateTime.Now,
                IsRemote = IsRemote,
                JobType = JobType,
                HowToApply = HowToApply,
                JoelTest = new JoelTest
                {
                    HasSourceControl = this.HasSourceControl,
                    HasOneStepBuilds = this.HasOneStepBuilds,
                    HasDailyBuilds = this.HasDailyBuilds,
                    HasBugDatabase = this.HasBugDatabase,
                    HasBusFixedBeforeProceding = this.HasBusFixedBeforeProceding,
                    HasUpToDateSchedule = this.HasUpToDateSchedule,
                    HasSpec = this.HasSpec,
                    HasQuiteEnvironment = this.HasQuiteEnvironment,
                    HasBestTools = this.HasBestTools,
                    HasTesters = this.HasTesters,
                    HasWrittenTest = this.HasWrittenTest,
                    HasHallwayTests = this.HasHallwayTests
                }
            };

            if (!string.IsNullOrWhiteSpace(LocationName) &&
                !string.IsNullOrWhiteSpace(LocationPlaceId))
            {
                entity.JobOpportunityLocation = new JobOpportunityLocation
                {
                    Latitude = LocationLatitude,
                    Longitude = LocationLongitude,
                    Name = LocationName,
                    PlaceId = LocationPlaceId
                };
            }

            return entity;
        }
    }
}