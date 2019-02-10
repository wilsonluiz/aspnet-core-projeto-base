using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.Api.Dominio.Entidades;

namespace Template.Api.Dominio.Interfaces
{
    public interface IRepositorioBase<TContexto, TEntidade> : IRepositorioBaseSomenteLeitura<TContexto, TEntidade>
        where TContexto : DbContext
        where TEntidade : class, IEntidade
    {
        /// <summary>
        ///     Adiciona a entidade no contexto.
        ///     Salva as alterações, realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser adicionada</param>
        /// <returns></returns>
        TEntidade Adicionar(TEntidade entidade);

        /// <summary>
        ///     Altera o 'estado' da entidade para 'Modified' (modificada) no contexto.
        ///     Salva as alterações, realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser alterada</param>
        /// <returns></returns>
        void Atualizar(TEntidade entidade);

        /// <summary>
        ///     Remove a entidade do contexto.
        ///     Salva as alterações, realizadas no contexto, no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade a ser removida</param>
        /// <returns></returns>
        void Remover(TEntidade entidade);

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
        ///     Uma 'task' (tarefa) que representa a operação assícrona que foi salva
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
        ///     Uma 'task' (tarefa) que representa a operação assícrona que foi salva
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
        ///     Uma 'task' (tarefa) que representa a operação assícrona que foi salva
        /// </returns>
        Task RemoverAssincrono(TEntidade entidade);
    }
}