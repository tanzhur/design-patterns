﻿using System;

namespace Memento___Sales
{
    public static class Program
    {
        static void Main()
        {
            SalesProspect s = new SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Store internal state
            ProspectMemory m = new ProspectMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Restore saved state
            s.RestoreMemento(m.Memento);
        }
    }

    /// <summary>
    /// The 'Originator' class
    /// </summary>
    class SalesProspect
    {
        private string name;
        private string phone;
        private double budget;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                Console.WriteLine("Name:  " + name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
                Console.WriteLine("Phone: " + phone);
            }
        }

        public double Budget
        {
            get
            {
                return budget;
            }

            set
            {
                budget = value;
                Console.WriteLine("Budget: " + budget);
            }
        }

        // Stores memento
        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(name, phone, budget);
        }

        // Restores memento
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    class Memento
    {
        private string name;
        private string phone;
        private double budget;

        public Memento(string name, string phone, double budget)
        {
            this.name = name;
            this.phone = phone;
            this.budget = budget;
        }

        // Gets or sets name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Gets or set phone
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public double Budget
        {
            get
            {
                return budget;
            }

            set
            {
                budget = value;
            }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class ProspectMemory
    {
        private Memento memento;

        // Property
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }
}