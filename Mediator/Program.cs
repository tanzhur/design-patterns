using System;

namespace Mediator
{
    public static class Program
    {
        static void Main()
        {
            var m = new ConcreteMediator();

            var c1 = new ConcreteColleague1(m);
            var c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");
        }
    }

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1;
        private ConcreteColleague2 colleague2;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1 = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2 = value; }
        }

        public override void Send(string message,
          Colleague colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.Notify(message);
            }
            else
            {
                colleague1.Notify(message);
            }
        }
    }

    /// <summary>
    /// The 'Colleague' abstract class
    /// </summary>
    abstract class Colleague
    {
        protected Mediator mediator;

        protected Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class ConcreteColleague2 : Colleague
    {
        // Constructor
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: " + message);
        }
    }
}