DECLARE @TradesCategories as Table(CategoryName VARCHAR(20))
DECLARE @Trades AS TABLE 
(	
	[Value] DECIMAL(18,0),
	ClientSector VARCHAR(20)
);

INSERT INTO @Trades VALUES(2000000,'PRIVATE')
INSERT INTO @Trades VALUES(400000,'PUBLIC')
INSERT INTO @Trades VALUES(500000,'PUBLIC')
INSERT INTO @Trades VALUES(3000000,'PUBLIC')

DECLARE 
    @Value DECIMAL(18,0),
	@ClientSector VARCHAR(20),
	@Result VARCHAR(MAX) = ''

DECLARE cursor_trades CURSOR FOR 

SELECT [Value], ClientSector FROM @Trades;

OPEN cursor_trades;
FETCH NEXT FROM cursor_trades INTO @Value, @ClientSector;
WHILE @@FETCH_STATUS = 0
    BEGIN
		
		IF(UPPER(@ClientSector) = 'PUBLIC') BEGIN
			IF(@Value < 1000000) BEGIN
				INSERT INTO @TradesCategories VALUES ('LOWRISK')
			END

			IF(@Value > 1000000) BEGIN
				INSERT INTO @TradesCategories  VALUES('MEDIUMRISK')
			END
		END

		IF(UPPER(@ClientSector) = 'PRIVATE' AND @Value > 1000000) BEGIN
			INSERT INTO @TradesCategories  VALUES('HIGHRISK')
		END

        FETCH NEXT FROM cursor_trades INTO @Value,@ClientSector
    END;

CLOSE cursor_trades;

DEALLOCATE cursor_trades;

SELECT 
	@Result += '"' + a.CategoryName + '"' + ', '
FROM 
	@TradesCategories a

SET @Result = 'tradeCategories = {' + SUBSTRING(@Result,0,LEN(@Result)) + '}'


SELECT @Result as Result
 
