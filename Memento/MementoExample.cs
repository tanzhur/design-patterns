using System;

namespace Memento
{
    public static class MementoExample
    {
        static void Main()
        {
            Originator o = new Originator {State = "On"};

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);
        }
    }

    /// <summary>
    /// The 'Originator' class
    /// </summary>
    class Originator
    {
        private string state;

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }

        // Creates memento
        public Memento CreateMemento()
        {
            return (new Memento(state));
        }

        // Restores original state
        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string State
        {
            get { return state; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    class Caretaker
    {
        private Memento memento;

        // Gets or sets memento
        public Memento Memento
        {
            set { memento = value; }
            get { return memento; }
        }
    }
}