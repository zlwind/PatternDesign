using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//接口适配器
namespace _07_AdapterPattern
{
    //被适配的接口
    interface Adaptee
    {
        int m1();
        void m2(string m);
        void m3();
    }
    /// <summary>
    /// 在抽象类中采用虚方法默认实现接口的所有方法
    /// </summary>
    public abstract class AbsAdapter : Adaptee
    {
        public virtual int m1()
        { return 1; }
        public virtual void m2(string m)
        { }
        public virtual void m3()
        { }
    }
    public class Adapter : AbsAdapter
    {
        public override int m1()
        {
            return 100;
        }
    }
}
