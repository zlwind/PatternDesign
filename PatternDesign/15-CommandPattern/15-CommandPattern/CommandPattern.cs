using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_CommandPattern
{
    /// <summary>
    /// 命令抽象类，声明一个执行操作的接口Execute，该抽象类并不实现这个接口，
    /// 所有的具体命令都继承自命令抽象类。
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
    /// <summary>
    /// ConcreteCommand
    //  ° 定义一个接收者对象与动作之间的请求绑定
    //  ° 调用Receiver的操作，实现Execute方法
    /// </summary>
    public class ConcreteCommand : ICommand
    {
        private Receiver receiver;//定义一个接收者对象与动作之间的请求绑定
        public ConcreteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void Execute()//调用Receiver的操作，实现Execute方法
        {
            receiver.Action();
        }
    }
    /// <summary>
    /// 命令的接收者，知道如何实施与执行一个请求相关的操作
    /// </summary>
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }
    /// <summary>
    /// 命令的调用者，将命令请求传递给相应的命令对象，每个ConcreteCommand都是一个Invoker的成员。
    /// 要求命令对象执行请求，通常会持有命令对象，可以持有很多的命令对象。这个是客户端真正触发命令并要求命令执行相应操作的地方，
    //也就是说相当于使用命令对象的入口。
    /// </summary>
    public class Invoker
    {
        private ICommand command;//通常会持有命令对象，
        public Invoker(ICommand command)
        { this.command = command; }
        public void ExecuteCommand()//执行命令的执行方法
        {
            command.Execute();
        }
    }
}
