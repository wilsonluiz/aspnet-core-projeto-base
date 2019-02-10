using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Api.Infraestrutura.Dados.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricosFiltros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HistoricoConsultaId = table.Column<int>(nullable: false),
                    NomeConsulta = table.Column<string>(nullable: true),
                    OperadorLogico = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosFiltros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataOcorrencia = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chave = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Chave = table.Column<string>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissoesPerfis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerfilId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissoesPerfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataExclusao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaTabelas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataOcorrencia = table.Column<DateTime>(nullable: false),
                    NomeTabela = table.Column<string>(nullable: true),
                    IdRegistro = table.Column<int>(nullable: false),
                    AcaoRealizado = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaTabelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaTabelas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosConsultas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataExecucao = table.Column<DateTime>(nullable: false),
                    NomeConsulta = table.Column<string>(nullable: true),
                    Sql = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosConsultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosConsultas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    MensagemOrigemId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Assunto = table.Column<string>(nullable: true),
                    Conteudo = table.Column<string>(nullable: true),
                    DataArquivamento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfisUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfisUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfisUsuarios_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfisUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaColunas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeColuna = table.Column<string>(nullable: true),
                    ValorAnterior = table.Column<string>(nullable: true),
                    ValorAtual = table.Column<string>(nullable: true),
                    AuditoriaTabelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaColunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaColunas_AuditoriaTabelas_AuditoriaTabelaId",
                        column: x => x.AuditoriaTabelaId,
                        principalTable: "AuditoriaTabelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinatariosMensagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Conteudo = table.Column<string>(nullable: true),
                    DataLeitura = table.Column<DateTime>(nullable: true),
                    DataArquivamento = table.Column<DateTime>(nullable: true),
                    MensagemId = table.Column<int>(nullable: false),
                    UsuarioDestinatarioId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinatariosMensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinatariosMensagens_Mensagens_MensagemId",
                        column: x => x.MensagemId,
                        principalTable: "Mensagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinatariosMensagens_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaColunas_AuditoriaTabelaId",
                table: "AuditoriaColunas",
                column: "AuditoriaTabelaId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaTabelas_UsuarioId",
                table: "AuditoriaTabelas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinatariosMensagens_MensagemId",
                table: "DestinatariosMensagens",
                column: "MensagemId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinatariosMensagens_UsuarioId",
                table: "DestinatariosMensagens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosConsultas_UsuarioId",
                table: "HistoricosConsultas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_UsuarioId",
                table: "Mensagens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfisUsuarios_PerfilId",
                table: "PerfisUsuarios",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfisUsuarios_UsuarioId",
                table: "PerfisUsuarios",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriaColunas");

            migrationBuilder.DropTable(
                name: "DestinatariosMensagens");

            migrationBuilder.DropTable(
                name: "HistoricosConsultas");

            migrationBuilder.DropTable(
                name: "HistoricosFiltros");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "PerfisUsuarios");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "PermissoesPerfis");

            migrationBuilder.DropTable(
                name: "AuditoriaTabelas");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
