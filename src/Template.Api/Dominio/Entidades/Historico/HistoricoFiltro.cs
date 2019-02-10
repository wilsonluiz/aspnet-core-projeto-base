namespace Template.Api.Dominio.Entidades.Historico
{
    public class HistoricoFiltro : IEntidade
    {
        public int Id { get; set; }
        public int HistoricoConsultaId { get; set; }
        public string NomeConsulta { get; set; }
        public string OperadorLogico { get; set; }
        public string Valor { get; set; }
    }
}