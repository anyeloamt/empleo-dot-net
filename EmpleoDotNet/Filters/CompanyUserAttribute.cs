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

        public bool RequiresUserProfileComplete { get; set; } = true;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var identity = filterContext.RequestContext.HttpContext.User.Identity;

            if (!identity.IsAuthenticated)
            {
                Redirect(filterContext, action: "Login");

                return;
            }

            var userProfile = UserProfileRepository.GetByUserId(identity.GetUserId());

            if (userProfile.UserProfileType != UserProfileType.Company)
            {
                Redirect(filterContext);

                return;
            }

            if (!RequiresUserProfileComplete) return;

            if (!userProfile.IsProfileCompleted) Redirect(filterContext);
        }

        private static void Redirect(ActionExecutingContext filterContext, string controller = "Account", string action = "Profile")
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new { controller, action, returnUrl = filterContext.HttpContext.Request.Path }));
        }
    }
}