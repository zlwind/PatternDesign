using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//场景：气象站每天测量气温 气压参数以公告的形式发布出去（发布平台 百度 新浪 腾讯）
//      设计开放型API，便于其他第三方平台可以获取气象站数据并公告
//      第三方平台为具体观察者，用于同步气象站的数据并公告
//      气象站为具体主题，提供气温 气压的参数，当数据更新时，通知第三方平台
namespace _18_ObserverPattern
{
    /// <summary>
    /// 抽象主题角色
    /// 并提供增加和删除观察者对象的操作
    /// </summary>
    interface Subject
    {
        void Attach(Observer o);//观察者增加接口
        void Detach(Observer o);//观察者删除接口
        void Notify(double t,double p);//通知观察者接口
    }
    /// <summary>
    /// 具体主题角色
    /// 实现抽象主题接口
    /// 保存被观察的数据 即天气预报的气温 气压参数
    /// </summary>
    public class ConcreteSubject : Subject
    {
        private double temperature;//气温
        private double pressure;//气压

        List<Observer> observers = new List<Observer>();//维护观察者列表
        public void Attach(Observer o)
        {
            observers.Add(o);
        }
        public void Detach(Observer o)
        {
            observers.Remove(o);
        }
        public void Notify(double temperature, double pressure)
        {
            foreach (Observer o in observers)//遍历所有观察者
                o.Update(temperature,pressure);//通知观察者调用更新数据
        }
        public void SetData(double temperature,double pressure)//设置天气预报的气温 气压参数
        {
            this.temperature = temperature;
            this.pressure = pressure;
            Notify(this.temperature, this.pressure);
        }
    }
    /// <summary>
    /// 抽象观察者角色
    /// 为所有具体观察者定义一个接口，在得到主题通知时更新自己
    /// </summary>
    public interface Observer
    {
        void Update(double temperature,double pressure);//更新数据接口
    }
    /// <summary>
    /// 具体观察者模式
    /// 保存subjects状态
    ///实现当Observer接口发生变动时，subjects状态同步更新。
    /// </summary>
    public class ConcreteObserver : Observer
    {
        string name;
        double temperature;
        double pressure;
        public ConcreteObserver(string name)//创建不同观察者平台
        {
            this.name = name;
        }
        public void Update(double temperature, double pressure)//更新天气预报的数据与subjects状态同步 并显示
        { 
            this.temperature=temperature;
            this.pressure=pressure;
            Console.WriteLine("平台：{0} 天气预报：气温：{1}  压力：{2}", name, temperature, pressure);
        }
    }
}
