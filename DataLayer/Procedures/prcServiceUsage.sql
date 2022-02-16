CREATE PROCEDURE [dbo].[prcServiceUsage]
	@userId int,
	@onlyWithUsageNow bit
AS
BEGIN
	DECLARE @currDate DATETIME2 = GETDATE();

	SELECT * 
	FROM vwServiceUsageService vws
	WHERE ( vws.UserId = @userId ) AND 
	      ( vws.BeginUsage <= @currDate AND vws.EndUsage >= @currDate )
END
