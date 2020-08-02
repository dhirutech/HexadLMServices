CREATE SCHEMA hexad;

CREATE TABLE hexad.user (
	user_id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	user_name text NOT NULL,
	password text NOT NULL,	
	first_name text NOT NULL,
	las_name text NOT NULL,
	email text NOT NULL,
	phone text NULL,
	address text NOT NULL,
	dob timestamp NULL,	
	isactive bool NOT NULL DEFAULT true,
	created_date timestamp NULL,
	created_by int4 NULL,
	updated_date timestamp NULL,
	updated_by int4 NULL,
	CONSTRAINT user_pkey PRIMARY KEY (user_id)
);

CREATE TABLE hexad.role (
	role_id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	role_name text NOT NULL,
	is_active bool NOT NULL DEFAULT true,
	created_date timestamp NULL,
	created_by int4 NULL,
	updated_date timestamp NULL,
	updated_by int4 NULL,
	CONSTRAINT role_pkey PRIMARY KEY (role_id)
);

CREATE TABLE hexad.user_role (
	user_role_id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	user_id int4 NOT NULL,
	role_id int4 NOT NULL,
	created_date timestamp NULL,
	created_by int4 NULL,
	updated_date timestamp NULL,
	updated_by int4 NULL,
	CONSTRAINT user_role_pkey PRIMARY KEY (user_role_id),
	CONSTRAINT user_role_user_fkey FOREIGN KEY (user_id) REFERENCES hexad.user(user_id),
	CONSTRAINT user_role_role_fkey FOREIGN KEY (role_id) REFERENCES hexad.role(role_id)
);

CREATE TABLE hexad.book (
	book_id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	title text NOT NULL,
	author text NULL,
	isbn text NULL,
	publication text NULL,
	yearofpub timestamp NULL,
	is_active bool NOT NULL DEFAULT true,
	created_date timestamp NULL,
	created_by int4 NULL,
	updated_date timestamp NULL,
	updated_by int4 NULL,
	CONSTRAINT book_pkey PRIMARY KEY (book_id)
);

CREATE TABLE hexad.book_store (
	book_store_id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	book_id int4 NOT NULL,
	stock_count int4 NOT NULL,
	created_date timestamp NULL,
	created_by int4 NULL,
	updated_date timestamp NULL,
	updated_by int4 NULL,
	CONSTRAINT pk_book_store PRIMARY KEY (book_store_id),
	CONSTRAINT book_store_book_fkey FOREIGN KEY (book_id) REFERENCES hexad.book(book_id)
);

CREATE TABLE hexad.user_book (
	user_book_id int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	user_id int4 NOT NULL,
	book_id int4 NOT NULL,
	created_date timestamp NULL,
	created_by int4 NULL,
	updated_date timestamp NULL,
	updated_by int4 NULL,
	CONSTRAINT pk_user_book PRIMARY KEY (user_book_id),
	CONSTRAINT user_book_user_fkey FOREIGN KEY (user_id) REFERENCES hexad.user(user_id),
	CONSTRAINT user_book_book_fkey FOREIGN KEY (book_id) REFERENCES hexad.book(book_id)
);