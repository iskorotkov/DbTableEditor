using DbTableEditor.Data.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbTableEditor.AspNetApp.Migrations
{
    public partial class Populatewithdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO public.alliances (id, power, name) VALUES (1, 341, 'Holy League');
INSERT INTO public.alliances (id, power, name) VALUES (2, 434, 'Strong Alliance');
INSERT INTO public.alliances (id, power, name) VALUES (3, 34234, 'Defenders');
INSERT INTO public.alliances (id, power, name) VALUES (4, 5235, 'Hegemony');
INSERT INTO public.alliances (id, power, name) VALUES (5, 3423, 'Galactic Union');

INSERT INTO public.government_types (id, name) VALUES (1, 'Republic');
INSERT INTO public.government_types (id, name) VALUES (2, 'Empire');
INSERT INTO public.government_types (id, name) VALUES (3, 'Hivemind');
INSERT INTO public.government_types (id, name) VALUES (4, 'Federation');
INSERT INTO public.government_types (id, name) VALUES (5, 'Democracy');
INSERT INTO public.government_types (id, name) VALUES (6, 'Anarchy');

INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (1, 1, 'Ivanov', 100, 'Galactic Supremacy');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (2, 2, 'Petrov', 120, 'Intergalactic Exchange');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (3, 3, 'Sidorov', 3000, 'Fanatic Purifiers');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (4, 6, NULL, 2000, 'Stagnating Order');

INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (2, 1, 1, 2020);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (3, 1, 2, 2839);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (4, 1, 3, 2452);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (5, 2, 4, 2555);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (6, 2, 3, 3442);

INSERT INTO public.star_types (id, name) VALUES (1, 'Type C');
INSERT INTO public.star_types (id, name) VALUES (2, 'Type G');
INSERT INTO public.star_types (id, name) VALUES (3, 'Type A');

INSERT INTO public.stars (id, type_id, size, age, name) VALUES (1, 1, 4, 4500000000, 'Sol');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (2, 2, 6, 6000000000, 'Alpha Centauri');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (3, 3, 5, 500000000, 'Proxima Centauri');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (4, 2, 8, 8000000000, 'Betelgeuse');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (5, 1, 54, 12000000000, 'Unity');

INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (1, 43, 80, 1000000, 86, 1, 1, 'Mercury');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (2, 23, 80, 25153535, 67, 2, 2, 'Venus');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (3, 43, 56, 532555644, 56, NULL, 3, 'Earth');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (4, 32, 98, 2466243436, 65, 3, 3, 'Mars');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (5, 43, 34, 25325, 76, 4, 4, 'Jupyter');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (6, 15, 67, 0, NULL, NULL, 1, 'Saturn');

INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (5, 1, 2, 4, 'Ship Assemblies');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (2, 65, 54, 5, 'Jupyter Station');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (1, 80, 800, 1, 'Grand Royal Shipyard');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (3, 3, 34, 2, 'Observation Post');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (4, 2, 34, 3, 'Titan Factory');

INSERT INTO public.ranks (id, name) VALUES (1, 'Captain');
INSERT INTO public.ranks (id, name) VALUES (2, 'Commander');
INSERT INTO public.ranks (id, name) VALUES (3, 'Admiral');
INSERT INTO public.ranks (id, name) VALUES (4, 'Grand Admiral');

INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (2, 'Antuan', 90, 'm', 18, 4);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (3, 'Liz', 20, 'f', 12, 3);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (4, 'Allen', 29, 'm', 40, 4);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (5, 'Alina', 46, 'f', 50, 2);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (1, 'Alexander', 34, 'm', 10, 2);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (6, 'Sergey', 99, 'm', 100, 4);

INSERT INTO public.statuses (id, name) VALUES (1, 'Fighting');
INSERT INTO public.statuses (id, name) VALUES (2, 'Repairing');
INSERT INTO public.statuses (id, name) VALUES (3, 'FTL');
INSERT INTO public.statuses (id, name) VALUES (4, 'Standby');
INSERT INTO public.statuses (id, name) VALUES (5, 'Pursue');
INSERT INTO public.statuses (id, name) VALUES (6, 'Fleeing');
INSERT INTO public.statuses (id, name) VALUES (7, 'Patrol');
INSERT INTO public.statuses (id, name) VALUES (8, 'Bombardment');

INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (2, 4, 3, 'Striking Armada');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (3, 2, 2, 'Defending Formation');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (5, 5, 5, 'United Naval Garrison 5544');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (1, 1, 4, 'First Fleet');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (21, 5, 1, 'Ground Assault Fleet');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (28, 1, 6, 'Undestructible Armada');

INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (5, 42, 2, 42, 32, 65, 6, 5, 78, 5, 1, 'Black Pearl');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (2, 12, 43, 42, 4, 43, 4, 65, 45, 3, 1, 'Flagship');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (31, 0, 0, 0, 0, 0, 0, 0, 0, 3, 2, 'ef');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (3, 42, 42, 23, 43, 45, 54, 6, 54, 5, 3, 'Black ');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (4, 42, 4, 32, 43, 7, 54, 65, 6, 5, 4, 'Queen Anne''s Revenge');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (1, 60, 57, 3, 45, 95, 65, 5, 34, 5, 2, 'Escalibur');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (44, 0, 0, 0, 0, 3432, 0, 0, 0, 3, 4, 'Gh');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (33, 1, 1, 0, 2, 0, 0, 0, 0, 1, 2, 'fe');
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DELETE FROM spaceships WHERE id in (1,2,3,4,5,31,33,44);
DELETE FROM fleets WHERE id in (1,2,3,5,21,28);
DELETE FROM statuses WHERE id in (1,2,3,4,5,6,7,8);
DELETE FROM commanders WHERE id in (1,2,3,4,5,6);
DELETE FROM ranks WHERE id in (1,2,3,4);
DELETE FROM shipyards WHERE id in (1,2,3,4,5);
DELETE FROM planets WHERE id in (1,2,3,4,5,6);
DELETE FROM stars WHERE id in (1,2,3,4,5);
DELETE FROM star_types WHERE id in (1,2,3);
DELETE FROM alliances_entries WHERE id in (2,3,4,5,6);
DELETE FROM alliances WHERE id in (1,2,3,4,5);
DELETE FROM empires WHERE id in (1,2,3,4);
DELETE FROM government_types WHERE id in (1,2,3,4,5,6);
                ");
        }
    }
}
