using Template.Api.Dominio.Entidades;

namespace Template.Api.Dominio.Interfaces
{
    public interface IRepositorio<TEntidade> : IRepositorioSomenteLeitura<TEntidade>
        where TEntidade : EntidadeBase
    {
        /// <summary>
        ///     Adiciona a entidade no contexto.
        ///     Salva as alterações realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <returns></returns>
        TEntidade Adicionar(TEntidade entidade);

        /// <summary>
        ///     Altera o 'estado' da entidade para 'Modified' (modificada) no contexto.
        ///     Salva as alterações realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser alterada</param>
        /// <returns></returns>
        void Atualizar(TEntidade entidade);

        /// <summary>
        ///     Remove a entidade do contexto.
        ///     Salva as alterações realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser removida</param>
        /// <returns></returns>
        void Remover(TEntidade entidade);
    }
}