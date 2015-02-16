SELECT e.FirstName + ' ' + e.LastName AS [FULL Name], e.HireDate, d.Name as [Department Name]
	FROM Employees e
		INNER JOIN Departments d 
			ON e.DepartmentID = d.DepartmentID
				WHERE d.Name IN('Sales', 'Finance')
				AND
				YEAR(e.HireDate) BETWEEN 1995 AND 2005

-------------------- Second Variant --------------------
--SELECT e.FirstName + ' ' + e.LastName AS [FULL Name], e.HireDate, d.Name as [Department Name]
--FROM Employees e, Departments d
--WHERE (e.HireDate BETWEEN '1994' AND '2006') AND 
	--(e.DepartmentID = d.DepartmentID) AND
	--(d.Name = 'Sales' OR d.Name = 'Finance')