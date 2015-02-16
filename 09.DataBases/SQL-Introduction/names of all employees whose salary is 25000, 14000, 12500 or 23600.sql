SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [FULL NAME]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 2360)

