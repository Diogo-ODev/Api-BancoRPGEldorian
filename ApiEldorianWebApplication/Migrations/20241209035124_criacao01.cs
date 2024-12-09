using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEldorianWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class criacao01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racas",
                columns: table => new
                {
                    idRaca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomeRaca = table.Column<string>(type: "TEXT", nullable: false),
                    descricaoRaca = table.Column<string>(type: "TEXT", nullable: false),
                    sinergiaStatusRaca = table.Column<string>(type: "TEXT", nullable: false),
                    passivaRaca = table.Column<string>(type: "TEXT", nullable: false),
                    beneficioRaca = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racas", x => x.idRaca);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    emailUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    senhaUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    nomeUsuario = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    idPersonagem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomePersonagem = table.Column<string>(type: "TEXT", nullable: false),
                    idNivel = table.Column<int>(type: "INTEGER", nullable: false),
                    xpAtualPersonagem = table.Column<decimal>(type: "TEXT", nullable: false),
                    pesoMaximoPersonagem = table.Column<decimal>(type: "TEXT", nullable: false),
                    idClasse = table.Column<int>(type: "INTEGER", nullable: false),
                    idRaca = table.Column<int>(type: "INTEGER", nullable: false),
                    RacaidRaca = table.Column<int>(type: "INTEGER", nullable: false),
                    idMagia = table.Column<int>(type: "INTEGER", nullable: false),
                    idHabilidade = table.Column<int>(type: "INTEGER", nullable: false),
                    idItemPersonagem = table.Column<int>(type: "INTEGER", nullable: false),
                    idPet = table.Column<int>(type: "INTEGER", nullable: false),
                    vidaPersonagem = table.Column<decimal>(type: "TEXT", nullable: false),
                    manaPersonamge = table.Column<decimal>(type: "TEXT", nullable: false),
                    vigorPersonagem = table.Column<int>(type: "INTEGER", nullable: false),
                    idAtributo = table.Column<int>(type: "INTEGER", nullable: false),
                    idEfeito = table.Column<int>(type: "INTEGER", nullable: false),
                    idUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.idPersonagem);
                    table.ForeignKey(
                        name: "FK_Personagens_Racas_RacaidRaca",
                        column: x => x.RacaidRaca,
                        principalTable: "Racas",
                        principalColumn: "idRaca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personagens_Usuarios_idPersonagem",
                        column: x => x.idPersonagem,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario");
                    table.ForeignKey(
                        name: "FK_Personagens_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_idUsuario",
                table: "Personagens",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_RacaidRaca",
                table: "Personagens",
                column: "RacaidRaca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Racas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
