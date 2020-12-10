using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//场景：设计一个代理，代理数学加减乘除四则运算
namespace _13_Proxy_Pattern
{
    /// <summary>
    /// 抽象主题角色：定义ConcreteSubject与Proxy的共用接口，从而在任何使用ConcreteSubject的地方都可以使用Proxy。
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }
    /// <summary>
    /// 真实主题角色：定义Proxy所代表的Subject
    /// </summary>
    public class Math : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
    }
    /// <summary>
    /// 代理主题角色
    //  ° 维持一个引用，使得代理可以访问Subject。
    //  ° 提供一个与Subject的接口相同的接口，这样代理就可以替代Subject。
    //  ° 控制对Subject的访问，并可能负责对Subject的创建和删除。
    /// </summary>
    public class MathProxy : IMath
    {
        private Math _math = new Math();//维持一个具体引用

        public double Add(double x, double y)//可以在内部增加控制访问Math类
        {
            return _math.Add(x, y);
        }

        public double Sub(double x, double y)//可以在内部增加控制访问Math类
        {
            return _math.Sub(x, y);
        }

        public double Mul(double x, double y)//可以在内部增加控制访问Math类
        {
            return _math.Mul(x, y);
        }

        public double Div(double x, double y)//可以在内部增加控制访问Math类
        {
            if (y != 0)
            {
                return _math.Div(x, y);
            }
            else
            { return double.NaN; }
        }
    }
}
