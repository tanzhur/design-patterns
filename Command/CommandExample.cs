﻿using System;

namespace Command
{
    static class CommandExample
    {
        static void Main()
        {
            // Create receiver, command, and invoker
            Receiver receiver = new Receiver(); // TV
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker(); // Remote

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver;

        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    class ConcreteCommand : Command
    {
        // Constructor
        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class Invoker
    {
        private Command command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}