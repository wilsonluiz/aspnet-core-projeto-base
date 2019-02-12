using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Template.Api.Dominio.Entidades.ControleAcesso;
using Template.Api.ViewModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Template.Api.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
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
                        return Redirect(Request.Query["ReturnUrl"].First());
                    return RedirectToAction("Index", "App");
                }
            }

            ModelState.AddModelError("", "Usuário e/ou senha incorreto(s)");

            return View();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = await _userManager.FindByNameAsync(model.Username);
            if (usuario == null)
                return BadRequest();

            var result = await _signInManager.CheckPasswordSignInAsync(usuario, model.Password, false);
            if (!result.Succeeded)
                return BadRequest();

            var results = GerarToken(usuario);

            return Created("", results);
        }

        private object GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Tokens:Issuer"],
                _config["Tokens:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            var results = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };

            return results;
        }
    }
}