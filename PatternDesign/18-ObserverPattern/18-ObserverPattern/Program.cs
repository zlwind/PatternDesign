using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18_ObserverPattern
{
    //观察者模式:
    //定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象，
    //这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己的行为。

    //抽象主题角色（Subject）：抽象主题把所有观察者对象的引用保存在一个列表中，
    //                         并提供增加和删除观察者对象的操作，抽象主题角色又叫做抽象被观察者角色，一般由抽象类或接口实现。
    //                         提供Attach和Detach Observer对象的接口
    //抽象观察者角色（Observer）：为所有具体观察者定义一个接口，在得到主题通知时更新自己，一般由抽象类或接口实现。
    //具体主题角色（ConcreteSubject）：实现抽象主题接口，具体主题角色又叫做具体被观察者角色。
    //具体观察者角色（ConcreteObserver）：实现抽象观察者角色所要求的接口，以便使自身状态与主题的状态相协调。
    //                                      维持一个对ConcreteSubject对象的引用
    //                                   保存subjects状态
    //                                   实现当Observer接口发生变动时，subjects状态同步更新。
    //在观察者模式中，Subject通过Attach()和Detach()方法添加或删除其所关联的观察者，并通过Notify进行更新，让每个观察者都可以观察到最新的状态。
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();
            Observer baidu = new ConcreteObserver("百度");
            subject.Attach(baidu);
            Observer xinlang = new ConcreteObserver("新浪");
            subject.Attach(xinlang);
            Observer tenxun = new ConcreteObserver("腾讯");
            subject.Attach(tenxun);
            Console.WriteLine("设置天气预报数据，在第三方平台显示");
            subject.SetData(125,101);
            Console.WriteLine("更新天气预报数据，在第三方平台显示");
            subject.SetData(13, 2345);
            Console.ReadKey();
        }
    }
}
//观察者模式适用情形：
//  ◊ 当一个抽象模型有两个方面，其中一方面依赖于另一方面。将这二者封装在独立的对象中以使它们可以各自独立地改变和复用。
//  ◊ 当对一个对象的改变需要同时改变其他对象，而不需要知道具体有多少对象有待改变。
//  ◊ 当一个对象必须通知其他对象，而它又不需要知道其它的通知对象是谁，那些其它对象是谁不影响它发送通知这件事。
//观察者模式特点：
//  ◊ 使用面向对象的抽象，Observer模式使得可以独立地改变目标与观察者，从而使二者之间的依赖关系达到松耦合。
//  ◊ 目标发送通知时，无需指定观察者，通知会自动传播。观察者自己决定是否需要订阅通知。
//  ◊ 在C#中的Event。委托充当了Observer接口，而提供事件的对象充当了目标对象，委托是比抽象Observer接口更为松耦合的设计。

//观察者模式有以下几个优点：
//观察者模式实现了表示层和数据逻辑层的分离，并定义了稳定的更新消息传递机制，并抽象了更新接口，使得可以有各种各样不同的表示层，即观察者。
//观察者模式在被观察者和观察者之间建立了一个抽象的耦合，被观察者并不知道任何一个具体的观察者，只是保存着抽象观察者的列表，每个具体观察者都符合一个抽象观察者的接口。
//观察者模式支持广播通信。被观察者会向所有的注册过的观察者发出通知。
//观察者也存在以下一些缺点：
//如果一个被观察者有很多直接和间接的观察者时，将所有的观察者都通知到会花费很多时间。
//虽然观察者模式可以随时使观察者知道所观察的对象发送了变化，但是观察者模式没有相应的机制使观察者知道所观察的对象是怎样发生变化的。
//如果在被观察者之间有循环依赖的话，被观察者会触发它们之间进行循环调用，导致系统崩溃，在使用观察者模式应特别注意这点。