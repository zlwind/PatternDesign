using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_DecoratorPattern
{
    //场景：三种咖啡：Espresso、LongBlack、ShortBlack，而牛奶 巧克力 豆浆作为装饰，显示最后组合的描述和价格


    /// <summary>
    /// 抽象咖啡类
    /// 抽象构件（NoteBook）角色：给出一个抽象接口，以规范准备接受附加责任的对象
    /// </summary>
    public  abstract class Coffe
    {
        string des;

        public string Des
        {
            get { return des; }
            set { des = value; }
        }
        double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }    
    }
    /// <summary>
    /// 具体咖啡类：Espresso
    /// </summary>
    public class Espresso:Coffe
    {
        public Espresso()
        {
            Des = "Espresso咖啡";
            Price = 5;
        }
    }
    /// <summary>
    /// 具体咖啡类：LongBlack
    /// </summary>
    public class LongBlack : Coffe
    {
        public LongBlack()
        {
            Des = "LongBlack咖啡";
            Price = 2;
        }
    }
    /// <summary>
    /// 具体咖啡类：ShortBlack
    /// </summary>
    public class ShortBlack : Coffe
    {
        public ShortBlack()
        {
            Des = "ShortBlack咖啡";
            Price = 7;
        }
    }


    /// <summary>
    /// 抽象装饰类
    /// 装饰（Dicorator）角色：持有一个构件（Component）对象的实例，并定义一个与抽象构件接口一致的接口。
    /// </summary>
    public abstract class Decorator
    {
        Coffe coffe;//咖啡的对象实例

        public Coffe Coffe
        {
            get { return coffe; }
            set { coffe = value; }
        }
      
        string des;

        public string Des
        {
            get { return des; }
            set { des = value; }
        }
        double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
       

    }
    /// <summary>
    /// 具体装饰类：巧克力
    /// </summary>
    public class Chocolate : Decorator
    {
        public Chocolate(Coffe coffe)
        {
            this.Coffe = coffe;
            Des = "巧克力";
            Price = 1;
            this.Coffe.Des = Des.ToString() + ":  " + Price.ToString() + "  &&  " + Coffe.Des;
            this.Coffe.Price = Coffe.Price + Price;
        }
       
    }
    /// <summary>
    ///  具体装饰类：牛奶
    /// </summary>
    public class Milk : Decorator
    {
        public Milk(Coffe coffe)
        {
            this.Coffe = coffe;
            Des = "牛奶";
            Price = 3.5;
            this.Coffe.Des = Des.ToString() + ":  " + Price.ToString() + "  &&  " + Coffe.Des;
            this.Coffe.Price = Coffe.Price + Price;
        }
       
    }
    /// <summary>
    ///  具体装饰类：豆浆
    /// </summary>
    public class Soy : Decorator
    {
        public Soy(Coffe coffe)
        {
            this.Coffe = coffe;
            Des = "豆浆";
            Price = 1.2;
            this.Coffe.Des = Des.ToString() + ":  " + Price.ToString() + "  &&  " + Coffe.Des;
            this.Coffe.Price= Coffe.Price + Price;
        }
      
    }
}
