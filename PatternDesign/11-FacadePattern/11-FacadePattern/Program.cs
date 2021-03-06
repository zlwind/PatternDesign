﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11_FacadePattern
{
  //外观模式（Facade）
  //通过提供一个统一接口，来访问子系统的多个接口。
  //使用外观模式时，创建一个统一的类，用来包装子系统中一个或多个复杂的类，客户端可以直接通过外观类来调用内部子系统中方法。
  //外观模式让客户端与子系统之间避免紧耦合。

    
    //使用了外观模式之后，客户端只依赖与外观类，从而将客户端与子系统的依赖解耦了，如果子系统发生改变，
    //此时客户端的代码并不需要去改变。外观模式的实现核心主要是——由外观类去保存各个子系统的引用，
    //实现由一个统一的外观类去包装多个子系统类，然而客户端只需要引用这个外观类，
    //然后由外观类来调用各个子系统中的方法。然而这样的实现方式非常类似适配器模式，
    //然而外观模式与适配器模式不同的是：适配器模式是将一个对象包装起来以改变其接口，
    //而外观是将一群对象 ”包装“起来以简化其接口。
    //它们的意图是不一样的，适配器是将接口转换为不同接口，而外观模式是提供一个统一的接口来简化接口。


  //  外观模式参与者：
  //◊ Facade
  //  ° 知道哪些子系统类负责处理请求
  //  ° 将客户的请求代理给相应的子系统对象
  //◊ Subsystem Classes
  //  ° 实现子系统的功能
  //  ° 处理由Facade对象指派的任务来协调子系统下各子类的调用方式
  //在外观模式中，外观类Facade的方法OptionWrapper实现的就是以不同的次序调用下面类SubSystem1、
  //  SubSystem2的方法Operation，通过不同的Operation组合实现装饰功能。
    class Program
    {
        static void Main(string[] args)
        {
            RegistCourseFacade facade = new RegistCourseFacade();
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();
        }
    }
}
//外观的优缺点
//优点：
//外观模式对客户屏蔽了子系统组件，从而简化了接口，减少了客户处理的对象数目并使子系统的使用更加简单。
//外观模式实现了子系统与客户之间的松耦合关系，而子系统内部的功能组件是紧耦合的。松耦合使得子系统的组件变化不会影响到它的客户。

//它实现了子系统对客户的屏蔽，因而减少了客户处理的对象数目并且使子系统使用起来更加方便。
//它实现了子系统与客户之间的松耦合关系。而子系统内部的功能组件往往是紧耦合的。松耦合关系使得子系统的组件变化不会影响到它的客户。
//外观模式有助于建立系统的层次结构，也有助于对对象之间的依赖关系分层。
//外观模式可以消除复杂的循环依赖关系。这一点在客户程序与子系统是分别实现的时候尤为重要。
//在大型软件系统中降低编译依赖性至关重要。在子系统类改变时，希望尽量减少重编译工作以节省时间。
//用外观模式可以降低编译依赖性，减少对重要系统做较小的改变所需的重编译工作。
//外观模式有利于简化系统在不同平台之间的移植过程。因为编译一个子系统一般不需要编译所有其他子系统。
//如果应用需要，外观模式并不限制子系统类的使用。因此可以在系统易用性和通用性之间加以选择。
//缺点：
//如果增加新的子系统可能需要修改外观类或客户端的源代码，这样就违背了”开——闭原则“（不过这点也是不可避免）。
//使用场景
//在以下情况下可以考虑使用外观模式：
//外一个复杂的子系统提供一个简单的接口
//提供子系统的独立性
//在层次化结构中，可以使用外观模式定义系统中每一层的入口。其中三层架构就是这样的一个例子。