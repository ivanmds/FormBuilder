using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormBuilder.Core.Data.Migrations
{
    public partial class Atualizando_Relacionamento_DO_FormResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseFieldResponse_FormResponse_FieldBuilderId",
                table: "BaseFieldResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseFieldResponse_BaseFieldBuilder_FieldBuilderId1",
                table: "BaseFieldResponse");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BaseFieldResponse",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "TextFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseFieldResponse_TextFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse",
                column: "TextFieldResponse_FieldBuilderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseFieldResponse_FormResponse_Id",
                table: "BaseFieldResponse",
                column: "Id",
                principalTable: "FormResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseFieldResponse_BaseFieldBuilder_TextFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse",
                column: "TextFieldResponse_FieldBuilderId",
                principalTable: "BaseFieldBuilder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseFieldResponse_FormResponse_Id",
                table: "BaseFieldResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseFieldResponse_BaseFieldBuilder_TextFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse");

            migrationBuilder.DropIndex(
                name: "IX_BaseFieldResponse_TextFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse");

            migrationBuilder.DropColumn(
                name: "TextFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BaseFieldResponse",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseFieldResponse_FormResponse_FieldBuilderId",
                table: "BaseFieldResponse",
                column: "FieldBuilderId",
                principalTable: "FormResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseFieldResponse_BaseFieldBuilder_FieldBuilderId1",
                table: "BaseFieldResponse",
                column: "FieldBuilderId",
                principalTable: "BaseFieldBuilder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
