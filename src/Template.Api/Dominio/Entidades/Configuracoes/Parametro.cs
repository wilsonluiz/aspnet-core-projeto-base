namespace Template.Api.Dominio.Entidades.Configuracoes
{
    public class Parametro : IEntidade
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}