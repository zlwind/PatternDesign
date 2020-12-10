using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_CompositePattern_
{
    /// <summary>
    /// 抽象组合构件
    /// </summary>
    public abstract class Compoent
    {
        protected string name;//属性

        /// <summary>
        /// 增加一个节点
        /// </summary>
        /// <param name="compent"></param>
        public abstract void Add(Compoent compent);
        /// <summary>
        /// 删除一个节点
        /// </summary>
        /// <param name="compent"></param>
        public abstract void Remove(Compoent compent);
        /// <summary>
        /// 显示层级结构
        /// </summary>
        /// <param name="level"></param>
        public abstract void Display(int level);
    }
    /// <summary>
    /// 叶子节点
    /// </summary>
    public class Leaf : Compoent
    {
        public Leaf(string name)
        {
            this.name = name;
        }
        public override void Add(Compoent compent)
        {
            Console.WriteLine("无法添加元素到叶子节点");
        }
        public override void Remove(Compoent compent)
        {
            Console.WriteLine("无法在叶子节点移除元素");
        }
        public override void Display(int level)
        {
            Console.WriteLine(new string('-',level)+' '+name);
        }
    }
    /// <summary>
    /// 定义有枝节点的行为 实现存储部件，实现Compoent接口的操作
    /// </summary>
    public class Composite : Compoent
    {
        //子对象集合，村粗其下属的枝节点和叶节点
        private List<Compoent> children = new List<Compoent>();
        public Composite(string name)
        {
            this.name = name;
        }
        public override void Add(Compoent compent)
        {
            children.Add(compent);
        }
        public override void Remove(Compoent compent)
        {
            children.Remove(compent);
        }
        public override void Display(int level)
        {
            Console.WriteLine(new string('-',level)+' '+name);

            foreach (Compoent compent in children)
            { compent.Display(level + 2); }
        }
    }
}
