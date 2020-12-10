using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
   //概念: 表示一个类实现一个或多个接口的方法。接口定义好操作的集合，由实现类去完成接口的具体操作。

    //实现是指一个类实现一个接口,接口使用interface定义,接口并不是一个类.接口中属性只有常量,方法是抽象的,只能定义,不能包含方法体
    interface IPeople
    {
        void eat();

    }

    public class People : IPeople
    {
        public void eat()
        {
            Console.WriteLine("人正在吃饭。。。");
        }
    }

}
