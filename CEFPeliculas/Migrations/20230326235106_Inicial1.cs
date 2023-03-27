using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace CEFPeliculas.Migrations
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cine");

            migrationBuilder.CreateTable(
                name: "tblActor",
                schema: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblActor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCine",
                schema: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblGenero",
                schema: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGenero = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGenero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblPeliculas",
                schema: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EnCartelera = table.Column<bool>(type: "bit", nullable: false),
                    FechaEstreno = table.Column<DateTime>(type: "date", nullable: false),
                    PosterURL = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPeliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCineOferta",
                schema: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCineOferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCineOferta_tblCine_CineId",
                        column: x => x.CineId,
                        principalSchema: "Cine",
                        principalTable: "tblCine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSalaCines",
                schema: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSalaCine = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Precio = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalaCines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSalaCines_tblCine_CineId",
                        column: x => x.CineId,
                        principalSchema: "Cine",
                        principalTable: "tblCine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneroPelicula",
                schema: "Cine",
                columns: table => new
                {
                    GenerosId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPelicula", x => new { x.GenerosId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_tblGenero_GenerosId",
                        column: x => x.GenerosId,
                        principalSchema: "Cine",
                        principalTable: "tblGenero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroPelicula_tblPeliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalSchema: "Cine",
                        principalTable: "tblPeliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasActores",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Personaje = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasActores", x => new { x.PeliculaId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_PeliculasActores_tblActor_ActorId",
                        column: x => x.ActorId,
                        principalSchema: "Cine",
                        principalTable: "tblActor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_tblPeliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalSchema: "Cine",
                        principalTable: "tblPeliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSalaCine",
                schema: "Cine",
                columns: table => new
                {
                    PeliculasId = table.Column<int>(type: "int", nullable: false),
                    SalasCinesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSalaCine", x => new { x.PeliculasId, x.SalasCinesId });
                    table.ForeignKey(
                        name: "FK_PeliculaSalaCine_tblPeliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalSchema: "Cine",
                        principalTable: "tblPeliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSalaCine_tblSalaCines_SalasCinesId",
                        column: x => x.SalasCinesId,
                        principalSchema: "Cine",
                        principalTable: "tblSalaCines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_PeliculasId",
                schema: "Cine",
                table: "GeneroPelicula",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_ActorId",
                table: "PeliculasActores",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSalaCine_SalasCinesId",
                schema: "Cine",
                table: "PeliculaSalaCine",
                column: "SalasCinesId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCineOferta_CineId",
                schema: "Cine",
                table: "TblCineOferta",
                column: "CineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblSalaCines_CineId",
                schema: "Cine",
                table: "tblSalaCines",
                column: "CineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroPelicula",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "PeliculaSalaCine",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "TblCineOferta",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "tblGenero",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "tblActor",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "tblPeliculas",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "tblSalaCines",
                schema: "Cine");

            migrationBuilder.DropTable(
                name: "tblCine",
                schema: "Cine");
        }
    }
}
