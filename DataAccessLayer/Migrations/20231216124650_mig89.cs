using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig89 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_AppUserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_WriterId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_EmotionResult_EmotionResultId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmotionResult",
                table: "EmotionResult");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "EmotionResult",
                newName: "EmotionResults");

            migrationBuilder.RenameIndex(
                name: "IX_Post_WriterId",
                table: "Posts",
                newName: "IX_Posts_WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_EmotionResultId",
                table: "Posts",
                newName: "IX_Posts_EmotionResultId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_AppUserId",
                table: "Posts",
                newName: "IX_Posts_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmotionResults",
                table: "EmotionResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_WriterId",
                table: "Posts",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_EmotionResults_EmotionResultId",
                table: "Posts",
                column: "EmotionResultId",
                principalTable: "EmotionResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_WriterId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_EmotionResults_EmotionResultId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmotionResults",
                table: "EmotionResults");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "EmotionResults",
                newName: "EmotionResult");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_WriterId",
                table: "Post",
                newName: "IX_Post_WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_EmotionResultId",
                table: "Post",
                newName: "IX_Post_EmotionResultId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AppUserId",
                table: "Post",
                newName: "IX_Post_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmotionResult",
                table: "EmotionResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_AppUserId",
                table: "Post",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_WriterId",
                table: "Post",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
