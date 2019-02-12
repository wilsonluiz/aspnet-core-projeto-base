using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Dominio.Entidades.ControleAcesso;
using Template.Api.Dominio.Interfaces;
using Template.Api.Infraestrutura.Dados;

namespace Template.Api.Controllers
{
    [Route("api/usuarios/{id}/perfis")]
    [ApiController]
    public class UsuariosPerfisController : Controller
    {
        private readonly IRepositorioBase<ContextoTemplate, Usuario> _repositorio;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<Perfil> _roleManager;

        public UsuariosPerfisController(IRepositorioBase<ContextoTemplate, Usuario> repositorio, 
            UserManager<Usuario> userManager,
            RoleManager<Perfil> roleManager)
        {
            _repositorio = repositorio;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilUsuario>>> ListarPerfisUsuario([FromRoute] int id)
        {
            var usuario = await _repositorio.ObterPorIdAssincrono(id);
            var perfisUsuario = await _userManager.GetRolesAsync(usuario);

            return Ok(perfisUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> AssociarPerfiAoUsuario([FromRoute] int id, [FromQuery] string perfil)
        {
            var usuario = await _repositorio.ObterPorIdAssincrono(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");

            if (!await _roleManager.RoleExistsAsync(perfil))
                return NotFound("Perfil não encontrado");

            var perfisUsuario = await _userManager.GetRolesAsync(usuario);
            if (perfisUsuario.Contains(perfil))
                return BadRequest($"Usuário já possui o perfil '{perfil}'");

            await _userManager.AddToRoleAsync(usuario, perfil);
            
            return Created("", null);
        }
    }
}
