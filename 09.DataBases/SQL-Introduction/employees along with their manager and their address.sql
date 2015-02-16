SELECT e.FirstName + ' ' + e.LastName AS [FULL Name],
	   a.AddressText as [Address],
	   m.FirstName + ' ' + m.LastName AS [Manager]  
	       FROM Employees e 
				INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
				INNER JOIN Addresses a ON e.AddressID = a.AddressID