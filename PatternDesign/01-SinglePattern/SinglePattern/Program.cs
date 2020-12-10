using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    class Program
    {
        /// <summary>
        /// 单例模式：一个类只产生一个实例
        /// 确保一个类只有一个实例,并提供一个全局访问点
        /// </summary>
        public class Singleton
        {
            // 定义私有构造函数，使外界不能创建该类实例
            private Singleton()
            { }
            // 定义一个静态变量来保存类的实例
            private static Singleton instance;

            // 定义一个标识确保线程同步
            private static readonly object locker = new object();


            /// <summary>
            /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
            /// </summary>
            /// <returns></returns>
            public static Singleton GetInstance()
            {
                if (instance == null)//双重检查保证线程安全
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            Console.WriteLine("s1==s2:{0}", s1 == s2);
            Console.ReadKey();
        }
    }
}
