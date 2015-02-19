-- Problem 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. --
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)

-- Problem 2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company. --
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary >
  (SELECT MIN(Salary) FROM Employees) * 1.10

-- Problem 3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. --
SELECT e.FirstName + ' ' + ISNULL(MiddleName + ' ','') + LastName AS [Full Name], e.Salary,
       d.Name AS [Department Name]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees
  WHERE DepartmentID = d.DepartmentID)
ORDER BY d.DepartmentID

-- Problem 4.	Write a SQL query to find the average salary in the department #1. --
SELECT AVG(Salary) AS [Average salary in the department #1]
FROM Employees
WHERE DepartmentID = 1

-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department. --
SELECT AVG(Salary) AS [Average salary in the "Sales" department]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department. --
SELECT COUNT(*) AS [Number of employees in the "Sales" department]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

-- Problem 7.	Write a SQL query to find the number of all employees that have manager. --
SELECT COUNT(*) FROM Employees AS [Employees with manager]
WHERE ManagerID IS NOT NULL

-- Problem 8.	Write a SQL query to find the number of all employees that have no manager. --
SELECT COUNT(*) FROM Employees AS [Employees without manager]
WHERE ManagerID IS NULL

-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them. --
SELECT d.Name, AVG(e.Salary) AS [Average Salary]
FROM Departments d
INNER JOIN Employees e
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name
ORDER BY d.Name

-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town. --
SELECT t.Name AS [Town], d.Name AS [Deparment], COUNT(*) AS [Employees count]
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name, d.Name
ORDER BY d.Name

-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees. --
SELECT e.FirstName, e.LastName, m.[Employees count]
FROM Employees e
	INNER JOIN 
		(SELECT ManagerID, COUNT(ManagerID) AS [Employees count]
		FROM Employees
		GROUP BY ManagerID) m
	ON m.ManagerID = e.EmployeeID
WHERE m.[Employees count] = 5

-- Problem 11. Second Solution --
SELECT m.FirstName, m.LastName, COUNT(e.ManagerID) AS [Employees count]
FROM Employees e 
	JOIN Employees m
		ON m.EmployeeID = e.ManagerID
GROUP BY m.ManagerID, m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5

-- Problem 12.	Write a SQL query to find all employees along with their managers. --
SELECT e.FirstName + ' ' + e.LastName AS [Employee Name], 
	   ISNULL(m.FirstName + ' ' + m.LastName, 'No manager') AS [Manager name]
FROM Employees e
LEFT OUTER JOIN Employees m 
	ON e.ManagerID = m.EmployeeID

-- Problem 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.  --
SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

-- Problem 14.	Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". --
SELECT CONVERT(VARCHAR(23), GETDATE(), 121) AS [DateTime]

-- Problem 15.	Write a SQL statement to create a table Users. --
-- Users should have username, password, full name and last login time.
-- Choose appropriate data types for the table fields.
-- Define a primary key column with a primary key constraint. 
-- Define the primary key column as identity to facilitate inserting records.
-- Define unique constraint to avoid repeating usernames.
-- Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users 
(
  [UserID] int IDENTITY(1,1),
  [Username] nvarchar(100) NOT NULL,
  [Password] nvarchar(100) NOT NULL,
  [FullName] nvarchar(100) NOT NULL,
  [LastLoginTime] smalldatetime DEFAULT GETDATE(),
  CONSTRAINT PK_UserID PRIMARY KEY(UserID),
  CONSTRAINT chk_Password CHECK (LEN(Password) > 5)
)
GO

-- Problem 16.	Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. --
CREATE VIEW [SHOW USERS] AS
SELECT * FROM Users
GO
SELECT * FROM [SHOW USERS]
GO

-- Problem 17.	Write a SQL statement to create a table Groups. --
-- Groups should have unique name (use unique constraint).
-- Define primary key and identity column
CREATE TABLE Groups 
(
  [Id] int IDENTITY(1,1) NOT NULL,
  [Name] nvarchar(100) NOT NULL,
  CONSTRAINT PK_Id PRIMARY KEY(Id),
  CONSTRAINT UK_Name UNIQUE(Name)
)

-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users. --
 ALTER TABLE Users 
 ADD GroupId int FOREIGN KEY REFERENCES Groups(Id)

 -- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables. --
INSERT INTO Groups 
VALUES ('GroupB')

INSERT INTO Groups
VALUES ('GroupC')

INSERT INTO Groups
VALUES ('GroupD')

INSERT INTO Users (Username, Password, FullName, LastLoginTime, GroupId)
VALUES ('Pecata', '123456', 'pepi pepov', '2015-02-15', 1)

INSERT INTO Users (Username, Password, FullName, LastLoginTime, GroupId)
VALUES ('Deska', '123456', 'Desislava Petrova', '2010-02-15', 2)

INSERT INTO Users (Username, Password, FullName, LastLoginTime, GroupId)
VALUES ('Mimi', '123456', 'Mara Otvarachkata', '2007-02-15', 3)

-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables. --
UPDATE Groups
SET Name = 'GroupY'
WHERE Name = 'GroupA'

UPDATE Users
SET UserName = 'Mara', GroupId = 2
WHERE UserName = 'Mimi'

-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables. --
Delete Users
WHERE UserName = 'Deska'

Delete Groups
WHERE Name = 'GroupD'

-- Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table. --
INSERT INTO Users
SELECT UPPER(LEFT(FirstName, 1) + LEFT(LastName, 1)) AS UserName,
	 LOWER(LEFT(FirstName, 1) + LEFT(LastName, 1)+ 'yfav3') AS Password,
	 FirstName + ' ' + LastName as FullName,
	 NULL AS LastLoginTime,
	 2 AS GroupId
FROM Employees

-- Problem 23.	Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010. --
ALTER TABLE Users
ALTER COLUMN Password NVARCHAR(100) NULL

UPDATE Users SET Password = NULL
WHERE LastLoginTime <= '2010-03-10'

-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password). --
DELETE FROM Users
WHERE Password IS NULL

-- Problem 25.	Write a SQL query to display the average employee salary by department and job title. --
SELECT d.Name, e.JobTitle, AVG(Salary) AS [Average Employee Salary]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle

-- Problem 26.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it. --
SELECT e.FirstName, e.LastName, d.Name, e.Salary
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary =
	(SELECT MIN(Salary) FROM Employees
	where DepartmentID = e.DepartmentID)
GROUP BY d.Name, e.FirstName, e.LastName, e.Salary
ORDER BY d.Name

-- Problem 27.	Write a SQL query to display the town where maximal number of employees work. --
SELECT TOP 1 * 
FROM (SELECT t.Name, COUNT(*) AS [EmployeeCount] 
	FROM Employees e
		INNER JOIN Addresses a ON a.AddressID = e.AddressID
		INNER JOIN Towns t ON t.TownID = a.TownID
	GROUP BY t.Name) ec
ORDER BY ec.EmployeeCount DESC

-- Problem 28.	Write a SQL query to display the number of managers from each town. --
SELECT mt.Town, COUNT(*) AS [Number of managers]
FROM 
(SELECT DISTINCT e.EmployeeID, e.FirstName, e.LastName, t.Name AS Town
FROM Employees e 
	JOIN Employees m
		ON m.ManagerID = e.EmployeeID
	JOIN Addresses a
		ON  a.AddressID = e.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID) AS mt
GROUP BY mt.Town
ORDER BY mt.Town

-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee. --
CREATE TABLE WorkHours
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
	TaskDate DATETIME NULL DEFAULT GETDATE(),
	Task NVARCHAR(150) NOT NULL,
	Hours SMALLINT NOT NULL,
	Comments NVARCHAR(MAX) NULL
)
GO

-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table. --
INSERT INTO WorkHours (EmployeeID, Task, Hours, Comments)
VALUES(10, 'Install SQL Server 2014', 4, 'GO, GO!');

INSERT INTO WorkHours (EmployeeID, Task, Hours, Comments)
VALUES(11, 'Reinstall your windows', 4, 'Dude ... Linux forever!');

UPDATE WorkHours
SET EmployeeID = 12
WHERE EmployeeID = 10

DELETE FROM WorkHours
WHERE Id = 1

INSERT INTO WorkHours (EmployeeID, Task, Hours, Comments)
VALUES(10, 'Install SQL Server 2014', 4, 'GO, GO!');

-- Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. --
CREATE TABLE WorkHoursLogs
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ChangeDate DATETIME DEFAULT GETDATE() NOT NULL,
	Command NCHAR(6) NOT NULL,
	OldEmployeeId INT NULL,
	NewEmployeeId INT NULL,
	OldTaskDate DATETIME NULL,
	NewTaskDate DATETIME NULL,
	OldTask NVARCHAR(150) NULL,
	NewTask NVARCHAR(150) NULL,
	OldHours SMALLINT NULL,
	NewHours SMALLINT NULL,
	OldComments NVARCHAR(MAX) NULL,
	NewComments NVARCHAR(MAX) NULL
)
GO

CREATE TRIGGER workhours_change
ON WorkHours
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @operation CHAR(6)
		SET @operation = CASE
				WHEN EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
					THEN 'Update'
				WHEN EXISTS(SELECT * FROM inserted)
					THEN 'Insert'
				WHEN EXISTS(SELECT * FROM deleted)
					THEN 'Delete'
				ELSE NULL
		END
	IF @operation = 'Delete'
			INSERT INTO WorkHoursLogs (Command, ChangeDate, OldTaskDate, OldTask, OldHours, OldComments)
			SELECT @operation, GETDATE(), d.TaskDate, d.Task, d.Hours, d.Comments
			FROM deleted d
	IF @operation = 'Insert'
			INSERT INTO WorkHoursLogs (Command, ChangeDate, NewTaskDate, NewTask, NewHours, NewComments)
			SELECT @operation, GETDATE(), i.TaskDate, i.Task, i.Hours, i.Comments
			FROM inserted i
	IF @operation = 'Update'
			INSERT INTO WorkHoursLogs (Command, ChangeDate, OldTaskDate, OldTask, OldHours, OldComments,
						NewTaskDate, NewTask, NewHours, NewComments)
			SELECT @operation, GETDATE(), d.TaskDate, d.Task, d.Hours, d.Comments,
										  i.TaskDate, i.Task, i.Hours, i.Comments
			FROM deleted d, inserted i
END
GO

UPDATE WorkHours
SET TaskDate = DATEADD(MONTH, 3, GETDATE()) 
WHERE Id = 2

UPDATE WorkHours
SET Comments = 'F*CK YEAH. LET''S GO'
WHERE Id = 3

INSERT INTO WorkHours (EmployeeID, Task, Hours, Comments)
VALUES (21, 'WORK HARD', 24 , 'Work hard - play hard')

-- Problem 32.	Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction. --
BEGIN TRAN
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

DELETE Employees
WHERE DepartmentID =
		(SELECT DepartmentID 
		FROM Departments 
		WHERE Name = 'Sales')

SELECT * FROM Employees e
		 INNER JOIN Departments d
				ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ROLLBACK TRAN

-- Problem 33.	Start a database transaction and drop the table EmployeesProjects. --
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

SELECT * FROM EmployeesProjects

-- Problem 34.	Find how to use temporary tables in SQL Server.
SELECT * INTO ##TempTableProjects
FROM EmployeesProjects
 
 DROP TABLE EmployeesProjects
 
 CREATE TABLE EmployeesProjects
  (
   EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
   ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID) NOT NULL,
  )
 
 INSERT INTO EmployeesProjects
 SELECT * FROM  ##TempTableProjects
