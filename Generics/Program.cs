namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();


            management.AddEmployee(new Employee("Григорий Саввич Сковорода", "Менеджер", 15000, "savich@.com"));
            management.AddEmployee(new Employee("Бучко Вікторія Ігорівна", "Розробник", 20000, "vika@.com"));
            management.AddEmployee(new Employee("Тарас Григорьевич Шевченко", "Дизайнер", 17000, "taras@.com"));


            Console.WriteLine("Список співробітників:");
            management.SortEmployees("fullname");


            Console.WriteLine("\nПошук співробітників за параметром Менеджер:");
            management.SearchEmployee("Менеджер");


            Console.WriteLine("\nОновлення інформації:");
            management.UpdateEmployee("Григорий Саввич Сковорода", new Employee("Григорий Саввич Сковорода", "Старший Менеджер", 18000, "savich@.com"));


            Console.WriteLine("\nСписок співробітників після оновлення:");
            management.SortEmployees("fullname");


            Console.WriteLine("\nВидалення співробітника:");
            management.RemoveEmployee("Тарас Григорьевич Шевченко", "taras@.com");


            Console.WriteLine("\nСписок співробітників після видалення:");
            management.SortEmployees("fullname");


            Console.WriteLine("\nСортування співробітників за зарплатою:");
            management.SortEmployees("salary");

            Console.WriteLine("\nTask3");
            Cafe cafe = new Cafe(3); 

            var visitorGroups = new List<List<Visitor>>
            {
            new List<Visitor>
            {
                new Visitor("Сергій", true),
                new Visitor("Олег", false),
                new Visitor("Олександр", true)
            },
            new List<Visitor>
            {
                new Visitor("Іван", true),
                new Visitor("Ольга", false)
            },
            new List<Visitor>
            {
                new Visitor("Дмитро", false),
                new Visitor("Марія", false)
            }
          };

            cafe.ProcessArrivalGroups(visitorGroups);
        }
    }
}