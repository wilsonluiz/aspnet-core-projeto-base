using System;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class Permissao : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Chave { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}