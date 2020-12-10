using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00a_SevenPrinciples
{
    //3.    里氏替换原则（Liskov Substitution Principle） 
    //定义：子类型必须能够替换掉它们的父类型。注意这里的能够两字。有人也戏称老鼠的儿子会打洞原则。
    //问题由来：有一功能P1，由类A完成。现需要将功能P1进行扩展，扩展后的功能为P，
    //          其中P由原有功能P1与新功能P2组成。新功能P由类A的子类B来完成，则子类B在完成新功能P2的同时，有可能会导致原有功能P1发生故障。 
    //解决方法：类B继承类A时，除添加新的方法完成新增功能P2外，尽量不要重写父类A的方法，也尽量不要重载父类A的方法 
    //小结：所有引用父类的地方必须能透明地使用其子类的对象。
    //      子类可以扩展父类的功能，但不能改变父类原有的功能，即：子类可以实现父类的抽象方法，
    //      子类也中可以增加自己特有的方法，但不能覆盖父类的非抽象方法。当子类的方法重载父类的方法时，
    //      方法的前置条件（即方法的形参）要比父类方法的输入参数更宽松。当子类的方法实现父类的抽象方法时，
    //      方法的后置条件（即方法的返回值）要比父类更严格。

    public class Bird
    {
        private string name;
        public Bird()
        {
         
        }
        public Bird(string name)
        {
            this.name = name;
        }

        public void Eat()
        {
            Console.WriteLine("我是{0}，我需要吃东西", name);
        }

        public void Drink()
        {
            Console.WriteLine("我是{0}，我需要喝水", name);
        }

        public void Fly()
        {
            Console.WriteLine("我是{0}，我可以飞", name);
        }
    }

   /// <summary>
   /// 现在来了只比较大的鸟，叫企鹅，继承了鸟类
   /// </summary>
   public class Penguin : Bird
   {
       //Do nothing
   }
   public class Client
   {
       public void client()
       {
           try
           {
               Bird bird = new Penguin();
               bird.Eat();
               bird.Drink();
               bird.Fly();
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
           }
           Console.Read();
       }
   }
//运行结果：
//我是Penguin，我需要吃东西
//我是Penguin，我需要喝水
//我是Penguin，我可以飞
//这就出问题了，企鹅显然是不会飞的啊，也继承了鸟类，这就违背了里氏替换原则。企鹅属于海鸟，
//虽然是鸟类，可不能飞，比较特珠，就需要断掉继承。企鹅这是说话了，我不能飞，我也要吃和喝啊，
//怎么办？那你都不属于动物吗，我们来使用里氏替换原则重构一下：
//企鹅、麻雀、孔雀

    //*************************************里式替换原则修改*******************************************************//
   public class Animal
   {
       protected  string name;
       public Animal()
       {    }
       public Animal(string name)
       {
           this.name = name;
       }

       public void Eat()
       {
           Console.WriteLine("我是{0}，我需要吃东西", name);
       }

       public void Drink()
       {
           Console.WriteLine("我是{0}，我需要喝水", name);
       }
   }

   public class Bird1 : Animal
   {
       /// <summary>
       /// 鸟有自己可以飞的方法
       /// </summary>
       public void Fly()
       {
           Console.WriteLine("我是{0}，我可以飞", name);
       }
   }

   public class Sparrow : Bird1		//麻雀
   {
       //do nothing
   }

    public class Peacock : Bird1		//孔雀
    {
        /// <summary>
        /// 孔雀可以开屏
        /// </summary>
        public void Open()
        {
            Console.WriteLine("我是{0}，我可以开屏，开着屏抖抖更漂亮！", name);
        }
    }

    public class Client1
    {
        public void client()
        {
            try
            {
                {
                    Bird1 bird = new Sparrow();
                    bird.Fly();  //可以飞
                }

                {
                    //Bird bird = new Peacock(); //子类出现的地方父类不能代替
                    Peacock bird = new Peacock();
                    bird.Fly();
                    bird.Open();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();

        }
    }

}
//里氏替换原则通俗的来讲就是：子类可以扩展父类的功能，但不能改变父类原有的功能。它包含以下4层含义：

//子类可以实现父类的抽象方法，但不能覆盖父类的非抽象方法。
//子类中可以增加自己特有的方法。
//当子类的方法重载父类的方法时，方法的前置条件（即方法的形参）要比父类方法的输入参数更宽松。
//当子类的方法实现父类的抽象方法时，方法的后置条件（即方法的返回值）要比父类更严格。
