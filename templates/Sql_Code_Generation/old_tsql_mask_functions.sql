

CREATE FUNCTION [DataObfuscation].[GetHashClever]
(
	@MULTIPLIER [bigint],
	@HASH_BUCKET_SIZE [int],
	@SEED [bigint],

	@Value [nvarchar](MAX)
)
RETURNS [int]
AS
BEGIN	
	DECLARE @hashcode [bigint]
	DECLARE @MINOR_UPPER_BOUND [bigint]
	DECLARE @MAJOR_UPPER_BOUND [bigint]
	
	SET @MINOR_UPPER_BOUND = 2147483647
	SET @MAJOR_UPPER_BOUND = 4294967295
	
	SET @hashcode = @SEED;
	SELECT @hashcode = (@hashcode * @MULTIPLIER + (SUBSTRING(CAST(@Value AS VARBINARY(MAX)), [BinaryTable].[Index], 1))) % @MAJOR_UPPER_BOUND
		FROM (SELECT TOP(LEN(CAST(@Value AS VARBINARY(MAX)))) ROW_NUMBER() OVER (ORDER BY GETDATE()) AS [Index] FROM sys.all_objects) AS [BinaryTable];
 	
	SET @hashcode =	CASE WHEN @hashcode > @MINOR_UPPER_BOUND THEN @hashcode - @MAJOR_UPPER_BOUND ELSE @hashcode END;
	SET @hashcode = CASE WHEN @hashcode < 0	THEN @hashcode + @MINOR_UPPER_BOUND ELSE @hashcode END % @HASH_BUCKET_SIZE;
 
	RETURN CAST(@hashcode AS [int])	
END
GO


CREATE FUNCTION [DataObfuscation].[GetHash]
(
	@MULTIPLIER [bigint],
	@HASH_BUCKET_SIZE [int],
	@SEED [bigint],

	@Value [nvarchar](MAX)
)
RETURNS [int]
AS
BEGIN	

	DECLARE @buffer [varbinary](MAX)
	DECLARE @hashcode [bigint]
	DECLARE @index [int]
	DECLARE @length [int]
	DECLARE @octet [bigint]
	DECLARE @MINOR_UPPER_BOUND [bigint]
	DECLARE @MAJOR_UPPER_BOUND [bigint]
	
	SET @MINOR_UPPER_BOUND = 2147483647
	SET @MAJOR_UPPER_BOUND = 4294967295
	
	SET @buffer = CAST(@value AS VARBINARY(MAX))
	SET @length = LEN(@buffer)
	SET @index = 1
	SET @hashcode = @SEED

	WHILE @index <= (@length)
	BEGIN        
	 
		   SET @octet = SUBSTRING(@buffer, @index, 1)
		   SET @index = @index + 1
		   SET @hashcode = ((@hashcode * @MULTIPLIER) + @octet) % @MAJOR_UPPER_BOUND 
	END

	SET @hashcode = CASE WHEN @hashcode > @MINOR_UPPER_BOUND THEN @hashcode - @MAJOR_UPPER_BOUND ELSE @hashcode END
	SET @hashcode = CASE WHEN @hashcode < 0 THEN @hashcode + @MINOR_UPPER_BOUND ELSE @hashcode END % @HASH_BUCKET_SIZE
	
	RETURN CAST(@hashcode AS [int])
END
GO


CREATE FUNCTION [DataObfuscation].[GetHashSubstitution]
(
	@DictionaryId [int],
	
	@Value [nvarchar](MAX)
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @hashMultiplier [bigint]
	DECLARE @hashBucketSize [int]
	DECLARE @hashSeed [bigint]	
	
	DECLARE @dictionaryKey [int]
	DECLARE @dictionaryValue [nvarchar](MAX)
	
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = @DictionaryId;
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	
	SELECT
	@dictionaryValue = t.[Value]
	FROM [DataObfuscation].[Associative] t
	WHERE t.[DictionaryId] = @DictionaryId AND t.[Key] = @dictionaryKey
	
	RETURN @dictionaryValue	
END
GO


CREATE FUNCTION [DataObfuscation].[GetHashVariance]
(
	@DictionaryId [int],
	
	@Value [nvarchar](MAX)
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @hashMultiplier [bigint]
	DECLARE @hashBucketSize [int]
	DECLARE @hashSeed [bigint]	
	
	DECLARE @dictionaryKey [int]
	DECLARE @dictionaryValue [nvarchar](MAX)
	
	DECLARE @sign [int]
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = 0; -- WELL KNOWN
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	
	SET @sign = CASE WHEN @dictionaryKey % 2 = 0 THEN 1 ELSE -1 END
	
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = @DictionaryId;
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	SET @dictionaryValue = @dictionaryKey * @sign
	
	RETURN @dictionaryValue
END
GO


INSERT INTO [DataObfuscation].[Strategy] VALUES (0, 'None', 'Performs no obfuscation.');
INSERT INTO [DataObfuscation].[Strategy] VALUES (1, 'Substitution', 'Returns an alternate value for the real data using a hash appoach.');
INSERT INTO [DataObfuscation].[Strategy] VALUES (2, 'Shuffling', 'Returns an alternate value for the real data using a shuffle appoach.');
INSERT INTO [DataObfuscation].[Strategy] VALUES (3, 'Variance', 'Returns a value within +/- (10% | 120d) of the real data.');
INSERT INTO [DataObfuscation].[Strategy] VALUES (4, 'Cipher', 'Returns an encrypted value for all real data.');
INSERT INTO [DataObfuscation].[Strategy] VALUES (5, 'Nulling', 'Return a null value instead of the real data.');
INSERT INTO [DataObfuscation].[Strategy] VALUES (6, 'Masking', 'Returns a mask value for most but not all of the real data.');
GO


CREATE FUNCTION [DataObfuscation].[GetObfuscatedTableViewColumnData]
(
	@CatalogName as [nvarchar](64),
	@SchemaName as [nvarchar](128),
	@TableName as [nvarchar](128),
	@ColumnName as [nvarchar](128),
	@Value as [nvarchar](MAX)
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @strategyId [int]
	DECLARE @dictionaryId [int]
	
	IF @Value IS NULL OR LEN(@Value) = 0 BEGIN RETURN @Value END;
	
	SELECT @strategyId = t.[StrategyId], @dictionaryId = t.[DictionaryId]
	FROM [DataObfuscation].[TableViewColumnConfig] t
	WHERE t.[CatalogName] = @CatalogName AND t.[SchemaName] = @SchemaName AND t.[TableName] = @TableName AND t.[ColumnName] = @ColumnName;

	SET @Value = CASE
		WHEN @strategyId IS NULL OR
			@strategyId = 0 THEN @Value
		WHEN @strategyId = 1 THEN [DataObfuscation].[GetHashSubstitution](@dictionaryId, @Value)
		--WHEN @strategyId = 2 THEN @Value
		--WHEN @strategyId = 3 THEN @Value
		WHEN @strategyId = 4 THEN ENCRYPTBYPASSPHRASE('TEXTMETAL', @Value)
		WHEN @strategyId = 5 THEN null
		--WHEN @strategyId = 6 THEN @Value
		ELSE @Value
	END

	RETURN @Value
	
END
GO


alter FUNCTION [DataObfuscation].[GetHashVarianceNumeric]
(
	@DictionaryId [int],
	
	@Value [bigint]
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @hashMultiplier [bigint]
	DECLARE @hashBucketSize [int]
	DECLARE @hashSeed [bigint]	
	
	DECLARE @dictionaryKey [int]
	DECLARE @dictionaryValue [nvarchar](MAX)
	
	DECLARE @sign [int]
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = 0; -- WELL KNOWN
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	
	SET @sign = CASE WHEN @dictionaryKey % 2 = 0 THEN 1 ELSE -1 END
	
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = @DictionaryId;
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	SET @dictionaryValue = @dictionaryKey * @sign
	
	RETURN @value * @dictionaryValue
END
GO



CREATE FUNCTION [DataObfuscation].[GetHashVariance]
(
	@DictionaryId [int],
	
	@Value [nvarchar](MAX)
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @hashMultiplier [bigint]
	DECLARE @hashBucketSize [int]
	DECLARE @hashSeed [bigint]	
	
	DECLARE @dictionaryKey [int]
	DECLARE @dictionaryValue [nvarchar](MAX)
	
	DECLARE @sign [int]
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = 0; -- WELL KNOWN
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	
	SET @sign = CASE WHEN @dictionaryKey % 2 = 0 THEN 1 ELSE -1 END
	
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = @DictionaryId;
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	SET @dictionaryValue = @dictionaryKey * @sign
	
	RETURN @dictionaryValue
END


CREATE FUNCTION [DataObfuscation].[GetObfuscatedTableViewColumnData]
(
	@CatalogName as [nvarchar](64),
	@SchemaName as [nvarchar](128),
	@TableName as [nvarchar](128),
	@ColumnName as [nvarchar](128),
	@Value as [nvarchar](MAX)
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @strategyId [int]
	DECLARE @dictionaryId [int]
	
	SELECT @strategyId = t.[StrategyId], @dictionaryId = t.[DictionaryId]
	FROM [DataObfuscation].[TableViewColumnConfig] t
	WHERE t.[CatalogName] = @CatalogName AND t.[SchemaName] = @SchemaName AND t.[TableName] = @TableName AND t.[ColumnName] = @ColumnName;

	SET @Value = CASE
		WHEN @strategyId IS NULL OR
			@strategyId = 0 THEN @Value
		WHEN @strategyId = 1 THEN [DataObfuscation].[GetHashSubstitution](@dictionaryId, @Value)
		--WHEN @strategyId = 2 THEN @Value
		--WHEN @strategyId = 3 THEN @Value
		WHEN @strategyId = 4 THEN ENCRYPTBYPASSPHRASE('TEXTMETAL', @Value)
		WHEN @strategyId = 5 THEN null
		--WHEN @strategyId = 6 THEN @Value
		ELSE @Value
	END

	RETURN @Value
	
END



--SELECT [DataObfuscation].[GetHash] (33, 100, 5381, N'TEXTMETAL') = 77
CREATE FUNCTION [DataObfuscation].[GetHash]
(
	@MULTIPLIER [bigint],
	@HASH_BUCKET_SIZE [int],
	@SEED [bigint],

	@Value [nvarchar](MAX)
)
RETURNS [int]
AS
BEGIN	

	DECLARE @buffer [varbinary](MAX)
	DECLARE @hashcode [bigint]
	DECLARE @index [int]
	DECLARE @length [int]
	DECLARE @octet [bigint]
	DECLARE @MINOR_UPPER_BOUND [bigint]
	DECLARE @MAJOR_UPPER_BOUND [bigint]
	
	SET @MINOR_UPPER_BOUND = 2147483647
	SET @MAJOR_UPPER_BOUND = 4294967295
	
	SET @buffer = CAST(@value AS VARBINARY(MAX))
	SET @length = LEN(@buffer)
	SET @index = 1
	SET @hashcode = @SEED

	WHILE @index <= (@length)
	BEGIN        
	 
		   SET @octet = SUBSTRING(@buffer, @index, 1)
		   SET @index = @index + 1
		   SET @hashcode = ((@hashcode * @MULTIPLIER) + @octet) % @MAJOR_UPPER_BOUND 
	END

	SET @hashcode = CASE WHEN @hashcode > @MINOR_UPPER_BOUND THEN @hashcode - @MAJOR_UPPER_BOUND ELSE @hashcode END
	SET @hashcode = CASE WHEN @hashcode < 0 THEN @hashcode + @MINOR_UPPER_BOUND ELSE @hashcode END % @HASH_BUCKET_SIZE
	
	RETURN CAST(@hashcode AS [int])
END

GO




CREATE FUNCTION [DataObfuscation].[GetHashVariance]
(
	@DictionaryId [int],
	
	@Value [nvarchar](MAX)
)
RETURNS [nvarchar](MAX)
AS
BEGIN

	DECLARE @hashMultiplier [bigint]
	DECLARE @hashBucketSize [int]
	DECLARE @hashSeed [bigint]	
	
	DECLARE @dictionaryKey [int]
	DECLARE @dictionaryValue [nvarchar](MAX)
	
	DECLARE @sign [int]
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = 0; -- WELL KNOWN
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	
	SET @sign = CASE WHEN @dictionaryKey % 2 = 0 THEN 1 ELSE -1 END
	
	
	SELECT
	@hashMultiplier = [HashMultiplier],
	@hashBucketSize = [HashBucketSize],
	@hashSeed = [HashSeed]
	FROM [DataObfuscation].[Dictionary] t
	WHERE t.[DictionaryId] = @DictionaryId;
	
	SET @dictionaryKey = [DataObfuscation].[GetHash] (@hashMultiplier, @hashBucketSize, @hashSeed, @Value);
	SET @dictionaryValue = @dictionaryKey * @sign
	
	RETURN @dictionaryValue
END
GO