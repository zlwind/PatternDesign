using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleFactoryPattern
{
    //简单工厂模式：定义一个工厂类，他可以根据参数的不同返回不同类的实例，被创建的实例通常都具有共同的父类
    //在简单工厂模式中用于被创建实例的方法通常为静态(static)方法,因此简单工厂模式又被成为静态工厂方法(Static Factory Method)
    //需要什么，只需要传入一个正确的参数，就可以获取所需要的对象，而无需知道其实现过程

    //例如，我开一家披萨店，当客户需要某种披萨并且我这家店里也能做的时候，
    //我就会为其提供所需要的披萨(当然是要钱的哈哈),如果其所需的我这没有，则是另外的情况，后面会谈。
    //这时候，我这家 披萨店就可以看做工厂(Factory),而生产出来的披萨被成为产品(Product),披萨的名称则被称为参数，
    //工厂可以根据参数的不同返回不同的产品，这就是简单工厂模式

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
    /// <summary>
    /// 工厂类：核心部分，负责实现创建所有产品的内部逻辑，工厂类可以被外界直接调用，创建所需对象
    /// </summary>
    public class SampleFactoryFood
    {
        public static Food CreateFood(string foodname)
        {
            Food food = null;
            if (foodname == "tomato")
            {
                food = new TomatoFood();
            }
            else if (foodname == "fish")
            {
                food = new FishFood();
            }
            return food;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string fname = null;
            Console.WriteLine("请输入菜名：");

            // 接收用户输入，为变量赋值
            fname = Console.ReadLine();
            Food food=SampleFactoryFood.CreateFood(fname);
            if (food != null)
            {
                food.OrderFoodPrint();
            }
            else
            { Console.WriteLine("没有相应产品"); }
            Console.ReadKey();

        }
    }

//    简单工厂模式的优点
//    （1）工厂类包含必要的逻辑判断，可以决定在什么时候创建哪一个产品的实例。客户端可以免除直接创建产品对象的职责
//    （2）客户端无需知道所创建具体产品的类名，只需知道参数即可
//    （3）也可以引入配置文件，在不修改客户端代码的情况下更换和添加新的具体产品类。（这也是我在开始的披萨店里遇到没有的披萨的解决情况）
//简单工厂模式的缺点
//    （1）工厂类集中了所有产品的创建逻辑，职责过重，一旦异常，整个系统将受影响
//    （2）使用简单工厂模式会增加系统中类的个数(引入新的工厂类)，增加系统的复杂度和理解难度
//    （3）系统扩展困难，一旦增加新产品不得不修改工厂逻辑，在产品类型较多时，可能造成逻辑过于复杂
//    （4）简单工厂模式使用了static工厂方法，造成工厂角色无法形成基于继承的等级结构。
//简单工厂模式的适用环境
//    (1)工厂类负责创建对的对象比较少，因为不会造成工厂方法中的业务逻辑过于复杂
//    (2)客户端只知道传入工厂类的参数，对如何创建对象不关心
}
