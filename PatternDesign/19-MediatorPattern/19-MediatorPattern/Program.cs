using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19_MediatorPattern
{
    //中介者模式：
    //定义了一个中介对象来封装一系列对象之间的交互关系。中介者使各个对象之间不需要显式地相互引用，
    //从而使耦合性降低，而且可以独立地改变它们之间的交互行为。


    //可以看出，在中介者模式的结构图有以下角色：

    //（1）、抽象中介者角色（Mediator）：在里面定义各个同事之间交互需要的方法，可以是公共的通信方法，也可以是小范围的交互方法。

    //（2）、具体中介者角色（ConcreteMediator）：它需要了解并维护各个同事对象，并负责具体的协调各同事对象的交互关系。

    //（3）、抽象同事类（Colleague）：通常为抽象类，主要约束同事对象的类型，并实现一些具体同事类之间的公共功能，
    //比如，每个具体同事类都应该知道中介者对象，也就是具体同事类都会持有中介者对象，都可以到这个类里面。

    //（4）、具体同事类（ConcreteColleague）：实现自己的业务，需要与其他同事通信时候，就与持有的中介者通信，中介者会负责与其他同事类交互。
    class Program
    {
        static void Main(string[] args)
        {
            AbstractCardPlayer a = new PlayerA() { MoneyCount = 20 };
            AbstractCardPlayer b = new PlayerB() { MoneyCount = 20 };
            AbstractMediator mediator = new Mediator(a, b);
            //玩家a赢了玩家b 5元
            Console.WriteLine("a赢了b5元");
            a.ChangeCount(5, mediator);
            Console.WriteLine("玩家a现在有{0}元", a.MoneyCount);
            Console.WriteLine("玩家b现在有{0}元", b.MoneyCount);
            //玩家b赢了玩家a 10元
            Console.WriteLine("b赢了a10元");
            b.ChangeCount(10, mediator);
            Console.WriteLine("玩家a现在有{0}元", a.MoneyCount);
            Console.WriteLine("玩家b现在有{0}元", b.MoneyCount);
            Console.ReadKey();
        }
    }
}
//中介者模式优点：
//  1 降低了同事类交互的复杂度，将一对多转化成了一对一；
//  2 各个类之间的解耦；
//  3 符合迪米特原则。
//中介者模式缺点：
//  1 业务复杂时中介者类会变得复杂难以维护。
//  2 新增加一个同事类时，不得不去修改抽象中介者类和具体中介者类，此时可以使用观察者模式和状态模式来解决这个问题。


//中介者模式的适用场景
//   一般在以下情况下可以考虑使用中介者模式：
//     一组定义良好的对象，现在要进行复杂的相互通信。
//     想通过一个中间类来封装多个类中的行为，而又不想生成太多的子类。