using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17_IteratorPattern
{
    /// <summary>
    /// 定义一个迭代器接口
    /// </summary>
    public interface Iterator
    {
        /// <summary>
        /// 迭代器定位到聚合的第一个元素
        /// </summary>
        void First();

        /// <summary>
        /// 遍历下一个
        /// </summary>
        void Next();

        /// <summary>
        /// 判断是否完成遍历
        /// </summary>
        /// <returns></returns>
        bool IsDone();

        /// <summary>
        /// 获得当前遍历的项
        /// </summary>
        /// <returns></returns>
        object CurrentItem();
    }
    /// <summary>
    /// 定义具体的迭代器类
    /// </summary>
    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate aggregate;
        private int index = 0;
        private int size = 0;

        /// <summary>
        /// 根据不同的聚合类进行初始化
        /// </summary>
        /// <param name="aggregate"></param>
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
            size = aggregate.Size();
            index = 0;
        }

        public void First()
        {
            index = 0;
        }

        public void Next()
        {
            if (index < size)
            {
                index++;
            }
        }

        /// <summary>
        /// 判断是否遍历完毕
        /// </summary>
        /// <returns></returns>
        public bool IsDone()
        {
            return index >= size;
        }

        /// <summary>
        /// 获取当前遍历的元素
        /// </summary>
        /// <returns></returns>
        public object CurrentItem()
        {
            return aggregate.GetElement(index);
        }
    }

    /// <summary>
    /// 定义一个抽象的聚合类
    /// </summary>
    public abstract class Aggregate
    {
        /// <summary>
        /// 只有一个功能，创建迭代器
        /// </summary>
        /// <returns></returns>
        public virtual Iterator CreateIterator()
        {
            return null;
        }
    }

    /// <summary>
    /// 定义一个具体的聚合类
    /// </summary>
    public class ConcreteAggregate : Aggregate
    {
        // 存储元素的集合
        private object[] objs = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        /// <summary>
        /// 获得元素个数
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return objs.Length;
        }

        /// <summary>
        /// 获取指定序号的元素
        /// </summary>
        /// <param name="index">指定的序号</param>
        /// <returns></returns>
        public object GetElement(int index)
        {
            if (index < 0 || index > objs.Length)
            {
                return null;
            }

            return objs[index];
        }

        /// <summary>
        /// 创建该聚合类的迭代器
        /// </summary>
        /// <returns></returns>
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }
}

