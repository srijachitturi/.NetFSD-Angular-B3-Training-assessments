--Level-1 Problem 2: Creating Views and Indexes for Performance

USE EcommDb;
--CREATE TABLES
CREATE TABLE staffs
(
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    store_id INT
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_status INT,
    order_date DATE
);

--INSERT DATA
INSERT INTO staffs VALUES
(1,'Pavan','Kumar',1),
(2,'Ravi','Teja',2),
(3,'Kajal','Agarwal',1),
(4,'Rahul','Verma',2),
(5,'Sneha','Reddy',1);

INSERT INTO orders VALUES
(1,1,1,1,4,'2026-03-01'),
(2,2,2,2,4,'2026-03-02'),
(3,3,1,3,4,'2026-03-03'),
(4,4,2,4,4,'2026-03-04'),
(5,5,1,5,4,'2026-03-05');

--VIEW 1
CREATE VIEW vw_ProductDetails3
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.list_price
FROM products p
INNER JOIN brands b ON p.brand_id = b.brand_id
INNER JOIN categories c ON p.category_id = c.category_id;

-- VIEW 2
CREATE VIEW vw_OrderDetails3
AS
SELECT 
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.first_name + ' ' + st.last_name AS staff_name
FROM orders o
INNER JOIN customers c ON o.customer_id = c.customer_id
INNER JOIN stores s ON o.store_id = s.store_id
INNER JOIN staffs st ON o.staff_id = st.staff_id;

-- INDEXES
CREATE INDEX idx_products_brand ON products(brand_id);
CREATE INDEX idx_products_category ON products(category_id);
CREATE INDEX idx_orders_customer ON orders(customer_id);
CREATE INDEX idx_orders_store ON orders(store_id);
CREATE INDEX idx_orders_staff ON orders(staff_id);

-- TEST
SELECT * FROM vw_ProductDetails3;
SELECT * FROM vw_OrderDetails3;

