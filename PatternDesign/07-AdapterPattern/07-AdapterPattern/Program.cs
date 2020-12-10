using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_AdapterPattern
{
    //适配器模式：
    //把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作。适配器模式有类的适配器模式和对象的适配器模式两种形式，
    //使得新环境中不需要去重复实现已经存在了的实现而很好地把现有对象（指原来环境中的现有对象）加入到新环境来使用。
    //可以看出，在适配器模式的结构图有以下角色：

    //  （1）、目标角色（Target）：定义Client使用的与特定领域相关的接口。
   
    //  （2）、客户角色（Client）：与符合Target接口的对象协同。
  
    //  （3）、被适配角色（Adaptee)：定义一个已经存在并已经使用的接口，这个接口需要适配。
  
    //  （4）、适配器角色（Adapte) ：适配器模式的核心。它将对被适配Adaptee角色已有的接口转换为目标角色Target匹配的接口。
    //         对Adaptee的接口与Target接口进行适配.
    class Program
    {
        static void Main(string[] args)
        {
            IVoltage5 v5 = new AdapterVoltage();
            int voltage=v5.GetVoltage5();//类适配器
            ObjIVoltage5 objv5 = new ObjAdapterVoltage();
            int objVoltage = objv5.GetVoltage5();//对象适配器
            Adapter a = new Adapter();
            int v = a.m1();
        }
    }
}
 //1】、类的适配器模式：

 //        优点：

 //              （1）、可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”

 //              （2）、可以重新定义Adaptee(被适配的类)的部分行为，因为在类适配器模式中，Adapter是Adaptee的子类

 //              （3）、仅仅引入一个对象，并不需要额外的字段来引用Adaptee实例（这个即是优点也是缺点）。

 //        缺点：

 //              （1）、用一个具体的Adapter类对Adaptee和Target进行匹配，当如果想要匹配一个类以及所有它的子类时，类的适配器模式就不能胜任了。因为类的适配器模式中没有引入Adaptee的实例，光调用this.SpecificRequest方法并不能去调用它对应子类的SpecificRequest方法。

 //              （2）、采用了 “多继承”的实现方式，带来了不良的高耦合。

 //       2】、对象的适配器模式

 //            优点：

 //                 （1）、可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”（这点是两种实现方式都具有的）

 //                 （2）、采用 “对象组合”的方式，更符合松耦合。

 //           缺点：

 //                 （1）、使得重定义Adaptee的行为较困难，这就需要生成Adaptee的子类并且使得Adapter引用这个子类而不是引用Adaptee本身。

 //    3】、适配器模式使用的场景：

 //             （1）、系统需要复用现有类，而该类的接口不符合系统的需求

 //             （2）、想要建立一个可重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。

 //             （3）、对于对象适配器模式，在设计里需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。

