using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcHelpDesk.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Denunciar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(nullable: true),
                    Tecnico = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denunciar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nota = table.Column<decimal>(nullable: false),
                    Comentário = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<decimal>(nullable: false),
                    Telefone = table.Column<decimal>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Escolaridade = table.Column<string>(nullable: true),
                    Experiencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdemDeServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Endereco = table.Column<string>(nullable: true),
                    TipoServico = table.Column<string>(nullable: true),
                    CategoriaServico = table.Column<string>(nullable: true),
                    DescricaoProblema = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    DenunciarId = table.Column<int>(nullable: true),
                    FeedBackId = table.Column<int>(nullable: true),
                    TecnicoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDeServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Denunciar_DenunciarId",
                        column: x => x.DenunciarId,
                        principalTable: "Denunciar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Feedback_FeedBackId",
                        column: x => x.FeedBackId,
                        principalTable: "Feedback",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Usuario_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemDeServico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_DenunciarId",
                table: "OrdemDeServico",
                column: "DenunciarId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_FeedBackId",
                table: "OrdemDeServico",
                column: "FeedBackId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_TecnicoId",
                table: "OrdemDeServico",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDeServico_UsuarioId",
                table: "OrdemDeServico",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemDeServico");

            migrationBuilder.DropTable(
                name: "Denunciar");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
