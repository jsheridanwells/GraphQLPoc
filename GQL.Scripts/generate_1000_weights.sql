USE [GQLAppDb]
GO

DECLARE @idx int = 1;
WHILE @idx <= 1000
  BEGIN
	INSERT INTO Weights
	   ([Id]
	   ,[UserId]
      ,[CreatedDate]
      ,[Active]
      ,[Amount]
	  , [WeightUnit])
	VALUES(
			NEWID()
			,'6B75F005-05B1-4DBA-DFA5-08D77831AAAC'
			, GETDATE()
			, 1
			, (SELECT CEILING(RAND()*(150 - 140)+140))
			, 'Lbs'
		)
	SET @idx = @idx + 1
END	