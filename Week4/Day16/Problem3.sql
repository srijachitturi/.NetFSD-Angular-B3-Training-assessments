USE stores_db;

-- Create orders3 table
CREATE TABLE orders3
(
    order_id INT PRIMARY KEY,
    order_date DATE NOT NULL,
    shipped_date DATE NULL,
    order_status INT NOT NULL
);

-- Insert sample data
INSERT INTO orders3 VALUES
(1,'2026-03-01',NULL,1),
(2,'2026-03-02','2026-03-04',2),
(3,'2026-03-03','2026-03-05',3);

-- Create AFTER UPDATE trigger
CREATE TRIGGER trg_OrderStatusValidation3
ON orders3
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        IF EXISTS
        (
            SELECT 1
            FROM inserted
            WHERE order_status = 4
              AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Shipped date cannot be NULL when order status is Completed (4).',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        RAISERROR('Error occurred while validating order status.',16,1);
    END CATCH
END;

-- Test 1 : Invalid update
BEGIN TRY
    UPDATE orders3
    SET order_status = 4
    WHERE order_id = 1;
END TRY
BEGIN CATCH
    SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

-- Test 2 : Valid update
UPDATE orders3
SET shipped_date = '2026-03-06',
    order_status = 4
WHERE order_id = 1;

SELECT * FROM orders3;