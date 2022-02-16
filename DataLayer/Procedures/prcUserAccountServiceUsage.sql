CREATE PROCEDURE [dbo].[prcUserAccountServiceUsage]
	@userType int,
	@onlyUsersWithUsageNow bit
AS
BEGIN
	DECLARE @currDate DATETIME2 = GETDATE();
	DECLARE @IdTableVar TABLE(Id INT NOT NULL);

	IF @onlyUsersWithUsageNow = 1 
		BEGIN
			INSERT INTO @IdTableVar(Id)
				SELECT DISTINCT TSU.[User]
				FROM tblServiceUsage AS TSU
				WHERE TSU.BeginUsage <= @currDate AND TSU.EndUsage >= @currDate
		END
	ELSE
	    BEGIN
			INSERT INTO @IdTableVar(Id)
			SELECT Id FROM tblUser
        END

	SELECT * 
	FROM vwUserAccountUserType vwu
	INNER JOIN @IdTableVar IT ON vwu.UserId = IT.Id
	WHERE ( @userType = NULL OR vwu.TypeId = @userType )

END