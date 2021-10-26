CREATE table category (
	id int identity(1,1) primary key,
	cat_name varchar(50) not null
	);
	
CREATE table product (
	id int identity(1,1) primary key,
	prod_number int,
	prod_name varchar(50) not null,
	prod_price money not null,
	prod_description text,
)

create table prod_cat (
	id int identity(1,1) primary key,
	prod_id int not null FOREIGN KEY references product (id),
	cat_id int not null foreign key references category (id)
)
-------
create table customer (
	id int IDENTITY(1,1) PRIMARY KEY,
	cust_number int not null,
	cust_name varchar(50) not null,
	cust_address varchar(250) not null,
	cust_email varchar(50) not null,
	cust_phone int not null,
)

create table storefront (
	id int IDENTITY(1,1) primary key,
	store_name varchar(100) not null,
	store_address varchar(250) not null,
	store_phone int not null
)

create table s_order (
	id int identity(1,1) primary key,
	store_id int not null FOREIGN KEY references storefront (id),
	cust_id int not null FOREIGN KEY REFERENCES customer (id), 
	order_number int not null,
	total_price money not null
)

create table line_item (
	id int identity(1,1) primary key,
	order_id int not null FOREIGN KEY REFERENCES s_order (id),
	prod_id int not null FOREIGN KEY REFERENCES product (id),
	quantity int not null
)

create table inventory (
	id int IDENTITY(1,1) PRIMARY KEY,
	store_id int not null FOREIGN KEY REFERENCES storefront (id),
	prod_id int not null FOREIGN KEY REFERENCES product (id),
	quantity int not null
)


insert into category (cat_name)
	values ('Toys');
insert into category (cat_name)
	values ('Gadgets');
insert into product (prod_number, prod_name, prod_price, prod_description)
	values (112342, 'Knick Knack', $9.99, 'A Knick Knack for Paddy Whacking.');
insert into product (prod_number, prod_name, prod_price, prod_description)
	values (112343, 'Paddy Whack', $12.99, 'A Paddy Whack for Knick Knacking.');
insert into product (prod_number, prod_name, prod_price, prod_description)
	values (112451, 'Go-Yo', $4.99, 'A deluxe Yo-Yo.');


insert into prod_cat  (prod_id, cat_id)
	values (1, 1);
insert into prod_cat (prod_id, cat_id)
	values (1,2);
insert into prod_cat (prod_id, cat_id)
	values (2,1);
insert into prod_cat (prod_id, cat_id)
	values (2,2);
insert into prod_cat (prod_id, cat_id)
	values (3,1);

insert into customer (cust_number, cust_name, cust_address, cust_email, cust_phone) 
	VALUES (100, 'Test Customer', '123 Test Way Apt 3, Test TS, 00000', 'test@test.com', 1234567890);
insert into storefront (store_name, store_address, store_phone)
	VALUES ('Test Store', '456 Test Way Suite 5, Test TS, 00000', 1234567890);
insert into s_order (store_id, cust_id, order_number, total_price)
	VALUES (1, 1, 1, $9.99);
insert into line_item (order_id, prod_id, quantity)
	VALUES (1, 1, 1);
insert into inventory (store_id, prod_id, quantity)
	VALUES (1, 1, 10);

--drop table inventory, line_item, s_order, storefront, customer, prod_cat, product, category;