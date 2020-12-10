using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12_FlyweightPattern
{
    //享元模式：
    //运用共享技术有效地支持大量细粒度的对象。享元模式可以避免大量相似类的开销，
    //在软件开发中如果需要生成大量细粒度的类实例来表示数据，如果这些实例除了几个参数外基本上都是相同的，
    //这时候就可以使用享元模式来大幅度减少需要实例化类的数量。如果能把这些参数（指的这些类实例不同的参数）移动类实例外面，
    //在方法调用时将他们传递进来，这样就可以通过共享大幅度地减少单个实例的数目。（这个也是享元模式的实现要领）,
    //然而我们把类实例外面的参数称为享元对象的外部状态，把在享元对象内部定义称为内部状态。具体享元对象的内部状态与外部状态的定义为：
    //内部状态：在享元对象的内部并且不会随着环境的改变而改变的共享部分
    //外部状态：随环境改变而改变的，不可以共享的状态。

  //  享元模式参与者：
    //◊ 抽象享元角色 Flyweight：声明一个接口，通过这个接口flyweight可以直接接收并作用于外部状态。
    //◊具体享元角色  ConcreteFlyweight：实现Flyweight接口，并为内部状态增加存储空间。ConcreteFlyweight对象必须是可以共享的，它所存储的状态必须是内部的，
  //  即它必须独立于ConcreteFlyweight对象的场景。
  //◊ UnsharedConcreteFlyweight：并非所有的Flyweight子类都需要被共享。
  //  Flyweight接口使共享成为可能，但它不强制共享。在Flyweight对象结构的某些层次，
  //  UnsharedConcreteFlyweight对象通常将ConcreteFlyweight对象作为子节点。
    //◊ 享元工厂角色 FlyweightFactory
  //  ° 创建和管理flyweight对象。
  //  ° 确保flyweight对象被合理共享。当Client请求一个flyweight对象时，FlyweightFactory需要可以进行分配，若flyweight对象不存在时，则先创建一个。
    //◊ 客户端角色  Client：维持一个对Flyweight的引用
  //在享元模式中，Client调用Flyweight下的ConcreteFlyweight，如果ConcreteFlyweight存在则调用成功；
  //  否则就调用FlyweightFactory生产所需要的继承Flyweight接口的ConcreteFlyweight，以供调用。
    class Program
    {
        static void Main(string[] args)
        {
            // 定义外部状态，例如字母的位置等信息
            int externalState = 10;//
            FlyweightFactory ff = new FlyweightFactory();
            IFlweight f1=ff.GetFlyweight("a");
            IFlweight f2=ff.GetFlyweight("B");
            f1.Operation(--externalState);
            f2.Operation(--externalState);
            Console.WriteLine("享元工厂哈希表长度：{0}", ff.GetFlyweightCount());
            IFlweight f3 = ff.GetFlyweight("A");
            f3.Operation(--externalState);
            IFlweight f4 = ff.GetFlyweight("B");
            f4.Operation(--externalState);
            Console.WriteLine("享元工厂哈希表长度：{0}", ff.GetFlyweightCount());
            IFlweight f5 = ff.GetFlyweight("f");
            f5.Operation(--externalState);
            Console.WriteLine("享元工厂哈希表长度：{0}", ff.GetFlyweightCount());
            Console.ReadKey();

        }
    }
}
//优缺点：
//优点：
//降低了系统中对象的数量，从而降低了系统中细粒度对象给内存带来的压力。
//缺点：
//为了使对象可以共享，需要将一些状态外部化，这使得程序的逻辑更复杂，使系统复杂化。
//享元模式将享元对象的状态外部化，而读取外部状态使得运行时间稍微变长。


 //享元模式适用情形：
 // ◊ 一个应用程序使用了大量的对象
 // ◊ 完全由于使用大量的对象，造成很大的存储开销
 // ◊ 对象的大多数状态都可变为外部状态
 // ◊ 如果删除对象的外部状态，那么可以用相对较少的共享对象取代很多组对象
 // ◊ 应用程序不依赖对象标识
 // 享元模式特点：
 // ◊ 享元模式的核心是把大量共享的对象收集在一起使用简单工厂模式进行管理，避免由于大量的小对象导致系统内存过度消耗。
 // ◊ 享元当重复对象较多时有很好的空间复杂度，但在查找搜索上消耗了时间复杂度。
