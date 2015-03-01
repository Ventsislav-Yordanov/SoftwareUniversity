-- Problem 1.	All Question Titles
SELECT Title 
FROM Questions
ORDER BY Title ASC

-- Problem 2.	Answers in Date Range
SELECT Content, CreatedOn
FROM Answers
WHERE CreatedOn > '15-jun-2012' AND CreatedOn < '21-mar-2013'
ORDER BY CreatedOn, Id

-- Problem 3.	Users with "1/0" Phones
SELECT Username, LastName, CASE
							  WHEN PhoneNumber IS NULL THEN 0
							  ELSE 1
						   END AS [Has Phone]
FROM Users
ORDER BY LastName, Id

-- Problem 4.	Questions with their Author
SELECT q.Title AS [Question Title], u.Username AS Author
FROM Questions q
JOIN Users u ON q.UserId = u.Id

-- Problem 5.	Answers with their Question with their Category and User 
SELECT 
	a.Content AS [Answer Content],
	a.CreatedOn,
	u.Username AS [Answer Author],
	q.Title AS [Question Title],
	c.Name AS [Category Name]
FROM Answers a 
JOIN Questions q ON a.QuestionId = q.Id
JOIN Categories c ON q.CategoryId = c.Id
JOIN Users u ON a.UserId = u.Id
ORDER BY c.Name , u.Username, a.CreatedOn

-- Problem 6. Category with Questions
SELECT c.Name, q.Title, q.CreatedOn
FROM Questions q
RIGHT JOIN Categories c ON q.CategoryId = c.Id
ORDER BY c.Name

-- Problem 7.	*Users without PhoneNumber and Questions
SELECT u.Id, u.Username, u.FirstName, u.PhoneNumber, u.RegistrationDate, u.Email
FROM Users u
LEFT JOIN Questions q ON q.UserId = u.Id
WHERE PhoneNumber IS NULL AND q.UserId IS NULL
ORDER BY u.RegistrationDate

-- Problem 8. Earliest and Latest Answer Date
SELECT MIN(CreatedOn) AS MinDate, MAX(CreatedOn) AS MaxDate
FROM Answers
WHERE CreatedOn BETWEEN '2012-01-01' AND '2014-12-31'

-- Problem 9. Find the latest ten answers
SELECT TOP 10 a.Content, a.CreatedOn, u.Username
FROM Answers a
JOIN Users u ON a.UserId = u.Id
ORDER BY a.CreatedOn

-- Problem 10.	Not Published Answers from the First and Last Month
SELECT a.Content AS [Answer Content], q.Title AS Question, c.Name AS Category
FROM Answers a
JOIN Questions q ON a.QuestionId = q.Id
JOIN Categories c ON q.CategoryId = c.Id
WHERE (
		  MONTH(a.CreatedOn) = (SELECT MONTH(MIN(CreatedOn)) FROM Answers)
		  OR
		  MONTH(a.CreatedOn) = (SELECT MONTH(MAX(CreatedOn)) FROM Answers)
	  )
	  AND
	  (
		 YEAR(a.CreatedOn) = (SELECT YEAR(MAX(CreatedOn)) FROM Answers)
	  )
	  AND a.IsHidden = 1
ORDER by c.Name

-- Problem 11.	Answers count for Category
SELECT c.Name AS Category, COUNT(a.Id) AS [Answers Count]
FROM Categories c
LEFT JOIN Questions q on q.CategoryId = c.Id
LEFT JOIN Answers a on a.QuestionId = q.Id
GROUP BY c.Name
ORDER BY [Answers Count] DESC

-- Problem 12.	Answers Count by Category and Username
SELECT c.Name AS Category, u.Username, u.PhoneNumber, COUNT(a.Id) AS [Answers Count]
FROM Categories c
LEFT JOIN Questions q ON q.CategoryId = c.Id
LEFT JOIN Answers a ON a.QuestionId = q.Id
LEFT JOIN Users u ON a.UserId = u.Id
GROUP BY c.Name, u.Username, u.PhoneNumber
HAVING u.PhoneNumber IS NOT NULL
ORDER BY [Answers Count] DESC