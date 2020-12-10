using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24_ChainOfResponsibilityPattern
{
   //场景：
   //下面以公司采购东西为例子来实现责任链模式。公司规定，采购架构总价在1万之内，经理级别的人批准即可，总价大于1万小于2万5的则还需要副总进行批准，
   //总价大于2万5小于10万的需要还需要总经理批准，而大于总价大于10万的则需要组织一个会议进行讨论。

    //对于这样一个需求，最直观的方法就是设计一个方法，参数是采购的总价，然后在这个方法内对价格进行调整判断，
    //然后针对不同的条件交给不同级别的人去处理，这样确实可以解决问题，但这样一来，我们就需要多重if-else语句来进行判断，但当加入一个新的条件范围时，
    //我们又不得不去修改原来设计的方法来再添加一个条件判断，这样的设计显然违背了“开-闭”原则。这时候，可以采用责任链模式来解决这样的问题。

    /// <summary>
    /// 采购请求
    /// </summary>
    public class PurchaseRequest
    {
        // 金额
        public double Amount { get; set; }
        // 产品名字
        public string ProductName { get; set; }
        public PurchaseRequest(double amount, string productName)
        {
            Amount = amount;
            ProductName = productName;
        }
    }

    /// <summary>
    /// 审批人,Handler
    /// </summary>
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }//当处理不了，给下一个审批人
        public string Name { get; set; }

        protected Approver(string name)
        {
            this.Name = name;
        }
        public abstract void ProcessRequest(PurchaseRequest request);
    }
    /// <summary>
    /// 具体审批人 董事长 将抽象处理接口具体实现 或者将请求传给下一个处理者。
    /// </summary>
    public class Manager : Approver
    {
        public Manager(string name)
            : base(name)
        { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount>25000.0&&request.Amount <= 100000.0)//如果处理，自己处理
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)//处理不了交给下个处理者
            {
                if (request.Amount <= 100000.0)
                {
                    NextApprover.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("Request需要组织一个会议讨论");
                }
            }
        }

    }

    /// <summary>
    /// 具体审批人 副董事长 将抽象处理接口具体实现 或者将请求传给下一个处理者。
    /// </summary>
    public class VicePresident : Approver
    {
        public VicePresident(string name)
            : base(name)
        {
        }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount>10000.0&&request.Amount <= 25000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                if (request.Amount <= 100000.0)
                {
                    NextApprover.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("Request需要组织一个会议讨论");
                }
            }
        }
    }
    /// <summary>
    /// 具体审批人 总经理 将抽象处理接口具体实现 或者将请求传给下一个处理者。
    /// </summary>
    public class President : Approver
    {
        public President(string name)
            : base(name)
        { }
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount <= 10000.0)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
            }
            else if (NextApprover != null)//处理不了交给下个处理者
            {
                if (request.Amount <= 100000.0)
                {
                    NextApprover.ProcessRequest(request);
                }
                else
                {
                    Console.WriteLine("Request需要组织一个会议讨论");
                }
            }
        }
    }

}
//在以下场景中可以考虑使用责任链模式：
//一个系统的审批需要多个对象才能完成处理的情况下，例如请假系统等。
//代码中存在多个if-else语句的情况下，此时可以考虑使用责任链模式来对代码进行重构。
//责任链模式的优缺点
//优点：
//降低了请求的发送者和接收者之间的耦合。
//把多个条件判定分散到各个处理类中，使得代码更加清晰，责任更加明确。
//缺点：
//在找到正确的处理对象之前，所有的条件判定都要执行一遍，当责任链过长时，可能会引起性能的问题
//可能导致某个请求不被处理。