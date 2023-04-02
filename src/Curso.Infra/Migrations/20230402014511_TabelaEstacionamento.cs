using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TabelaEstacionamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(80)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(80)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(5)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estacionamentos");
        }
    }
}
