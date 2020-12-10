using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
   //组合关系(composition)
   //概念: 相比于聚合，组合是一种耦合度更强的关联关系。存在组合关系的类表示“整体-部分”的关联关系，
   // “整体”负责“部分”的生命周期，他们之间是共生共死的；并且“部分”单独存在时没有任何意义。

    //它也是关联关系,但是聚合度比聚合关系还要强.组合关系是整体-部分,部分单独存在没有意义,
    //需要与整体结合使用.也就是表示整体的这个类负责部分的这些类的生命周期,整体消亡,部分也就不存在了.

    //Woman类和Body类，Soul类是整体与部分的关系，但是Woman的生命周期与Body类，Soul类同生共死
    public class Body
    {

        private String name="身体";

        public String getName()
        {

            return this.name;

        }

    }

    public class Soul
    {

        private String name="灵魂";

        public String getName()
        {

            return this.name;

        }

    }
    /// <summary>
    /// 如果Woman类new创建，Soul类和Body类也创建，Woman类销毁，Soul类和Body类也销毁
    /// </summary>
    public class Woman
    {
        //组合关系中 Woman类与Soul类和Body类是同生共死的关系，在Woman类中声明（new）部分类
        Soul soul=new Soul();

        Body body=new Body();


        public void study(){

            Console.WriteLine("学习要用灵魂" + soul.getName());

   }

        public void eat(){

            Console.WriteLine("吃饭用身体：" + body.getName());  

   }

    }




}
