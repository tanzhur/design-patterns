using System;
using System.Collections.Generic;

namespace Visitor___Employee
{
    /// <summary>
    /// Program startup class for Real-World
    /// Visitor Design Pattern.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Setup employee collection
            Employees employees = new Employees();
            employees.Attach(new Clerk());
            employees.Attach(new Director());
            employees.Attach(new President());

            // Employees are 'visited'
            employees.Accept(new IncomeVisitor());
            employees.Accept(new VacationVisitor());

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    interface IVisitor
    {
        void Visit(Element element);
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}", employee.GetType().Name, employee.Name, employee.Income);
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            Console.WriteLine("{0} {1}'s new vacation days: {2}", employee.GetType().Name, employee.Name, employee.VacationDays);
        }
    }

    /// <summary>
    /// The 'Element' abstract class
    /// </summary>
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    class Employee : Element
    {
        private string name;
        private double income;
        private int vacationDays;

        // Constructor
        public Employee(string name, double income, int vacationDays)
        {
            this.name = name;
            this.income = income;
            this.vacationDays = vacationDays;
        }

        // Gets or sets the name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Gets or sets income
        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        // Gets or sets number of vacation days
        public int VacationDays
        {
            get { return vacationDays; }
            set { vacationDays = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    class Employees
    {
        private List<Employee> employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in employees)
            {
                e.Accept(visitor);
            }
            Console.WriteLine();
        }
    }

    // Three employee types

    class Clerk : Employee
    {
        // Constructor
        public Clerk()
            : base("Hank", 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        // Constructor
        public Director()
            : base("Elly", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        // Constructor
        public President()
            : base("Dick", 45000.0, 21)
        {
        }
    }
}