CREATE TABLE [dbo].[tblService]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(32) NOT NULL, 
    [ShortTariffName] NVARCHAR(12) NOT NULL,
    [Comment] NVARCHAR(256) NOT NULL, 
    [CreationDate] DATETIME2 NOT NULL DEFAULT (getdate()), 
    [Price] INT NOT NULL , 
    [UsagesCount] INT NOT NULL DEFAULT 0 
)
