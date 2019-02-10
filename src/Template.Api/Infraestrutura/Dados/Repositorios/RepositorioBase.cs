using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.Api.Dominio.Entidades;
using Template.Api.Dominio.Interfaces;

namespace Template.Api.Infraestrutura.Dados.Repositorios
{
    public class RepositorioBase<TContexto, TEntidade> :
        RepositorioBaseSomenteLeitura<TContexto, TEntidade>,
        IRepositorioBase<TContexto, TEntidade>
        where TContexto : DbContext
        where TEntidade : class, IEntidade
    {
        private readonly DbSet<TEntidade> _dbSet;

        public RepositorioBase(TContexto contexto)
            : base(contexto)
        {
            Contexto = contexto;
            _dbSet = contexto.Set<TEntidade>();
        }

        /// <inheritdoc />
        public TEntidade Adicionar(TEntidade entidade)
        {
            _dbSet.Add(entidade);
            Contexto.SaveChanges();

            return entidade;
        }

        /// <inheritdoc />
        public void Atualizar(TEntidade entidade)
        {
            _dbSet.Attach(entidade);
            Contexto.Entry(entidade).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        /// <inheritdoc />
        public void Remover(TEntidade entidade)
        {
            _dbSet.Remove(entidade);
            Contexto.SaveChanges();
        }

        /// <inheritdoc />
        public async Task<TEntidade> AdicionarAssincrono(TEntidade entidade)
        {
            _dbSet.Add(entidade);
            await Contexto.SaveChangesAsync();

            return entidade;
        }

        /// <inheritdoc />
        public async Task AtualizarAssincrono(TEntidade entidade)
        {
            _dbSet.Attach(entidade);
            Contexto.Entry(entidade).State = EntityState.Modified;
            await Contexto.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoverAssincrono(TEntidade entidade)
        {
            _dbSet.Attach(entidade);
            _dbSet.Remove(entidade);
            await Contexto.SaveChangesAsync();
        }
    }
}