using System;
using Template.Api.Dominio.Entidades.ControleAcesso;

namespace Template.Api.Dominio.Entidades.Mensageria
{
    public class Mensagem : IEntidade
    {
        public int Id { get; set; }
        public DateTime DataEnvio { get; set; }
        public int MensagemOrigemId { get; set; }
        public int UsuarioId { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public DateTime? DataArquivamento { get; set; }

        public Usuario Usuario { get; set; }
    }
}