using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Core.Domain;
using EmpleoDotNet.Data;
using EmpleoDotNet.Filters;
using EmpleoDotNet.Helpers.Alerts;
using EmpleoDotNet.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.ViewModel.Account;

namespace EmpleoDotNet.Controllers
{
    /// <summary>
    /// Este es el controlador de cuentas de usuario
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserProfileService _userProfileService;

        public AccountController(IAuthenticationService authenticationService, IUserProfileService userProfileService, UserManager<IdentityUser> userManager)
        {
            _authenticationService = authenticationService;
            _userProfileService = userProfileService;
            UserManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var result = await AuthenticationManager.AuthenticateAsync(DefaultAuthenticationTypes.ExternalCookie).ConfigureAwait(false);
            if (result == null || result.Identity == null)
            {
                return RedirectToAction("Login");
            }

            var idClaim = result.Identity.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim == null)
            {
                return RedirectToAction("Login");
            }

            var login = new UserLoginInfo(idClaim.Issuer, idClaim.Value);

            // Si el usuario ya tiene una cuenta, autenticarlo con su cuenta de red social
            var user = await UserManager.FindAsync(login).ConfigureAwait(false);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // Si el usuario no tiene una cuenta se le crea y se le invita a compeltar su perfil, redireccionandolo 
                //a la pantalla de profile
                try
                {
                    user = _authenticationService.CreateUserWithSocialProvider(login, result.Identity);
                    await SignInAsync(user, isPersistent: false).ConfigureAwait(false);

                    return RedirectToAction("Profile", new { returnUrl });
                }
                catch (Exception ex)
                {
                    Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                    throw;
                }
            }
        }
   
        //
        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(IdentityUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).ConfigureAwait(false);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        public ActionResult Profile()
        {
            var user = _userProfileService.GetByUserId(this.User.Identity.GetUserId());

            var viewModel = UserProfileViewModel.FromModel(user);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CompleteProfile(UserProfileType userProfileType)
        {
            var userProfile = _userProfileService.GetByUserId(User.Identity.GetUserId());

            if (userProfile.IsProfileCompleted) return RedirectToAction(nameof(Profile));

            if (userProfileType == UserProfileType.Company)
            {
                userProfile.UserProfileType = userProfileType;

                _userProfileService.Update(userProfile);

                return RedirectToAction(nameof(Personalize));
            }

            _userProfileService.CompleteProfile(userProfile, userProfileType);

            return RedirectToAction(nameof(Profile));
        }

        [CompanyUser(RequiresUserProfileComplete = false)]
        public ActionResult Personalize()
        {
            var userProfile = _userProfileService.GetByUserId(User.Identity.GetUserId());

            var company = userProfile.Companies.FirstOrDefault() ?? new Company();

            var viewModel = new PersonalizeCompanyInfoViewModel
            {
                UserProfileId = userProfile.Id,
                Id = company.Id,
                CompanyName = company.CompanyName,
                CompanyUrl = company.CompanyUrl,
                CompanyEmail = company.CompanyEmail,
                CompanyLogoUrl = company.CompanyLogoUrl,
                CompanyDescription = company.CompanyDescription,
                CompanyPhone = company.CompanyPhone,
                CompanyVideoUrl = company.CompanyVideoUrl,
                FacebookProfile = company.FacebookProfile,
                TwitterProfile = company.TwitterProfile,
                InstagramProfile = company.InstagramProfile,
                LinkedInProfile = company.LinkedInProfile,
                YoutubeProfile = company.YoutubeProfile
            };

            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [CompanyUser(RequiresUserProfileComplete = false)]
        public ActionResult Personalize(PersonalizeCompanyInfoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model)
                    .WithError("Han ocurrido errores de validación que no permiten continuar el proceso");

            var userProfile = _userProfileService.GetByUserId(User.Identity.GetUserId());
            
            userProfile.Companies.Add(model.ToEntity());

            _userProfileService.CompleteProfile(userProfile, UserProfileType.Company);

            return RedirectToAction(nameof(Profile));
        }
    }
}