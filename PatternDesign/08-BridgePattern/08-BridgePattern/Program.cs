using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_BridgePattern
{ 
    //桥接模式：
    //桥接模式即将抽象部分与实现部分脱耦，使它们可以独立变化。
    //桥接模式的目的就是使两者分离，根据面向对象的封装变化的原则，
    //我们可以把实现部分的变化封装到另外一个类中，这样的一个思路也就是桥接模式的实现，

    //结构：
    //Abstraction：抽象化生成的类，如形状类；
    //Implementor：行为实现接口，抽象化后关注的其他的特性，如例子中颜色接口。注意：我们可以把颜色抽象化生成抽象类，把形状作为行为实现接口；
    //RefinedAbstraction：抽象类子类，如圆形，长方形等；
    //ConcreteImplementor：行为实现接口的实现类，如黄色，红色等；

    //场景：给图形绘制颜色 抽象化：图形 行为：绘制颜色
    /// <summary>
    ///Abstraction：抽象化生成的类，如形状类；
    /// </summary>
    public abstract class Shape
    {
        protected IColor color;//管理行为
        public void setColor(IColor color)
        { this.color = color; }
        public abstract void Paint();
    }
    /// <summary>
    /// RefinedAbstraction：抽象类子类 圆形
    /// </summary>
    public class Circle : Shape
    {
        public override void Paint()
        {
            color.Draw("圆形");
        }
    }
    /// <summary>
    /// RefinedAbstraction：抽象类子类 长方形
    /// </summary>
    public class Rectangle : Shape
    {
        public override void Paint()
        {
            color.Draw("长方形");
        }
    }
    /// <summary>
    /// RefinedAbstraction：抽象类子类 三角形
    /// </summary>
    public class Triangle : Shape
    {
        public override void Paint()
        {
            color.Draw("三角形");
        }
    }
    /// <summary>
    /// Implementor：行为实现接口，抽象化后关注的其他的特性，如例子中颜色接口。
    /// 注意：我们可以把颜色抽象化生成抽象类，把形状作为行为实现接口；
    /// </summary>
    public interface IColor
    {
        void Draw(string shape);
    }
    /// <summary>
    /// ConcreteImplementor：行为实现接口的实现类，蓝色；
    /// </summary>
    class Blue : IColor
    {
        public void Draw(string shape)
        {
            Console.WriteLine("{0}绘制蓝色", shape);
        }
    }
    /// <summary>
    /// ConcreteImplementor：行为实现接口的实现类，红色；
    /// </summary>
    class Red : IColor
    {
        public void Draw(string shape)
        {
            Console.WriteLine("{0}绘制红色", shape);
        }
    }
    /// <summary>
    /// ConcreteImplementor：行为实现接口的实现类，黄色；
    /// </summary>
    class Yellow : IColor
    {
        public void Draw(string shape)
        {
            Console.WriteLine("{0}绘制黄色", shape);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IColor blue = new Blue();
            Shape shape = new Triangle();
            shape.setColor(blue);
            shape.Paint();
            Console.ReadKey();
        }
    }
}
//桥接模式可以适用于以下情形：
//  ◊ 不希望在抽象与实现部分之间有固定的绑定关系；
//  ◊ 类的抽象以及它的实现都应该可以通过生成子类的方法加以扩充。这时桥接模式可以对不同的抽象接口和实现部分进行组合，并分别对它们进行扩充；
//  ◊ 对抽象的实现部分进行修改应对客户不产生影响，即客户的代码不必重新编译；
//  ◊ 想对客户完全隐藏抽象的实现部分；
//  ◊ 想在多个对象间共享实现，但同时要求客户并不知道这点。
//  桥接模式具有以下特点：
//  ◊ 分离接口及其实现部分，一个实现未必不变地绑定在一个接口上。抽象类的实现可以在运行时刻进行配置，
//       一个对象甚至可以在运行时刻改变它的实现；
//  ◊ 将Abstraction与Implementor分离有助于降低对实现部分编译时刻的依赖性；当改变一个实现类时，
//      并不需要重新编译Abstraction类和Client类。为了保证一个类库的不同版本之间的兼容，需要有这个特性；
//  ◊ 接口与实现分离有助于分层，从而产生更好的结构化系统。系统的高层部分仅需要知道Abstraction和Implementor即可；
//  ◊ 提高可扩充性。可以独立的对Abstraction和Implementor层次结构进行扩充；
//  ◊ 实现细节对Client透明。可以对Client隐藏实现细节，如共享Implementor对象以及相应的引用计数机制。