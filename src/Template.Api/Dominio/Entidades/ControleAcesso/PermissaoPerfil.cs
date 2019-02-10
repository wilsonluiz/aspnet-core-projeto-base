using System;

namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class PermissaoPerfil : EntidadeBase
    {
        public int PerfilId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}