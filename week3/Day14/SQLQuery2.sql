--Level-1: Problem 2 – Customer Activity Classification
USE Auto_Db;

-- Create Customers table
CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

-- Create Orders table
CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_value DECIMAL(10,2)
);

-- Insert sample customers
INSERT INTO customers VALUES
(1,'John','Smith'),
(2,'Emma','Brown'),
(3,'David','Wilson'),
(4,'Sophia','Taylor'),
(5,'Liam','Martin');

-- Insert sample orders
INSERT INTO orders VALUES
(101,1,4000),
(102,1,7000),
(103,2,3000),
(104,3,6000),
(105,3,5000);

-- Customers WITH orders(Query)
SELECT
    CONCAT(c.first_name,' ',c.last_name) AS FullName,
    t.TotalOrderValue,
    CASE
        WHEN t.TotalOrderValue > 10000 THEN 'Premium'
        WHEN t.TotalOrderValue BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS CustomerCategory
FROM customers c
JOIN
(
    SELECT customer_id,
           SUM(order_value) AS TotalOrderValue
    FROM orders
    GROUP BY customer_id
) t
ON c.customer_id = t.customer_id

UNION

-- Customers WITHOUT orders
SELECT
    CONCAT(c.first_name,' ',c.last_name) AS FullName,
    0 AS TotalOrderValue,
    'Basic' AS CustomerCategory
FROM customers c
LEFT JOIN orders o
ON c.customer_id = o.customer_id
WHERE o.customer_id IS NULL;