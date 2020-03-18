using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbTableEditor.AspNetApp.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alliances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    power = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alliances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "government_types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_government_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "star_types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_star_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "empires",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    government_type_id = table.Column<int>(nullable: false),
                    power = table.Column<int>(nullable: false),
                    ruler = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empires", x => x.id);
                    table.ForeignKey(
                        name: "empires_government_types_id_fk",
                        column: x => x.government_type_id,
                        principalTable: "government_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "commanders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    gender = table.Column<string>(type: "character varying", nullable: false),
                    age = table.Column<int>(nullable: false),
                    rank_id = table.Column<int>(nullable: false),
                    skill = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commanders", x => x.id);
                    table.ForeignKey(
                        name: "commanders_ranks_id_fk",
                        column: x => x.rank_id,
                        principalTable: "ranks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    age = table.Column<long>(nullable: false),
                    size = table.Column<int>(nullable: false),
                    type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stars", x => x.id);
                    table.ForeignKey(
                        name: "stars_star_types_id_fk",
                        column: x => x.type_id,
                        principalTable: "star_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "alliances_entries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false, defaultValueSql: "nextval('alliance_entries_id_seq'::regclass)"),
                    alliance_id = table.Column<int>(nullable: false),
                    empire_id = table.Column<int>(nullable: false),
                    entry_year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alliances_entries", x => x.id);
                    table.ForeignKey(
                        name: "alliance_entries_alliances_id_fk",
                        column: x => x.alliance_id,
                        principalTable: "alliances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "alliance_entries_empires_id_fk",
                        column: x => x.empire_id,
                        principalTable: "empires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fleets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    commander_id = table.Column<int>(nullable: false),
                    status_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fleets", x => x.id);
                    table.ForeignKey(
                        name: "fleets_commanders_id_fk",
                        column: x => x.commander_id,
                        principalTable: "commanders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fleets___fk",
                        column: x => x.status_id,
                        principalTable: "statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "planets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    approval = table.Column<int>(nullable: true),
                    empire_id = table.Column<int>(nullable: true),
                    habitability = table.Column<int>(nullable: false),
                    population = table.Column<long>(nullable: false),
                    size = table.Column<int>(nullable: false),
                    star_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planets", x => x.id);
                    table.ForeignKey(
                        name: "planets_empires_id_fk",
                        column: x => x.empire_id,
                        principalTable: "empires",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "planets_stars_id_fk",
                        column: x => x.star_id,
                        principalTable: "stars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shipyards",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    pipelines = table.Column<int>(nullable: false),
                    planet_id = table.Column<int>(nullable: false),
                    staff = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipyards", x => x.id);
                    table.ForeignKey(
                        name: "shipyards_planets_id_fk",
                        column: x => x.planet_id,
                        principalTable: "planets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "spaceships",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    capacity = table.Column<int>(nullable: false),
                    energy = table.Column<int>(nullable: false),
                    firepower = table.Column<int>(nullable: false),
                    fleet_id = table.Column<int>(nullable: false),
                    fuel = table.Column<int>(nullable: false),
                    hull = table.Column<int>(nullable: false),
                    shipyard_id = table.Column<int>(nullable: false),
                    speed = table.Column<int>(nullable: false),
                    staff = table.Column<int>(nullable: false),
                    weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spaceships", x => x.id);
                    table.ForeignKey(
                        name: "spaceships_fleets_id_fk",
                        column: x => x.fleet_id,
                        principalTable: "fleets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "spaceships_shipyards_id_fk",
                        column: x => x.shipyard_id,
                        principalTable: "shipyards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "alliances_name_uindex",
                table: "alliances",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_alliances_entries_empire_id",
                table: "alliances_entries",
                column: "empire_id");

            migrationBuilder.CreateIndex(
                name: "alliance_entries_alliance_id_empire_id_uindex",
                table: "alliances_entries",
                columns: new[] { "alliance_id", "empire_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_commanders_rank_id",
                table: "commanders",
                column: "rank_id");

            migrationBuilder.CreateIndex(
                name: "IX_empires_government_type_id",
                table: "empires",
                column: "government_type_id");

            migrationBuilder.CreateIndex(
                name: "empires_name_uindex",
                table: "empires",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fleets_commander_id_uindex",
                table: "fleets",
                column: "commander_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fleets_name_uindex",
                table: "fleets",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_fleets_status_id",
                table: "fleets",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "government_types_name_uindex",
                table: "government_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_planets_empire_id",
                table: "planets",
                column: "empire_id");

            migrationBuilder.CreateIndex(
                name: "planets_name_uindex",
                table: "planets",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_planets_star_id",
                table: "planets",
                column: "star_id");

            migrationBuilder.CreateIndex(
                name: "ranks_name_uindex",
                table: "ranks",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "shipyards_name_uindex",
                table: "shipyards",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "shipyards_planet_id_uindex",
                table: "shipyards",
                column: "planet_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_spaceships_fleet_id",
                table: "spaceships",
                column: "fleet_id");

            migrationBuilder.CreateIndex(
                name: "spaceships_name_uindex",
                table: "spaceships",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_spaceships_shipyard_id",
                table: "spaceships",
                column: "shipyard_id");

            migrationBuilder.CreateIndex(
                name: "star_types_name_uindex",
                table: "star_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "stars_name_uindex",
                table: "stars",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stars_type_id",
                table: "stars",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "statuses_name_uindex",
                table: "statuses",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alliances_entries");

            migrationBuilder.DropTable(
                name: "spaceships");

            migrationBuilder.DropTable(
                name: "alliances");

            migrationBuilder.DropTable(
                name: "fleets");

            migrationBuilder.DropTable(
                name: "shipyards");

            migrationBuilder.DropTable(
                name: "commanders");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "planets");

            migrationBuilder.DropTable(
                name: "ranks");

            migrationBuilder.DropTable(
                name: "empires");

            migrationBuilder.DropTable(
                name: "stars");

            migrationBuilder.DropTable(
                name: "government_types");

            migrationBuilder.DropTable(
                name: "star_types");
        }
    }
}
