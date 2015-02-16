SELECT FirstName + ' ' + LastName AS [FULL Name], a.AddressText AS [Address] 
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID