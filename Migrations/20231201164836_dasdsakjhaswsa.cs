using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleJornadas.Migrations
{
    /// <inheritdoc />
    public partial class dasdsakjhaswsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_Jornadas_Jornadasid",
                table: "funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_funcionarios_Jornadasid",
                table: "funcionarios");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Jornadas");

            migrationBuilder.DropColumn(
                name: "Jornadasid",
                table: "funcionarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Jornadas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "Jornadasid",
                table: "funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_Jornadasid",
                table: "funcionarios",
                column: "Jornadasid");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_Jornadas_Jornadasid",
                table: "funcionarios",
                column: "Jornadasid",
                principalTable: "Jornadas",
                principalColumn: "id");
        }
    }
}
