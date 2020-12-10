using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
    //类之间有6种关系:
    //依赖关系(dependence):类A当中使用了类B，其中类B是作为类A的方法参数、方法中的局部变量、或者静态方法调用

    //关联关系(association):单向关联表现为：类A当中使用了类B，其中类B是作为类A的成员变量。
                            //双向关联表现为：类A当中使用了类B作为成员变量；同时类B中也使用了类A作为成员变量。
    //聚合关系(aggregation): 聚合关系是关联关系的一种，耦合度强于关联，他们的代码表现是相同的，仅仅是在语义上有所区别：
                             //关联关系的对象间是相互独立的，而聚合关系的对象之间存在着包容关系，他们之间是“整体-个体”的相互关系。
    //组合关系(composition):相比于聚合，组合是一种耦合度更强的关联关系。存在组合关系的类表示“整体-部分”的关联关系，
                           //“整体”负责“部分”的生命周期，他们之间是共生共死的；并且“部分”单独存在时没有任何意义。
    //继承关系(generalization)(泛化),类A当中使用了类B，其中类B是作为类A的方法参数、方法中的局部变量、或者静态方法调用。

    //实现关系(implementation):表示一个类实现一个或多个接口的方法。接口定义好操作的集合，由实现类去完成接口的具体操作。
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
//https://www.cnblogs.com/ForEverKissing/archive/2007/12/13/993818.html
//https://blog.csdn.net/zhaoli081223/article/details/46530587
//https://blog.csdn.net/jisuanji198509/article/details/80924742