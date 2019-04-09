using Microsoft.EntityFrameworkCore.Migrations;

namespace FormBuilder.Core.Data.Migrations
{
    public partial class Removendo_Propriedades_De_Valor_Da_Contrucao_Do_Form : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "BaseField");

            migrationBuilder.DropColumn(
                name: "TextField_Value",
                table: "BaseField");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "BaseField",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextField_Value",
                table: "BaseField",
                nullable: true);
        }
    }
}
