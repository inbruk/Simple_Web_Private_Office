CREATE TABLE [dbo].[tblServiceUsage]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [User] INT NOT NULL, 
    [Service] INT NOT NULL,
	[BeginUsage] DATETIME2 NOT NULL, 
    [EndUsage] DATETIME2 NOT NULL, 
    [TotalPayment] INT NOT NULL, 

    CONSTRAINT [FK_tblServiceUsage_tblService] FOREIGN KEY ([Service]) REFERENCES [tblServiceUsage]([Id]),
    CONSTRAINT [FK_tblServiceUsage_tblUser] FOREIGN KEY ([User]) REFERENCES [tblUser]([Id])
)
