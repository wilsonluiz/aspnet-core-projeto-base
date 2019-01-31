using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.Api.Dominio.Entidades;
using Template.Api.Dominio.Interfaces;

namespace Template.Api.Infraestrutura.Dados.Repositorios
{
    public class RepositorioBaseSomenteLeitura<TContexto, TEntidade> :
        IRepositorioBaseSomenteLeitura<TContexto, TEntidade>
        where TEntidade : EntidadeBase
        where TContexto : DbContext
    {
        private readonly DbSet<TEntidade> _dbSet;
        protected TContexto Contexto;

        public RepositorioBaseSomenteLeitura(TContexto contexto)
        {
            Contexto = contexto;
            _dbSet = contexto.Set<TEntidade>();
        }

        public bool ExisteEntidade(int id)
        {
            return _dbSet.AsNoTracking().Any(e => e.Id == id);
        }

        public TEntidade ObterPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntidade> ListarTodos()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public async Task<bool> ExisteEntidadeAssincrono(int id)
        {
            return await _dbSet.AsNoTracking().AnyAsync(e => e.Id == id);
        }

        public async Task<TEntidade> ObterPorIdAssincrono(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntidade>> ListarTodosAssincrono()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Contexto == null) return;

            Contexto.Dispose();
            Contexto = null;
        }
    }
}