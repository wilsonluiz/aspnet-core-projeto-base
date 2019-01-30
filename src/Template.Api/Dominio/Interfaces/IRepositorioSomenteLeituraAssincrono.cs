using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.Dominio.Entidades;

namespace Template.Api.Dominio.Interfaces
{
    public interface IRepositorioSomenteLeituraAssincrono<TEntidade> : IDisposable 
        where TEntidade : EntidadeBase
    {
        Task<bool> ExisteEntidadeAssincrono(decimal id);
        Task<List<TEntidade>> ListarTodosAssincrono();
        Task<TEntidade> ObterPorIdAssincrono(decimal id);
    }
}