namespace EntityFrameworkActions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SoftUni.Entities;

    class EntityFrameworkActionsClass
    {
        private static SoftUniEntities softUniEntities = new SoftUniEntities();

        static void Main(string[] args)
        {
            // Problem 3.       Employees with Projects after 2002
            Console.WriteLine("----- Problem 3. Employees with Projects after 2002 -----");
            var employeesWithProjectsAfter2012 = (softUniEntities.Employees
                .Where(
                    e =>
                    DateTime.Compare(e.HireDate, new DateTime(2002, 1, 1)) > 0
                )).ToList();

            int employeesCount = 1;

            foreach (var employee in employeesWithProjectsAfter2012)
            {
                Console.WriteLine(employeesCount + " " + employee.FirstName + " " + employee.LastName +
                    ", HireDate: " + employee.HireDate);
                employeesCount++;
            }

            // Problem 4.       Native SQL Query
            Console.WriteLine("----- Problem 4. previous task by using native SQL query  -----");
            string nativeSQLQuery =
                "SELECT FirstName + ' ' + LastName + ' ' + CONVERT(VARCHAR(24), HireDate, 113) " +
                "FROM dbo.Employees WHERE HireDate > {0}";
            var employees = softUniEntities.Database.SqlQuery<string>(nativeSQLQuery, "01-jan-2002");
            int employeesCount2 = 1;

            foreach (var emp in employees)
            {
                Console.WriteLine(employeesCount2 + " " + emp);
                employeesCount2++;
            }

            // Problem 5.       Employees by Department and Manager [Example Usage]
            var employeesByDepartmentAndManager = EmployeesByDepartmentAndManager("Production", "Jo Brown");
            Console.WriteLine("----- 05. Employees by Department and Manager -----");
            foreach (var emp in employeesByDepartmentAndManager)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName);
            }

            // Problem 8.	Insert a New Project [Example Usage]
            var employeesForProject = softUniEntities.Employees.Where(e => e.EmployeeID > 20 && e.EmployeeID < 35).ToList();
            InsertProject(
                "My awesome project", 
                "The briliant idea man!",
                new DateTime(2002, 12, 20),
                new DateTime(2012, 1, 23),
                employeesForProject);

            // Problem 9.	Call a Stored Procedure [Example Usage]
            Console.WriteLine(GetProjectsCountByEmployee("Roberto", "Tamburello"));
            Console.WriteLine(GetProjectsCountByEmployee("David", "Bradley"));
            Console.WriteLine(GetProjectsCountByEmployee("Ruth", "Ellerbrock"));
        }

        // Problem 5.   Employees by Department and Manager
        public static IQueryable<Employee> EmployeesByDepartmentAndManager(string departmentName, string managerFullName)
        {
            IQueryable<Employee> employees = softUniEntities.Employees
                            .Where(e => e.Department.Name == departmentName &&
                            e.Employee1.FirstName + " " + e.Employee1.LastName == managerFullName);

            return employees;
        }

        // Problem 8.	Insert a New Project
        // Useful Info for transactions : https://msdn.microsoft.com/en-us/data/dn456843.aspx
        public static void InsertProject(
            string name, 
            string description, 
            DateTime startDate, 
            DateTime endDate, 
            ICollection<Employee> employees)
        {
            using (softUniEntities)
            {
                using (var softUniTransaction = softUniEntities.Database.BeginTransaction())
                {
                    Project projectToAdd = new Project();

                    try
                    {
                        projectToAdd.Name = name;
                        projectToAdd.Description = description;
                        projectToAdd.StartDate = startDate;
                        projectToAdd.EndDate = endDate;
                        projectToAdd.Employees = employees;

                        softUniEntities.Projects.Add(projectToAdd);
                        softUniEntities.SaveChanges();
                        softUniTransaction.Commit();
                        Console.WriteLine("Successfully insert new project with name: {0}", projectToAdd.Name);
                    }
                    catch (Exception)
                    {
                        softUniTransaction.Rollback();
                    }
                }
            }
        }

        // Problem 9.	Call a Stored Procedure
        public static int GetProjectsCountByEmployee(string firstName, string lastName)
        {
            using (SoftUniEntities softUniEntities = new SoftUniEntities())
            {
                var projectsCount = softUniEntities.usp_GetProjectsCountByEmployee(firstName, lastName).FirstOrDefault();
                return projectsCount.Value;
            }
        }
    }
}
