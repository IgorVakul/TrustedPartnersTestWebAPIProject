--Split string with ids (with separator comma) to table with ids var char
CREATE OR ALTER FUNCTION [dbo].[CSVToTableVarChar] (@InStr NVARCHAR(MAX))
RETURNS @TempTab TABLE
   (id NVARCHAR(100) not null)
AS
BEGIN
	--Split string with ids (with separator comma) to table with ids var char
    -- Ensure input ends with comma
	SET @InStr = REPLACE(@InStr + ',', ',,', ',');
	DECLARE @SP INT;
	DECLARE @VALUE VARCHAR(1000);
	WHILE PATINDEX('%,%', @INSTR ) <> 0 
	BEGIN
	   SELECT  @SP = PATINDEX('%,%',@INSTR);
	   SELECT  @VALUE = LEFT(@INSTR , @SP - 1);
	   SELECT  @INSTR = STUFF(@INSTR, 1, @SP, '');
	   INSERT INTO @TempTab(id) VALUES (@VALUE);
	END
	RETURN
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAgentCodeWithHighestSumOfAdvanceAmount]
	@Year INT,
	@Quarter INT = 1
AS
BEGIN	

	SET NOCOUNT ON;		

	SELECT TOP 1 AGENT_CODE AgentCode
	FROM [dbo].[ORDERS] WITH(NOLOCK)
	WHERE 
		YEAR([ORD_DATE]) = @Year 
		AND DATEPART(QUARTER,[ORD_DATE]) = @Quarter
	GROUP BY AGENT_CODE
	ORDER BY SUM([ADVANCE_AMOUNT]) DESC,MAX([ORD_DATE]) DESC		
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetSpecificAgentsOrders]
	@NumberOfRow INT,
	@AgentCodes NVARCHAR(MAX)
AS
BEGIN	

	SET NOCOUNT ON;		

	WITH resultTable AS (
	SELECT
		tmpOrders.ORD_NUM, 
		tmpOrders.ORD_AMOUNT, 
		tmpOrders.ADVANCE_AMOUNT, 
		tmpOrders.ORD_DATE, 
		tmpOrders.CUST_CODE, 
		tmpOrders.AGENT_CODE, 
		tmpOrders.ORD_DESCRIPTION,
		ROW_NUMBER() OVER(PARTITION BY [AGENT_CODE] ORDER BY [ORD_DATE] ASC) AS RowNumber
	FROM [dbo].[ORDERS] tmpOrders WITH (NOLOCK)
	WHERE tmpOrders.[AGENT_CODE] in
									(SELECT sqOrders1.[AGENT_CODE] 
									 FROM [dbo].[ORDERS] sqOrders1
									 WHERE sqOrders1.[AGENT_CODE] IN (SELECT * FROM [dbo].[CSVToTableVarChar](@AgentCodes))
									 GROUP BY sqOrders1.[AGENT_CODE] 
									 HAVING COUNT(sqOrders1.ORD_NUM) >= @NumberOfRow)
	)
	SELECT
		tbl.ORD_NUM, 
		tbl.ORD_AMOUNT, 
		tbl.ADVANCE_AMOUNT, 
		tbl.ORD_DATE, 
		tbl.CUST_CODE, 
		tbl.AGENT_CODE, 
		tbl.ORD_DESCRIPTION
	FROM resultTable tbl
	WHERE tbl.RowNumber = @NumberOfRow;
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAgentsWithCountOfOrdersInYear]
	@Year INT,
	@CountOfOrders INT
AS
BEGIN	

	SET NOCOUNT ON;		

	SELECT 
		TRIM(orders.AGENT_CODE) AgentCode,
		TRIM(ag.AGENT_NAME) AgentName,
		TRIM(ag.PHONE_NO) PhoneNum
	FROM [dbo].[ORDERS] orders WITH(NOLOCK)
	JOIN [dbo].[AGENTS] ag on ag.AGENT_CODE = orders.[AGENT_CODE]
	WHERE YEAR(orders.[ORD_DATE]) = @year
	GROUP BY orders.AGENT_CODE, ag.AGENT_NAME, ag.PHONE_NO
	HAVING count(orders.ORD_NUM) >= @CountOfOrders
	ORDER BY ag.AGENT_NAME
END
GO