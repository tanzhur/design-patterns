using System;

namespace State
{
    public static class StateExample
    {
        static void Main()
        {
            // Setup context in a state
            var c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }

    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Context
    {
        private State state;

        public Context(State state)
        {
            this.State = state;
        }

        public State State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                Console.WriteLine("State: " +state.GetType().Name);
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }
}