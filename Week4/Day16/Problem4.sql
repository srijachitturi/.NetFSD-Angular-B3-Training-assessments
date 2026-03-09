USE stores_db;

-- Temporary table to store revenue
IF OBJECT_ID('tempdb..#RevenueTemp') IS NOT NULL
DROP TABLE #RevenueTemp;

CREATE TABLE #RevenueTemp
(
    order_id INT,
    store_id INT,
    revenue MONEY
);

-- Cursor-Based Revenue Calculation
DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue MONEY

BEGIN TRY

    BEGIN TRANSACTION;

    DECLARE order_cursor CURSOR FOR
    SELECT order_id, store_id
    FROM orders
    WHERE order_status = 4;

    OPEN order_cursor;

    FETCH NEXT FROM order_cursor
    INTO @order_id, @store_id;

    WHILE @@FETCH_STATUS = 0
    BEGIN

        SELECT @revenue =
        SUM(quantity * list_price * (1 - discount))
        FROM order_items
        WHERE order_id = @order_id;

        INSERT INTO #RevenueTemp
        VALUES(@order_id, @store_id, ISNULL(@revenue,0));

        FETCH NEXT FROM order_cursor
        INTO @order_id, @store_id;

    END

    CLOSE order_cursor;
    DEALLOCATE order_cursor;

    COMMIT TRANSACTION;

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION;

    PRINT 'Error occurred during revenue calculation';

END CATCH;

-- Store-wise Revenue Summary
SELECT 
    store_id,
    SUM(revenue) AS total_store_revenue
FROM #RevenueTemp
GROUP BY store_id;