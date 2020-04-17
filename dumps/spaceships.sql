--
-- PostgreSQL database dump
--

-- Dumped from database version 12.1
-- Dumped by pg_dump version 12.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: power_is_not_negative_fn(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.power_is_not_negative_fn() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF new.power < 0 THEN
        RAISE EXCEPTION DATA_EXCEPTION USING MESSAGE = 'Power can''t be negative';
    END IF;
    RETURN new;
END ;
$$;


ALTER FUNCTION public.power_is_not_negative_fn() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Name: alliances_entries; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.alliances_entries (
    id integer NOT NULL,
    alliance_id integer NOT NULL,
    empire_id integer NOT NULL,
    entry_year integer NOT NULL
);


ALTER TABLE public.alliances_entries OWNER TO postgres;

--
-- Name: alliance_entries_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.alliance_entries_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.alliance_entries_id_seq OWNER TO postgres;

--
-- Name: alliance_entries_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.alliance_entries_id_seq OWNED BY public.alliances_entries.id;


--
-- Name: alliances; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.alliances (
    id integer NOT NULL,
    power integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.alliances OWNER TO postgres;

--
-- Name: alliances_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.alliances_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.alliances_id_seq OWNER TO postgres;

--
-- Name: alliances_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.alliances_id_seq OWNED BY public.alliances.id;


--
-- Name: commanders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.commanders (
    id integer NOT NULL,
    name character varying NOT NULL,
    age integer NOT NULL,
    gender character varying NOT NULL,
    skill integer NOT NULL,
    rank_id integer NOT NULL
);


ALTER TABLE public.commanders OWNER TO postgres;

--
-- Name: commanders_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.commanders_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.commanders_id_seq OWNER TO postgres;

--
-- Name: commanders_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.commanders_id_seq OWNED BY public.commanders.id;


--
-- Name: empires; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.empires (
    id integer NOT NULL,
    government_type_id integer NOT NULL,
    ruler character varying,
    power integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.empires OWNER TO postgres;

--
-- Name: empires_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.empires_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.empires_id_seq OWNER TO postgres;

--
-- Name: empires_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.empires_id_seq OWNED BY public.empires.id;


--
-- Name: fleets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fleets (
    id integer NOT NULL,
    status_id integer NOT NULL,
    commander_id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.fleets OWNER TO postgres;

--
-- Name: fleets_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.fleets_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.fleets_id_seq OWNER TO postgres;

--
-- Name: fleets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.fleets_id_seq OWNED BY public.fleets.id;


--
-- Name: government_types; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.government_types (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.government_types OWNER TO postgres;

--
-- Name: government_types_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.government_types_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.government_types_id_seq OWNER TO postgres;

--
-- Name: government_types_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.government_types_id_seq OWNED BY public.government_types.id;


--
-- Name: planets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.planets (
    id integer NOT NULL,
    size integer NOT NULL,
    habitability integer NOT NULL,
    population bigint NOT NULL,
    approval integer,
    empire_id integer,
    star_id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.planets OWNER TO postgres;

--
-- Name: planets_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.planets_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.planets_id_seq OWNER TO postgres;

--
-- Name: planets_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.planets_id_seq OWNED BY public.planets.id;


--
-- Name: ranks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ranks (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.ranks OWNER TO postgres;

--
-- Name: ranks_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ranks_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ranks_id_seq OWNER TO postgres;

--
-- Name: ranks_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ranks_id_seq OWNED BY public.ranks.id;


--
-- Name: shipyards; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.shipyards (
    id integer NOT NULL,
    pipelines integer NOT NULL,
    staff integer NOT NULL,
    planet_id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.shipyards OWNER TO postgres;

--
-- Name: shipyards_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.shipyards_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.shipyards_id_seq OWNER TO postgres;

--
-- Name: shipyards_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.shipyards_id_seq OWNED BY public.shipyards.id;


--
-- Name: spaceships; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.spaceships (
    id integer NOT NULL,
    speed integer NOT NULL,
    capacity integer NOT NULL,
    weight integer NOT NULL,
    energy integer NOT NULL,
    firepower integer NOT NULL,
    hull integer NOT NULL,
    staff integer NOT NULL,
    fuel integer NOT NULL,
    fleet_id integer NOT NULL,
    shipyard_id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.spaceships OWNER TO postgres;

--
-- Name: spaceships_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.spaceships_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.spaceships_id_seq OWNER TO postgres;

--
-- Name: spaceships_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.spaceships_id_seq OWNED BY public.spaceships.id;


--
-- Name: star_types; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.star_types (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.star_types OWNER TO postgres;

--
-- Name: star_types_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.star_types_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.star_types_id_seq OWNER TO postgres;

--
-- Name: star_types_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.star_types_id_seq OWNED BY public.star_types.id;


--
-- Name: stars; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.stars (
    id integer NOT NULL,
    type_id integer NOT NULL,
    size integer NOT NULL,
    age bigint NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.stars OWNER TO postgres;

--
-- Name: stars_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.stars_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.stars_id_seq OWNER TO postgres;

--
-- Name: stars_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.stars_id_seq OWNED BY public.stars.id;


--
-- Name: statuses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.statuses (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.statuses OWNER TO postgres;

--
-- Name: statuses_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.statuses_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.statuses_id_seq OWNER TO postgres;

--
-- Name: statuses_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.statuses_id_seq OWNED BY public.statuses.id;


--
-- Name: alliances id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alliances ALTER COLUMN id SET DEFAULT nextval('public.alliances_id_seq'::regclass);


--
-- Name: alliances_entries id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alliances_entries ALTER COLUMN id SET DEFAULT nextval('public.alliance_entries_id_seq'::regclass);


--
-- Name: commanders id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commanders ALTER COLUMN id SET DEFAULT nextval('public.commanders_id_seq'::regclass);


--
-- Name: empires id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.empires ALTER COLUMN id SET DEFAULT nextval('public.empires_id_seq'::regclass);


--
-- Name: fleets id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fleets ALTER COLUMN id SET DEFAULT nextval('public.fleets_id_seq'::regclass);


--
-- Name: government_types id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.government_types ALTER COLUMN id SET DEFAULT nextval('public.government_types_id_seq'::regclass);


--
-- Name: planets id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.planets ALTER COLUMN id SET DEFAULT nextval('public.planets_id_seq'::regclass);


--
-- Name: ranks id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ranks ALTER COLUMN id SET DEFAULT nextval('public.ranks_id_seq'::regclass);


--
-- Name: shipyards id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shipyards ALTER COLUMN id SET DEFAULT nextval('public.shipyards_id_seq'::regclass);


--
-- Name: spaceships id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spaceships ALTER COLUMN id SET DEFAULT nextval('public.spaceships_id_seq'::regclass);


--
-- Name: star_types id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.star_types ALTER COLUMN id SET DEFAULT nextval('public.star_types_id_seq'::regclass);


--
-- Name: stars id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stars ALTER COLUMN id SET DEFAULT nextval('public.stars_id_seq'::regclass);


--
-- Name: statuses id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statuses ALTER COLUMN id SET DEFAULT nextval('public.statuses_id_seq'::regclass);


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: alliances; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.alliances (id, power, name) VALUES (36, 100000, 'Alliance 2');
INSERT INTO public.alliances (id, power, name) VALUES (37, 0, 'Alliance 3');
INSERT INTO public.alliances (id, power, name) VALUES (38, 10, 'Alliance 4');


--
-- Data for Name: alliances_entries; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (49, 37, 39, 2342);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (50, 38, 41, 42342);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (44, 38, 39, 1);
INSERT INTO public.alliances_entries (id, alliance_id, empire_id, entry_year) VALUES (48, 36, 39, 414222);


--
-- Data for Name: commanders; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (2, 'Antuan', 90, 'm', 18, 4);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (3, 'Liz', 20, 'f', 12, 3);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (4, 'Allen', 29, 'm', 40, 4);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (5, 'Alina', 46, 'f', 50, 2);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (1, 'Alexander', 34, 'm', 10, 2);
INSERT INTO public.commanders (id, name, age, gender, skill, rank_id) VALUES (6, 'Sergey', 99, 'm', 100, 4);


--
-- Data for Name: empires; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (38, 2, NULL, 180, 'Empire 1');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (40, 2, 'Ruler 2', 220, 'Empire 3');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (43, 2, 'Ruler 5', 220, 'Empire 6');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (69, 1, NULL, 520, 'Empire #1002955697');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (39, 1, 'Ruler 1', 260, 'Empire 2');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (42, 2, 'Ruler 4', 220, 'Empire  4');
INSERT INTO public.empires (id, government_type_id, ruler, power, name) VALUES (41, 4, 'Ruler 3 1', 178, 'Empire 4');


--
-- Data for Name: fleets; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (2, 4, 3, 'Striking Armada');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (3, 2, 2, 'Defending Formation');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (5, 5, 5, 'United Naval Garrison 5544');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (21, 5, 1, 'Ground Assault Fleet');
INSERT INTO public.fleets (id, status_id, commander_id, name) VALUES (1, 1, 4, 'First Fleet 2');


--
-- Data for Name: government_types; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.government_types (id, name) VALUES (1, 'Republic');
INSERT INTO public.government_types (id, name) VALUES (2, 'Empire');
INSERT INTO public.government_types (id, name) VALUES (3, 'Hivemind');
INSERT INTO public.government_types (id, name) VALUES (4, 'Federation');
INSERT INTO public.government_types (id, name) VALUES (5, 'Democracy');
INSERT INTO public.government_types (id, name) VALUES (6, 'Anarchy');


--
-- Data for Name: planets; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (7, 1, 1, 1, 1, 38, 1, 'Planet 1');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (10, 43, 34, 234, 41, 39, 1, 'Planet 2');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (11, 4, 3, 34, 43, 38, 2, 'Planet 3');
INSERT INTO public.planets (id, size, habitability, population, approval, empire_id, star_id, name) VALUES (12, 3424, 34, 3, 34, 40, 3, 'Planet 4');


--
-- Data for Name: ranks; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.ranks (id, name) VALUES (1, 'Captain');
INSERT INTO public.ranks (id, name) VALUES (2, 'Commander');
INSERT INTO public.ranks (id, name) VALUES (3, 'Admiral');
INSERT INTO public.ranks (id, name) VALUES (4, 'Grand Admiral');


--
-- Data for Name: shipyards; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (6, 43, 43, 7, 'Shipyard 1');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (7, 2, 342, 10, 'Shipyard 2');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (8, 34, 342, 11, 'Shipyard 3');
INSERT INTO public.shipyards (id, pipelines, staff, planet_id, name) VALUES (9, 12, 423, 12, 'Shipyard 4');


--
-- Data for Name: spaceships; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (63, 45, 32, 324, 3, 34, 234, 34, 23, 1, 8, 'Ship 1');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (64, 234, 234, 234, 54, 2, 34, 4, 23, 2, 9, 'Ship 2');
INSERT INTO public.spaceships (id, speed, capacity, weight, energy, firepower, hull, staff, fuel, fleet_id, shipyard_id, name) VALUES (65, 324, 32, 34, 3, 43, 43, 43, 34, 2, 8, 'Ship 3');


--
-- Data for Name: star_types; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.star_types (id, name) VALUES (1, 'Type C');
INSERT INTO public.star_types (id, name) VALUES (2, 'Type G');
INSERT INTO public.star_types (id, name) VALUES (3, 'Type A');
INSERT INTO public.star_types (id, name) VALUES (12, 'a');


--
-- Data for Name: stars; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.stars (id, type_id, size, age, name) VALUES (1, 1, 4, 4500000000, 'Sol');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (2, 2, 6, 6000000000, 'Alpha Centauri');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (3, 3, 5, 500000000, 'Proxima Centauri');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (4, 2, 8, 8000000000, 'Betelgeuse');
INSERT INTO public.stars (id, type_id, size, age, name) VALUES (5, 1, 54, 12000000000, 'Unity');


--
-- Data for Name: statuses; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.statuses (id, name) VALUES (1, 'Fighting');
INSERT INTO public.statuses (id, name) VALUES (2, 'Repairing');
INSERT INTO public.statuses (id, name) VALUES (3, 'FTL');
INSERT INTO public.statuses (id, name) VALUES (4, 'Standby');
INSERT INTO public.statuses (id, name) VALUES (5, 'Pursue');
INSERT INTO public.statuses (id, name) VALUES (6, 'Fleeing');
INSERT INTO public.statuses (id, name) VALUES (7, 'Patrol');
INSERT INTO public.statuses (id, name) VALUES (8, 'Bombardment');


--
-- Name: alliance_entries_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alliance_entries_id_seq', 51, true);


--
-- Name: alliances_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alliances_id_seq', 38, true);


--
-- Name: commanders_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.commanders_id_seq', 6, true);


--
-- Name: empires_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.empires_id_seq', 71, true);


--
-- Name: fleets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.fleets_id_seq', 33, true);


--
-- Name: government_types_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.government_types_id_seq', 6, true);


--
-- Name: planets_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.planets_id_seq', 12, true);


--
-- Name: ranks_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ranks_id_seq', 4, true);


--
-- Name: shipyards_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.shipyards_id_seq', 9, true);


--
-- Name: spaceships_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.spaceships_id_seq', 65, true);


--
-- Name: star_types_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.star_types_id_seq', 13, true);


--
-- Name: stars_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.stars_id_seq', 5, true);


--
-- Name: statuses_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.statuses_id_seq', 8, true);


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: alliances_entries alliance_entries_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alliances_entries
    ADD CONSTRAINT alliance_entries_pk PRIMARY KEY (id);


--
-- Name: alliances alliances_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alliances
    ADD CONSTRAINT alliances_pk PRIMARY KEY (id);


--
-- Name: commanders commanders_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commanders
    ADD CONSTRAINT commanders_pk PRIMARY KEY (id);


--
-- Name: empires empires_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.empires
    ADD CONSTRAINT empires_pk PRIMARY KEY (id);


--
-- Name: fleets fleets_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fleets
    ADD CONSTRAINT fleets_pk PRIMARY KEY (id);


--
-- Name: government_types government_types_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.government_types
    ADD CONSTRAINT government_types_pk PRIMARY KEY (id);


--
-- Name: planets planets_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.planets
    ADD CONSTRAINT planets_pk PRIMARY KEY (id);


--
-- Name: ranks ranks_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ranks
    ADD CONSTRAINT ranks_pk PRIMARY KEY (id);


--
-- Name: shipyards shipyards_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shipyards
    ADD CONSTRAINT shipyards_pk PRIMARY KEY (id);


--
-- Name: spaceships spaceships_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spaceships
    ADD CONSTRAINT spaceships_pk PRIMARY KEY (id);


--
-- Name: star_types star_types_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.star_types
    ADD CONSTRAINT star_types_pk PRIMARY KEY (id);


--
-- Name: stars stars_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stars
    ADD CONSTRAINT stars_pk PRIMARY KEY (id);


--
-- Name: statuses statuses_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statuses
    ADD CONSTRAINT statuses_pk PRIMARY KEY (id);


--
-- Name: alliance_entries_alliance_id_empire_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX alliance_entries_alliance_id_empire_id_uindex ON public.alliances_entries USING btree (alliance_id, empire_id);


--
-- Name: alliances_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX alliances_name_uindex ON public.alliances USING btree (name);


--
-- Name: empires_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX empires_name_uindex ON public.empires USING btree (name);


--
-- Name: fleets_commander_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX fleets_commander_id_uindex ON public.fleets USING btree (commander_id);


--
-- Name: fleets_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX fleets_name_uindex ON public.fleets USING btree (name);


--
-- Name: government_types_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX government_types_name_uindex ON public.government_types USING btree (name);


--
-- Name: planets_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX planets_name_uindex ON public.planets USING btree (name);


--
-- Name: ranks_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX ranks_name_uindex ON public.ranks USING btree (name);


--
-- Name: shipyards_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX shipyards_name_uindex ON public.shipyards USING btree (name);


--
-- Name: shipyards_planet_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX shipyards_planet_id_uindex ON public.shipyards USING btree (planet_id);


--
-- Name: spaceships_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX spaceships_name_uindex ON public.spaceships USING btree (name);


--
-- Name: star_types_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX star_types_name_uindex ON public.star_types USING btree (name);


--
-- Name: stars_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX stars_name_uindex ON public.stars USING btree (name);


--
-- Name: statuses_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX statuses_name_uindex ON public.statuses USING btree (name);


--
-- Name: empires power_is_not_negative_tg; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER power_is_not_negative_tg BEFORE INSERT OR UPDATE ON public.empires FOR EACH ROW EXECUTE FUNCTION public.power_is_not_negative_fn();


--
-- Name: alliances_entries alliance_entries_alliances_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alliances_entries
    ADD CONSTRAINT alliance_entries_alliances_id_fk FOREIGN KEY (alliance_id) REFERENCES public.alliances(id);


--
-- Name: alliances_entries alliance_entries_empires_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alliances_entries
    ADD CONSTRAINT alliance_entries_empires_id_fk FOREIGN KEY (empire_id) REFERENCES public.empires(id);


--
-- Name: commanders commanders_ranks_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.commanders
    ADD CONSTRAINT commanders_ranks_id_fk FOREIGN KEY (rank_id) REFERENCES public.ranks(id);


--
-- Name: empires empires_government_types_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.empires
    ADD CONSTRAINT empires_government_types_id_fk FOREIGN KEY (government_type_id) REFERENCES public.government_types(id);


--
-- Name: fleets fleets___fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fleets
    ADD CONSTRAINT fleets___fk FOREIGN KEY (status_id) REFERENCES public.statuses(id);


--
-- Name: fleets fleets_commanders_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.fleets
    ADD CONSTRAINT fleets_commanders_id_fk FOREIGN KEY (commander_id) REFERENCES public.commanders(id);


--
-- Name: planets planets_empires_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.planets
    ADD CONSTRAINT planets_empires_id_fk FOREIGN KEY (empire_id) REFERENCES public.empires(id);


--
-- Name: planets planets_stars_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.planets
    ADD CONSTRAINT planets_stars_id_fk FOREIGN KEY (star_id) REFERENCES public.stars(id);


--
-- Name: shipyards shipyards_planets_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shipyards
    ADD CONSTRAINT shipyards_planets_id_fk FOREIGN KEY (planet_id) REFERENCES public.planets(id);


--
-- Name: spaceships spaceships_fleets_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spaceships
    ADD CONSTRAINT spaceships_fleets_id_fk FOREIGN KEY (fleet_id) REFERENCES public.fleets(id);


--
-- Name: spaceships spaceships_shipyards_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spaceships
    ADD CONSTRAINT spaceships_shipyards_id_fk FOREIGN KEY (shipyard_id) REFERENCES public.shipyards(id);


--
-- Name: stars stars_star_types_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.stars
    ADD CONSTRAINT stars_star_types_id_fk FOREIGN KEY (type_id) REFERENCES public.star_types(id);


--
-- PostgreSQL database dump complete
--

