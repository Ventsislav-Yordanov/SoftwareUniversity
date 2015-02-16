SELECT  e.FirstName + ' ' + e.LastName AS [FULL Name], m.FirstName + ' ' + m.LastName AS [Manager]  
	FROM Employees e 
		RIGHT OUTER JOIN Employees m
			ON e.ManagerID = m.EmployeeID

SELECT  e.FirstName + ' ' + e.LastName AS [FULL Name], m.FirstName + ' ' + m.LastName AS [Manager]  
	FROM Employees e 
		LEFT OUTER JOIN Employees m
			ON e.ManagerID = m.EmployeeID