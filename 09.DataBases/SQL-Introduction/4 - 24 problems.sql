-- Problem 4.	Write a SQL query to find all information about all departments (use "SoftUni" database). --
SELECT * FROM Departments

-- Problem 5.	Write a SQL query to find all department names. --
SELECT Name FROM Departments

-- Problem 6.	Write a SQL query to find the salary of each employee. --
SELECT Salary FROM Employees

-- Problem 7.	Write a SQL to find the full name of each employee. --
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [FULL NAME]
FROM Employees

-- Problem 8.	Write a SQL query to find the email addresses of each employee. --
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Addresses] FROM Employees

-- Problem 9.	Write a SQL query to find all different employee salaries. --
SELECT DISTINCT Salary FROM Employees

-- Problem 10.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“. --
SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative'

-- Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA". --
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [FULL NAME]
FROM Employees
WHERE FirstName LIKE 'SA%'

-- Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei". --
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [FULL NAME]
FROM Employees
WHERE LastName LIKE '%ei%'

-- Problem 13.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. --
SELECT Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

-- Problem 14.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. --
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [FULL NAME]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 2360)

-- Problem 15.	Write a SQL query to find all employees that do not have manager. --
SELECT * FROM Employees
WHERE ManagerID IS NULL

-- Problem 16.	Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. --
SELECT * FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- Problem 17.	Write a SQL query to find the top 5 best paid employees. --
SELECT TOP 5 * FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- Problem 18.	Write a SQL query to find all employees along with their address. --
SELECT FirstName + ' ' + LastName AS [FULL Name], a.AddressText AS [Address] 
	FROM Employees e INNER JOIN Addresses a
	ON e.AddressID = a.AddressID

-- Problem 19.	Write a SQL query to find all employees and their address. --
SELECT FirstName + ' ' + LastName AS [FULL Name], a.AddressText AS [Address] 
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID

-- Problem 20.	Write a SQL query to find all employees along with their manager. --
SELECT  e.FirstName + ' ' + e.LastName AS [FULL Name], m.FirstName + ' ' + m.LastName AS [Manager]  
	FROM Employees e INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

-- Problem 21.	Write a SQL query to find all employees, along with their manager and their address. --
SELECT e.FirstName + ' ' + e.LastName AS [FULL Name],
	   a.AddressText as [Address],
	   m.FirstName + ' ' + m.LastName AS [Manager]  
	       FROM Employees e 
				INNER JOIN Employees m ON e.ManagerID = m.EmployeeID
				INNER JOIN Addresses a ON e.AddressID = a.AddressID

-- Problem 22.	Write a SQL query to find all departments and all town names as a single list. --
SELECT Name FROM Departments
UNION
SELECT Name FROM Towns

-- Problem 23.	Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. --
-- Use right outer join. Rewrite the query to use left outer join. --
SELECT  e.FirstName + ' ' + e.LastName AS [FULL Name], m.FirstName + ' ' + m.LastName AS [Manager]  
	FROM Employees e 
		RIGHT OUTER JOIN Employees m
			ON e.ManagerID = m.EmployeeID

SELECT  e.FirstName + ' ' + e.LastName AS [FULL Name], m.FirstName + ' ' + m.LastName AS [Manager]  
	FROM Employees e 
		LEFT OUTER JOIN Employees m
			ON e.ManagerID = m.EmployeeID

-- Problem 24.	Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005. --
SELECT e.FirstName + ' ' + e.LastName AS [FULL Name], e.HireDate, d.Name as [Department Name]
	FROM Employees e
		INNER JOIN Departments d 
			ON e.DepartmentID = d.DepartmentID
				WHERE d.Name IN('Sales', 'Finance')
				AND
				YEAR(e.HireDate) BETWEEN 1995 AND 2005

-------------------- Problem 24. Second Solution --------------------
--SELECT e.FirstName + ' ' + e.LastName AS [FULL Name], e.HireDate, d.Name as [Department Name]
--FROM Employees e, Departments d
--WHERE (e.HireDate BETWEEN '1994' AND '2006') AND 
	--(e.DepartmentID = d.DepartmentID) AND
	--(d.Name = 'Sales' OR d.Name = 'Finance')
