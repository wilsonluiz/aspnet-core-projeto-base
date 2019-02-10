using System;
using Template.Api.Dominio.Entidades.ControleAcesso;

namespace Template.Api.Dominio.Entidades.Mensageria
{
    public class DestinatarioMensagem : IEntidade
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public DateTime? DataLeitura { get; set; }
        public DateTime? DataArquivamento { get; set; }

        public int MensagemId { get; set; }
        public int UsuarioDestinatarioId { get; set; }
        public Mensagem Mensagem { get; set; }
        public Usuario Usuario { get; set; }
    }
}