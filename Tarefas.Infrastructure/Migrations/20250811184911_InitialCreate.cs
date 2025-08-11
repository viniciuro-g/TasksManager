using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR(1000)", maxLength: 1000, nullable: false),
                    EstaCompleta = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");
        }
    }
}
