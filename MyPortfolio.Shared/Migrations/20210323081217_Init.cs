using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolio.Shared.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(513)", maxLength: 513, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    AvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "About", "AddressId", "AvatarPath", "CVPath", "Description", "FullName", "Profile" },
                values: new object[] { new Guid("6b9262c4-bde3-46b7-904c-8e2d6b773bcf"), "I am a software developer, studying Computer Engineering at Selçuk University in Turkey and I'm so motivated to continue with improving my skills in computer science.", null, "avatar.png", "MyCV.pdf", "I have experience developing Android apps because I produced many apps which I have published on Google Play Store. I am now starting to develop myself in the field of web applications and my goal is to become a full stack developer.", "Ahmet Bakırcı", ".NET Full Stack Web Developer" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Description", "ImagePath", "Link", "Name" },
                values: new object[,]
                {
                    { new Guid("5b5a15c2-2a6b-469d-85e8-ee9e2e4ace84"), "A video status application that contains many videos and beautiful statuses that are constantly updated and also allows users to download videos and share them on social networking sites.", "videostatuses.png", "https://play.google.com/store/apps/details?id=com.mahwous.videostatuses", "Video Statuses" },
                    { new Guid("bbb91f7a-fddb-40de-b83a-6cf5d5833a93"), "A video status application that contains many videos and beautiful statuses that are constantly updated and also allows users to download videos and share them on social networking sites.", "mystatuses.png", "https://play.google.com/store/apps/details?id=com.mahwous.mystatuses", "My Statuses" },
                    { new Guid("6ef86f66-67c2-4fa1-be48-e3da8b7dbcf0"), "The website of Asia company for the sale and rental of stadiums in Turkey.", "asiacompany.png", "https://jx0hwxn75fznewe0qppjwq-on.drv.tw/AsiaSport/", "Asia For Stadiums" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Owner_AddressId",
                table: "Owner",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
