SELECT  emp.FirstName + ' ' + emp.LastName AS [FULL Name], e.FirstName + ' ' + e.LastName AS [Manager]  
	FROM Employees emp INNER JOIN Employees e
	ON emp.ManagerID = e.EmployeeID