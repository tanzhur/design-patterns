using System;
using System.Collections;

namespace Interpreter
{
    public static class Program
    {
        static void Main()
        {
            var context = new Context();

            var list = new ArrayList
            {
                new TerminalExpression(),
                new NonterminalExpression(),
                new TerminalExpression(),
                new TerminalExpression()
            };

            // Interpret
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Context
    {
    }

    /// <summary>
    /// The 'AbstractExpression' abstract class
    /// </summary>
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    /// <summary>
    /// The 'TerminalExpression' class
    /// </summary>
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    /// <summary>
    /// The 'NonterminalExpression' class
    /// </summary>
    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}