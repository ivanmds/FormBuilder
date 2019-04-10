using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormBuilder.Core.Data.Migrations
{
    public partial class Criacao_Das_Tabelas_Das_Respostas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormBuildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormResponse_FormBuilder_FormBuildId",
                        column: x => x.FormBuildId,
                        principalTable: "FormBuilder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseFieldResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FieldBuilderId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IntFieldValue = table.Column<int>(nullable: true),
                    TextFieldValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFieldResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseFieldResponse_FormResponse_FieldBuilderId",
                        column: x => x.FieldBuilderId,
                        principalTable: "FormResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseFieldResponse_BaseFieldBuilder_FieldBuilderId",
                        column: x => x.FieldBuilderId,
                        principalTable: "BaseFieldBuilder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseFieldResponse_BaseFieldBuilder_FieldBuilderId1",
                        column: x => x.FieldBuilderId,
                        principalTable: "BaseFieldBuilder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseFieldResponse_FieldBuilderId",
                table: "BaseFieldResponse",
                column: "FieldBuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_FormResponse_FormBuildId",
                table: "FormResponse",
                column: "FormBuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseFieldResponse");

            migrationBuilder.DropTable(
                name: "FormResponse");
        }
    }
}
