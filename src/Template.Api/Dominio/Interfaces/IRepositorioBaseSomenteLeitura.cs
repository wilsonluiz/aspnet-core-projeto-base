using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.Api.Dominio.Entidades;

namespace Template.Api.Dominio.Interfaces
{
    public interface IRepositorioBaseSomenteLeitura<TContexto, TEntidade> : IDisposable
        where TContexto : DbContext
        where TEntidade : EntidadeBase
    {
        bool ExisteEntidade(decimal id);
        IEnumerable<TEntidade> ListarTodos();
        TEntidade ObterPorId(decimal id);

        Task<bool> ExisteEntidadeAssincrono(decimal id);
        Task<List<TEntidade>> ListarTodosAssincrono();
        Task<TEntidade> ObterPorIdAssincrono(decimal id);
    }
}