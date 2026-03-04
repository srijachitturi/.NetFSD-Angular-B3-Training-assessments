CREATE Database stores_db;
use stores_db;
--Store Wise Sales Summary

CREATE TABLE stores
(
    store_id   INT PRIMARY KEY,
    store_name VARCHAR(50) NOT NULL
);
CREATE TABLE orders
(
    order_id     INT PRIMARY KEY,
    store_id     INT NOT NULL,
    order_date   DATE,
    order_status INT NOT NULL,   
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    order_id      INT NOT NULL,
    quantity      INT NOT NULL,
    list_price    DECIMAL(10,2) NOT NULL,
    discount      DECIMAL(5,2)  NOT NULL,  -- 0.10 = 10%
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);


-- INSERT SAMPLE DATA 

INSERT INTO stores (store_id, store_name) VALUES
(1, 'Rajahmundry Store'),
(2, 'Hyderabad Store'),
(3, 'Vijayawada Store');

INSERT INTO orders (order_id, store_id, order_date, order_status) VALUES
(101, 1, '2026-03-01', 4),  
(102, 1, '2026-03-02', 2),  
(103, 2, '2026-03-02', 4),  
(104, 2, '2026-03-03', 4),  
(105, 3, '2026-03-03', 1);  

INSERT INTO order_items (order_item_id, order_id, quantity, list_price, discount) VALUES
(1, 101, 2, 1000.00, 0.10),  
(2, 101, 1,  500.00, 0.00),  
(3, 102, 3,  200.00, 0.05),  
(4, 103, 1, 3000.00, 0.20),  
(5, 104, 2, 1500.00, 0.10),  
(6, 105, 5,  100.00, 0.00);  


--REQUIRED QUERY 
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
ORDER BY total_sales DESC;
