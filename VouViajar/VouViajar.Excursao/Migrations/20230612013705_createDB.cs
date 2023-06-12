using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VouViajar.Excursoes.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "Excursoes");

            migrationBuilder.CreateTable(
                name: "Localidade",
                schema: "Excursoes",
                columns: table => new
                {
                    LocalidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidade", x => x.LocalidadeID);
                });

            migrationBuilder.CreateTable(
                name: "Situacao",
                schema: "Excursoes",
                columns: table => new
                {
                    SituacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.SituacaoID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                schema: "Excursoes",
                columns: table => new
                {
                    TipoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.TipoID);
                });

            migrationBuilder.CreateTable(
                name: "Excursao",
                schema: "Excursoes",
                columns: table => new
                {
                    ExcursaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciaID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVagas = table.Column<int>(type: "int", nullable: false),
                    ValorVaga = table.Column<decimal>(type: "decimal(5,0)", precision: 5, nullable: false),
                    NomeArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrigemID = table.Column<int>(type: "int", nullable: false),
                    DestinoID = table.Column<int>(type: "int", nullable: false),
                    SituacaoID = table.Column<int>(type: "int", nullable: false),
                    TipoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursao", x => x.ExcursaoID);
                    table.ForeignKey(
                        name: "FK_Excursao_Localidade_DestinoID",
                        column: x => x.DestinoID,
                        principalSchema: "Excursoes",
                        principalTable: "Localidade",
                        principalColumn: "LocalidadeID");
                    table.ForeignKey(
                        name: "FK_Excursao_Localidade_OrigemID",
                        column: x => x.OrigemID,
                        principalSchema: "Excursoes",
                        principalTable: "Localidade",
                        principalColumn: "LocalidadeID");
                    table.ForeignKey(
                        name: "FK_Excursao_Situacao_SituacaoID",
                        column: x => x.SituacaoID,
                        principalSchema: "Excursoes",
                        principalTable: "Situacao",
                        principalColumn: "SituacaoID");
                    table.ForeignKey(
                        name: "FK_Excursao_Tipo_TipoID",
                        column: x => x.TipoID,
                        principalSchema: "Excursoes",
                        principalTable: "Tipo",
                        principalColumn: "TipoID");
                });

            migrationBuilder.CreateTable(
                name: "Agencia",
                schema: "dbo",
                columns: table => new
                {
                    AgenciaID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastur = table.Column<int>(type: "int", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.AgenciaID);
                    table.ForeignKey(
                        name: "FK_Agencia_Excursao_AgenciaID",
                        column: x => x.AgenciaID,
                        principalSchema: "Excursoes",
                        principalTable: "Excursao",
                        principalColumn: "ExcursaoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excursao_DestinoID",
                schema: "Excursoes",
                table: "Excursao",
                column: "DestinoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Excursao_OrigemID",
                schema: "Excursoes",
                table: "Excursao",
                column: "OrigemID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Excursao_SituacaoID",
                schema: "Excursoes",
                table: "Excursao",
                column: "SituacaoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Excursao_TipoID",
                schema: "Excursoes",
                table: "Excursao",
                column: "TipoID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Excursao",
                schema: "Excursoes");

            migrationBuilder.DropTable(
                name: "Localidade",
                schema: "Excursoes");

            migrationBuilder.DropTable(
                name: "Situacao",
                schema: "Excursoes");

            migrationBuilder.DropTable(
                name: "Tipo",
                schema: "Excursoes");
        }
    }
}
