using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactoryPattern
{
    //抽象工厂模式:
    //是围绕一个超级工厂创建其他工厂。该超级工厂又称为其他工厂的工厂。
    //这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。在抽象工厂模式中，
    //接口是负责创建一个相关对象的工厂，不需要显式指定它们的类。每个生成的工厂都能按照工厂模式提供对象。

   // 2.1 抽象工厂（AbstractFactory）：担任这个角色的是工厂方法模式的核心，它是与应用系统商业逻辑无关的。
   //2.2 具体工厂（ConcreteFactory）：这个角色直接在客户端的调用下创建产品的实例。这个角色含有选择合适的产品对象的逻辑，而这个逻辑是与应用系统的商业逻辑紧密相关的。
   //2.3 抽象产品（AbstractProduct）：担任这个角色的类是工厂方法模式所创建的对象的父类，或它们共同拥有的接口。
   //2.4 具体产品（ConcreteProduct）：抽象工厂模式所创建的任何产品对象都是某一个具体产品类的实例。这是客户端最终需要的东西，其内部一定充满了应用系统的商业逻辑。
   
    /// 产品抽象类
    
    public abstract class TomatoFood
    {
        public abstract void OrderTomatoFoodPrint();
    }
    public abstract class FishFood
    {
        public abstract void OrderFishFoodPrint();
    }
    //具体实现类：继承抽象类 简单工厂模式的创建目标，所有被创建的对象都是某个具体类的实例。
    //它要实现抽象产品中声明的抽象方法(有关抽象类)
    /// <summary>
    /// 土豆丝
    /// </summary>
    public class ShanghaiTomatoFood : TomatoFood
    {
        public override void OrderTomatoFoodPrint()
        {
            Console.WriteLine("点餐上海餐厅土豆丝");
        }
    }
    public class BeijingTomatoFood : TomatoFood
    {
        public override void OrderTomatoFoodPrint()
        {
            Console.WriteLine("点餐北京餐厅土豆丝");
        }
    }

    /// <summary>
    /// 清蒸鱼
    /// </summary>
    public class ShanghaiFishFood : FishFood
    {
        public override void OrderFishFoodPrint()
        {
            Console.WriteLine("点餐上海餐厅清蒸鱼");
        }
    }
    public class BeijingFishFood : FishFood
    {
        public override void OrderFishFoodPrint()
        {
            Console.WriteLine("点餐北京餐厅清蒸鱼");
        }
    }

    //抽象工厂
    /// <summary>
    /// 接口：可以生产土豆丝 清蒸鱼（抽象工厂）
    /// </summary>
    public interface AbsFactoryFood
    {
        TomatoFood CreateTomatoFood();
        FishFood CreateFishFood();
    }
    /// <summary>
    /// 上海餐厅，继承接口，可以在上海餐厅生产土豆丝，清蒸鱼
    /// </summary>
    public class ShangHaiFactoryFood : AbsFactoryFood
    {
        public TomatoFood CreateTomatoFood()
        {
            return new ShanghaiTomatoFood();
        }
        public FishFood CreateFishFood()
        {
            return new ShanghaiFishFood();
        }
   
    }
    /// <summary>
    /// 北京餐厅，继承接口，可以在上海餐厅生产土豆丝，清蒸鱼
    /// </summary>
    public class BeiJingFactoryFood : AbsFactoryFood
    {
        public TomatoFood CreateTomatoFood()
        {
            return new BeijingTomatoFood();
        }
        public FishFood CreateFishFood()
        {
            return new BeijingFishFood();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AbsFactoryFood factory = new ShangHaiFactoryFood();
            FishFood fishfood = factory.CreateFishFood();
            fishfood.OrderFishFoodPrint();
            Console.ReadKey();
        }
    }

    //工厂方法模式是为了克服简单工厂模式的缺点而设计出来的,简单工厂模式的工厂类随着产品类的增加需要增加额外的代码），
    //而工厂方法模式每个具体工厂类只完成单个实例的创建,所以它具有很好的可扩展性。但是在现实生活中，
    //一个工厂只创建单个产品这样的例子很少，因为现在的工厂都多元化了，一个工厂创建一系列的产品，如果我们要设计这样的系统时，
    //工厂方法模式显然在这里不适用，
    //然后抽象工厂模式却可以很好地解决一系列产品创建的问题,这是本专题所要介绍的内容。


    //抽象工厂模式将具体产品的创建延迟到具体工厂的子类中，这样将对象的创建封装起来，可以减少客户端与具体产品类之间的依赖，从而使系统耦合度低，这样更有利于后期的维护和扩展，这真是抽象工厂模式的优点所在，然后抽象模式同时也存在不足的地方。下面就具体看下抽象工厂的缺点（缺点其实在前面的介绍中以已经涉及了）：
    //抽象工厂模式很难支持新种类产品的变化。这是因为抽象工厂接口中已经确定了可以被创建的产品集合，如果需要添加新产品，此时就必须去修改抽象工厂的接口，这样就涉及到抽象工厂类的以及所有子类的改变，这样也就违背了“开发——封闭”原则。
    //知道了抽象工厂的优缺点之后，也就能很好地把握什么情况下考虑使用抽象工厂模式了，下面就具体看看使用抽象工厂模式的系统应该符合那几个前提：
    //一个系统不要求依赖产品类实例如何被创建、组合和表达的表达，这点也是所有工厂模式应用的前提。
    //这个系统有多个系列产品，而系统中只消费其中某一系列产品
    //系统要求提供一个产品类的库，所有产品以同样的接口出现，客户端不需要依赖具体实现。
}
