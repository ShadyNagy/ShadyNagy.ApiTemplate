using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShadyNagy.ApiTemplate.Infrastructure.Data.Migrations;

public partial class MIGRATIONNAME : Migration
{
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.EnsureSchema(
        name: "Lockup");

    migrationBuilder.CreateTable(
        name: "Countries",
        schema: "Lockup",
        columns: table => new
        {
          Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
          Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Countries", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "Cities",
        schema: "Lockup",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Cities", x => x.Id);
          table.ForeignKey(
                    name: "FK_Cities_Countries_CountryId",
                    column: x => x.CountryId,
                    principalSchema: "Lockup",
                    principalTable: "Countries",
                    principalColumn: "Id");
        });

    migrationBuilder.CreateTable(
        name: "Branches",
        schema: "Lockup",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
          Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
          Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
          CityId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Branches", x => x.Id);
          table.ForeignKey(
                    name: "FK_Branches_Cities_CityId",
                    column: x => x.CityId,
                    principalSchema: "Lockup",
                    principalTable: "Cities",
                    principalColumn: "Id");
        });

    migrationBuilder.CreateTable(
        name: "UserInfos",
        schema: "Lockup",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
          CityId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_UserInfos", x => x.Id);
          table.ForeignKey(
                    name: "FK_UserInfos_Cities_CityId",
                    column: x => x.CityId,
                    principalSchema: "Lockup",
                    principalTable: "Cities",
                    principalColumn: "Id");
        });

    migrationBuilder.CreateTable(
        name: "Users",
        schema: "Lockup",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
          Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
          IsActive = table.Column<bool>(type: "bit", nullable: false),
          UserType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
          UserInfoId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Users", x => x.Id);
          table.ForeignKey(
                    name: "FK_Users_UserInfos_UserInfoId",
                    column: x => x.UserInfoId,
                    principalSchema: "Lockup",
                    principalTable: "UserInfos",
                    principalColumn: "Id");
        });

    migrationBuilder.CreateIndex(
        name: "IX_Branches_CityId",
        schema: "Lockup",
        table: "Branches",
        column: "CityId");

    migrationBuilder.CreateIndex(
        name: "IX_Cities_CountryId",
        schema: "Lockup",
        table: "Cities",
        column: "CountryId");

    migrationBuilder.CreateIndex(
        name: "IX_UserInfos_CityId",
        schema: "Lockup",
        table: "UserInfos",
        column: "CityId");

    migrationBuilder.CreateIndex(
        name: "IX_Users_UserInfoId",
        schema: "Lockup",
        table: "Users",
        column: "UserInfoId",
        unique: true);
  }

  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Branches",
        schema: "Lockup");

    migrationBuilder.DropTable(
        name: "Users",
        schema: "Lockup");

    migrationBuilder.DropTable(
        name: "UserInfos",
        schema: "Lockup");

    migrationBuilder.DropTable(
        name: "Cities",
        schema: "Lockup");

    migrationBuilder.DropTable(
        name: "Countries",
        schema: "Lockup");
  }
}
