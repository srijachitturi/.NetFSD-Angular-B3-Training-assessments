--Create Database
CREATE DATABASE SalesDB;
USE SalesDB;

--Create Tables
CREATE TABLE stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    order_status INT
);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price MONEY,
    discount FLOAT
);

--Insert Sample Data
INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Bangalore Store');

INSERT INTO products VALUES
(101,'Laptop'),
(102,'Mobile'),
(103,'Keyboard'),
(104,'Mouse'),
(105,'Monitor');

INSERT INTO orders VALUES
(1,1,'2026-03-01',4),
(2,1,'2026-03-02',4),
(3,2,'2026-03-03',4);

INSERT INTO order_items VALUES
(1,1,101,2,50000,0.10),
(2,1,102,1,20000,0.05),
(3,2,101,3,50000,0.10),
(4,2,103,2,2000,0.05),
(5,3,104,5,1000,0.00),
(6,3,105,1,8000,0.15);

--Stored Procedure: Total Sales Per Store

CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
    FROM stores s
    INNER JOIN orders o
        ON s.store_id = o.store_id
    INNER JOIN order_items oi
        ON o.order_id = oi.order_id
    WHERE o.order_status = 4
    GROUP BY s.store_name
END

--Stored Procedure: Orders By Date Range

CREATE PROCEDURE sp_GetOrdersByDate
(
    @StartDate DATE,
    @EndDate DATE
)
AS
BEGIN
    SELECT *
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
END
GO

--Scalar Function: Calculate Price After Discount

CREATE FUNCTION fn_CalculateDiscount
(
    @qty INT,
    @price MONEY,
    @discount FLOAT
)
RETURNS MONEY
AS
BEGIN
    DECLARE @total MONEY

    SET @total = @qty * @price * (1 - @discount)

    RETURN @total
END

--Table Valued Function: Top 5 Selling Products

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS total_quantity
    FROM products p
    INNER JOIN order_items oi
        ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY total_quantity DESC
)

--Execution

EXEC sp_TotalSalesPerStore;

EXEC sp_GetOrdersByDate '2026-03-01','2026-03-10';

SELECT dbo.fn_CalculateDiscount(2,50000,0.10);

SELECT * FROM dbo.fn_Top5SellingProducts();