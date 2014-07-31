using System;

namespace Decorator___Pizza
{
    static class Program
    {
        static void Main()
        {
            Ingredient item = new TomatoSauce(new Mozzarella(new Dough()));

            Console.WriteLine(item.Description);
            Console.WriteLine(item.Cost);
        }
    }

    /// <summary>
    /// Component abstract class
    /// </summary>
    public abstract class Ingredient
    {
        public abstract string Description { get; }

        public abstract decimal Cost { get; }
    }

    /// <summary>
    /// Concrete component
    /// </summary>
    public sealed class Dough : Ingredient
    {
        private readonly decimal cost;
        private readonly string description;

        public Dough()
        {
            Console.WriteLine("Adding dough.");
            this.cost = 10m;
            this.description = "Thin Dough";
        }

        public override string Description
        {
            get { return description; }
        }

        public override decimal Cost
        {
            get { return cost; }
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    public abstract class Topping : Ingredient
    {
        protected readonly Ingredient ingredient;

        protected Topping(Ingredient ingredient)
        {
            this.ingredient = ingredient;
        }

        public override string Description
        {
            get { return this.ingredient.Description; }
        }

        public override decimal Cost
        {
            get
            {
                return this.ingredient.Cost;
            }
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class Mozzarella : Topping
    {
        public Mozzarella(Ingredient ingredient)
            : base(ingredient)
        {
            Console.WriteLine("Adding mozzarella.");
        }

        public override string Description
        {
            get
            {
                return this.ingredient.Description + ", Mozzarella";
            }
        }

        public override decimal Cost
        {
            get { return this.ingredient.Cost + 2.00m; }
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class TomatoSauce : Topping
    {
        public TomatoSauce(Ingredient ingredient)
            : base(ingredient)
        {
            Console.WriteLine("Adding tomato sauce.");
        }

        public override string Description
        {
            get
            {
                return this.ingredient.Description + ", Tomato sauce";
            }
        }

        public override decimal Cost
        {
            get { return this.ingredient.Cost + 3.00m; }
        }
    }
}
