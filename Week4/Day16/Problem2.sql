USE stores_db;

-- Create Tables

CREATE TABLE products2
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50) NOT NULL
);
GO

CREATE TABLE stocks2
(
    product_id INT PRIMARY KEY,
    quantity INT NOT NULL
);
GO

CREATE TABLE orders2
(
    order_id INT PRIMARY KEY,
    order_date DATE NOT NULL
);
GO

CREATE TABLE order_items2
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price MONEY,
    discount FLOAT
);

-- Insert Sample Data

INSERT INTO products2 VALUES
(101,'Laptop'),
(102,'Mobile'),
(103,'Keyboard'),
(104,'Mouse'),
(105,'Monitor');

INSERT INTO stocks2 VALUES
(101,50),
(102,40),
(103,30),
(104,20),
(105,10);

INSERT INTO orders2 VALUES
(1,'2026-03-01'),
(2,'2026-03-02');

-- AFTER INSERT Trigger

CREATE TRIGGER trg_UpdateStock2
ON order_items2
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check stock availability
        IF EXISTS
        (
            SELECT 1
            FROM inserted i
            INNER JOIN stocks2 s
                ON i.product_id = s.product_id
            WHERE i.quantity > s.quantity
        )
        BEGIN
            RAISERROR('Insufficient stock available!',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks2 s
        INNER JOIN inserted i
            ON s.product_id = i.product_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;

-- Test Valid Insert

INSERT INTO order_items2 VALUES
(1,1,101,5,50000,0.10);

SELECT * FROM stocks2;

-- Test Insufficient Stock
BEGIN TRY
    INSERT INTO order_items2 VALUES
    (2,2,105,50,8000,0.05);
END TRY
BEGIN CATCH
    SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
