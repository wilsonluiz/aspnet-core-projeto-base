using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Dominio.Entidades.ControleAcesso;
using Template.Api.ViewModels;

namespace Template.Api.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;

        public AccountController(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "App");

            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "App");
                    }
                }
            }
            
            ModelState.AddModelError("", "Usuário e/ou senha incorreto(s)");

            return View();
        }
    }
}
