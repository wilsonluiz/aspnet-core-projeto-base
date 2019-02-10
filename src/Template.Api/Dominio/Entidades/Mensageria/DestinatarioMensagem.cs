using System;
using Template.Api.Dominio.Entidades.ControleAcesso;

namespace Template.Api.Dominio.Entidades.Mensageria
{
    public class DestinatarioMensagem : EntidadeBase
    {
        public int IdMensagem { get; set; }
        public int IdUsuarioDestinatario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataLeitura { get; set; }
        public DateTime DataArquivamento { get; set; }

        public Mensagem Mensagem { get; set; }
        public Usuario Usuario { get; set; }
    }
}