using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Helpers.Alerts;
using EmpleoDotNet.Repository.Contracts;
using Microsoft.AspNet.Identity;
using Ninject;

namespace EmpleoDotNet.Filters
{
    public class CompanyUserAttribute : ActionFilterAttribute
    {
        [Inject]
        public IUserProfileRepository UserProfileRepository { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var identity = filterContext.RequestContext.HttpContext.User.Identity;

            if (!identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = filterContext.HttpContext.Request.Path }))
                    .WithInfo("Debes iniciar sesión para acceder a esta sección.");

                return;
            }

            var userProfile = UserProfileRepository.GetByUserId(identity.GetUserId());

            if (userProfile.UserType != UserType.Company)
            {
                // TODO: Redirect to page where the user converts its account to company type.
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index", returnUrl = filterContext.HttpContext.Request.Path }))
                    .WithInfo("Sólo las empresas pueden acceder a esta sección, TODO: Complete this message.");
            }
        }
    }
}