--Level-2: Problem 4 – Order Cleanup and Data Maintenance
Use Auto_db;

--CREATING TABLES

CREATE TABLE customers2
(
    customer_id INT PRIMARY KEY,
    first_name  VARCHAR(50),
    last_name   VARCHAR(50)
);

CREATE TABLE orders2
(
    order_id      INT PRIMARY KEY,
    customer_id   INT NOT NULL,
    order_status  INT NOT NULL,          -- 3 = Rejected 
    order_date    DATE NOT NULL,
    required_date DATE NOT NULL,
    shipped_date  DATE NULL
);

CREATE TABLE order_items2
(
    order_item_id INT PRIMARY KEY,
    order_id      INT NOT NULL,
    product_name  VARCHAR(100),
    quantity      INT,
    unit_price    DECIMAL(10,2)
);

CREATE TABLE archived_orders2
(
    order_id      INT,
    customer_id   INT,
    order_status  INT,
    order_date    DATE,
    required_date DATE,
    shipped_date  DATE,
    archived_on   DATETIME
);

--INSERT DATA

INSERT INTO customers2 VALUES
(1,'Srija','Chowdary'),
(2,'Arjun','Reddy'),
(3,'Mahesh','Babu');

INSERT INTO orders2 VALUES
(1001,1,4,'2026-02-01','2026-02-05','2026-02-04'), -- On Time
(1002,1,4,'2026-01-10','2026-01-15','2026-01-16'), -- Delayed
(1003,2,3,'2024-01-15','2024-01-20',NULL),         -- Rejected + older than 1 year (archive + delete)
(1004,2,4,'2026-02-20','2026-02-25','2026-02-23'), -- On Time
(1005,3,2,'2026-02-10','2026-02-14',NULL);         -- Not completed

INSERT INTO order_items2 VALUES
(1,1001,'Helmet',2,2000),
(2,1002,'Cover', 2,1500),
(3,1003,'Mount', 1,5000),
(4,1004,'Jacket',1,6000),
(5,1005,'Oil',   2,2000);

 --Archive rejected orders older than 1 year
 --INSERT INTO SELECT

INSERT INTO archived_orders2
(
    order_id, customer_id, order_status,
    order_date, required_date, shipped_date,
    archived_on
)
SELECT
    o.order_id, o.customer_id, o.order_status,
    o.order_date, o.required_date, o.shipped_date,
    GETDATE()
FROM orders2 o
WHERE o.order_status = 3
  AND o.order_date < DATEADD(YEAR, -1, GETDATE());

 --Delete rejected orders older than 1 year
 --DELETE with nested query
 --Delete child rows first

DELETE FROM order_items2
WHERE order_id IN
(
    SELECT o.order_id
    FROM orders2 o
    WHERE o.order_status = 3
      AND o.order_date < DATEADD(YEAR, -1, GETDATE())
);

DELETE FROM orders2
WHERE order_id IN
(
    SELECT o.order_id
    FROM orders2 o
    WHERE o.order_status = 3
      AND o.order_date < DATEADD(YEAR, -1, GETDATE())
);
GO

 --Customers whose ALL orders are completed
 --Nested query (assume Completed = 4 for this sample data)

SELECT
    c.customer_id,
    c.first_name + ' ' + c.last_name AS FullName
FROM customers2 c
WHERE EXISTS
(
    SELECT 1
    FROM orders2 o
    WHERE o.customer_id = c.customer_id
)
AND NOT EXISTS
(
    SELECT 1
    FROM orders2 o
    WHERE o.customer_id = c.customer_id
      AND o.order_status <> 4
);
GO

-- Processing delay = DATEDIFF(DAY, order_date, shipped_date)
-- Delivery flag based on required_date using CASE

SELECT
    o.order_id,
    c.first_name + ' ' + c.last_name AS FullName,
    o.order_status,
    o.order_date,
    o.required_date,
    o.shipped_date,
    DATEDIFF(DAY, o.order_date, o.shipped_date) AS ProcessingDelayDays,
    CASE
        WHEN o.shipped_date > o.required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS DeliveryFlag
FROM orders2 o
JOIN customers2 c
ON c.customer_id = o.customer_id
WHERE o.shipped_date IS NOT NULL
ORDER BY o.order_id;
