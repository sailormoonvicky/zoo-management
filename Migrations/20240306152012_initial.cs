using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    DateOfAcquisition = table.Column<DateOnly>(type: "date", nullable: false),
                    EnclosureId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -6, "remaining animals" },
                    { -5, "hippo" },
                    { -4, "giraffe" },
                    { -3, "reptile" },
                    { -2, "aviary" },
                    { -1, "lions" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { -13, 3, "bumblebee" },
                    { -12, 3, "ladybug" },
                    { -11, 5, "startfish" },
                    { -10, 5, "octopus" },
                    { -9, 4, "seahorse" },
                    { -8, 4, "jellyfish" },
                    { -7, 1, "tortoise" },
                    { -6, 1, "python" },
                    { -5, 2, "swan" },
                    { -4, 2, "eagle" },
                    { -3, 0, "hippo" },
                    { -2, 0, "giraffe" },
                    { -1, 0, "lion" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -130, new DateOnly(2021, 10, 13), new DateOnly(2013, 1, 27), -6, "bumblebee #-130", 1, -13 },
                    { -129, new DateOnly(2020, 5, 9), new DateOnly(2017, 8, 8), -6, "bumblebee #-129", 0, -13 },
                    { -128, new DateOnly(2020, 2, 16), new DateOnly(2016, 8, 6), -6, "bumblebee #-128", 1, -13 },
                    { -127, new DateOnly(2021, 5, 2), new DateOnly(2014, 4, 11), -6, "bumblebee #-127", 0, -13 },
                    { -126, new DateOnly(2020, 3, 19), new DateOnly(2016, 3, 11), -6, "bumblebee #-126", 1, -13 },
                    { -125, new DateOnly(2020, 6, 7), new DateOnly(2016, 9, 19), -6, "bumblebee #-125", 0, -13 },
                    { -124, new DateOnly(2021, 10, 25), new DateOnly(2010, 7, 10), -6, "bumblebee #-124", 0, -13 },
                    { -123, new DateOnly(2020, 12, 16), new DateOnly(2014, 11, 19), -6, "bumblebee #-123", 1, -13 },
                    { -122, new DateOnly(2021, 10, 3), new DateOnly(2010, 7, 1), -6, "bumblebee #-122", 0, -13 },
                    { -121, new DateOnly(2020, 8, 14), new DateOnly(2010, 11, 1), -6, "bumblebee #-121", 0, -13 },
                    { -120, new DateOnly(2022, 5, 25), new DateOnly(2016, 6, 5), -6, "ladybug #-120", 1, -12 },
                    { -119, new DateOnly(2022, 3, 6), new DateOnly(2018, 7, 1), -6, "ladybug #-119", 0, -12 },
                    { -118, new DateOnly(2020, 8, 27), new DateOnly(2017, 6, 3), -6, "ladybug #-118", 0, -12 },
                    { -117, new DateOnly(2022, 11, 26), new DateOnly(2018, 8, 4), -6, "ladybug #-117", 1, -12 },
                    { -116, new DateOnly(2022, 4, 12), new DateOnly(2010, 8, 20), -6, "ladybug #-116", 1, -12 },
                    { -115, new DateOnly(2022, 1, 25), new DateOnly(2017, 10, 1), -6, "ladybug #-115", 1, -12 },
                    { -114, new DateOnly(2020, 10, 25), new DateOnly(2010, 6, 27), -6, "ladybug #-114", 1, -12 },
                    { -113, new DateOnly(2022, 1, 24), new DateOnly(2012, 12, 11), -6, "ladybug #-113", 0, -12 },
                    { -112, new DateOnly(2021, 8, 19), new DateOnly(2013, 11, 14), -6, "ladybug #-112", 1, -12 },
                    { -111, new DateOnly(2022, 1, 13), new DateOnly(2015, 10, 11), -6, "ladybug #-111", 1, -12 },
                    { -110, new DateOnly(2021, 9, 18), new DateOnly(2018, 9, 26), -6, "startfish #-110", 0, -11 },
                    { -109, new DateOnly(2022, 1, 6), new DateOnly(2011, 8, 19), -6, "startfish #-109", 1, -11 },
                    { -108, new DateOnly(2021, 3, 1), new DateOnly(2011, 3, 2), -6, "startfish #-108", 0, -11 },
                    { -107, new DateOnly(2020, 6, 21), new DateOnly(2010, 7, 14), -6, "startfish #-107", 0, -11 },
                    { -106, new DateOnly(2022, 4, 17), new DateOnly(2012, 8, 10), -6, "startfish #-106", 0, -11 },
                    { -105, new DateOnly(2020, 6, 23), new DateOnly(2016, 3, 9), -6, "startfish #-105", 1, -11 },
                    { -104, new DateOnly(2022, 9, 17), new DateOnly(2016, 7, 1), -6, "startfish #-104", 1, -11 },
                    { -103, new DateOnly(2021, 7, 9), new DateOnly(2018, 1, 22), -6, "startfish #-103", 1, -11 },
                    { -102, new DateOnly(2022, 5, 28), new DateOnly(2014, 12, 17), -6, "startfish #-102", 1, -11 },
                    { -101, new DateOnly(2020, 6, 14), new DateOnly(2010, 3, 2), -6, "startfish #-101", 1, -11 },
                    { -100, new DateOnly(2020, 4, 3), new DateOnly(2014, 8, 2), -6, "octopus #-100", 0, -10 },
                    { -99, new DateOnly(2021, 10, 28), new DateOnly(2017, 8, 14), -6, "octopus #-99", 1, -10 },
                    { -98, new DateOnly(2020, 7, 4), new DateOnly(2013, 4, 17), -6, "octopus #-98", 0, -10 },
                    { -97, new DateOnly(2021, 2, 28), new DateOnly(2016, 11, 13), -6, "octopus #-97", 1, -10 },
                    { -96, new DateOnly(2020, 8, 28), new DateOnly(2011, 6, 27), -6, "octopus #-96", 0, -10 },
                    { -95, new DateOnly(2021, 12, 11), new DateOnly(2017, 5, 9), -6, "octopus #-95", 0, -10 },
                    { -94, new DateOnly(2020, 6, 3), new DateOnly(2018, 11, 26), -6, "octopus #-94", 1, -10 },
                    { -93, new DateOnly(2022, 3, 22), new DateOnly(2019, 2, 9), -6, "octopus #-93", 0, -10 },
                    { -92, new DateOnly(2020, 2, 15), new DateOnly(2012, 10, 2), -6, "octopus #-92", 1, -10 },
                    { -91, new DateOnly(2022, 7, 4), new DateOnly(2010, 1, 23), -6, "octopus #-91", 0, -10 },
                    { -90, new DateOnly(2021, 1, 14), new DateOnly(2014, 3, 4), -6, "seahorse #-90", 1, -9 },
                    { -89, new DateOnly(2020, 5, 24), new DateOnly(2014, 3, 11), -6, "seahorse #-89", 1, -9 },
                    { -88, new DateOnly(2022, 9, 11), new DateOnly(2017, 10, 3), -6, "seahorse #-88", 0, -9 },
                    { -87, new DateOnly(2022, 6, 7), new DateOnly(2019, 2, 17), -6, "seahorse #-87", 1, -9 },
                    { -86, new DateOnly(2020, 11, 3), new DateOnly(2019, 5, 17), -6, "seahorse #-86", 0, -9 },
                    { -85, new DateOnly(2022, 5, 24), new DateOnly(2016, 12, 15), -6, "seahorse #-85", 1, -9 },
                    { -84, new DateOnly(2020, 7, 11), new DateOnly(2015, 3, 9), -6, "seahorse #-84", 0, -9 },
                    { -83, new DateOnly(2021, 1, 27), new DateOnly(2012, 3, 8), -6, "seahorse #-83", 0, -9 },
                    { -82, new DateOnly(2021, 1, 22), new DateOnly(2016, 1, 4), -6, "seahorse #-82", 1, -9 },
                    { -81, new DateOnly(2021, 7, 12), new DateOnly(2018, 2, 11), -6, "seahorse #-81", 1, -9 },
                    { -80, new DateOnly(2021, 8, 23), new DateOnly(2012, 5, 26), -6, "jellyfish #-80", 0, -8 },
                    { -79, new DateOnly(2021, 7, 15), new DateOnly(2018, 10, 22), -6, "jellyfish #-79", 1, -8 },
                    { -78, new DateOnly(2022, 10, 21), new DateOnly(2011, 12, 16), -6, "jellyfish #-78", 1, -8 },
                    { -77, new DateOnly(2022, 8, 1), new DateOnly(2015, 5, 1), -6, "jellyfish #-77", 1, -8 },
                    { -76, new DateOnly(2022, 11, 2), new DateOnly(2014, 8, 15), -6, "jellyfish #-76", 0, -8 },
                    { -75, new DateOnly(2022, 7, 20), new DateOnly(2019, 7, 8), -6, "jellyfish #-75", 0, -8 },
                    { -74, new DateOnly(2021, 1, 27), new DateOnly(2019, 12, 20), -6, "jellyfish #-74", 0, -8 },
                    { -73, new DateOnly(2021, 1, 16), new DateOnly(2017, 6, 12), -6, "jellyfish #-73", 1, -8 },
                    { -72, new DateOnly(2020, 11, 28), new DateOnly(2019, 12, 23), -6, "jellyfish #-72", 1, -8 },
                    { -71, new DateOnly(2022, 5, 12), new DateOnly(2011, 3, 25), -6, "jellyfish #-71", 0, -8 },
                    { -70, new DateOnly(2021, 4, 5), new DateOnly(2012, 1, 7), -3, "tortoise #-70", 1, -7 },
                    { -69, new DateOnly(2021, 3, 16), new DateOnly(2019, 9, 7), -3, "tortoise #-69", 1, -7 },
                    { -68, new DateOnly(2022, 10, 8), new DateOnly(2011, 3, 22), -3, "tortoise #-68", 0, -7 },
                    { -67, new DateOnly(2021, 5, 1), new DateOnly(2014, 11, 10), -3, "tortoise #-67", 1, -7 },
                    { -66, new DateOnly(2020, 9, 9), new DateOnly(2013, 10, 13), -3, "tortoise #-66", 1, -7 },
                    { -65, new DateOnly(2021, 1, 22), new DateOnly(2018, 5, 2), -3, "tortoise #-65", 0, -7 },
                    { -64, new DateOnly(2021, 2, 4), new DateOnly(2016, 3, 1), -3, "tortoise #-64", 1, -7 },
                    { -63, new DateOnly(2021, 1, 21), new DateOnly(2010, 1, 16), -3, "tortoise #-63", 1, -7 },
                    { -62, new DateOnly(2020, 5, 15), new DateOnly(2014, 11, 2), -3, "tortoise #-62", 1, -7 },
                    { -61, new DateOnly(2021, 12, 28), new DateOnly(2016, 12, 8), -3, "tortoise #-61", 1, -7 },
                    { -60, new DateOnly(2020, 7, 15), new DateOnly(2015, 5, 10), -3, "python #-60", 0, -6 },
                    { -59, new DateOnly(2020, 6, 13), new DateOnly(2015, 9, 8), -3, "python #-59", 0, -6 },
                    { -58, new DateOnly(2020, 10, 13), new DateOnly(2016, 10, 13), -3, "python #-58", 1, -6 },
                    { -57, new DateOnly(2020, 5, 19), new DateOnly(2014, 3, 17), -3, "python #-57", 1, -6 },
                    { -56, new DateOnly(2021, 10, 15), new DateOnly(2014, 12, 6), -3, "python #-56", 1, -6 },
                    { -55, new DateOnly(2020, 3, 25), new DateOnly(2010, 11, 9), -3, "python #-55", 0, -6 },
                    { -54, new DateOnly(2021, 4, 28), new DateOnly(2014, 3, 9), -3, "python #-54", 0, -6 },
                    { -53, new DateOnly(2020, 3, 18), new DateOnly(2018, 5, 28), -3, "python #-53", 0, -6 },
                    { -52, new DateOnly(2022, 12, 11), new DateOnly(2017, 8, 11), -3, "python #-52", 1, -6 },
                    { -51, new DateOnly(2020, 3, 28), new DateOnly(2019, 12, 25), -3, "python #-51", 0, -6 },
                    { -50, new DateOnly(2021, 9, 4), new DateOnly(2018, 6, 16), -2, "swan #-50", 0, -5 },
                    { -49, new DateOnly(2020, 7, 20), new DateOnly(2015, 9, 2), -2, "swan #-49", 1, -5 },
                    { -48, new DateOnly(2020, 11, 10), new DateOnly(2017, 2, 17), -2, "swan #-48", 1, -5 },
                    { -47, new DateOnly(2022, 4, 3), new DateOnly(2019, 12, 9), -2, "swan #-47", 1, -5 },
                    { -46, new DateOnly(2021, 4, 27), new DateOnly(2013, 5, 14), -2, "swan #-46", 1, -5 },
                    { -45, new DateOnly(2020, 1, 26), new DateOnly(2019, 7, 3), -2, "swan #-45", 0, -5 },
                    { -44, new DateOnly(2021, 12, 19), new DateOnly(2017, 12, 7), -2, "swan #-44", 1, -5 },
                    { -43, new DateOnly(2021, 10, 20), new DateOnly(2015, 12, 25), -2, "swan #-43", 0, -5 },
                    { -42, new DateOnly(2020, 12, 7), new DateOnly(2012, 4, 3), -2, "swan #-42", 1, -5 },
                    { -41, new DateOnly(2022, 6, 22), new DateOnly(2015, 1, 28), -2, "swan #-41", 1, -5 },
                    { -40, new DateOnly(2020, 1, 8), new DateOnly(2018, 6, 26), -2, "eagle #-40", 0, -4 },
                    { -39, new DateOnly(2020, 9, 5), new DateOnly(2015, 9, 27), -2, "eagle #-39", 1, -4 },
                    { -38, new DateOnly(2021, 5, 18), new DateOnly(2011, 7, 5), -2, "eagle #-38", 0, -4 },
                    { -37, new DateOnly(2021, 3, 14), new DateOnly(2013, 5, 17), -2, "eagle #-37", 0, -4 },
                    { -36, new DateOnly(2021, 12, 28), new DateOnly(2017, 5, 2), -2, "eagle #-36", 0, -4 },
                    { -35, new DateOnly(2022, 7, 20), new DateOnly(2013, 5, 15), -2, "eagle #-35", 1, -4 },
                    { -34, new DateOnly(2022, 11, 6), new DateOnly(2010, 11, 5), -2, "eagle #-34", 1, -4 },
                    { -33, new DateOnly(2021, 5, 5), new DateOnly(2013, 3, 17), -2, "eagle #-33", 0, -4 },
                    { -32, new DateOnly(2021, 5, 6), new DateOnly(2013, 7, 21), -2, "eagle #-32", 1, -4 },
                    { -31, new DateOnly(2021, 5, 13), new DateOnly(2014, 2, 25), -2, "eagle #-31", 1, -4 },
                    { -30, new DateOnly(2022, 4, 27), new DateOnly(2010, 5, 16), -5, "hippo #-30", 0, -3 },
                    { -29, new DateOnly(2020, 9, 13), new DateOnly(2018, 4, 21), -5, "hippo #-29", 0, -3 },
                    { -28, new DateOnly(2022, 10, 12), new DateOnly(2013, 12, 1), -5, "hippo #-28", 1, -3 },
                    { -27, new DateOnly(2021, 6, 23), new DateOnly(2018, 12, 12), -5, "hippo #-27", 0, -3 },
                    { -26, new DateOnly(2020, 6, 3), new DateOnly(2016, 6, 1), -5, "hippo #-26", 1, -3 },
                    { -25, new DateOnly(2021, 8, 8), new DateOnly(2018, 6, 15), -5, "hippo #-25", 0, -3 },
                    { -24, new DateOnly(2022, 5, 26), new DateOnly(2013, 2, 22), -5, "hippo #-24", 1, -3 },
                    { -23, new DateOnly(2021, 8, 10), new DateOnly(2016, 1, 27), -5, "hippo #-23", 0, -3 },
                    { -22, new DateOnly(2022, 10, 5), new DateOnly(2015, 7, 16), -5, "hippo #-22", 0, -3 },
                    { -21, new DateOnly(2022, 7, 27), new DateOnly(2019, 5, 12), -5, "hippo #-21", 1, -3 },
                    { -20, new DateOnly(2022, 7, 25), new DateOnly(2016, 10, 14), -6, "giraffe #-20", 1, -2 },
                    { -19, new DateOnly(2022, 3, 1), new DateOnly(2012, 12, 28), -6, "giraffe #-19", 0, -2 },
                    { -18, new DateOnly(2022, 3, 11), new DateOnly(2016, 9, 22), -6, "giraffe #-18", 0, -2 },
                    { -17, new DateOnly(2021, 4, 23), new DateOnly(2012, 6, 6), -6, "giraffe #-17", 1, -2 },
                    { -16, new DateOnly(2022, 10, 10), new DateOnly(2018, 12, 12), -4, "giraffe #-16", 1, -2 },
                    { -15, new DateOnly(2021, 7, 20), new DateOnly(2019, 3, 2), -4, "giraffe #-15", 1, -2 },
                    { -14, new DateOnly(2021, 3, 22), new DateOnly(2016, 9, 6), -4, "giraffe #-14", 0, -2 },
                    { -13, new DateOnly(2022, 8, 4), new DateOnly(2017, 10, 10), -4, "giraffe #-13", 1, -2 },
                    { -12, new DateOnly(2022, 4, 25), new DateOnly(2016, 11, 18), -4, "giraffe #-12", 0, -2 },
                    { -11, new DateOnly(2020, 7, 2), new DateOnly(2018, 1, 28), -4, "giraffe #-11", 0, -2 },
                    { -10, new DateOnly(2020, 8, 8), new DateOnly(2018, 5, 21), -6, "lion #-10", 1, -1 },
                    { -9, new DateOnly(2020, 4, 10), new DateOnly(2013, 6, 11), -6, "lion #-9", 0, -1 },
                    { -8, new DateOnly(2021, 10, 20), new DateOnly(2017, 8, 27), -1, "lion #-8", 1, -1 },
                    { -7, new DateOnly(2020, 6, 2), new DateOnly(2014, 4, 17), -1, "lion #-7", 0, -1 },
                    { -6, new DateOnly(2021, 1, 5), new DateOnly(2013, 12, 24), -1, "lion #-6", 1, -1 },
                    { -5, new DateOnly(2022, 1, 8), new DateOnly(2016, 1, 7), -1, "lion #-5", 0, -1 },
                    { -4, new DateOnly(2022, 8, 22), new DateOnly(2016, 9, 20), -1, "lion #-4", 0, -1 },
                    { -3, new DateOnly(2020, 6, 23), new DateOnly(2012, 4, 10), -1, "lion #-3", 0, -1 },
                    { -2, new DateOnly(2020, 12, 13), new DateOnly(2019, 1, 6), -1, "lion #-2", 1, -1 },
                    { -1, new DateOnly(2020, 8, 2), new DateOnly(2016, 8, 21), -1, "lion #-1", 0, -1 },
                    { 1, new DateOnly(2000, 1, 1), new DateOnly(1998, 10, 13), -1, "simba", 0, -1 },
                    { 2, new DateOnly(2001, 2, 3), new DateOnly(1997, 9, 18), -1, "nala", 0, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureId",
                table: "Animals",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Enclosures");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
