CREATE TABLE offer
(
    id int PRIMARY KEY NOT NULL,
	available boolean NOT NULL,
	price float NOT NULL,
	category_id int NOT NULL,
	name text NOT NULL,
    description	text,
	vendor text,
	barcode bigint NOT NULL,
	parameters hstore
);

CREATE INDEX ON offer
  USING gin(parameters);

CREATE TABLE customer
(
    id serial PRIMARY KEY NOT NULL,
	name text NOT NULL,
	birth timestamp NOT NULL
);

CREATE TABLE purchase
(
    id serial PRIMARY KEY NOT NULL,
	customer_id int NOT NULL,
	datetime timestamp NOT NULL,
	offers int[] NOT NULL
);
