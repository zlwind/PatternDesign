using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14_TemplateMethodPattern
{
    /// <summary>
    /// 抽象类角色（AbstractClass）：定义一个模板，其子类将重定义PrimitiveOperation1和PrimitiveOperation2操作。
    /// </summary>
    public abstract class AbstractClass
    {
        /// <summary>
        /// 需要具体子类实现的抽象方法 可以抽象方法或虚方法（具体实现，可以重写）
        /// 模板方法里面的算法步骤，可以有默认实现，也可以没有实现，在C#里面可以是抽象方法，
        /// 当然模板方法也可以有有返回值，也可以没有返回值。
        /// </summary>
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        /// <summary>
        /// The "Template method"
        /// 定义的模板方法，规定了算法的结构
        /// </summary>
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }
    /// <summary>
    /// 具体类A:
    /// 具体类角色（ConcreteClass）：实现PrimitiveOperation1和PrimitiveOperation2以完成算法中与特定子类（Client）相关的内容。
    /// </summary>
    public class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }
    /// <summary>
    /// 具体类B:
    /// 具体类角色（ConcreteClass）：实现PrimitiveOperation1和PrimitiveOperation2以完成算法中与特定子类（Client）相关的内容。
    /// </summary>
    public class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }
}
