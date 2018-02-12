using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ForOOPS.BehavioralPattern.Interpreter
{
    /// <summary>

    /// MainApp startup class for Structural 

    /// Interpreter Design Pattern.

    /// </summary>

    class Structural

    {
        /// <summary>

        /// Entry point into console application.

        /// </summary>

        void Main()
        {
            Context1 context = new Context1();

            // Usually a tree 

            ArrayList list = new ArrayList();

            // Populate 'abstract syntax tree' 

            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Context' class

    /// </summary>

    class Context1

    {
    }

    /// <summary>

    /// The 'AbstractExpression' abstract class

    /// </summary>

    abstract class AbstractExpression

    {
        public abstract void Interpret(Context1 context);
    }

    /// <summary>

    /// The 'TerminalExpression' class

    /// </summary>

    class TerminalExpression : AbstractExpression

    {
        public override void Interpret(Context1 context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    /// <summary>

    /// The 'NonterminalExpression' class

    /// </summary>

    class NonterminalExpression : AbstractExpression

    {
        public override void Interpret(Context1 context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}
