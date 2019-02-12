using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Dominio.Entidades.ControleAcesso;
using Template.Api.Dominio.Interfaces;
using Template.Api.Infraestrutura.Dados;

namespace Template.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositorioBase<ContextoTemplate, Usuario> _repositorio;
        private readonly UserManager<Usuario> _userManager;

        public UsuariosController(IRepositorioBase<ContextoTemplate, Usuario> repositorio,
            UserManager<Usuario> userManager)
        {
            _repositorio = repositorio;
            _userManager = userManager;
        }

        // GET api/usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return Ok(_repositorio.ListarTodos());
        }

        // GET api/usuarios/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            return Ok(_repositorio.ObterPorId(id));
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            var usuarioCriado = await _userManager.CreateAsync(usuario, "P@ssw0rd!");
            //_repositorio.Adicionar(usuario);

            return Created("", null);
        }

        // PUT api/usuarios/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usuario)
        {
        }

        // DELETE api/usuarios/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var usuario = _repositorio.ObterPorId(id);

            if (usuario != null)
                _repositorio.Remover(usuario);
        }
    }
}
