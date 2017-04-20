using AppliFrais.EntityFramework.Models;
using AppliFrais.Models;
using AppliFrais.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AppliFrais.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _IUserService;

        public AuthenticationController(IUserService iUserService)
        {
            _IUserService = iUserService;
        }

        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = _IUserService.GetUser(model.Login, model.Password);

            if (!ValidateUser(user))
            {
                ModelState.AddModelError(string.Empty, "Le nom d'utilisateur ou le mot de passe est incorrect.");
                return View(model);
            }
           
            var loginClaim = new Claim(ClaimTypes.NameIdentifier, model.Login);
            var claimsIdentity = new ClaimsIdentity(new[] { loginClaim }, DefaultAuthenticationTypes.ApplicationCookie);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Metier));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.Id.ToString()));
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(claimsIdentity);
            
            return RedirectToAction("Index", user.Metier );
        }

        private bool ValidateUser(User user)
        {
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut();
            
            return RedirectToAction("Index", "Home");
        }
    }
}