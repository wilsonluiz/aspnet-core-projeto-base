using System;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}