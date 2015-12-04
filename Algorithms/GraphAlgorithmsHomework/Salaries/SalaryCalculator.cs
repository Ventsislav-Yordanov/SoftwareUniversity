namespace Salaries
{
    using System;
    using System.Collections.Generic;

    public class SalaryCalculator
    {
        public static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            List<int>[] employees = ReadEmployees(numberOfEmployees);

            ulong[] salaries = new ulong[numberOfEmployees];
            ulong totalSum = 0;

            for (int employeeIndex = 0; employeeIndex < employees.Length; employeeIndex++)
            {
                salaries[employeeIndex] = CalculateSalariesDFS(employees, salaries, employeeIndex);
                totalSum += salaries[employeeIndex];
            }

            Console.WriteLine(totalSum);
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

        private static ulong CalculateSalariesDFS(List<int>[] employees, ulong[] salaries, int employeeIndex)
        {
            if (employees[employeeIndex].Count == 0)
            {
                salaries[employeeIndex] = 1;
            }

            if (salaries[employeeIndex] != 0)
            {
                // Memoization - do not repeat the same computations twice
                return salaries[employeeIndex];
            }

            ulong salary = 0;
            foreach (var subordinateEmployee in employees[employeeIndex])
            {
                ulong subordinateSalary = CalculateSalariesDFS(employees, salaries, subordinateEmployee);
                salaries[subordinateEmployee] = subordinateSalary;
                salary += subordinateSalary;
            }

            return salary;
        }
    }
}
