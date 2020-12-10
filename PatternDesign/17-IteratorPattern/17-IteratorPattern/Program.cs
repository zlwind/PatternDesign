using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _17_IteratorPattern
{
    //迭代器模式:
    //提供一种方法可以顺序访问聚合对象中各个元素，但又不暴露该对象的内部表示。
    //这样既可以做到不暴露集合的内部结构，又可让外部代码透明地访问集合内部的数据。

    //迭代器角色（Iterator）：迭代器角色负责定义访问和遍历元素的接口
    //具体迭代器角色（Concrete Iteraror）：具体迭代器角色实现了迭代器接口，并需要记录遍历中的当前位置。
    //聚合角色（Aggregate）：聚合角色负责定义获得迭代器角色的接口
    //具体聚合角色（Concrete Aggregate）：具体聚合角色实现聚合角色接口。
    public class Client
    {
        private Iterator _iterator;
        private Aggregate _aggregate = new ConcreteAggregate();

        public void Operation()
        {
            // 获得迭代器
            _iterator = _aggregate.CreateIterator();

            while (!_iterator.IsDone())
            {
                Console.WriteLine(_iterator.CurrentItem());
                _iterator.Next();
            }
        }

        static void Main(string[] args)
        {
            Client client = new Client();
            client.Operation();
            Console.ReadKey();
        }
    }
}
 //迭代器模式适用情形：
 // 1>、访问一个具体对象的内容而不暴露它的内部表示；
 // 2>、支持对聚合对象的多种遍历；
 // 3>、为遍历不同的聚合结构提供一个统一的接口（即支持多态迭代）。
 // 迭代器模式特点：
 // 1>、简化聚集的行为，迭代器具备了遍历的接口，这样聚集的接口就不必具备遍历接口；
 // 2>、每一个聚集对象都可以有一个或者更多的迭代器对象，每一个迭代器的迭代状态可以彼此独立（外禀迭代器）；
 // 3>、遍历算法被封装到迭代器对象中，迭代算法可以独立于聚集对象变化。Client不必知道聚集对象的类型，
 //       通过迭代器可以就读取和遍历聚集对象。这样的好处是聚集本身内部数据发生变化而不影响Client的程序。

//由于迭代器承担了遍历集合的职责，从而有以下的优点：
//迭代器模式使得访问一个聚合对象的内容而无需暴露它的内部表示，即迭代抽象。
//迭代器模式为遍历不同的集合结构提供了一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作
//迭代器模式存在的缺陷：
//迭代器模式在遍历的同时更改迭代器所在的集合结构会导致出现异常。
//所以使用foreach语句只能在对集合进行遍历，不能在遍历的同时更改集合中的元素。