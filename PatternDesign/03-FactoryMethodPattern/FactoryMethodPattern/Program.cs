using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodPattern
{
    //工厂方法模式：
    //定义一个创建产品对象的工厂接口，将实际创建工作推迟到子类当中。核心工厂类不再负责产品的创建，这样核心类成为一个抽象工厂角色，
    //仅负责具体工厂子类必须实现的接口，这样进一步抽象化的好处是使得工厂方法模式可以使系统在不修改具体工厂角色的情况下引进新的产品
    /// <summary>
    /// 抽象类：食物:工厂类所创建的所有对象的父类，封装了产品对象的公共方法，所有的具体产品为其子类对象
    /// </summary>
    public abstract class Food
    {
        public abstract void OrderFoodPrint();
    }
    //具体实现类：继承抽象类 简单工厂模式的创建目标，所有被创建的对象都是某个具体类的实例。
    //它要实现抽象产品中声明的抽象方法(有关抽象类)
    /// <summary>
    /// 土豆丝
    /// </summary>
    public class TomatoFood : Food
    {
        public override void OrderFoodPrint()
        {
            Console.WriteLine("点餐土豆丝");
        }
    }
    /// <summary>
    /// 清蒸鱼
    /// </summary>
    public class FishFood : Food
    {
        public override void OrderFoodPrint()
        {
            Console.WriteLine("点餐清蒸鱼");
        }
    }
    //工厂类：核心部分，负责实现创建所有产品的内部逻辑，工厂类可以被外界直接调用，创建所需对象
    /// <summary>
    /// 将工厂类进行抽象
    /// </summary>
    public abstract class FactoryMethodFood
    {
        public abstract  Food CreateFood();
    }
    //将创建菜品的对象推迟到工厂子类，继承抽象工厂类
    /// <summary>
    /// 土豆丝工厂子类，实例化推迟到子类中
    /// </summary>
    public class CreateTomato : FactoryMethodFood
    {
        public override Food CreateFood()
        { return new TomatoFood(); }
    }
    /// <summary>
    /// 清蒸鱼工厂子类，实例化推迟到子类中
    /// </summary>
    public class CreateFish : FactoryMethodFood
    {
        public override  Food CreateFood()
        { return new  FishFood(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FactoryMethodFood sff = new CreateFish();
            Food food = sff.CreateFood();
            food.OrderFoodPrint();
            Console.ReadKey();
        }
    }

    //抽象工厂角色：是工厂方法模式的核心，与应用程序无关。任何在模式中创建的对象的工厂类必须实现这个接口。
    //具体工厂角色：这是实现抽象工厂接口的具体工厂类，包含与应用程序密切相关的逻辑，并且受到应用程序调用以创建产品对象
    //抽象产品角色：工厂方法模式所创建的对象的超类型，也就是产品对象的共同父类或共同拥有的接口。在上图中，这个角色是Light。
    //具体产品角色：这个角色实现了抽象产品角色所定义的接口。某具体产品有专门的具体工厂创建，它们之间往往一一对应。

    //使用工厂方法实现的系统，如果系统需要添加新产品时，我们可以利用多态性来完成系统的扩展，
    //对于抽象工厂类和具体工厂中的代码都不需要做任何改动。例如，我们我们还想点一个“肉末茄子”，
    //此时我们只需要定义一个肉末茄子具体工厂类和肉末茄子类就可以。
    //而不用像简单工厂模式中那样去修改工厂类中的实现（具体指添加case语句)。
}
