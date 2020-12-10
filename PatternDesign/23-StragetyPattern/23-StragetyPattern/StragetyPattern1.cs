using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _23_StragetyPattern
{
    // "Strategy"
    abstract class Strategy
    {
        // Methods
        abstract public void AlgorithmInterface();
    }

    // "ConcreteStrategyA"
    class ConcreteStrategyA : Strategy
    {
        // Methods
        override public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    // "ConcreteStrategyB"
    class ConcreteStrategyB : Strategy
    {
        // Methods
        override public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    // "ConcreteStrategyC"
    class ConcreteStrategyC : Strategy
    {
        // Methods
        override public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    // "Context"
    class Context
    {
        // Fields
        Strategy strategy;

        // Constructors
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        // Methods
        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }

    /// <summary>
    /// Client test
    /// </summary>
    public class Client
    {

        // Three contexts following different strategies
        public void client()
        {
            Context c = new Context(new ConcreteStrategyA());
            c.ContextInterface();

            Context d = new Context(new ConcreteStrategyB());
            d.ContextInterface();

            Context e = new Context(new ConcreteStrategyC());
            e.ContextInterface();
        }

    }
}
