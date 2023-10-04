using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.Web.Controllers
{
    public class AccountController : Controller
    {

        // GET: /Account/Login
        public IActionResult Login(string returnUrl = "")
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(User user)
        {
            User usr = UserManager.Authenticate(user.Username, user.Password);
            if (usr == null)
            {
                return View();
            }
            // usr != null
            if (usr.Role == "Customer")
            {
                HttpContext.Session.SetInt32("CurrentCustomer", (int)usr.Id);
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usr.Username),
                new Claim("FullName", usr.Fullname),
                new Claim(ClaimTypes.Role, usr.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("Cookies", claimsPrincipal); // logs in
            if (String.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }

        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("Cookies");

            HttpContext.Session.Remove("CurrentCustomer");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
