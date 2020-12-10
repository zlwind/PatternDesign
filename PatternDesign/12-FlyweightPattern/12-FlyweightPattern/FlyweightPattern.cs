using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _12_FlyweightPattern
{
    //场景：生成26个英文字母的类并显示英文字母
    //内部状态：在享元对象的内部并且不会随着环境的改变而改变的共享部分，在这个场景中就是26个英文字母（大小写） letters
    //外部状态：随环境改变而改变的，不可以共享的状态。在这个场景中  externalState

    /// <summary>
    /// 抽象享元角色 定义运行方法 直接接收并作用于外部状态 
    /// </summary>
    public interface IFlweight
    {
        //externalstate 外部状态
        void Operation(int externalstate);
    }
    /// <summary>
    /// 具体享元角色 并为内部状态增加存储空间 存储的状态必须是内部的
    /// </summary>
    public class ConcreteFlyweight : IFlweight
    {
        //定义内部状态，可以共享
        string letters;
        public ConcreteFlyweight(string letters)
        {
            letters = letters.ToUpper();
            this.letters = letters;
        }
        //externalstate 外部状态
        public void Operation(int externalstate)
        { Console.WriteLine("英文字母：大写：{0}--小写：{1} 外部状态：{2}",letters,letters.ToLower(),externalstate); }
    }



    /// <summary>

    /// 享元工厂，负责创建和管理享元对象

    /// </summary>

    public class FlyweightFactory
    {

        Hashtable flyweighrs = new Hashtable();


        public IFlweight GetFlyweight(string key)
        {
            key = key.ToUpper();
            if (!flyweighrs.Contains(key))
            {
                flyweighrs.Add(key, new ConcreteFlyweight(key));
            }
            return flyweighrs[key] as IFlweight;

        }
        /// <summary>
        /// 获取池中的对象个数
        /// </summary>
        /// <returns></returns>
        public int GetFlyweightCount()
        {
            
            return flyweighrs.Count;

        }
    }

}
