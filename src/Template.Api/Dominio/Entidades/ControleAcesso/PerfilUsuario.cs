namespace Template.Api.Dominio.Entidades.ControleAcesso
{
    public class PerfilUsuario : EntidadeBase
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }

        public Usuario Usuario { get; set; }
        public Perfil Perfil { get; set; }
    }
}