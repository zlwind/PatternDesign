using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _20_MementoPattern
{
    //从字面意思就可以明白，备忘录模式就是对某个类的状态进行保存下来，等到需要恢复的时候，
    //可以从备忘录中进行恢复。生活中这样的例子经常看到，如备忘电话通讯录，备份操作操作系统，备份数据库等。
    //备忘录模式的具体定义是：
    //在不破坏封装的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态，这样以后就可以把该对象恢复到原先的状态。

    //备忘录模式中主要有三类角色：
    // 发起人角色(Origninator)：记录当前时刻的内部状态，负责创建和恢复备忘录数据。
    // 备忘录角色(Memento)：负责存储发起人对象的内部状态，在进行恢复时提供给发起人需要的状态。
    // 管理者角色(Caretaker)：负责保存备忘录对象。
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<ContactPerson>
            {
                new ContactPerson { Name= "Learning Hard", MobileNum = "123445"},
                new ContactPerson { Name = "Tony", MobileNum = "234565"},
                new ContactPerson { Name = "Jock", MobileNum = "231455"}
            };

            var mobileOwner = new MobileOwner(persons);
            mobileOwner.Show();

            // 创建备忘录并保存备忘录对象
            var caretaker = new Caretaker();
            caretaker.ContactMementoDic.Add(DateTime.Now.ToString(), mobileOwner.CreateMemento());

            // 更改发起人联系人列表
            Console.WriteLine("----移除最后一个联系人--------");
            mobileOwner.ContactPersons.RemoveAt(2);
            mobileOwner.Show();

            // 创建第二个备份
            Thread.Sleep(1000);
            caretaker.ContactMementoDic.Add(DateTime.Now.ToString(), mobileOwner.CreateMemento());

            // 恢复到原始状态
            Console.WriteLine("-------恢复联系人列表,请从以下列表选择恢复的日期------");
            var keyCollection = caretaker.ContactMementoDic.Keys;
            foreach (string k in keyCollection)
            {
                Console.WriteLine("Key = {0}", k);
            }
            while (true)
            {
                Console.Write("请输入数字,按窗口的关闭键退出:");

                int index = -1;
                try
                {
                    index = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("输入的格式错误");
                    continue;
                }

                ContactMemento contactMentor = null;
                if (index < keyCollection.Count && caretaker.ContactMementoDic.TryGetValue(keyCollection.ElementAt(index), out contactMentor))
                {
                    mobileOwner.RestoreMemento(contactMentor);
                    mobileOwner.Show();
                }
                else
                {
                    Console.WriteLine("输入的索引大于集合长度！");
                }
            }
        }
    }


}
//备忘录模式的适用场景
//在以下情况下可以考虑使用备忘录模式：
//如果系统需要提供回滚操作时，使用备忘录模式非常合适。例如文本编辑器的Ctrl+Z撤销操作的实现，数据库中事务操作。
//备忘录模式的优缺点
//优点：
//如果某个操作错误地破坏了数据的完整性，此时可以使用备忘录模式将数据恢复成原来正确的数据。
//备份的状态数据保存在发起人角色之外，这样发起人就不需要对各个备份的状态进行管理。而是由备忘录角色进行管理，
//而备忘录角色又是由管理者角色管理，符合单一职责原则。
//缺点：
//在实际的系统中，可能需要维护多个备份，需要额外的资源，这样对资源的消耗比较严重。