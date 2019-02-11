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
    [Route("api/[controller]")]
    public class PerfisController : Controller
    {
        private readonly IRepositorioBase<ContextoTemplate, Perfil> _repositorio;
        private readonly RoleManager<Perfil> _perfilManager;

        public PerfisController(IRepositorioBase<ContextoTemplate, Perfil> repositorio,
            RoleManager<Perfil> perfilManager)
        {
            _repositorio = repositorio;
            _perfilManager = perfilManager;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPerfis()
        {
            var perfis = await _repositorio.ListarTodosAssincrono();
            return Ok(perfis);
        }

        [HttpGet("{id}/claims")]
        public async Task<IActionResult> ObterClaimsPorIdPerfil(int id)
        {
            var perfil = await _repositorio.ObterPorIdAssincrono(id);
            var claims = await _perfilManager.GetClaimsAsync(perfil);

            return Ok(claims);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPefil()
        {
            var perfil = new Perfil { Name = "Admin" };
            
            if (! await _perfilManager.RoleExistsAsync("Admin"))
                await _perfilManager.CreateAsync(perfil);

            return Created("", null);
        }
    }
}
