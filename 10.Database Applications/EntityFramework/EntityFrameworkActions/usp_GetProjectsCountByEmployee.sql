SET ANSI_NULLS ON
GO

IF (Object_Id('usp_GetProjectsCountByEmployee') IS NOT NULL)
DROP PROCEDURE usp_GetProjectsCountByEmployee
GO

CREATE PROCEDURE usp_GetProjectsCountByEmployee(
	@FirstName NVARCHAR(50) , 
	@LastName NVARCHAR(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT COUNT(p.ProjectID) 
	FROM Employees e
		LEFT OUTER JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
		LEFT OUTER JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE e.FirstName = @FirstName AND e.LastName = @LastName
END
GO