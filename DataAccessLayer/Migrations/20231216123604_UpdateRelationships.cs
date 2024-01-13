using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_EmotionResult_EmotionResultId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_EmotionResultId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "EmotionResultId",
                table: "Post",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Post_EmotionResultId",
                table: "Post",
                column: "EmotionResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_EmotionResult_EmotionResultId",
                table: "Post",
                column: "EmotionResultId",
                principalTable: "EmotionResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_EmotionResult_EmotionResultId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_EmotionResultId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "EmotionResultId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_EmotionResultId",
                table: "Post",
                column: "EmotionResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_EmotionResult_EmotionResultId",
                table: "Post",
                column: "EmotionResultId",
                principalTable: "EmotionResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }

}
