using System;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class PermissaoPerfil : EntidadeBase
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public DateTime DataExclusao { get; set; }
    }
}