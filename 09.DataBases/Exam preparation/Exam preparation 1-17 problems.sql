-- Problem 1.	All Ad Titles -- 
-- Display all ad titles in ascending order. --
-- Submit for evaluation the result grid with headers. --
SELECT Title 
FROM Ads
ORDER BY Title ASC

-- Problem 2.	Ads in Date Range --
-- Find all ads created between 26-December-2014 (00:00:00) and 1-January-2015 (23:59:59) sorted by date. --
-- Submit for evaluation the result grid with headers. --
SELECT Title, [Date] 
FROM Ads
WHERE [Date] >= '2014/12/26' AND [Date] < '2015/01/02'
ORDER BY [Date], Title

-- Problem 3.	* Ads with "Yes/No" Images --
-- Display all ad titles and dates along with a column named "Has Image" holding "yes" or "no" for all ads -- 
-- sorted by their Id. Submit for evaluation the result grid with headers. --
SELECT Title, [Date], [Has Image] = 
							CASE
								WHEN ImageDataURL IS NULL THEN 'yes'
								ELSE 'no'
							END
FROM Ads
ORDER BY Id

-- Problem 4.	Ads without Town, Category or Image --
-- Find all ads that have no town, no category or no image sorted by Id. --
-- Show all their data. Submit for evaluation the result grid with headers. --
SELECT *
FROM Ads
WHERE TownId IS NULL 
	OR
	  CategoryId IS NULL 
	OR 
      ImageDataURL IS NULL
ORDER BY Id

-- Problem 5.	Ads with Their Town --
-- Find all ads along with their towns sorted by Id. --
-- Display the ad title and town (even when there is no town). --
-- Name the columns exactly like in the table below. --
SELECT a.Title, t.Name AS [Town]
FROM Ads AS a
LEFT OUTER JOIN Towns t ON a.TownId = t.Id
ORDER BY a.Id

-- Problem 6.	Ads with Their Category, Town and Status --
-- Find all ads along with their categories, towns and statuses sorted by Id. --
-- Display the ad title, category name, town name and status. --
-- Include all ads without town or category or status. -- 
SELECT a.Title, c.Name AS [CategoryName], t.Name AS [TownName], s.[Status]
FROM Ads AS a
LEFT OUTER JOIN Categories AS c ON a.CategoryId = c.Id
LEFT OUTER JOIN Towns AS t ON a.TownId = t.Id
LEFT OUTER JOIN AdStatuses AS s ON a.StatusId = s.Id
ORDER BY a.id

-- Problem 7.	Filtered Ads with Category, Town and Status --
-- Find all Published ads from Sofia, Blagoevgrad or Stara Zagora, along with their category, --
-- town and status sorted by title. Display the ad title, category name, town name and status. -- 
-- Name the columns exactly like in the table below. --
SELECT a.Title, c.Name AS [CategoryName], t.Name AS [TownName], s.Status
FROM Ads AS a
INNER JOIN AdStatuses AS s ON a.StatusId = s.Id
INNER JOIN Towns t ON a.TownId = t.Id
INNER JOIN Categories c ON a.CategoryId = c.Id
WHERE s.Status = 'Published' 
					AND t.Name IN('Sofia', 'Stara Zagora', 'Blagoevgrad')
					-- AND (t.Name = 'Sofia' OR t.Name = 'Stara Zagora' OR t.Name = 'Blagoevgrad')
ORDER BY a.Title

-- Problem 8.	Earliest and Latest Ads --
-- Find the dates of the earliest and the latest published ads. --
-- Name the columns exactly like in the table below. --
SELECT MIN([Date]) AS MinDate,
		MAX([Date]) AS MaxDate
FROM Ads

-- Problem 9.	Latest 10 Ads --
-- Find the latest 10 ads sorted by date in descending order. --
-- Display for each ad its title, date and status. --
-- Name the columns exactly like in the table below. --
SELECT TOP 10 a.Title, a.Date, s.Status
FROM Ads AS a
INNER JOIN AdStatuses AS s ON a.StatusId = s.Id
ORDER BY a.Date DESC

-- Problem 10.	Not Published Ads from the First Month --
-- Find all not published ads, created in the same month and year like the earliest ad. -- 
-- Display for each ad its id, title, date and status. --
-- Submit for evaluation the result grid with headers. --
SELECT a.Id, a.Title, a.Date, s.Status
FROM Ads AS a
INNER JOIN AdStatuses AS s ON a.StatusId = s.Id
	WHERE MONTH(a.Date) = (SELECT TOP 1 MONTH(a.Date) FROM Ads)
		AND s.Status <> 'Published'

-- Problem 11.	Ads by Status --
-- Display the count of ads in each status. Sort the results by status.-- 
-- Name the columns exactly like in the table below. --
SELECT s.Status, COUNT(*) AS Count
FROM Ads AS a
INNER JOIN AdStatuses AS s ON a.StatusId = s.Id
GROUP BY s.Status

-- Problem 12.	Ads by Town and Status --
-- Display the count of ads for each town and each status. --
-- Sort the results by town, then by status. Display only non-zero counts. -- 
-- Name the columns exactly like in the table below. --
SELECT 
	t.Name AS [Town Name], 
	s.Status,
	COUNT(a.Id) as [Count]
FROM Ads AS a
INNER JOIN AdStatuses AS s ON a.StatusId = s.Id
INNER JOIN Towns AS t ON a.TownId = t.Id
GROUP BY s.Status, t.Name
ORDER BY t.Name, s.Status

-- Problem 13.	* Ads by Users --
-- Find the count of ads for each user. Display the username, ads count and --
-- "yes" or "no" depending on whether the user belongs to the role "Administrator". --
-- Sort the results by username. Name the columns exactly like in the table below. --
SELECT 
	u.UserName,
	COUNT(a.Id) AS AdsCount,
	(CASE WHEN admins.UserName IS NULL 
		THEN 'no' 
		ELSE 'yes' 
		END) AS IsAdministrator
FROM AspNetUsers u
	 LEFT JOIN Ads a ON u.Id = a.OwnerId
	 LEFT JOIN (
		SELECT DISTINCT u.Username
		FROM AspNetUsers u
		LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.Id
		LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
		WHERE r.Name = 'Administrator'
	 ) AS admins ON u.UserName = admins.UserName
GROUP BY a.OwnerId, u.UserName, admins.UserName
ORDER BY u.UserName

-- Problem 14.	Ads by Town
-- Find the count of ads for each town. 
-- Display the ads count and town name or "(no town)" for the ads without a town. 
-- Display only the towns, which hold 2 or 3 ads. Sort the results by town name.
-- Name the columns exactly like in the table below.
SELECT 
	COUNT(a.Id) AS [AdsCount],
	ISNULL(t.Name, '(no town)') AS [Town]
FROM Ads AS a
LEFT JOIN Towns as t ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Id) BETWEEN 2 AND 3
ORDER by t.Name

-- Problem 15.	Pairs of Dates within 12 Hours
-- Consider the dates of the ads. Find among them all pairs of different dates, 
-- such that the second date is no later than 12 hours after the first date. 
-- Sort the dates in increasing order by the first date, then by the second date. 
-- Name the columns exactly like in the table below.
SELECT a1.Date AS FirstDate, a2.Date AS SecondDate
FROM Ads a1, Ads a2
WHERE a2.Date > a1.Date AND
	DATEDIFF(HOUR, a1.Date, a2.Date) < 12
ORDER BY a1.Date, a2.Date

-- Part II – Changes in the Database --
-- Problem 16.	Ads by Country
-- 16.3.	Write and execute a SQL command that changes the town to "Paris" for all ads created at Friday.
UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name='Paris')
WHERE DATEPART(WEEKDAY, Ads.Date) = 6

-- 16.4.	Write and execute a SQL command that changes the town to "Hamburg" for all ads created at Thursday.
UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name='Hamburg')
WHERE DATEPART(WEEKDAY, Ads.Date) = 5

-- 16.5.	Delete all ads created by user in role "Partner".
DELETE FROM Ads 
FROM Ads a
	JOIN AspNetUsers u ON a.OwnerId = u.Id
	JOIN AspNetUserRoles ur ON ur.UserId = u.Id
	JOIN AspNetRoles r ON ur.RoleId = r.Id
WHERE r.Name = 'Partner'

-- 16.6.	Add a new add holding the following information: Title="Free Book", Text="Free C# Book",
-- Date={current date and time}, Owner="nakov", Status="Waiting Approval".
INSERT INTO Ads(Title, Text, Date, OwnerId, StatusId)
VALUES('Free Book', 'Free C# Book', GETDATE(),
(SELECT Id FROM AspNetUsers WHERE UserName = 'nakov'),
(SELECT Id from AdStatuses WHERE Status = 'Waiting Approval'))

-- 16.7.	Find the count of ads for each town. Display the ads count, the town name and the country name. 
-- Include also the ads without a town and country. Sort the results by town, then by country. 
-- Name the columns exactly like in the table below.
SELECT 
	t.Name AS Town,
	c.Name AS Country,
	COUNT(a.Id) AS AdsCount
FROM Ads a
FULL OUTER JOIN Towns t ON a.TownId = t.Id
FULL OUTER JOIN Countries c ON t.CountryId = c.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name, c.Name

-- Part III – Stored Procedures
-- Problem 17.	Create a View and a Stored Function
--------------- Important: start with a clean copy of the "Ads" database. ---------------
-- 17.1.	Create a view "AllAds" in the database that holds information about ads: 
-- id, title, author (username), date, town name, category name and status, sorted by id. 
CREATE VIEW AllAds AS
SELECT 
	a.Id,
	a.Title, 
	u.UserName AS Author,
	a.Date, 
	t.Name AS Town, 
	c.Name AS Category,
	s.Status
FROM Ads a
LEFT JOIN AspNetUsers u ON a.OwnerId= u.Id
LEFT JOIN Categories c ON a.CategoryId = c.Id
LEFT JOIN AdStatuses s ON a.StatusId = s.Id
LEFT JOIN Towns t ON a.TownId = t.Id

SELECT * FROM AllAds

-- 17.2.	Using the view above, create a stored function "fn_ListUsersAds" that returns a table,
-- holding all users in descending order as first column, along with all dates of their ads
-- (in ascending order) in format "yyyyMMdd", separated by "; " as second column.
IF (object_id(N'fn_ListUserAds') IS NOT NULL)
DROP FUNCTION fn_ListUserAds
GO

CREATE FUNCTION fn_ListUserAds()
	RETURNS @tbl_UserAds TABLE
	(
		UserName NVARCHAR(MAX),
		AdDates NVARCHAR(MAX)
	)
AS
BEGIN
	DECLARE UsersCursor CURSOR FOR
		SELECT UserName FROM AspNetUsers
		ORDER BY UserName DESC;
	OPEN UsersCursor;
	DECLARE @username NVARCHAR(MAX);
	FETCH NEXT FROM UsersCursor INTO @username;
	WHILE @@fetch_status = 0
	BEGIN
		DECLARE @dates NVARCHAR(MAX) = NULL;
		SELECT
			@dates = CASE
				WHEN @dates IS NULL THEN CONVERT(NVARCHAR(MAX), Date, 112)
				ELSE @dates + '; ' + CONVERT(NVARCHAR(MAX), Date, 112)
			END
		FROM AllAds
		WHERE Author = @username
		ORDER BY Date;

		INSERT INTO @tbl_UserAds
		VALUES(@username, @dates)

		FETCH NEXT FROM UsersCursor INTO @username;
	END;
	CLOSE UsersCursor;
	DEALLOCATE UsersCursor;
	RETURN;
END
GO

SELECT * FROM fn_ListUserAds()