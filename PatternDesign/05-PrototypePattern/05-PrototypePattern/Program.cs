using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _05_PrototypePattern
{
    //原型模式：
    //用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象；
    //原型模式属于创建型模式，原型模式最大的特点就是对一个基类对象进行克隆复制创建出模型一样的副本，进行操作；

    //◊ Prototype：原型类，声明一个Clone自身的接口；
    //◊ ConcretePrototype：具体原型类，实现一个Clone自身的操作。
    //在原型模式中，Prototype通常提供一个包含Clone方法的接口，具体的原型ConcretePrototype使用Clone方法完成对象的创建。

    /// <summary>
    /// Prototype：原型类，声明一个Clone自身的接口；克隆羊,在net中相当于ICloneable接口
    /// </summary>
     [Serializable] 
    public abstract class Sheep
    {
        public abstract Sheep Clone();//浅拷贝
        public abstract object DeepClone();//深拷贝
    }
    /// <summary>
    /// 具体原型类，浅拷贝
    /// </summary>
    [Serializable] 
    public class CloneSheep:Sheep
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string name;
  
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private CloneSheep friend;

        public CloneSheep Friend
        {
            get { return friend; }
            set { friend = value; }
        }
        public CloneSheep(int _id, string _name, int _age)
        {
            Id = _id;
            Name = _name;
            Age = _age;
        }
        public override Sheep Clone()
        {
            return this.MemberwiseClone() as Sheep;//浅拷贝
        }
        /// <summary>
        /// 二进制对象序列化 进行深拷贝
        /// </summary>
        /// <returns></returns>
        public override object DeepClone()
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                retval = bf.Deserialize(ms);
                ms.Close();
                ms.Dispose();
            }
            return retval;//深拷贝
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            CloneSheep sheep = new CloneSheep(1,"Tom",2);
            sheep.Friend = new CloneSheep(2,"Jack",4);
            CloneSheep sheepClone = (CloneSheep)sheep.Clone();//浅拷贝
            CloneSheep sheepCloneDeep = (CloneSheep)sheep.DeepClone();//深拷贝

            Console.WriteLine("原型模式：浅拷贝");
            Console.WriteLine("原型羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}",sheep.Id,sheep.Name,sheep.Age
                , sheep.Friend.Id, sheep.Friend.Name,sheep.Friend.Age);
            Console.WriteLine("克隆羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheepClone.Id, sheepClone.Name, sheepClone.Age
                , sheepClone.Friend.Id, sheepClone.Friend.Name, sheepClone.Friend.Age);
            Console.WriteLine("原型羊姓名hashcode：{0}---克隆羊姓名hashcode：{1}", sheep.Friend.GetHashCode(), sheepClone.Friend.GetHashCode());
            Console.WriteLine("原型模式：深拷贝");
            Console.WriteLine("原型羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheep.Id, sheep.Name, sheep.Age
                , sheep.Friend.Id, sheep.Friend.Name, sheep.Friend.Age);
            Console.WriteLine("克隆羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheepCloneDeep.Id, sheepCloneDeep.Name, sheepCloneDeep.Age
                , sheepCloneDeep.Friend.Id, sheepCloneDeep.Friend.Name, sheepCloneDeep.Friend.Age);
            Console.WriteLine("原型羊姓名hashcode：{0}---克隆羊姓名hashcode：{1}", sheep.Friend.GetHashCode(), sheepCloneDeep.Friend.GetHashCode());

            sheep.Friend.Name = "Frank";
            sheep.Friend.Age = 14;
            Console.WriteLine("*********************修改引用类型的属性************************************");
            Console.WriteLine("原型模式：浅拷贝");
            Console.WriteLine("原型羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheep.Id, sheep.Name, sheep.Age
                , sheep.Friend.Id, sheep.Friend.Name, sheep.Friend.Age);
            Console.WriteLine("克隆羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheepClone.Id, sheepClone.Name, sheepClone.Age
                , sheepClone.Friend.Id, sheepClone.Friend.Name, sheepClone.Friend.Age);
            Console.WriteLine("原型羊姓名hashcode：{0}---克隆羊姓名hashcode：{1}", sheep.Friend.GetHashCode(), sheepClone.Friend.GetHashCode());
            Console.WriteLine("原型模式：深拷贝");
            Console.WriteLine("原型羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheep.Id, sheep.Name, sheep.Age
                , sheep.Friend.Id, sheep.Friend.Name, sheep.Friend.Age);
            Console.WriteLine("克隆羊：编号：{0} 姓名：{1} 年龄：{2} 朋友：{3}-{4}-{5}", sheepCloneDeep.Id, sheepCloneDeep.Name, sheepCloneDeep.Age
                , sheepCloneDeep.Friend.Id, sheepCloneDeep.Friend.Name, sheepCloneDeep.Friend.Age);
            Console.WriteLine("原型羊姓名hashcode：{0}---克隆羊姓名hashcode：{1}", sheep.Friend.GetHashCode(), sheepCloneDeep.Friend.GetHashCode());
            Console.ReadKey();
        }
    }
}
//.Net在System命名空间中提供了ICloneable接口，其中有一个唯一的方法Clone( )，你只要实现这个接口就可以完成原型模式

//MemberwiseClone( ) 方法：如果字段是值类型的，则对该字段执行逐位复制，如果字段是引用类型，则复制引用但不复制引用的对象，因此原始对象及其复本引用同一对象。
//浅拷贝：被复制对象的所有变量都含有与原来的对象相同的值，而所有的对其它对象的引用都仍然指向原来的对象 
//深拷贝：把引用对象的变量指向复制过来的新对象，而不是原来的被引用的对象

 //原型模式可以适用于以下情形：
 // ◊ 当一个系统应该独立于它的产品创建、构成和表示时；
 // ◊ 当要实例化的类是在运行时刻指定时，例如通过动态装载来创建一个类；
 // ◊ 为了避免创建一个与产品类层次平行的工厂类层次时；
 // ◊ 当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并Clone它们可能比每次用合适的状态手工实例化该类更方便一些。

// 原型模式的优点有：
 //原型模式向客户隐藏了创建新实例的复杂性
 //原型模式允许动态增加或较少产品类。
 //原型模式简化了实例的创建结构，工厂方法模式需要有一个与产品类等级结构相同的等级结构，而原型模式不需要这样。
 //产品类不需要事先确定产品的等级结构，因为原型模式适用于任何的等级结构
 //原型模式的缺点有：
 //每个类必须配备一个克隆方法
 //配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，
 //特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。
