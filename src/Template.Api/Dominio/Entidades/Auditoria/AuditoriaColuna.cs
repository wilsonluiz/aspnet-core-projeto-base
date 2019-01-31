namespace Template.Api.Dominio.Entidades.Auditoria
{
    public class AuditoriaColuna : EntidadeBase
    {
        public string NomeColuna { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorAtual { get; set; }
        public int AuditoriaTabelaId { get; set; }

        public AuditoriaTabela AuditoriaTabela { get; set; }
    }
}