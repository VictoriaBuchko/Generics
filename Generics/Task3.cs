using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Visitor
    {
        public string Name { get; set; }
        public bool HasReservation { get; set; }

        public Visitor(string name, bool hasReservation)
        {
            Name = name;
            HasReservation = hasReservation;
        }
    }

    public class Cafe
    {
        private Queue<Visitor> waitingQueue = new Queue<Visitor>();
        private List<Visitor> reservedVisitors = new List<Visitor>();
        private int totalTables;
        private int occupiedTables;

        public Cafe(int totalTables)
        {
            this.totalTables = totalTables;
            occupiedTables = 0;
        }

        public void Arrive(List<Visitor> visitors)
        {
            foreach (var visitor in visitors)
            {
                if (visitor.HasReservation)
                {
                    reservedVisitors.Add(visitor);
                    Console.WriteLine($"{visitor.Name} с резервом пришёл");
                    
                }
                else
                {
                    waitingQueue.Enqueue(visitor);
                    Console.WriteLine($"{visitor.Name} попал в очередь");
                    
                }
            }

            AssignTables();
        }

        public void ReleaseTable()
        {
            if (occupiedTables > 0)
            {
                occupiedTables--;
                Console.WriteLine("Столик освободился");
                AssignTables(); 
            }
        }

        private void AssignTables()
        {
            while (reservedVisitors.Count > 0 && occupiedTables < totalTables)
            {
                var visitor = reservedVisitors.First();
                reservedVisitors.Remove(visitor);
                occupiedTables++;
                Console.WriteLine($"{visitor.Name} занял зарезервированный столик");
                Thread.Sleep(10000); 
                Console.WriteLine($"{visitor.Name} покинул столик");
                ReleaseTable();
            }

            while (waitingQueue.Count > 0 && occupiedTables < totalTables)
            {
                var visitor = waitingQueue.Dequeue();
                occupiedTables++;
                Console.WriteLine($"{visitor.Name} занял столик из очереди");
                Thread.Sleep(2000); 
                Console.WriteLine($"{visitor.Name} покинул столик");
                ReleaseTable();
            }
        }

        public void ProcessArrivalGroups(List<List<Visitor>> visitorGroups)
        {
            foreach (var group in visitorGroups)
            {
                Arrive(group);
                Thread.Sleep(1000); 
            }

            while (occupiedTables > 0 || reservedVisitors.Count > 0 || waitingQueue.Count > 0)
            {
                Thread.Sleep(100);
            }
        }
    }

}