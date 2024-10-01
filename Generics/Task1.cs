using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{

    public class Employee
    {
        private string? fullName;
        private string? position;
        private decimal salary;
        private string? corporateEmail;

        public Employee()
        {
            fullName = "Не вказано";
            position = "Не вказано";
            salary = 0;
            corporateEmail = "Не вказано";
        }

        public Employee(string fullName, string position, decimal salary, string corporateEmail)
        {
            FullName = fullName; 
            Position = position;
            Salary = salary; 
            CorporateEmail = corporateEmail;
        }

        public string? FullName
        {
            get { return fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("П.І.Б не може бути пустим");
                }
                fullName = value;
            }
        }

        public string? Position
        {
            get { return position; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Посада не може бути пустою");
                }
                position = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Зарплата має бути більшою за 0");
                }
                salary = value;
            }
        }

        public string? CorporateEmail
        {
            get { return corporateEmail; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    throw new ArgumentException("Некоректний корпоративний email");
                }
                corporateEmail = value;
            }
        }

        public override string ToString()
        {
            return $"П.І.Б.: {FullName}, Посада: {Position}, Зарплата: {Salary}, Email: {CorporateEmail}";
        }
    }



    public class Management
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmployee(string fullName, string corporateEmail)
        {
            var employeeToRemove = employees.FirstOrDefault(e => e.FullName == fullName && e.CorporateEmail == corporateEmail);

            if (employeeToRemove != null)
            {
                employees.Remove(employeeToRemove);
                Console.WriteLine($"Співробітник {fullName} видалений");
            }
            else
            {
                Console.WriteLine($"Співробітника з ім'ям {fullName} та email {corporateEmail} не знайдено");
            }
        }

        public void UpdateEmployee(string fullName, Employee newInf)
        {

            var employe = employees.FirstOrDefault(e => e.FullName == fullName);

            if (employe != null)
            {
                employe.FullName = newInf.FullName;
                employe.Position = newInf.Position;
                employe.Salary = newInf.Salary;
                employe.CorporateEmail = newInf.CorporateEmail;
                Console.WriteLine($"Інформацію про співробітника {fullName} оновлено");
            }
            else
            {
                Console.WriteLine($"Співробітник {fullName} не знайдений");
            }
        }

        public void SearchEmployee(string searchParameter)
        {
            if (employees.Any(employee => (employee.FullName?.Contains(searchParameter) ?? false) ||
            (employee.Position?.Contains(searchParameter) ?? false)))
            {
                Console.WriteLine("Знайдені співробітники:");

                foreach (var employee in employees.Where(employee =>
                    (employee.FullName?.Contains(searchParameter) ?? false) ||
                    (employee.Position?.Contains(searchParameter) ?? false)))
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Співробітники не знайдені");
            }
        }


        public void SortEmployees(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                Console.WriteLine("Параметр сортування не може бути пустим.");
                return;
            }

            Comparison<Employee> comparison;

            switch (parameter.ToLower())
            {
                case "salary":
                    comparison = (e1, e2) => e1.Salary.CompareTo(e2.Salary);
                    break;
                case "fullname":
                    comparison = (e1, e2) =>
                        (e1.FullName ?? string.Empty).CompareTo(e2.FullName ?? string.Empty);
                    break;
                case "position":
                    comparison = (e1, e2) =>
                        (e1.Position ?? string.Empty).CompareTo(e2.Position ?? string.Empty);
                    break;
                case "email":
                    comparison = (e1, e2) =>
                        (e1.CorporateEmail ?? string.Empty).CompareTo(e2.CorporateEmail ?? string.Empty);
                    break;
                default:
                    Console.WriteLine("Невірний параметр сортування. Використайте 'salary', 'fullname', 'position' або 'email'.");
                    return; 
            }

            employees.Sort(comparison);
            PrintEmployees(employees);
        }

        private void PrintEmployees(List<Employee> sortedEmployees)
        {
            if (sortedEmployees.Any())
            {
                foreach (var employee in sortedEmployees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("Співробітники не знайдені");
            }
        }

    }
}

