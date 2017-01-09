using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuansList.Data.Migrations
{
    public partial class modelsUpdatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_Album_AlbumId",
                table: "AlbumImages");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "AlbumImages",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_Album_AlbumId",
                table: "AlbumImages",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumImages_Album_AlbumId",
                table: "AlbumImages");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "AlbumImages",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumImages_Album_AlbumId",
                table: "AlbumImages",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
