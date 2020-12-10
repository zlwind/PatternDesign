using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13_Proxy_Pattern
{
    //代理模式（Proxy）定义：
    //代理模式为客户端程序提供一种中间层以控制对这个对象的访问。并由代理对象控制对原对象的引用
    //在一些情况下，一个客户不想或者不能直接引用一个对象，而代理对象可以在客户端和目标对象之间起到中介的作用。
    //例如电脑桌面的快捷方式就是一个代理对象，快捷方式是它所引用的程序的一个代理。

    //  ◊ Proxy 代理主题角色
  //  ° 维持一个引用，使得代理可以访问Subject。
  //  ° 提供一个与Subject的接口相同的接口，这样代理就可以替代Subject。
  //  ° 控制对Subject的访问，并可能负责对Subject的创建和删除。
    //◊ Subject 抽象主题角色：定义ConcreteSubject与Proxy的共用接口，从而在任何使用ConcreteSubject的地方都可以使用Proxy。
    //◊ ConcreteSubject 真实主题角色：定义Proxy所代表的Subject。
    //◊ Client 客户端：维持一个对Subject的引用
    class Program
    {
        static void Main(string[] args)
        {
            // Create math proxy
            MathProxy proxy = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
            Console.ReadKey();
        }
    }
}
//代理模式按照使用目的可以分为以下几种：
//远程（Remote）代理：
//为一个位于不同的地址空间的对象提供一个局域代表对象。这个不同的地址空间可以是本电脑中，
//也可以在另一台电脑中。最典型的例子就是——客户端调用Web服务或WCF服务。
//虚拟（Virtual）代理：
//根据需要创建一个资源消耗较大的对象，使得对象只在需要时才会被真正创建。
//Copy-on-Write代理：
//虚拟代理的一种，把复制（或者叫克隆）拖延到只有在客户端需要时，才真正采取行动。
//保护（Protect or Access）代理：
//控制一个对象的访问，可以给不同的用户提供不同级别的使用权限。
//防火墙（Firewall）代理：
//保护目标不让恶意用户接近。
//智能引用（Smart Reference）代理：
//当一个对象被引用时，提供一些额外的操作，比如将对此对象调用的次数记录下来等。
//Cache代理：
//为某一个目标操作的结果提供临时的存储空间，以便多个客户端可以这些结果。
//在哦上面所有种类的代理模式中，虚拟代理、远程代理、智能引用代理和保护代理较为常见的代理模式。



//代理模式适用范围很广，不同的代理适合于不同的情形。
//  ◊ 远程代理为一个对象在不同的地址空间提供局部代表。
//  ◊ 虚代理在需要创建开销很大的对象时缓存对象信息。
//  ◊ 保护代理控制对原始对象的访问。保护代理用于对象应该有不同的访问权限的时候。
//  ◊ 智能指引取代了简单指引，它在访问对象时执行了一些附加操作。它的典型用途包括：对指向实际对象的引用计数，这样当该对象没有引用时，可以自动释放。当第一次引用一个持久对象时，将它装入内存。在访问一个实际对象前，检查是否已经锁定了它，以确保其他对象不能改变它。
//代理模式特点：
//  ◊ 代理模式在访问对象时引入一定程度的间接性，可以隐藏对象的位置。
//  ◊ 代理模式可以对用户隐藏一种称之为copy-on-write的优化方式。当进行一个开销很大的复制操作的时候，如果复制没有被修改，则代理延迟这一复制过程，这一可以保证只有当这个对象被修改的时候才对它进行复制。
//代理模式与装饰模式比较分析
//  装饰器模式关注于在一个对象上动态的添加方法，代理模式关注于控制对对象的访问。
//  装饰器模式中Decorator和ConcreteComponent都实现Component，代理模式中Proxy和ConcreteSubject都实现Subject。使用这两种模式，都可以很容易地在具体对象的方法前面或者后面加上自定义的方法。
//  Proxy 可以对Client隐藏对象的具体信息，在使用代理模式时，常在Proxy中创建一个对象的实例。Proxy与ConcreteSubject之间的关系在编译时就能确定。
//  在使用装饰模式时，常是将ConcreteComponent对象作为一个参数传给ConcreteDecorator的构造器，Decorator在运行时递归的被构造。