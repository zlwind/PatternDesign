using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
    //依赖关系(dependence)
    //概念: 类A当中使用了类B，其中类B是作为类A的方法参数、方法中的局部变量、或者静态方法调用。
    //体现：在C#中体现为局部变量、方法/函数的参数或者是对静态方法的调用；

    //人看书：人这个类依赖于书的类
    public class Book
    {

        private String name = "《红楼梦》";

        public String getName()
        {

            return this.name;

        }

    }

    public class Human
    {
        //体现为局部变量、方法/函数的参数或者是对静态方法的调用

        //   这里 Book作为read()方法的形参

        public void read(Book book)
        {

            Console.WriteLine("读的书是 " + book.getName());

        }

    }
   
}
