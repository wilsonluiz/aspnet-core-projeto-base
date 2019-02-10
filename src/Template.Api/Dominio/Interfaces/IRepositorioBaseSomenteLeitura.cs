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
        bool ExisteEntidade(int id);
        IEnumerable<TEntidade> ListarTodos();
        TEntidade ObterPorId(int id);

        Task<bool> ExisteEntidadeAssincrono(int id);
        Task<List<TEntidade>> ListarTodosAssincrono();
        Task<TEntidade> ObterPorIdAssincrono(int id);
    }
}