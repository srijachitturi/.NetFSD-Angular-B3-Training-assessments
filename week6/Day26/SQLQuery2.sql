CREATE DATABASE ProductDB;
GO

USE ProductDB;
GO

CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
GO

--Stored procedures
--INSERT
CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price)
    VALUES(@ProductName, @Category, @Price);
END
GO
--view all
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Category, Price
    FROM Products;
END
GO
--update
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
END
--delete
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId;
END
GO
CREATE PROCEDURE GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products WHERE ProductId=@ProductId;
END

SELECT *FROM Products;