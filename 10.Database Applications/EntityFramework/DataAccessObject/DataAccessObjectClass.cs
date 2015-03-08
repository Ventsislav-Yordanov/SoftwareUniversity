using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUni.Entities;

namespace DataAccessObject
{
    class DataAccessObjectClass
    {
        private static SoftUniEntities softUniEntities = new SoftUniEntities();

        static void Main(string[] args)
        {
            var hireDate = DateTime.Today.AddDays(1);
            insertEmployee("Ventsislav", "Yordanov", "C# Developer", 1, hireDate, 1250m, null, null, null);

            var hireDate2 = DateTime.Today.AddDays(3);
            insertEmployee("Alex", "Obretenov", "C# Developer", 1, hireDate2, 1500m, "Ivanov", 288, 200);

            DeleteEmployee(303);

            UpdateEmployee(2, "FirstName", "Gosho");
        }

        public static void insertEmployee(string firstName, string lastName, string jobTitle, int departmentId,
            DateTime hireDate, decimal salary, string middleName = null, int? managerId = null, int? addressId = null)
        {
            var newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                JobTitle = jobTitle,
                DepartmentID = departmentId,
                ManagerID = managerId,
                HireDate = hireDate,
                Salary = salary,
                AddressID = addressId
            };
            softUniEntities.Employees.Add(newEmployee);
            softUniEntities.SaveChanges();
            Console.WriteLine("Successfuly insert employee" + Environment.NewLine +
                              "EmployeeID: " + newEmployee.EmployeeID + Environment.NewLine +
                              "FirstName: " + firstName + Environment.NewLine +
                              "LastName: " + lastName + Environment.NewLine +
                              "MiddleName: " + middleName + Environment.NewLine +
                              "JobTitle: " + jobTitle + Environment.NewLine +
                              "DepartmentID: " + departmentId + Environment.NewLine +
                              "ManagerID: " + managerId + Environment.NewLine +
                              "HireDate: " + hireDate + Environment.NewLine +
                              "Salary: " + salary + Environment.NewLine +
                              "AddressID: " + addressId + Environment.NewLine);
        }

        public static void DeleteEmployee(int employeeId)
        {
            Employee employee = softUniEntities.Employees.Find(employeeId);

            if (employee != null)
            {
                softUniEntities.Employees.Remove(employee);
                softUniEntities.SaveChanges();
                Console.WriteLine("Successfully deleted employee with id: {0}", employeeId);
            }
        }

        public static void UpdateEmployee(int employeeId, string properyName, object newValue)
        {
            Employee employee = softUniEntities.Employees.Find(employeeId);
            var oldValue = employee.GetType().GetProperty(properyName).GetValue(employee);

            if (employee != null)
            {
                employee.GetType().GetProperty(properyName).SetValue(employee, newValue);
                softUniEntities.SaveChanges();
                Console.WriteLine("Successfully updated propery: {0} on employee with Id: {1}." + Environment.NewLine +
                                  "Old value: {2}, New Value: {3}",
                                  properyName, employeeId, oldValue, newValue);
            }
        }
    }
}
