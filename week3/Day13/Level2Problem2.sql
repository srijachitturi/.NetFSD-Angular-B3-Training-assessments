CREATE Database Products_db;
USE Products_db;

CREATE TABLE products
(
    product_id   INT PRIMARY KEY,
    product_name VARCHAR(50) NOT NULL
);

CREATE TABLE stores
(
    store_id   INT PRIMARY KEY,
    store_name VARCHAR(50) NOT NULL
);

CREATE TABLE stocks
(
    store_id   INT,
    product_id INT,
    quantity   INT NOT NULL,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

--INSERT SAMPLE DATA

INSERT INTO products VALUES
(1, 'Laptop'),
(2, 'Mobile'),
(3, 'Headphones');

INSERT INTO stores VALUES
(1, 'Rajahmundry Store'),
(2, 'Hyderabad Store');

INSERT INTO stocks VALUES
(1, 1, 50),
(1, 2, 80),
(1, 3, 40),
(2, 1, 60),
(2, 2, 90);

INSERT INTO orders VALUES
(101, 1, '2026-03-01'),
(102, 2, '2026-03-02');

INSERT INTO order_items VALUES
(1, 101, 1, 2),   -- Laptop sold
(2, 101, 2, 5),   -- Mobile sold
(3, 102, 1, 3);   -- Laptop sold

--QUERY

SELECT
    p.product_name,
    s.store_name,
    st.quantity AS stock_quantity,
    SUM(oi.quantity) AS total_sold
FROM stocks st
INNER JOIN products p
    ON st.product_id = p.product_id
INNER JOIN stores s
    ON st.store_id = s.store_id
LEFT JOIN order_items oi
    ON st.product_id = oi.product_id
GROUP BY
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY
    p.product_name;