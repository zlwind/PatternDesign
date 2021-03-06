﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _23_StragetyPattern
{
    //策略模式：
    //是针对一组算法，将每个算法封装到具有公共接口的独立的类中，从而使它们可以相互替换。策略模式使得算法可以在不影响到客户端的情况下发生变化。
    //策略是为达到某一目的而采取的手段或方法，策略模式的本质是目标与手段的分离，手段不同而最终达成的目标一致。
    //客户只关心目标而不在意具体的实现方法，实现方法要根据具体的环境因素而变化。

  //  策略模式参与者：
  //◊ Strategy 策略
  //  ° 定义所支持的算法的公共接口。Context使用这个接口来调用某个ConcreteStrategy定义的算法。
  //◊ ConcreteStrategy 具体策略
    //  ° 实现Strategy接口中的具体算法。包装了相关算法或行为。
  //◊ Context 上下文
  //  ° 通过一个ConcreteStrategy对象来对其进行配置；
  //  ° 维护一个对Strategy对象的引用；
  //  ° 可定义一个接口来让Strategy访问它的数据。
    class Program
    {
        static void Main(string[] args)
        {
            // 个人所得税方式
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));

            // 企业所得税
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));

            Client c = new Client();
            c.client();
            Console.Read();
        }
    }
}
 //策略模式适用情形：
 // ◊ 如果在一个系统里面有许多类，它们之间的区别仅在于它们的行为，那么使用策略模式可以动态地让一个对象在许多行为中选择一种行为。
 // ◊ 一个系统需要动态地在几种算法中选择一种。这些具体算法类均有统一的接口，由于多态性原则，客户端可以选择使用任何一个具体算法类，
      //并只持有一个数据类型是抽象算法类的对象。
 // ◊ 一个系统的算法使用的数据不可以让客户端知道。策略模式可以避免让客户端涉及到不必要接触到的复杂的和只与算法有关的数据。
 // ◊ 如果一个对象有很多的行为，如果不用恰当的模式，这些行为就只好使用多重的条件选择语句来实现。此时，使用策略模式，
     //把这些行为转移到相应的具体策略类里面，可以避免使用难以维护的多重条件选择语句。
 // 策略模式优点：
 // ◊ 策略模式恰当使用继承可以把公共的代码移到父类里面，从而避免重复的代码。
 // ◊ 策略模式提供了可以替换继承关系的办法。继承可以处理多种算法或行为。如果不是用策略模式，
       //那么使用算法或行为的环境类就可能会有一些子类，每一个子类提供一个不同的算法或行为。
       //但是，这样一来算法或行为的使用者就和算法或行为本身混在一起。决定使用哪一种算法或采取哪一种行为的逻辑就和算法或行为的逻辑混合在一起，
       //从而不可能再独立演化。继承使得动态改变算法或行为变得不可能。
// ◊ 使用策略模式可以避免使用多重条件判断语句。多重转移语句不易维护，它把采取哪一种算法或采取哪一种行为的逻辑与算法或行为的逻辑混合在一起，
     //统统列在一个多重转移语句里面，比使用继承的办法还要原始和落后。

 // 策略模式缺点：
 // ◊ 客户端必须知道所有的策略类，并自行决定使用哪一个策略类。策略模式只适用于客户端知道所有的算法或行为的情况。
 // ◊ 策略模式造成很多的策略类。
      //有时候可以通过把依赖于环境的状态保存到客户端里面，而将策略类设计成可共享的，
      //这样策略类实例可以被不同客户端使用。换言之，可以使用享元模式来减少对象的数量。