using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPractice.DA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sch");

            migrationBuilder.CreateTable(
                name: "Directories",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directories_Files_DirectoryId",
                        column: x => x.DirectoryId,
                        principalSchema: "sch",
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DirectoryPermission",
                schema: "sch",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DirectoryId = table.Column<int>(type: "int", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryPermission", x => new { x.UserId, x.DirectoryId });
                    table.ForeignKey(
                        name: "FK_DirectoryPermissions_Directories_DirectoryId",
                        column: x => x.DirectoryId,
                        principalSchema: "sch",
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DirectoryPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AudioFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Bitrate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelCount = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilePermission",
                schema: "sch",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilePermission", x => new { x.UserId, x.FileId });
                    table.ForeignKey(
                        name: "FK_FilePermissions_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilePermissions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sch",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoFiles",
                schema: "sch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoFiles_Files_Id",
                        column: x => x.Id,
                        principalSchema: "sch",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Directories",
                columns: new[] { "Id", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, null, "C:" },
                    { 2, null, "D:" },
                    { 3, 1, "System" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@company.com", "12213w12wd", "admin" },
                    { 2, "lowrider@gmail.com", "12dwwaw12wd", "lowrider" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "DirectoryPermission",
                columns: new[] { "DirectoryId", "UserId", "CanRead", "CanWrite" },
                values: new object[,]
                {
                    { 1, 1, true, true },
                    { 2, 1, true, true },
                    { 3, 1, true, true },
                    { 1, 2, true, false },
                    { 2, 2, true, true },
                    { 3, 2, false, false }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "Files",
                columns: new[] { "Id", "DirectoryId", "Extension", "Size", "Title", "Type" },
                values: new object[,]
                {
                    { 2, 1, ".jpg", "1 Mb", "jpgImage", "ImageFile" },
                    { 1, 2, ".mp3", "5 Mb", "musicfile", "AudioFile" },
                    { 4, 3, ".txt", "12 Kb", "TextFile", "TextFile" },
                    { 3, 3, ".mp4", "2 Gb", "mp4File", "VideoFile" }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "AudioFiles",
                columns: new[] { "Id", "Bitrate", "ChannelCount", "Duration", "SampleRate" },
                values: new object[] { 1, "320kbps", 2, new TimeSpan(0, 0, 3, 41, 0), "44100" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "FilePermission",
                columns: new[] { "FileId", "UserId", "CanRead", "CanWrite" },
                values: new object[,]
                {
                    { 2, 1, true, true },
                    { 2, 2, false, false },
                    { 1, 1, true, true },
                    { 1, 2, true, true },
                    { 4, 1, true, true },
                    { 4, 2, false, false },
                    { 3, 1, true, true },
                    { 3, 2, false, false }
                });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "ImageFiles",
                columns: new[] { "Id", "Height", "Width" },
                values: new object[] { 2, 1080, 1920 });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "TextFiles",
                columns: new[] { "Id", "Content" },
                values: new object[] { 4, "Many many strings" });

            migrationBuilder.InsertData(
                schema: "sch",
                table: "VideoFiles",
                columns: new[] { "Id", "Duration", "Height", "Width" },
                values: new object[] { 3, new TimeSpan(0, 1, 15, 21, 0), 1080, 1920 });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryPermission_DirectoryId",
                schema: "sch",
                table: "DirectoryPermission",
                column: "DirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FilePermission_FileId",
                schema: "sch",
                table: "FilePermission",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DirectoryId",
                schema: "sch",
                table: "Files",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "DirectoryPermission",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "FilePermission",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "ImageFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "TextFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "VideoFiles",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "sch");

            migrationBuilder.DropTable(
                name: "Directories",
                schema: "sch");
        }
    }
}
