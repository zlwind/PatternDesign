using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_CommandPattern
{
    //命令模式:
    //目的是解除命令发出者和接收者之间的紧密耦合关系，使二者相对独立，
    //有利于程序的并行开发和代码的维护。命令模式的核心思想是将请求封装为一个对象，将其作为命令发起者和接收者的中介，
    //而抽象出来的命令对象又使得能够对一系列请求进行操作，如对请求进行排队，记录请求日志以及支持可撤销的操作等。

    //解决的问题
    //在软件系统中，行为请求者与行为实现者通常是一种紧耦合的关系，但某些场合，比如需要对行为进行记录、
    //撤销或重做、事务等处理时，这种无法抵御变化的紧耦合的设计就不太合适。

  //   命令模式参与者：
  //◊ Command：命令抽象类，声明一个执行操作的接口Execute，该抽象类并不实现这个接口，所有的具体命令都继承自命令抽象类。
  //◊ ConcreteCommand
  //  ° 定义一个接收者对象与动作之间的请求绑定
  //  ° 调用Receiver的操作，实现Execute方法
    //◊ Invoker：命令的调用者，将命令请求传递给相应的命令对象，每个ConcreteCommand都是一个Invoker的成员。
    //要求命令对象执行请求，通常会持有命令对象，可以持有很多的命令对象。这个是客户端真正触发命令并要求命令执行相应操作的地方，
    //也就是说相当于使用命令对象的入口。
  //◊ Receiver：命令的接收者，知道如何实施与执行一个请求相关的操作
  //◊ Client：客户端程序，创建一个具体命令对象并设定它的接收者
  //Command对象作为Invoker的一个属性，当点击事件发生时，Invoker调用方法Invoke()将请求发送给ConcreteCommand，
  //  再由ConcreteCommand调用Execute()将请求发送给Receiver，
  //  Client负责创建所有的角色，并设定Command与Invoker和Receiver之间的绑定关系。
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();//初始化接收命令者
            ICommand command = new ConcreteCommand(receiver);//初始化命令 传入接收者
            Invoker invoker = new Invoker(command);//调用命令
            invoker.ExecuteCommand();
            Console.ReadKey();
        }
    }
}
 //命令模式适用情形：
 // 1>、将用户界面和行为分离，使两者的开发可以并行不悖。
 // 2>、在需要指定、排列和执行一系列请求的情况下，适用命令模式。
 // 3>、支持修改日志。
 // 命令模式优点：
 // 1>、命令模式将调用操作对象和知道如何实现该操作对象的解耦。
 // 2>、在Command要增加新的处理操作对象很容易，可以通过创建新的继承自Command的子类来实现。
 // 3>、命令模式可以和Memento模式结合使用，支持取消的操作。
 // 4>、支持日志、请求队列和复合命令。
//  命令模式的缺点：
//  使用命令模式可能会导致系统有过多的具体命令类。这会使得命令模式在这样的系统里变得不实际。