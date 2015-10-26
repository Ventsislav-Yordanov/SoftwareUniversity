namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SalaryCalculator
    {
        public static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            List<int>[] employees = ReadEmployees(numberOfEmployees);

            int[] managerCounts = GetManagerCounts(numberOfEmployees, employees);
            int[] salaries = new int[numberOfEmployees];

            for (int employeeIndex = 0; employeeIndex < employees.Length; employeeIndex++)
            {
                salaries[employeeIndex] = CalculateSalariesDFS(employees, salaries, employeeIndex);
            }

            Console.WriteLine(salaries.Sum());
        }

        private static List<int>[] ReadEmployees(int numberOfEmployees)
        {
            var employees = new List<int>[numberOfEmployees];
            for (int i = 0; i < numberOfEmployees; i++)
            {
                employees[i] = new List<int>();
                char[] currentLinks = Console.ReadLine().ToCharArray();
                for (int link = 0; link < currentLinks.Length; link++)
                {
                    if (currentLinks[link] == 'Y')
                    {
                        employees[i].Add(link);
                    }
                }
            }

            return employees;
        }

        private static int[] GetManagerCounts(int numberOfEmployees, List<int>[] employees)
        {
            var managerCounts = new int[numberOfEmployees];
            foreach (var employee in employees)
            {
                foreach (var subordinateEmployee in employee)
                {
                    managerCounts[subordinateEmployee]++;
                }
            }

            return managerCounts;
        }

        private static int CalculateSalariesDFS(List<int>[] employees, int[] salaries, int employeeIndex)
        {
            if (employees[employeeIndex].Count == 0)
            {
                return 1;
            }
            else if (salaries[employeeIndex] != 0)
            {
                // Memoization - do not repeat the same computations twice
                return salaries[employeeIndex];
            }

            int salary = 0;
            foreach (var subordinateEmployee in employees[employeeIndex])
            {
                salary += CalculateSalariesDFS(employees, salaries, subordinateEmployee);
            }

            return salary;
        }
    }
}
