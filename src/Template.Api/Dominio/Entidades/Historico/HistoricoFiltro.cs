namespace Template.Api.Dominio.Entidades.Historico
{
    public class HistoricoFiltro : EntidadeBase
    {
        public int IdHistoricoConsulta { get; set; }
        public string NomeConsulta { get; set; }
        public string OperadorLogico { get; set; }
        public string Valor { get; set; }
    }
}