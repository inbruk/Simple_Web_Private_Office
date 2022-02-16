CREATE TABLE [dbo].[tblUser]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Login] NVARCHAR(32) NOT NULL, 
    [Password] NVARCHAR(32) NOT NULL, 
    [Type] INT NOT NULL, 
    [Account] INT NULL, 
    [Blocked] BIT NOT NULL DEFAULT 0, 
    [CreationDate] DATETIME2 NOT NULL DEFAULT (getdate()), 
    [FullName] NVARCHAR(100) NOT NULL, 
    [PassportNumber] NVARCHAR(32) NOT NULL, 
    [Address] NVARCHAR(200) NOT NULL, 
    [HomePhone] NVARCHAR(15) NULL, 
    [WorkPhone] NVARCHAR(15) NULL, 
    [MobilePhone] NVARCHAR(15) NOT NULL, 
    [WebPage] NVARCHAR(200) NULL, 
    [ICQ] NVARCHAR(15) NULL, 
    [Email] NVARCHAR(32) NOT NULL, 
    CONSTRAINT [FK_tblUser_tblUserType] FOREIGN KEY ([Type]) REFERENCES [tblUserType]([Id]), 
    CONSTRAINT [FK_tblUser_tblAccount] FOREIGN KEY ([Account]) REFERENCES [tblAccount]([Id])
)
