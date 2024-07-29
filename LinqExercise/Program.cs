using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Done  TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");
            

            //Done  TODO: Print the Average of numbers
            var average = numbers.Average();
            Console.WriteLine($"Average: {average}");

            //Done  TODO: Order numbers in ascending order and print to the console
            var ascendingOrder = numbers.OrderBy(x => x);
            foreach (var number in ascendingOrder)
            {
                Console.WriteLine($"Ascending order: {number}");
            }

            Console.WriteLine();

            //Done  TODO: Order numbers in descending order and print to the console
            /*var descendingOrder = numbers.OrderByDescending(x => x);
            foreach (var number in descendingOrder)
            {
                Console.WriteLine($"Descending order: {number}");
            }*/

            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var number in greaterThanSix)
            {
                Console.WriteLine($"Numbers > 6: {number}");
            }

            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            /*var fourNumbers = numbers.OrderBy(X => X).Where(X => X < 4);
            foreach (var number in fourNumbers)
            {
                Console.WriteLine($"Only four numbers: {number}");
            }*/
            var fourNumbers = numbers.OrderBy(x => x);
            foreach (var number in fourNumbers.Take(4))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            /*int myAge = 33;
            numbers[4] = myAge;
            var myAgeIncluded = numbers.OrderByDescending(x => x);
            foreach (var number in myAgeIncluded)
            {
                Console.WriteLine($"Switched in my age: {number}");
            }*/
            numbers.Select((number, index) => index == 4 ? 33 : number).OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var ascendingFirstName = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);
            foreach (var employee in ascendingFirstName)
            {
                Console.WriteLine($"Employee by first name: {employee.FullName}");
            }

            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
                
            var byAgeThenFirstName = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var employee in byAgeThenFirstName)
            {
                Console.WriteLine($"Employee by age and name: {employee.FullName}, {employee.Age}");
            }

            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumOfYoe = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);
            
            Console.WriteLine($"Sum of Years: {sumOfYoe}");
            Console.WriteLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var averageOfYoe = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience);
            Console.WriteLine($"Average of Years: {averageOfYoe}");
            Console.WriteLine();


            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine($"The list of employees includes: {employees.Count}");
            var lastEmployee = new Employee("Jax", "Harper", 44, 14);
            //employees = employees.Append(new Employee("Seth" "Bowman", 30, 5)).ToList();
            employees.Insert(employees.Count, lastEmployee);
            Console.WriteLine($"The list of employees includes: {employees.Count}");
            Console.WriteLine($"The list of employees includes:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
            


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
