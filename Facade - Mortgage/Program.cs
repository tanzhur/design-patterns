using System;

namespace Facade___Mortgage
{
    public static class Program
    {
        static void Main()
        {
            // Facade
            var mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            var customer = new Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Customer class
    /// </summary>
    class Customer
    {
        private string name;

        // Constructor
        public Customer(string name)
        {
            this.name = name;
        }

        // Gets the name
        public string Name
        {
            get { return name; }
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Mortgage
    {
        private Bank bank = new Bank();
        private Loan loan = new Loan();
        private Credit credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",cust.Name, amount);

            bool eligible = true;

            // Check creditworthyness of applicant
            if (!bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}