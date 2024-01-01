using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnDescriptionNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRIPTION_NEW",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRIPTION_NEW",
                table: "Notes");
        }
    }
}
