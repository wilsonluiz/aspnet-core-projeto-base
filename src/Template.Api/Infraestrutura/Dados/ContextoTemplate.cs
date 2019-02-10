using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Template.Api.Dominio.Entidades.Auditoria;
using Template.Api.Dominio.Entidades.Configuracoes;
using Template.Api.Dominio.Entidades.ControleAcesso;
using Template.Api.Dominio.Entidades.Historico;
using Template.Api.Dominio.Entidades.Logs;
using Template.Api.Dominio.Entidades.Mensageria;

namespace Template.Api.Infraestrutura.Dados
{
    public class ContextoTemplate : IdentityDbContext<Usuario, Perfil, int>
    {
        public ContextoTemplate(DbContextOptions<ContextoTemplate> options) : base(options)
        {
        }

        public DbSet<AuditoriaTabela> AuditoriaTabelas { get; set; }
        public DbSet<AuditoriaColuna> AuditoriaColunas { get; set; }
        public DbSet<DestinatarioMensagem> DestinatariosMensagens { get; set; }
        public DbSet<HistoricoConsulta> HistoricosConsultas { get; set; }
        public DbSet<HistoricoFiltro> HistoricosFiltros { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        //public DbSet<PerfilUsuario> PerfisUsuarios { get; set; }
        //public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PermissaoPerfil> PermissoesPerfis { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
    }
}