CREATE VIEW [dbo].[vwServiceUsageService]
AS 

SELECT 

	TSU.[Id] AS ServiceUsageId, 
    TSU.[User] AS UserId, 
	TSU.[BeginUsage], 
    TSU.[EndUsage], 
    TSU.[TotalPayment], 
	
	TS.[Id] AS ServiceId, 
    TS.[Name] AS Name, 
    TS.[ShortTariffName] AS ServiceShortTariffName,
    TS.[Comment] AS ServiceComment, 
    TS.[CreationDate] AS ServiceCreationDate, 
    TS.[Price] AS ServicePrice, 
    TS.[UsagesCount] AS ServiceUsagesCount

FROM [tblServiceUsage] AS TSU
INNER JOIN [tblService] AS TS ON  TSU.Service = TS.Id

