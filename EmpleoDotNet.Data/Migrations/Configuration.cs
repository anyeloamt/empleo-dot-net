using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using EmpleoDotNet.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EmpleoDotNet.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EmpleadoContext>
    {
        public Configuration()                   
        {
             AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmpleadoContext context)
        {
#if DEBUG
            #region JobOpportunities

            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            var user1 = new IdentityUser("Jimmy");

            manager.Create(user1, "secret");

            var company1 = new Company
            {
                UserProfile = new UserProfile
                {
                    Created = DateTime.Now,
                    Email = "prueba@developers.do",
                    Name = "Developers DO",
                    UserId = user1.Id,
                    UserProfileType = UserProfileType.Company
                },
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                CompanyName = "Developer DO",
                Created = DateTime.Now
            };

            var company2 = new Company
            {
                UserProfile = new UserProfile
                {
                    Created = DateTime.Now,
                    Email = "prueba@developers.do",
                    Name = "Developers DO Santiago",
                    UserId = user1.Id,
                    UserProfileType = UserProfileType.Company
                },
                CompanyEmail = "prueba@developers.do",
                CompanyUrl = "http://www.developers.do",
                CompanyName = "Developer DO Santiago",
                Created = DateTime.Now
            };

            var opportunitiesList = new List<JobOpportunity>
            {
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Pega Blo Senior",
                    Description = "Debe saber programar Java",
                    Created = DateTime.Now.AddDays(-2),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Pega Blo Junior",
                    Description = "Debe saber programar C#",
                    Created = DateTime.Now.AddDays(-3),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.Networking,
                    Title = "Gerente de IT",
                    Description = "Se necesita gerente de IT para multinacional",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.GraphicDesign,
                    Title = "Diseñador Gráfico Web",
                    Description = "Se necesita diseñador que sepa HTML, CSS, Javascript y maneje Bootstrap",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "4 Vacantes, Desarrolladores",
                    Description =
                        "Por este medio les informamos que el Sistema Único de Beneficiarios (SIUBEN) tiene disponible 4 vacantes para el área de Software para trabajar como Desarrolladores, debajo todas las informaciones necesarias para que apliquen:",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Programador IOS",
                    Description =
                        "Buscamos un programador con experiencia demostrable en aplicaciones para móviles (IOS, Android), para desarrollo de un nuevo y ambicioso proyecto.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Programador Android",
                    Description =
                        "Buscamos un programador con experiencia demostrable en aplicaciones para móviles (IOS, Android), para desarrollo de un nuevo y ambicioso proyecto.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador/Desarrollador",
                    Description = "Tecnologo de Software.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador",
                    Description =
                        "Por este medio les informamos que la empresa DATALINK NETWORKS tiene disponible una vacante para el área de Software para trabajar como Programador, debajo colocamos todas las informaciones necesarias para que apliquen:",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programadores y disenadores Junior y Senior",
                    Description =
                        "Estamos buscando programadores y diseñadores. Si manejas una o varias de las siguientes cosas envianos tu cv a empleo@ti.com.do",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Mobile Developer Intern",
                    Description =
                        "We are currently expanding, and are looking to bring on another aspiring compadre (or comadre) to [Megsoft Consulting Inc](http://www.megsoftconsulting.com). We're a company that has been profitable since day 0; we had an amazing year and continue to grow on a steady pace.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Backend python developer",
                    Description =
                        "Here at meSuma we are looking to fill an in-house position for a backend developer. We are looking for someone who can learn quickly, is very skilled and passionate about coding in general. You’d be working with a wide stack of technologies, including but not limited to: python, flask, pyramid, go, grunt, mongodb, postgresql.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Diseñador web Comunimas",
                    Description =
                        "Debe residir en Santo Domingo, R.D. Buena orientación de diseño Capacidad de crear propuestas de diseño para webs nuevas CSS3 HTML5 PHOTOSHOP ILUSTRATOR Responsive web design Manejo de Joomla (creacion de plantillas) Es un plus manejar herramientas de la suite de Adobe CC Y demás cosas como responsable, etc.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador PHP/C#.NET",
                    Description =
                        "Se buscan developers para puesto fijo que dominen bien PHP y MySQL, y algo de C#.NET.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Senior PHP Developer",
                    Description =
                        "Senior developer needed to work in a very agile environment. Requirements: - 3+ years of experience - PHP5 - MySQL - Must be fluent with linux Benefits: - Benefits act - Insurance - Mon-Fri: 9:00AM to 6:00PM, weekend rotation - Salary to be discussed",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.DataBaseAdministrator,
                    Title = "Programador Base de Datos",
                    Description =
                        "Necesito los servicios de alguien que tenga experiencia trabajando con base de datos. Somos una empresa de servicios con una creciente base de cleintes y necesitamos mejor organizar los mismos.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.MobileDevelopment,
                    Title = "Mobile y Web Developers",
                    Description =
                        "Se requieren VARIOS programadores en desarrollo de aplicaciones móviles para (Android, iOS y Windows Phone), para ser contratados Fijos y Freenlance por proyectos.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador web/Python",
                    Description =
                        "Necesito un desarrollador Web que me complete los codigos de una pagina que tengo casi lista. Es muy poco lo que le falta y es algo urgente.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "programador C++ y programador C#",
                    Description = "Conocimeinto en C++, c#, v isual studio. Sera para un empleo temporal de 3 meses.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador SENIOR .NET Indra",
                    Description = "Ingenieros de Sistemas o Tecnologías de la Información (egresados) 5 años o más de experiencia en desarrollo .NET Conocimientos avanzados Java y SQL. Se ofrece contrato indefinido con jornada completa, seguro médico y bonificación. El salario será a convenir según la valía del candidato.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador C ++ y c#",
                    Description =
                        "Buscamos un programador temporero (3 meses). Conocimiento de C++, C# Salario 25 mil Mensual.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador Java",
                    Description =
                        "Se necesitan 10 programadores Java para una empresa cliente. El salario ronda de RD$45,000 a RD$55,000",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company1
                },
                new JobOpportunity
                {
                    Category = JobCategory.WebDevelopment,
                    Title = "Programador web Tamontao",
                    Description = "Programador web en lenguaje asp.net con mucho tiempo libre para trabajar.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                },
                new JobOpportunity
                {
                    Category = JobCategory.SoftwareDevelopment,
                    Title = "Programador VB .net",
                    Description =
                        "• Egresado o Estudiante de una carrera universitaria en el área de Ingeniería de Sistemas o carrera afín.",
                    Created = DateTime.Now.AddDays(-1),
                    PublishedDate = DateTime.Now,
                    Company = company2
                }
            };

            foreach (var jobOpportunity in opportunitiesList)
            {
                context.JobOpportunities.AddOrUpdate(d => d.Title,
                    jobOpportunity);
            }
            #endregion

            #region Tags

            var tagList = new List<Tag>
            {
                new Tag
                {
                    Name = "Web",
                    Created = DateTime.Now
                },
                new Tag
                {

                    Name = "Design",
                    Created = DateTime.Now
                },
                new Tag
                {

                    Name = "Programming",
                    Created = DateTime.Now
                },
            }; 
              
            tagList.ForEach(tags => context.Tags.AddOrUpdate(a=>a.Name, tags));
            #endregion
#endif
        }
    }
}
