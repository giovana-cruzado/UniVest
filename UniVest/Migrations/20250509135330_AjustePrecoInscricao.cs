using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniVest.Migrations
{
    /// <inheritdoc />
    public partial class AjustePrecoInscricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoInscricao",
                table: "Vestibulares",
                type: "decimal(10,2)",
                maxLength: 100,
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoInscricao",
                table: "Vestibulares",
                type: "decimal(18,2)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldMaxLength: 100,
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
