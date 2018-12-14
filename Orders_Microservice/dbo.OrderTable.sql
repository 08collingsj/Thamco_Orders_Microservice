CREATE TABLE [dbo].OrderTable
(
	[OrderId] INT NOT NULL PRIMARY KEY, 
    [ProductId] INT NOT NULL, 
    [OrderDate] DATETIME NOT NULL, 
    [OrderState] VARCHAR(50) NOT NULL, 
    [OrderValue] NCHAR(10) NOT NULL, 
    [UsingReferal] BIT NOT NULL, 
    [ReferalValue] FLOAT NULL 
)
