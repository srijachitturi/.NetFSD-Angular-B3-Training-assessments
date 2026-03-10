--********Level-2 Problem 1: Transactions and Trigger Implementation*******--

CREATE DATABASE AutoDB;

USE AutoDB;

CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(50)
);

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

CREATE TABLE staffs
(
    staff_id INT PRIMARY KEY,
    staff_name VARCHAR(50),
    store_id INT FOREIGN KEY REFERENCES stores(store_id)
);

CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT FOREIGN KEY REFERENCES customers(customer_id),
    store_id INT FOREIGN KEY REFERENCES stores(store_id),
    staff_id INT FOREIGN KEY REFERENCES staffs(staff_id),
    order_status INT,
    order_date DATE
);

CREATE TABLE order_items
(
    order_id INT,
    item_id INT,
    product_id INT FOREIGN KEY REFERENCES products(product_id),
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    PRIMARY KEY(order_id,item_id),
    FOREIGN KEY(order_id) REFERENCES orders(order_id)
);

CREATE TABLE stocks
(
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY(store_id,product_id),
    FOREIGN KEY(store_id) REFERENCES stores(store_id),
    FOREIGN KEY(product_id) REFERENCES products(product_id)
);

INSERT INTO customers VALUES
(1,'Rahul'),
(2,'Srija');

INSERT INTO stores VALUES
(1,'Hyderabad Store'),
(2,'Vijayawada Store');

INSERT INTO products VALUES
(1,'Laptop'),
(2,'Mobile'),
(3,'Headphones');

INSERT INTO staffs VALUES
(1,'Pavan',1),
(2,'Ravi',2);

INSERT INTO stocks VALUES
(1,1,20),
(1,2,30),
(1,3,15),
(2,1,25),
(2,2,10),
(2,3,18);

CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    IF EXISTS
    (
        SELECT 1
        FROM stocks s
        JOIN inserted i
        ON s.product_id = i.product_id
        AND s.store_id = (SELECT store_id FROM orders WHERE order_id = i.order_id)
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR('Insufficient stock',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id
    AND s.store_id = (SELECT store_id FROM orders WHERE order_id = i.order_id);
END;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO orders VALUES
    (101,1,1,1,1,GETDATE());

    INSERT INTO order_items VALUES
    (101,1,1,2,50000,0),
    (101,2,3,1,2000,0);

    COMMIT TRANSACTION;
    PRINT 'Order placed successfully';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Transaction Failed';
END CATCH;

SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;