-- Problem 1.	Create a database with two tables --
-- Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), person id (FK), balance --
-- Insert few records for testing. --

CREATE DATABASE Bank
GO

CREATE TABLE Persons
(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
FirstName NVARCHAR(255) NOT NULL,
LastName NVARCHAR(255) NOT NULL,
SSN CHAR(10) NOT NULL
);

CREATE TABLE Accounts
(
ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
PersonID INT FOREIGN KEY REFERENCES Persons(ID) NOT NULL,
FirstName NVARCHAR(255) NOT NULL,
Balance MONEY NOT NULL
);

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES('Dimitar', 'Obretenov', 123459678);

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES('Alex', 'Kondov', 147563756);

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES('Ventsislav', 'Yordanov', 109321648);

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES('Ivan', 'Purvanov', 103681648);

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES('Petar', 'Ivanov', 103681740);

INSERT INTO Accounts(PersonID, FirstName, Balance)
VALUES(4, 'Ivan', 2130)

INSERT INTO Accounts(PersonID, FirstName, Balance)
VALUES(1, 'Dimitar', 1304)

INSERT INTO Accounts(PersonID, FirstName, Balance)
VALUES(5, 'Petar', 2534)

INSERT INTO Accounts(PersonID, FirstName, Balance)
VALUES(2, 'Alex', 3343)

INSERT INTO Accounts(PersonID, FirstName, Balance)
VALUES(3, 'Ventsi', 9999)

-- Write a stored procedure that selects the full names of all persons.
USE Bank
GO

CREATE PROC usp_SelectFullNameOfAllPersons
AS
	SELECT FirstName + ' ' + LastName AS [Full Name] 
	FROM Persons
GO

-- Example usage
EXEC usp_SelectFullNameOfAllPersons
GO

-- Problem 2.	Create a stored procedure --
-- Your task is to create a stored procedure that accepts a number as a parameter and returns all persons --
-- who have more money in their accounts than the supplied number. --


CREATE PROC usp_SelectAllPersonsWithMoneyMoreThan @number int
AS
	SELECT *
	FROM Persons p 
	INNER JOIN Accounts a
		ON p.ID = a.PersonID
	WHERE a.Balance > @number
GO

-- Example usage
EXEC usp_SelectAllPersonsWithMoneyMoreThan 2200
GO

-- Problem 3.	Create a function with parameters
-- Your task is to create a function that accepts as parameters – sum, yearly interest rate and number of months. --
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected. --
CREATE FUNCTION ufn_InterestCalculator(@sum money, @interest float, @months float) RETURNS money
AS
BEGIN
	RETURN (@sum * (@interest / 100)) * (@months / 12)
END
GO

-- Example usage
SELECT dbo.ufn_InterestCalculator(100, 5, 4) AS [Money]
GO

-- Problem 4.	Create a stored procedure that uses the function from the previous example. --
-- Your task is to create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters. --
CREATE PROC usp_InterestOverAccounts @accountID int, @interestRate float
AS
	SELECT ID, Balance, dbo.ufn_InterestCalculator(Balance, @interestRate, 1) AS [Interest]
	FROM Accounts
	WHERE ID = @accountID
GO

-- Example usage
EXEC usp_InterestOverAccounts 1, 2.5
GO

-- Problem 5.	Add two more stored procedures WithdrawMoney and DepositMoney. --
-- Add two more stored procedures WithdrawMoney (AccountId, money) and  --
-- DepositMoney (AccountId, money) that operate in transactions. --
CREATE PROC usp_WithdrawMoney @accountID int, @money money
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @money
		WHERE ID = @accountID
	COMMIT TRAN
GO

-- Example usage
EXEC usp_WithdrawMoney 1, 130
GO

CREATE PROC usp_DepositMoney @accountID int, @money money
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @money
		WHERE ID = @accountID
	COMMIT TRAN
GO

-- Example usage
EXEC usp_DepositMoney 1, 130
GO


-- Problem 6.	Create table Logs. --
-- Create another table – Logs (LogID, AccountID, OldSum, NewSum). --
-- Add a trigger to the Accounts table that enters a new entry into the Logs table --
-- every time the sum on an account changes. --

CREATE TABLE Logs
(
LogID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
AccountID INT FOREIGN KEY REFERENCES Accounts(ID) NOT NULL,
OldSum MONEY NOT NULL,
NewSum MONEY NOT NULL
);
GO

CREATE TRIGGER balance_change
ON Accounts
AFTER  UPDATE
AS
	INSERT INTO Logs(AccountID, OldSum, NewSum)
	SELECT d.ID, d.Balance, i.Balance 
	FROM INSERTED i	
	INNER JOIN DELETED d
		ON d.ID = i.ID
GO

-- Example usage
EXEC usp_DepositMoney 1, 200
GO

-- Example usage
EXEC usp_WithdrawMoney 4, 100
GO

-- Problem 7.	Define function in the SoftUni database. --
-- Define a function in the database SoftUni that returns all Employee's names (first or middle or last name) --
-- and all town's names that are comprised of given set of letters. --
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', but not 'Rob' and 'Guy'. --
USE SoftUni
GO

CREATE FUNCTION usp_SearchNames(@letterSet NVARCHAR(MAX))
RETURNS @Names TABLE
(
	Name NVARCHAR(MAX)
)
AS
BEGIN
	DECLARE nameCursor CURSOR READ_ONLY FOR
	SELECT FirstName FROM Employees
	UNION
	SELECT LastName FROM Employees
	UNION
	SELECT Name FROM Towns
	OPEN nameCursor
	DECLARE @currentName NVARCHAR(MAX)
	FETCH NEXT FROM nameCursor INTO @currentName
	WHILE @@fetch_status = 0
	BEGIN
		IF dbo.ufn_MatchesTheLetterSet(@currentName, @letterSet) = 1
		BEGIN
			INSERT INTO @Names(Name) VALUES(@currentName)
		END
		FETCH NEXT FROM nameCursor INTO @currentName
	END
	CLOSE nameCursor
	DEALLOCATE nameCursor
RETURN
END
GO

CREATE FUNCTION ufn_MatchesTheLetterSet(@wordToBeChecked NVARCHAR(100), @lettersCheckSet NVARCHAR(100))
RETURNS BIT
AS
BEGIN
	DECLARE @result BIT,
			@currentLetter NVARCHAR(1)
	SET @result = 1
	WHILE @wordToBeChecked <> ''
	BEGIN
		SET @currentLetter = SUBSTRING(@wordToBeChecked, 1, 1)
		IF CHARINDEX(@currentLetter, @lettersCheckSet) = 0
		BEGIN	
			SET @result = 0
			BREAK
		END
		SET @wordToBeChecked = REPLACE(@currentLetter, @wordToBeChecked, '')
	END
	RETURN @result
END
GO

-- Example usage
SELECT * FROM usp_SearchNames('oistmiahf')

-- Problem 8.	Using database cursor write a T-SQL --
-- Using database cursor write a T-SQL script that scans all employees and their addresses --
-- and prints all pairs of employees that live in the same town. --
DECLARE @FirstEmployeeTable TABLE
(
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	TownID INT,
	TownName NVARCHAR(50)
)

DECLARE @SecondEmployeeTable TABLE
(
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	TownID INT,
	TownName NVARCHAR(50)
)

INSERT INTO @FirstEmployeeTable(FirstName, LastName, TownID, TownName)
SELECT e.FirstName, e.LastName, t.TownID, t.Name
FROM Employees e 
	INNER JOIN Addresses a 
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t
		ON t.TownID = a.TownID
ORDER BY e.FirstName

INSERT INTO @SecondEmployeeTable(FirstName, LastName, TownID, TownName)
SELECT * FROM @FirstEmployeeTable

DECLARE employeesCursor CURSOR READ_ONLY FOR
SELECT fe.FirstName, fe.LastName, se.FirstName, se.LastName, fe.TownName
FROM @FirstEmployeeTable fe
	INNER JOIN @SecondEmployeeTable se
		ON fe.TownID = se.TownID
ORDER BY fe.FirstName

OPEN employeesCursor
DECLARE @FirstEmployeeFirstName NVARCHAR(50),
		@FirstEmployeeLastName NVARCHAR(50),
		@SecondEmployeeFirstName NVARCHAR(50),
		@SecondEmployeeLastName NVARCHAR(50),
		@TownName NVARCHAR(50)

FETCH NEXT FROM employeesCursor INTO @FirstEmployeeFirstName, @FirstEmployeeLastName,
									 @SecondEmployeeFirstName, @SecondEmployeeLastName, @TownName

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @TownName + ': ' + @FirstEmployeeFirstName + ' ' + @FirstEmployeeLastName + ' ' +
								 @SecondEmployeeFirstName + ' ' + @SecondEmployeeLastName

		FETCH NEXT FROM employeesCursor INTO @FirstEmployeeFirstName, @FirstEmployeeLastName,
			@SecondEmployeeFirstName, @SecondEmployeeLastName, @TownName
	END
CLOSE employeesCursor
DEALLOCATE employeesCursor