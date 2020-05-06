using Microsoft.EntityFrameworkCore.Migrations;

namespace Youtube2.Data.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrDislikesT",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrLikesT",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NrSubscribers",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nume",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommCh",
                columns: table => new
                {
                    CommentChannelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    NrLikes = table.Column<int>(nullable: false),
                    NrDislikes = table.Column<int>(nullable: false),
                    ProfileId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommCh", x => x.CommentChannelId);
                    table.ForeignKey(
                        name: "FK_CommCh_AspNetUsers_ProfileId1",
                        column: x => x.ProfileId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subs",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notification = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subs", x => x.SubscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    VideosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    NrLikes = table.Column<int>(nullable: false),
                    NrDislikes = table.Column<int>(nullable: false),
                    NrComments = table.Column<int>(nullable: false),
                    Video = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ProfileId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.VideosId);
                    table.ForeignKey(
                        name: "FK_Video_AspNetUsers_ProfileId1",
                        column: x => x.ProfileId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommVideo",
                columns: table => new
                {
                    CommentVideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideosId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    NrLikes = table.Column<int>(nullable: false),
                    NrDislikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommVideo", x => x.CommentVideoId);
                    table.ForeignKey(
                        name: "FK_CommVideo_Video_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Video",
                        principalColumn: "VideosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommCh_ProfileId1",
                table: "CommCh",
                column: "ProfileId1");

            migrationBuilder.CreateIndex(
                name: "IX_CommVideo_VideosId",
                table: "CommVideo",
                column: "VideosId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_ProfileId1",
                table: "Video",
                column: "ProfileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Subs_SubscriptionId",
                table: "AspNetUsers",
                column: "SubscriptionId",
                principalTable: "Subs",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Subs_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CommCh");

            migrationBuilder.DropTable(
                name: "CommVideo");

            migrationBuilder.DropTable(
                name: "Subs");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SubscriptionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NrDislikesT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NrLikesT",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NrSubscribers",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nume",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "AspNetUsers");
        }
    }
}
