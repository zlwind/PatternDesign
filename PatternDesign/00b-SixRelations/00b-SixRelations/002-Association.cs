using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
   //关联关系(association)
   // 概念: 单向关联表现为：类A当中使用了类B，其中类B是作为类A的成员变量。
   // 双向关联表现为：类A当中使用了类B作为成员变量；同时类B中也使用了类A作为成员变量。

    //关联关系使一个类获得另一个类的属性和方法.关联关系可以上单向的,也可以是双向的.
    //例如:儿子送个父亲一个礼物,儿子和父亲都需要打印一句话.从儿子的角度,儿子需要知道父亲的名字,
    //从父亲的角度,父亲需要知道儿子的名字,于是就需要在各自的类中实例对方的类,为得到对方的名字,这样,儿子和父亲都可以访问对方的属性和方法了.

    public class Son
    {

        private String name="李四";

        Father father = new Father();

        public String getName()
        {

            return this.name;

        }

        public void giveGift(){

        Console.WriteLine("送给"+father.getName()+"礼物");

    }

    }

    public class Father
    {

        private String name="张三";

        Son son = new Son();

        public String getName()
        {

            return this.name;

        }

        public void getGift()
        {

            Console.WriteLine("从" + son.getName() + "获得礼物");

        }

    }


}
