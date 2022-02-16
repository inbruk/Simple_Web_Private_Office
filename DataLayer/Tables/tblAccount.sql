CREATE TABLE [dbo].[tblAccount]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PersonalAccount] BIGINT NOT NULL, 
    [Balance] INT NOT NULL, 
    [RecommendedPayment] INT NOT NULL, 
    [Credit] INT NOT NULL
)
