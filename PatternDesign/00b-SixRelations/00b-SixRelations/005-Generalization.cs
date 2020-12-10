using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
  //继承关系(generalization)
  //概念: 类A当中使用了类B，其中类B是作为类A的方法参数、方法中的局部变量、或者静态方法调用。

    public class Animal
    {

        private void getPrivate()
        {

            Console.WriteLine("private");

        }

        void getDefault()
        {

            Console.WriteLine("default");

        }

        protected void getProtected()
        {

            Console.WriteLine("protected");

        }

        public void getPublic()
        {

            Console.WriteLine("public");

        }

    }
    /// <summary>
    /// 子类可以继承父类的非私有属性和方法
    /// 子类可以继承父类的protected public属性 方法
    /// </summary>
    public class Dog : Animal
    {

        public void dogFuc()
        {
            getProtected();

            getPublic();

        }

    }

}
