using HCL.UBP.WebUI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HCL.UBP.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly HCL.UBP.DataAccess.Interface.IUserRepository _userRepository;
        public AccountController(HCL.UBP.DataAccess.Interface.IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string encryptPassword = EncryptSource(model.Password);
            var result = _userRepository.GetUsers().Where(u => u.Username.Equals(model.Username) && u.Password.Equals(encryptPassword)).FirstOrDefault();
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.Username, false);
                var authTicket = new FormsAuthenticationTicket(1, result.Username, DateTime.Now, DateTime.Now.AddMinutes(30), false, "User");
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                //Redirect
                if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.IsSuccess = false;
            return View("Register");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            ViewBag.IsSuccess = false;
            if (ModelState.IsValid)
            {
                var hasRows = _userRepository.GetUsers().Where(u => u.Username.Equals(model.Username.Trim())).Count();
                if (hasRows == 0)
                {
                    string encryptPassword = EncryptSource(model.Password.Trim());
                    var isSuccess = _userRepository.CreateUser(new DataAccess.Model.UserDetails
                    {
                        Id = 0,
                        Username = model.Username.Trim(),
                        Password = encryptPassword,
                        CreationTime = DateTime.Now
                    });
                    ViewBag.IsSuccess = true;
                }
                else
                {
                    //Username already exists
                    ModelState.AddModelError("Username", "This username is already taken");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #region "NonAction"
        [NonAction]
        private string EncryptSource(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text.Trim());
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
        #endregion
    }
}