using System;

namespace Prototype___Animal
{
    static class Program
    {
        static void Main(string[] args)
        {
            var molly = new Sheep("Molly");
            var mollyClone = (Sheep)molly.Clone();

            Console.WriteLine("Molly clone hash: {0}.", mollyClone.GetHashCode());
            Console.WriteLine("Molly hash {0}.", molly.GetHashCode());
        }
    }

    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    public abstract class Animal : ICloneable
    {
        private readonly string name;

        // Constructor
        protected Animal(string name)
        {
            this.name = name;
        }

        // Gets name
        public string Name
        {
            get { return name; }
        }

        public abstract object Clone();
    }

    public class Sheep : Animal
    {
        public Sheep(string name)
            : base(name)
        {
            Console.WriteLine("Sheep with name {0} was created.", name);
        }

        public override object Clone()
        {
            return new Sheep(this.Name);
        }
    }
}
