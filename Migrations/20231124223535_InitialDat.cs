using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleJornadas.Migrations
{
    /// <inheritdoc />
    public partial class InitialDat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "funcionariosid",
                table: "Bases",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    HrInicio = table.Column<string>(type: "TEXT", nullable: false),
                    HrFim = table.Column<string>(type: "TEXT", nullable: false),
                    Turno = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    cargo = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    dataAdmissao = table.Column<DateOnly>(type: "TEXT", maxLength: 200, nullable: false),
                    codPix = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Jornadasid = table.Column<int>(type: "INTEGER", nullable: true),
                    funcionariosid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_funcionarios_Jornadas_Jornadasid",
                        column: x => x.Jornadasid,
                        principalTable: "Jornadas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_funcionarios_funcionarios_funcionariosid",
                        column: x => x.funcionariosid,
                        principalTable: "funcionarios",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bases_funcionariosid",
                table: "Bases",
                column: "funcionariosid");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_funcionariosid",
                table: "funcionarios",
                column: "funcionariosid");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_Jornadasid",
                table: "funcionarios",
                column: "Jornadasid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bases_funcionarios_funcionariosid",
                table: "Bases",
                column: "funcionariosid",
                principalTable: "funcionarios",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bases_funcionarios_funcionariosid",
                table: "Bases");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropIndex(
                name: "IX_Bases_funcionariosid",
                table: "Bases");

            migrationBuilder.DropColumn(
                name: "funcionariosid",
                table: "Bases");
        }
    }
}
