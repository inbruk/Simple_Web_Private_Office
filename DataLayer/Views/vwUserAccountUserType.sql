CREATE VIEW [dbo].[vwUserAccountUserType]
AS 
SELECT 
	TU.[Id] AS UserId, 
    TU.[Login], 
    TU.[Password], 
    TU.[Blocked], 
    TU.[CreationDate], 
    TU.[FullName], 
    TU.[PassportNumber], 
    TU.[Address], 
    TU.[HomePhone], 
    TU.[WorkPhone], 
    TU.[MobilePhone], 
    TU.[WebPage], 
    TU.[ICQ], 
    TU.[Email],

	TT.[Id] AS TypeId, 
    TT.[Name] AS TypeName, 
    TT.[Comment] AS TypeComment,

	TA.[Id] AS AccountId, 
    TA.[PersonalAccount] AS AccountPersonalAccount, 
    TA.[Balance] AS AccountBalance, 
    TA.[RecommendedPayment] AS AccountRecommendedPayment, 
    TA.[Credit] AS AccountCredit

FROM [tblUser] AS TU
INNER JOIN [tblUserType] AS TT ON  TU.Type = TT.Id
INNER JOIN [tblAccount] AS TA ON  TU.Account = TA.Id


