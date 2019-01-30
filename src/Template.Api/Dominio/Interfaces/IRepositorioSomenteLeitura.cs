using System;
using System.Collections.Generic;
using Template.Api.Dominio.Entidades;

namespace Template.Api.Dominio.Interfaces
{
    public interface IRepositorioSomenteLeitura<TEntidade> : IDisposable 
        where TEntidade : EntidadeBase
    {
        bool ExisteEntidade(decimal id);
        IEnumerable<TEntidade> ListarTodos();
        TEntidade ObterPorId(decimal id);
    }
}