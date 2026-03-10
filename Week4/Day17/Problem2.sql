--*******Level-2 Problem 2: Atomic Order Cancellation with SAVEPOINT******--

USE AutoDB;

BEGIN TRY
    BEGIN TRANSACTION;

    -- SAVEPOINT before restoring stock
    SAVE TRANSACTION SP1;

    -- Restore stock quantities
    UPDATE s
    SET s.quantity = s.quantity + oi.quantity
    FROM stocks s
    JOIN order_items oi
        ON s.product_id = oi.product_id
    JOIN orders o
        ON o.order_id = oi.order_id
       AND o.store_id = s.store_id
    WHERE oi.order_id = 101;

    -- If stock restoration fails
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Stock restoration failed.',16,1);
    END

    -- Update order status to Rejected (3)
    UPDATE orders
    SET order_status = 3
    WHERE order_id = 101;

    -- If order update fails
    IF @@ROWCOUNT = 0
    BEGIN
        RAISERROR('Order status update failed.',16,1);
    END

    COMMIT TRANSACTION;
    PRINT 'Order cancelled successfully';

END TRY

BEGIN CATCH
    IF ERROR_MESSAGE() = 'Stock restoration failed.'
    BEGIN
        ROLLBACK TRANSACTION SP1;
        PRINT 'Rollback to savepoint done';
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END
END CATCH;

-- Optional: verify results
SELECT * FROM orders;
SELECT * FROM order_items;
SELECT * FROM stocks;