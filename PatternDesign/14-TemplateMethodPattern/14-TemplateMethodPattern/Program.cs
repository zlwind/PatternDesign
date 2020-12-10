using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14_TemplateMethodPattern
{
    //模板方法模式:
    //定义一个操作中算法的骨架，将这些步骤延迟到子类中。模板方法模式使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。

  //  模板方法模式参与者：
  //◊ 抽象类角色（AbstractClass）：定义一个模板，其子类将重定义PrimitiveOperation1和PrimitiveOperation2操作。
  //◊ 具体类角色（ConcreteClass）：实现PrimitiveOperation1和PrimitiveOperation2以完成算法中与特定子类（Client）相关的内容。
  //在模板方法模式中，AbstractClass中的TemplateMethod提供了一个标准模板，
  //  该模板包含PrimitiveOperation1和PrimitiveOperation2两个方法，这两个方法的内容Client可以根据自己的需要重写。
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();
            Console.ReadKey();
        }
    }
}
//模板方法模式适用情形：
//  ◊ 一次性实现一个算法的不变部分，并将可变的行为留给子类来实现。
//  ◊ 各子类中公共的行为应被提取出来并集中到一个公共父类中以避免代码重复。
//  ◊ 控制子类扩展。模板方法只允许在特定点进行扩展，而模板部分则是稳定的。
//  模板方法模式特点：
//  ◊ TemplateMethod模式是一种非常基础性的设计模式，在面向对象系统中大量应用。
//      它用最简洁的机制（基础、多态）为很多应用程序框架提供了灵活的扩展点，是代码复用方面的基本实现结构。
//  ◊ 在具体实现方面，被TemplateMethod调用的虚方法可以具有实现，也可以没有任何实现（抽象方法或虚方法）。
//      但一般推荐将它们设置为protected方法使得只有子类可以访问它们。
//  ◊ 模板方法模式通过对子类的扩展增加新的行为，符合“开闭原则”。