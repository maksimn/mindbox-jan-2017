SELECT ProductId, COUNT(CustomerId) AS FirstBuyNumber
FROM (
    SELECT CustomerId, ProductId
	FROM Sales AS SalesX
	WHERE DateCreated = (
	    SELECT MIN(DateCreated) FROM Sales AS SalesY
		WHERE SalesX.CustomerId = SalesY.CustomerId
	)    
) AS CustomerFirstBuy
GROUP BY ProductId;
