SELECT FirstName + ' ' + LastName AS [FULL Name], a.AddressText AS [Address] 
	FROM Employees e INNER JOIN Addresses a
	ON e.AddressID = a.AddressID