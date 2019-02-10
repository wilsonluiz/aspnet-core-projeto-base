namespace Template.Api.Dominio.Entidades.Auditoria
{
    public class AuditoriaColuna : EntidadeBase
    {
        public int IdAuditoriaTabela { get; set; }
        public string NomeColuna { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorAtual { get; set; }

        public AuditoriaTabela AuditoriaTabela { get; set; }
    }
}