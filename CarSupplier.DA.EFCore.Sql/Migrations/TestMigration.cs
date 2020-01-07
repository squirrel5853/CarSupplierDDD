//using JetBrains.Annotations;
//using Microsoft.EntityFrameworkCore.Migrations;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CarSupplier.DA.EFCore.Sql.Migrations
//{
//    public class TestMigration : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable("CarEntity",
//                columns: table => new
//                {
//                    CourseID = table.Column<int>(nullable: false),
//                    Credits = table.Column<int>(nullable: false),
//                    Title = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_CarEntity", x => x.CourseID);
//                });
//        }
//    }
//}
