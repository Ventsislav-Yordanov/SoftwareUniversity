SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [FULL NAME]
FROM Employees