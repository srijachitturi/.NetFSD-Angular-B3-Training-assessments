--Level-2: Problem 3 – Store Performance and Stock Validation
USE Auto_Db;

--CREATE TABLES

CREATE TABLE stores1
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE products1
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    is_discontinued BIT
);

CREATE TABLE orders1
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE
);

CREATE TABLE order_items1
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(5,2)
);

CREATE TABLE stocks1
(
    store_id INT,
    product_id INT,
    quantity INT
);

--INSERT SAMPLE DATA 

INSERT INTO stores1 VALUES
(1,'Hyderabad Store'),
(2,'Vizag Store');

INSERT INTO products1 VALUES
(101,'Helmet Pro',0),
(102,'Riding Gloves',1),
(103,'Bike Cover',0),
(104,'Phone Mount',0);

INSERT INTO orders1 VALUES
(1001,1,'2026-03-01'),
(1002,1,'2026-03-02'),
(1003,2,'2026-03-02');

INSERT INTO order_items1 VALUES
(1,1001,101,2,2000,0.10),
(2,1001,102,1,3000,0),
(3,1002,103,3,1500,0.20),
(4,1003,102,2,3000,0.10),
(5,1003,104,1,1000,0);

INSERT INTO stocks1 VALUES
(1,101,5),
(1,102,7),
(1,103,0),
(1,104,10),
(2,101,0),
(2,102,4),
(2,104,0);

--UPDATE STOCK FOR DISCONTINUED PRODUCTS 

UPDATE s
SET s.quantity = 0
FROM stocks1 s
JOIN products1 p
ON s.product_id = p.product_id
WHERE p.is_discontinued = 1;

--INTERSECT (Sold and Still in Stock) 

SELECT store_id, product_id
FROM
(
    SELECT o.store_id, oi.product_id
    FROM orders1 o
    JOIN order_items1 oi
    ON o.order_id = oi.order_id

    INTERSECT

    SELECT store_id, product_id
    FROM stocks1
    WHERE quantity > 0
) t;

--FINAL QUERY – Sold but Currently Zero Stock 

SELECT
    st.store_name,
    p.product_name,
    sold.total_quantity_sold,
    sold.total_revenue
FROM
(
    SELECT
        o.store_id,
        oi.product_id,
        SUM(oi.quantity) AS total_quantity_sold,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_revenue
    FROM orders1 o
    JOIN order_items1 oi
      ON o.order_id = oi.order_id
    GROUP BY o.store_id, oi.product_id
) sold
JOIN stores1 st ON st.store_id = sold.store_id
JOIN products1 p ON p.product_id = sold.product_id
WHERE EXISTS
(
    SELECT 1
    FROM
    (
        SELECT o2.store_id, oi2.product_id
        FROM orders1 o2
        JOIN order_items1 oi2
        ON o2.order_id = oi2.order_id

        EXCEPT

        SELECT store_id, product_id
        FROM stocks1
        WHERE quantity > 0
    ) x
    WHERE x.store_id = sold.store_id
    AND x.product_id = sold.product_id
);