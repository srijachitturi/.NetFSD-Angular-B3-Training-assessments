-- Level-1 Problem 1: Basic Setup and Data Retrieval in EcommDb

CREATE Database EcommDb;
USE EcommDb;

--CREATING TABLES
-- Categories table
CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

-- Brands table
CREATE TABLE brands
(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);

-- Products table
CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(150) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

-- Customers table
CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(150),
    street VARCHAR(200),
    city VARCHAR(100),
    state VARCHAR(100),
    zip_code VARCHAR(20)
);

-- Stores table
CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(150),
    phone VARCHAR(20),
    email VARCHAR(150),
    street VARCHAR(200),
    city VARCHAR(100),
    state VARCHAR(100),
    zip_code VARCHAR(20)
);

--Insert Data
-- Categories
INSERT INTO categories VALUES
(1,'Sedan'),
(2,'SUV'),
(3,'Hatchback'),
(4,'Electric'),
(5,'Luxury');

-- Brands
INSERT INTO brands VALUES
(1,'Toyota'),
(2,'Honda'),
(3,'Hyundai'),
(4,'Tata'),
(5,'BMW');

-- Products
INSERT INTO products VALUES
(101,'Toyota Camry',1,1,2024,35000),
(102,'Honda CR-V',2,2,2024,42000),
(103,'Hyundai i20',3,3,2023,18000),
(104,'Tata Nexon EV',4,4,2024,22000),
(105,'BMW 5 Series',5,5,2024,65000);

-- Customers
INSERT INTO customers VALUES
(1,'Srija','Chowdary','9876543210','srija@gmail.com','Main Road','Rajahmundry','AP','533101'),
(2,'Mahesh','Babu','9123456780','mahesh@gmail.com','MG Road','Hyderabad','Telangana','500001'),
(3,'Arjun','Reddy','9988776655','arjun@gmail.com','Beach Road','Vizag','AP','530001'),
(4,'Bala','Krishna','9012345678','krish@gmail.com','Park Street','Hyderabad','Telangana','500002'),
(5,'Pawan','Kalyan','9090909090','Pawan@gmail.com','Ring Road','Bangalore','Karnataka','560001');

-- Stores
INSERT INTO stores VALUES
(1,'AutoWorld Rajahmundry','8881112221','raj@auto.com','Danavaipeta','Rajahmundry','AP','533103'),
(2,'AutoWorld Hyderabad','8881112222','hyd@auto.com','Banjara Hills','Hyderabad','Telangana','500034'),
(3,'AutoWorld Vizag','8881112223','vizag@auto.com','MVP Colony','Vizag','AP','530017'),
(4,'AutoWorld Bangalore','8881112224','blr@auto.com','Indiranagar','Bangalore','Karnataka','560038'),
(5,'AutoWorld Chennai','8881112225','chn@auto.com','T Nagar','Chennai','Tamil Nadu','600017');


--Queries

-- 1. Retrieve all products with their brand and category names
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b
ON p.brand_id = b.brand_id
INNER JOIN categories c
ON p.category_id = c.category_id;


-- 2. Retrieve all customers from a specific city
SELECT *
FROM customers
WHERE city = 'Hyderabad';


-- 3. Display total number of products available in each category
SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;