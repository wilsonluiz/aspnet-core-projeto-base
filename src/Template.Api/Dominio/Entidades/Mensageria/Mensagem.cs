using System;
using Template.Api.Dominio.Entidades.ControleAcesso;

namespace Template.Api.Dominio.Entidades.Mensageria
{
    public class Mensagem : EntidadeBase
    {
        public DateTime DataEnvio { get; set; }
        public int IdMensagemOrigem { get; set; }
        public int IdUsuarioRemetente { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataArquivamento { get; set; }

        public Usuario Usuario { get; set; }
    }
}