using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VouViajar.Excursoes.Migrations
{
    /// <inheritdoc />
    public partial class atualizaExcursao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencia",
                schema: "Excursoes",
                columns: table => new
                {
                    AgenciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cadastur = table.Column<int>(type: "int", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.AgenciaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Excursao_AgenciaID",
                schema: "Excursoes",
                table: "Excursao",
                column: "AgenciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursao_Agencia_AgenciaID",
                schema: "Excursoes",
                table: "Excursao",
                column: "AgenciaID",
                principalSchema: "Excursoes",
                principalTable: "Agencia",
                principalColumn: "AgenciaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursao_Agencia_AgenciaID",
                schema: "Excursoes",
                table: "Excursao");

            migrationBuilder.DropTable(
                name: "Agencia",
                schema: "Excursoes");

            migrationBuilder.DropIndex(
                name: "IX_Excursao_AgenciaID",
                schema: "Excursoes",
                table: "Excursao");
        }
    }
}
