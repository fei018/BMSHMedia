using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BMSHMedia.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseFormSubmit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Info_BaseFormSubmit",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseFormName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info_BaseFormSubmit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Info_BaseFormSubmitData",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormSubmitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info_BaseFormSubmitData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Info_BaseFormSubmitData_Info_BaseFormSubmit_FormSubmitId",
                        column: x => x.FormSubmitId,
                        principalTable: "Info_BaseFormSubmit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Info_BaseFormSubmitData_FormSubmitId",
                table: "Info_BaseFormSubmitData",
                column: "FormSubmitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Info_BaseFormSubmitData");

            migrationBuilder.DropTable(
                name: "Info_BaseFormSubmit");
        }
    }
}
