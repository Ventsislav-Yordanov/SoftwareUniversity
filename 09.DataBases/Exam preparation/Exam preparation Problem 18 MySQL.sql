-- Part V – Database Schema Design
-- Problem 18.	Design a Database Schema in MySQL and Write a Query
-- 1.	Design a MySQL database "orders" to hold products, customers and orders. 
-- Products hold name and price. Customers hold name. Orders hold customer, date and set of order items. 
-- Order items hold product and quantity. All tables should have auto-increment primary key – id.
DROP DATABASE IF EXISTS `orders`;

CREATE DATABASE `orders` CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `orders`;

DROP TABLE IF EXISTS `products`;

create table `products` (
	`id` INT(11) NOT NULL auto_increment,
    `name` varchar(45) not null,
    `price` decimal(10,2) not null,
    primary key (`id`)
);

DROP TABLE IF EXISTS `customers`;

create table `customers` (
	`id` int(11) not null auto_increment,
    `name` varchar(45) not null,
    primary key(`id`)
);

DROP TABLE IF EXISTS `orders`;

create table `orders` (
	`id` int(11) not null auto_increment,
    `date` datetime not null,
    primary key(`id`)
);

DROP TABLE IF EXISTS `order_items`;

create table `order_items` (
	`id` int(11) not null auto_increment,
    `order_id` int(11) not null,
    `product_id` int(11) not null,
    `quantity` decimal(10,2),
    primary key(`id`),
    constraint `fk_order_items_orders` foreign key(`order_id`) references `orders`(`id`) 
		on delete no action on update no action,
	constraint `fk_product_items_orders` foreign key(`product_id`) references `products`(`id`)
		on delete no action on update no action
);

-- 2.	Execute the following SQL script to load data in your tables. It should pass without any errors
INSERT INTO `products` VALUES (1,'beer',1.20), (2,'cheese',9.50), (3,'rakiya',12.40), (4,'salami',6.33), (5,'tomatos',2.50), (6,'cucumbers',1.35), (7,'water',0.85), (8,'apples',0.75);
INSERT INTO `customers` VALUES (1,'Peter'), (2,'Maria'), (3,'Nakov'), (4,'Vlado');
INSERT INTO `orders` VALUES (1,'2015-02-13 13:47:04'), (2,'2015-02-14 22:03:44'), (3,'2015-02-18 09:22:01'), (4,'2015-02-11 20:17:18');
INSERT INTO `order_items` VALUES (12,4,6,2.00), (13,3,2,4.00), (14,3,5,1.50), (15,2,1,6.00), (16,2,3,1.20), (17,1,2,1.00), (18,1,3,1.00), (19,1,4,2.00), (20,1,5,1.00), (21,3,1,4.00), (22,1,1,3.00);

-- 3.	Write a SQL query to list all products alphabetically along with the number of orders for each product
-- , the quantity sold (for all orders), the product price, and the total price (quantity * price). 
select 
	p.name as product_name,
    count(oi.id) as num_orders,
    ifnull(sum(oi.quantity), 0) as quantity,
    p.price,
    (ifnull(sum(oi.quantity) * p.price, 0)) as total_price
from products p
left join order_items oi on oi.product_id = p.id
group by p.name