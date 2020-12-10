using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_DecoratorPattern
{
    //装饰者模式：
    //以对客户透明的方式动态地给一个对象添加额外的职责，采用对象组合而非继承的方式实现了再运行时动态地扩展对象功能的能力，
    //相比生成子类可以更灵活地增加功能，而且可以根据需要扩展多个功能，避免了单独使用继承带来的灵活性差和多子类衍生问题。
    //同时它很好地符合面向对象设计原则中 ”优先使用对象组合而非继承“和”开放-封闭“原则。

    //装饰者模式中的各个角色：
    //抽象构件角色：给出一个抽象接口，以规范准备接受附加责任的对象。
    //具体构件角色：定义一个将要接收附加责任的类。
    //装饰角色：持有一个构件（Component）对象的实例，并定义一个与抽象构件接口一致的接口。
    //具体装饰角色：负责给构件对象 ”贴上“附加的责任。


    class Program
    {
        static void Main(string[] args)
        {
            Coffe espresso = new Espresso();//调用构件
            Decorator decorator = new Milk(espresso);//给构件添加装饰
            decorator = new Soy(espresso);
            decorator = new Chocolate(espresso);
            Console.WriteLine(espresso.Des);//输出描述
            Console.WriteLine("价格总计：" + espresso.Price.ToString());//输出合计价格
            Console.ReadKey();
        }
    }
}
//四、使用场景：
//需要扩展一个类的功能或给一个类增加附加责任。
//需要动态地给一个对象增加功能，这些功能可以再动态地撤销。
//需要增加由一些基本功能的排列组合而产生的非常大量的功能
//五、总结：
//优点：
//装饰这模式和继承的目的都是扩展对象的功能，但装饰者模式比继承更灵活
//通过使用不同的具体装饰类以及这些类的排列组合，设计师可以创造出很多不同行为的组合
//装饰者模式有很好地可扩展性
//缺点：
//装饰者模式会导致设计中出现许多小对象，如果过度使用，会让程序变的更复杂。并且更多的对象会是的差错变得困难，特别是这些对象看上去都很像。