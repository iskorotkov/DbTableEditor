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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: fields; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fields (
    table_name character varying NOT NULL,
    field_name character varying NOT NULL,
    friendly_name character varying
);


ALTER TABLE public.fields OWNER TO postgres;

--
-- Data for Name: fields; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'empire_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'star_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('shipyards', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('shipyards', 'planet_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'fleet_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'shipyard_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('fleets', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('fleets', 'status_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('fleets', 'commander_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('government_types', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('ranks', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('commanders', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('commanders', 'rank_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('star_types', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('stars', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('stars', 'type_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('statuses', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('empires', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('empires', 'government_type_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances_entries', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances_entries', 'alliance_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances_entries', 'empire_id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'id', NULL);
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('empires', 'name', 'Название империи');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('empires', 'power', 'Мощь империи');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('empires', 'ruler', 'Правитель империи');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances', 'power', 'Мощь альянса');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances', 'name', 'Название альянса');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'name', 'Название планеты');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'speed', 'Скорость корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'capacity', 'Вместительность корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('shipyards', 'staff', 'Персонал верфи');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('shipyards', 'pipelines', 'Конвейеры верфи');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('stars', 'size', 'Размер звезды');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'energy', 'Энергия корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'name', 'Название корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('shipyards', 'name', 'Название верфи');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('stars', 'name', 'Название звезды');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('statuses', 'name', 'Статус флота');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('star_types', 'name', 'Тип звезды');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'weight', 'Вес корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('stars', 'age', 'Возраст звезды');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'fuel', 'Топливо корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'staff', 'Персонал корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'hull', 'Прочность корпуса корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('government_types', 'name', 'Тип правления');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('commanders', 'gender', 'Пол командира');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('commanders', 'age', 'Возраст командира');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('ranks', 'name', 'Ранг командира');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('alliances_entries', 'entry_year', 'Год вступления');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'population', 'Население планеты');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'size', 'Размер планеты');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'habitability', 'Пригодность планеты для жизни');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('fleets', 'name', 'Название флота');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('commanders', 'skill', 'Уровень навыка командира');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('commanders', 'name', 'Имя командира');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('spaceships', 'firepower', 'Военная мощь корабля');
INSERT INTO public.fields (table_name, field_name, friendly_name) VALUES ('planets', 'approval', 'Уровень одобрения планеты');


--
-- Name: fields_friendly_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX fields_friendly_name_uindex ON public.fields USING btree (friendly_name);


--
-- Name: fields_table_name_field_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX fields_table_name_field_name_uindex ON public.fields USING btree (table_name, field_name);


--
-- PostgreSQL database dump complete
--

