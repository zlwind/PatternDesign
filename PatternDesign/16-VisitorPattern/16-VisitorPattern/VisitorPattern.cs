using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16_VisitorPattern
{
    //场景：读取公司不同职位的薪水
    //定义一个公司的员工管理系统的基本员工类，这个类层次要求保持稳定，不得随意添加内容。视为元素
    //对此就需要给这些类增加一个Accept方法用于将来的动态扩展。

    /// <summary>
    /// 声明一个或者多个访问操作，使得所有具体访问者必须实现的接口。
    /// </summary>
    public interface IVisitor
    {
        void Visit(Emploree emploree);//访问元素
    }
    /// <summary>
    /// 具体访问者角色（ConcreteVistor）：实现抽象访问者角色中所有声明的接口。
    /// </summary>
    public class ConcreteVistor : IVisitor
    {
        public void Visit(Emploree emploree)
        {
            Console.WriteLine("职位：{0}，薪金：{1}",emploree.Post,emploree.Salary);
        }
    }
    /// <summary>
    /// 抽象节点角色（Element）：声明一个接受操作，接受一个访问者对象作为参数。
    /// </summary>
    public abstract class Emploree
    {
        public string Post { get; set; }//被访问元素 职位
        public double Salary { get; set; }//被访问元素 薪水
        public abstract void Accept(IVisitor visitor);//声明一个接受操作，接受一个访问者对象作为参数访问元素
    }
    /// <summary>
    /// 具体节点角色（ConcreteElement）：实现抽象元素所规定的接受操作。
    /// </summary>
    public class Manager : Emploree
    {
        public Manager()
        {
            this.Salary = 100000;
            this.Post = "经理";
        }

        public override void Accept(IVisitor visitor)//接收this 为元素 调用访问操作
        {
            visitor.Visit(this);
        }
    }
    /// <summary>
    /// 具体节点角色（ConcreteElement）：实现抽象元素所规定的接受操作。
    /// </summary>
    public class Chairman : Emploree
    {
        public Chairman()
        {
            this.Salary = 500000;
            this.Post = "董事长";
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    /// <summary>
    /// 具体节点角色（ConcreteElement）：实现抽象元素所规定的接受操作。
    /// </summary>
    public class HeadMan : Emploree
    {
        public HeadMan()
        {
            this.Salary = 3000;
            this.Post = "组长";
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    /// <summary>
    /// 结构对象角色（ObjectStructure）：节点的容器，可以包含多个不同类或接口的容器
    /// </summary>
    public class ObjectStructurre
    {
        public List<Emploree> element = new List<Emploree>();
        public void Add(Emploree e)
        { element.Add(e); }
        public void Remove(Emploree e)
        { element.Remove(e); }
        public void Display()
        {
            foreach (Emploree e in element)
            {
                e.Accept(new ConcreteVistor());//接收一个访问者 调用访问操作接口  获取职位和薪水
            }
        }
    }
}
