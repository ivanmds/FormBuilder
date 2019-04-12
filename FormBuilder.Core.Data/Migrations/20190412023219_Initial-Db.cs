using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormBuilder.Core.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormBuild",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ExpiredIn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBuild", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseFieldBuilder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsRequired = table.Column<bool>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FormBuildId = table.Column<int>(nullable: true),
                    MinValue = table.Column<int>(nullable: true),
                    MaxValue = table.Column<int>(nullable: true),
                    MinLength = table.Column<int>(nullable: true),
                    MaxLength = table.Column<int>(nullable: true),
                    Placeholder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFieldBuilder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseFieldBuilder_FormBuild_FormBuildId",
                        column: x => x.FormBuildId,
                        principalTable: "FormBuild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        name: "FK_FormResponse_FormBuild_FormBuildId",
                        column: x => x.FormBuildId,
                        principalTable: "FormBuild",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseFieldResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormResponseId = table.Column<int>(nullable: true),
                    FieldBuildId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IntFieldValue = table.Column<int>(nullable: true),
                    TextFieldValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFieldResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseFieldResponse_BaseFieldBuilder_FieldBuildId",
                        column: x => x.FieldBuildId,
                        principalTable: "BaseFieldBuilder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseFieldResponse_FormResponse_FormResponseId",
                        column: x => x.FormResponseId,
                        principalTable: "FormResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseFieldBuilder_FormBuildId",
                table: "BaseFieldBuilder",
                column: "FormBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFieldResponse_FieldBuildId",
                table: "BaseFieldResponse",
                column: "FieldBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseFieldResponse_FormResponseId",
                table: "BaseFieldResponse",
                column: "FormResponseId");

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
                name: "BaseFieldBuilder");

            migrationBuilder.DropTable(
                name: "FormResponse");

            migrationBuilder.DropTable(
                name: "FormBuild");
        }
    }
}
