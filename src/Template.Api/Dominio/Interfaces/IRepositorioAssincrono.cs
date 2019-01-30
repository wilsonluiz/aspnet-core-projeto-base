using System.Threading.Tasks;
using Template.Api.Dominio.Entidades;

namespace Template.Api.Dominio.Interfaces
{
    public interface IRepositorioAssincrono<TEntidade> : IRepositorioSomenteLeituraAssincrono<TEntidade>
        where TEntidade : EntidadeBase
    {
        /// <summary>
        ///     Adiciona a entidade no contexto.
        ///     Salva, de forma assíncrona, as alterações realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <remarks>
        ///     Use 'await' para ter a certeza de que qualquer operação assíncrona tenha sido completada
        ///     antes de outro método seja chamado utilizando o mesmo contexto
        /// </remarks>
        /// <returns>
        ///     Uma 'task' (tarefa) quw representa a operação assícrona que foi salva
        /// </returns>
        Task<TEntidade> AdicionarAssincrono(TEntidade entidade);

        /// <summary>
        ///     Altera o 'estado' da entidade para 'Modified' (modificada) no contexto.
        ///     Salva, de forma assíncrona, as alterações realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser alterada</param>
        /// <remarks>
        ///     Use 'await' para ter a certeza de que qualquer operação assíncrona tenha sido completada
        ///     antes de outro método seja chamado utilizando o mesmo contexto
        /// </remarks>
        /// <returns>
        ///     Uma 'task' (tarefa) quw representa a operação assícrona que foi salva
        /// </returns>
        Task AtualizarAssincrono(TEntidade entidade);

        /// <summary>
        ///     Remove a entidade do contexto.
        ///     Salva, de forma assíncrona, as alterações realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser removida</param>
        /// <remarks>
        ///     Use 'await' para ter a certeza de que qualquer operação assíncrona tenha sido completada
        ///     antes de outro método seja chamado utilizando o mesmo contexto
        /// </remarks>
        /// <returns>
        ///     Uma 'task' (tarefa) quw representa a operação assícrona que foi salva
        /// </returns>
        Task RemoverAssincrono(TEntidade entidade);
    }
}