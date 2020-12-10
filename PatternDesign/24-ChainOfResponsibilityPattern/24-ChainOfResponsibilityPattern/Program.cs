using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24_ChainOfResponsibilityPattern
{
    //责任链模式
    //指的是——某个请求需要多个对象进行处理，从而避免请求的发送者和接收之间的耦合关系。
    //将这些对象连成一条链子，并沿着这条链子传递该请求，直到有对象处理它为止。

    //命令的请求要经过多层判断，为了避免客户端和处理程序的耦合作用，将处理程序进行抽象，每个对象持有下一个处理对象的引用，
    //就像是链表一样，一级一级的处理，这样的设计方式就叫做责任链模式。

    //主要涉及两个角色：
    //抽象处理者角色（Handler）：定义出一个处理请求的接口。这个接口通常由接口或抽象类来实现。
    //具体处理者角色（ConcreteHandler）：具体处理者接受到请求后，可以选择将该请求处理掉，
    //或者将请求传给下一个处理者。因此，每个具体处理者需要保存下一个处理者的引用，以便把请求传递下去。
    class Program
    {
        static void Main(string[] args)
        {
            var requestTelphone = new PurchaseRequest(4000.0, "Telphone");
            var requestSoftware = new PurchaseRequest(12000.0, "Visual Studio");
            var requestComputers = new PurchaseRequest(400000.0, "Computers");

            Approver manager = new Manager("LearningHard");
            Approver vp = new VicePresident("Tony");
            Approver pre = new President("BossTom");

            // 设置责任链 构成环状，即在哪个级别调用都可以
            manager.NextApprover = vp;
            vp.NextApprover = pre;
            pre.NextApprover = manager;

            // 处理请求
            manager.ProcessRequest(requestTelphone);
            manager.ProcessRequest(requestSoftware);
            vp.ProcessRequest(requestComputers);
            Console.ReadLine();
        }
    }
}
