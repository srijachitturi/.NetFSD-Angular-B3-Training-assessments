CREATE Database Auto_db;
USE Auto_db;

--Level-1: Problem 1 – Product Analysis Using Nested Queries
-- CREATING TABLE
CREATE TABLE dbo.categories
(
    category_id   INT PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL
);

CREATE TABLE dbo.products
(
    product_id    INT PRIMARY KEY,
    product_name  VARCHAR(100) NOT NULL,
    category_id   INT NOT NULL,
    model_year    INT NOT NULL,
    list_price    DECIMAL(10,2) NOT NULL
);

--INSERT DATA
INSERT INTO dbo.categories (category_id, category_name) VALUES
(1,'Sedan'),
(2,'Sports Bike'),
(3,'SUV');

INSERT INTO dbo.products (product_id, product_name, category_id, model_year, list_price) VALUES
-- Sedan (avg = (18000 + 22000 + 26000)/3 = 22000)
(1,'Toyota Corolla',1,2017,18000.00),
(2,'Honda Civic',   1,2018,22000.00),
(3,'Skoda Octavia', 1,2019,26000.00),

-- Sports Bike (avg = (150000 + 220000 + 180000)/3 = 183333.33)
(4,'Yamaha R15',    2,2019,150000.00),
(5,'Kawasaki Ninja',2,2018,220000.00),
(6,'Honda CBR',     2,2017,180000.00),

-- SUV (avg = (30000 + 45000 + 38000)/3 = 37666.67)
(7,'Hyundai Creta', 3,2019,30000.00),
(8,'Toyota Fortuner',3,2018,45000.00),
(9,'Kia Seltos',    3,2020,38000.00);


SELECT
    CONCAT(p.product_name,' (',p.model_year,')') AS ProductDetails,
    p.product_name,
    p.model_year,
    p.list_price,

    (SELECT AVG(p2.list_price)
     FROM products p2
     WHERE p2.category_id = p.category_id) AS CategoryAverage,

    p.list_price -
    (SELECT AVG(p3.list_price)
     FROM products p3
     WHERE p3.category_id = p.category_id) AS PriceDifference

FROM products p
WHERE p.list_price >
      (SELECT AVG(p4.list_price)
       FROM products p4
       WHERE p4.category_id = p.category_id);