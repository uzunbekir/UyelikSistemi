using Deneme1MVC.Identity;
using Deneme1MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Deneme1MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;



        public AccountController()

        {

            OkulContext db = new OkulContext();



            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);

            userManager = new UserManager<ApplicationUser>(userStore);



            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);

            roleManager = new RoleManager<ApplicationRole>(roleStore);

        }
        #region üye ol
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)

            {

                ApplicationUser user = new ApplicationUser();

                user.Name = model.Ad;

                user.Surname = model.Soyad;

                user.Email = model.Email;

                user.UserName = model.Username;

                IdentityResult iResult = userManager.Create(user, model.Password);

                if (iResult.Succeeded)

                {

                    // User isminde bir Role ataması yapacağız. Bu rolü ilerleyen kısımda oluşturacağız

                    userManager.AddToRole(user.Id, "User");

                    return RedirectToAction("Login", "Account");

                }

                else
                {

                    ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");

                }

            }

            return View(model);
        }
        #endregion
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)

            {

                ApplicationUser user = userManager.Find(model.Username, model.Password);




                if (user != null)

                {

                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;

                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");

                    AuthenticationProperties authProps = new AuthenticationProperties();

                    authProps.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProps, identity);

                    return RedirectToAction("Index", "Home");

                }

                else

                {

                    ModelState.AddModelError("LoginUser", "Böyle bir kullanıcı bulunamadı");

                }

            }

            return View(model);
        }
        #endregion
        #region Logout
        [Authorize]

        public ActionResult Logout()

        {

            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;

            authManager.SignOut();

            return RedirectToAction("Login", "Account");

        }
        #endregion
    }
}