using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormBuilder.Core.Data.Migrations
{
    public partial class Initial_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormBuilder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ExpiredIn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBuilder", x => x.Id);
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
                        name: "FK_BaseFieldBuilder_FormBuilder_FormBuildId",
                        column: x => x.FormBuildId,
                        principalTable: "FormBuilder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseFieldBuilder_FormBuildId",
                table: "BaseFieldBuilder",
                column: "FormBuildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseFieldBuilder");

            migrationBuilder.DropTable(
                name: "FormBuilder");
        }
    }
}
