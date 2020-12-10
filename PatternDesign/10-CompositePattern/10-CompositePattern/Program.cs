using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_CompositePattern_
{
    //组合模式：
    //允许你将对象组合成树形结构来表现”部分-整体“的层次结构，使得客户以一致的方式处理单个对象以及对象的组合。下面我们用绘制的例子来详细介绍组合模式，
    //图形可以由一些基本图形元素组成（如直线，圆等），也可以由一些复杂图形组成（由基本图形元素组合而成），为了使客户对基本图形和复杂图形的调用保持一致，我们使用组合模式来达到整个目的。
    //组合模式实现的最关键的地方是——简单对象和复合对象必须实现相同的接口。这就是组合模式能够将组合对象和简单对象进行一致处理的原因。

  //  组合模式参与者：
    //◊ Component 抽象构件
  //  ° 声明组合中对象的接口；
  //  ° 实现全部类中公共接口的默认行为；
  //  ° 声明访问和管理子类的接口；
  //  ° （可选择）定义接口提供在递归结构中访问父类。
    //◊ Leaf  树叶构件
  //  ° 表示在组合对象中叶子节点对象，没有子节点；
  //  ° 定义组合对象中的初始行为。
    //◊ Composite 容器构件
  //  ° 定义Component子类的行为；
  //  ° 保存Component子类；
  //  ° 实现Component接口的子类关联操作。
  //◊ Client
  //  ° 通过Component接口组合多个对象。
    class Program
    {
        static void Main(string[] args)
        {
            Compoent root = new Composite("清华大学");
            Compoent branch1 = new Composite("计算机学院");
            Compoent branch2 = new Composite("艺术学院");
            Compoent branch3 = new Composite("理化学院");

            Compoent b1leaf1 = new Leaf("通信专业");
            Compoent b1leaf2 = new Leaf("信息专业");
            Compoent b2leaf1 = new Leaf("音乐专业");
            Compoent b2leaf2 = new Leaf("美术专业");
            Compoent b2leaf3 = new Leaf("表演专业");
            Compoent b3leaf1 = new Leaf("数学专业");
            Compoent b3leaf2 = new Leaf("物理专业");

            root.Add(branch1); root.Add(branch2); root.Add(branch3);
            branch1.Add(b1leaf1); branch1.Add(b1leaf2);
            branch2.Add(b2leaf1); branch2.Add(b2leaf2); branch2.Add(b2leaf3);
            branch3.Add(b3leaf1); branch3.Add(b3leaf2);
            root.Display(0);
            Console.ReadKey();

        }
    }
}
//组合模式可以适用以下情形：
//  ◊ 希望把对象表示成部分—整体层次结构；
//  ◊ 希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中所有对象。
//  组合模式具有以下特点：
//  ◊ 定义了包含基本对象和组合对象的类层次结构。基本对象可以被组合成更复杂的组合对象，而这个组合对象又可以被组合，不断的递归下去。
//    客户代码中，任何用到基本对象的地方都可以使用组合对象；
//  ◊ 简化客户代码。客户可以一致地使用组合结构和单个对象。这样用户就不必关心处理的是一个叶子节点还是一个组合组件，从而简化了客户代码；
//  ◊ 使得新增类型的组件更加容易。新定义的Composite或Leaf子类自动地与已有的结构和客户代码一起协同工作，客户程序不需因新的Component类而改变。

    //    优点
            //使客户端调用简单，它可以一致使用组合结构或是其中单个对象，简化了客户端代码。
            //容易在组合体内增加对象部件。客户端不必因加入了新的部件而更改代码。有利于功能的扩展。
            //组合模式使得客户端代码可以一致地处理对象和对象容器，无需关系处理的单个对象，还是组合的对象容器。
            //将”客户代码与复杂的对象容器结构“解耦。
            //可以更容易地往组合对象中加入新的构件。
    //  缺点
            //需要抉择使用透明方式还是安全方式。
            //透明方式违背了面向对象的单一职责原则；安全方式增加了客户需要端判定的负担。

//透明方式与安全方式
//  透明方式：在Component中声明所有来管理子对象的方法，其中包括Add，Remove等。
//这样实现Component接口的所有子类都具备了Add和Remove方法。这样做的好处是叶节点和枝节点对于外界没有区别，它们具备完全一致的接口。
//  安全方式：在Component中不去声明Add和Remove方法，那么子类的Leaf就不需要实现它，
//而是在Composit声明所有用来管理子类对象的方法。
//  两种方式有缺点：对于透明方式，客户端对叶节点和枝节点是一致的，但叶节点并不具备Add和Remove的功能，
//因而对它们的实现是没有意义的；对于安全方式，叶节点无需在实现Add与Remove这样的方法，
//但是对于客户端来说，必须对叶节点和枝节点进行判定，为客户端的使用带来不便。