----PROBLEM1 
use EventDb;
CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(20),
    last_name VARCHAR(20),
    order_id INT,

    FOREIGN KEY(order_id) REFERENCES orders(order_id)
);
CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    order_date DATE,
    order_status INT,
);

-- Insert
INSERT INTO orders VALUES
(101, '2026-01-10', 1),
(102, '2026-01-12', 2),
(103, '2026-01-15', 1),
(104, '2026-01-18', 4),
(105, '2026-01-20', 3);
INSERT INTO customers VALUES
(1, 'Rahul', 'Sharma', 101),
(2, 'Priya', 'Reddy', 102),
(3, 'Amit', 'Verma', 103),
(4, 'Sneha', 'Patel', 104),
(5, 'Kiran', 'Kumar', 105);

--
SELECT c.first_name,
       c.last_name,
       o.order_id,
       o.order_date,
       o.order_status
FROM customers c
INNER JOIN orders o
ON c.order_id = o.order_id
WHERE o.order_status = 1
  OR  o.order_status = 4
ORDER BY o.order_date DESC;

--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------
----PROBLEM2
CREATE TABLE brands
(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);
CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);


--INSERT SAMPLE DATA
INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized'),
(4,'Cannondale');
INSERT INTO categories VALUES
(1,'Mountain Bike'),
(2,'Road Bike'),
(3,'Hybrid Bike');
INSERT INTO products VALUES
(101,'X-Caliber 8',1,1,2022,800),
(102,'Marlin 7',1,1,2021,450),
(103,'Defy Advanced',2,2,2023,1200),
(104,'Allez Elite',3,2,2022,950),
(105,'Quick CX 3',4,3,2023,650),
(106,'Escape 3',2,3,2021,400);
---QUERY
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
ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;



