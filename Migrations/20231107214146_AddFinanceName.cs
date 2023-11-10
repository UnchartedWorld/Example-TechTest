using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotivWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFinanceName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinanceLoanName",
                table: "TableFinanceOptions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinanceLoanName",
                table: "TableFinanceOptions");
        }
    }
}
