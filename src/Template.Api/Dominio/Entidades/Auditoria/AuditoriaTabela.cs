using System;
using Template.Api.Dominio.Entidades.ControleAcesso;

namespace Template.Api.Dominio.Entidades.Auditoria
{
    public class AuditoriaTabela : EntidadeBase
    {
        public DateTime DataOcorrencia { get; set; }
        public string NomeTabela { get; set; }
        public int IdRegistro { get; set; }
        public string AcaoRealizado { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}