using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderPattern
{
    //建造者（Builder）模式
    //将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
    //建造者模式使得建造代码与表示代码的分离，可以使客户端不必知道产品内部组成的细节，从而降低了客户端与具体产品之间的耦合度。
    //在软件系统中，有时需要创建一个复杂对象，并且这个复杂对象由其各部分子对象通过一定的步骤组合而成

       //抽象建造者角色（Builder)
       //    为创建一个Product对象的各个部件指定抽象接口，以规范产品对象的各个组成部分的建造。一般而言，此角色规定要实现复杂对象的哪些部件的创建，并不涉及具体的对象部件的创建。
       //具体建造者（ConcreteBuilder）
       //    1.继承Builder类，即实现抽象建造者角色Builder的方法。
       //    2.具体化组件以实现方法的创建。
       //    3.返回产品角色的实例。
       //指导者（Director）
       //    调用具体建造者角色以创建产品对象的各个部分。指导者并没有涉及具体产品类的信息，真正拥有具体产品的信息是具体建造者。
       //产品角色（Product）
       //    建造中的复杂对象。它要包含那些定义组件的类，包括将这些组件装配成产品的接口。
    /// <summary>
    /// 以组装电脑为例
    /// 每台电脑的组成过程都是一致的，但是使用同样的构建过程可以创建不同的表示(即可以组装成不一样的电脑，配置不一样)
    /// 组装电脑的这个场景就可以应用建造者模式来设计
    /// 产品角色（Product）
    /// </summary>
    public class Computer
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string cpu;

        public string Cpu
        {
            get { return cpu; }
            set { cpu = value; }
        }

        string memory;

        public string Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        string disk;

        public string Disk
        {
            get { return disk; }
            set { disk = value; }
        }

    }
    /// <summary>
    /// 抽象建造者角色（Builder)
    /// </summary>
    public abstract class Builder
    {
        public abstract string BuilderCase();//组装机箱
        public abstract string BuilderCpu();//组装cpu
        public abstract string BuilderMemory();//组装内存
        public abstract string BuilderDisk();//组装硬盘
        public abstract Computer GetComputer();//获取产品
    }
    /// <summary>
    /// 具体建造者（ConcreteBuilder）
    /// </summary>
    class HpComputerBuilder : Builder
    {
        public override string BuilderCase()
        {
            string name = "惠普";
            Console.WriteLine("组装电脑机箱：{0}",name);
            return name;
        }
        public override string BuilderCpu()
        {
            string cpu = "intel";
            Console.WriteLine("组装电脑cpu：{0}", cpu);
            return cpu;
        }
        public override string BuilderMemory()
        {
            string memory = "2G";
            Console.WriteLine("组装电脑内存：{0}", memory);
            return memory;
        }
        public override string BuilderDisk()
        {
            string disk = "160G";
            Console.WriteLine("组装电脑硬盘：{0}", disk);
            return disk;
        }
        public override Computer GetComputer()
        {
            return new Computer();
        }
    }
    class LenovoComputerBuilder : Builder
    {
        public override string BuilderCase()
        {
            string name = "联想";
            Console.WriteLine("组装电脑机箱：{0}", name);
            return name;
        }
        public override string BuilderCpu()
        {
            string cpu = "AMD";
            Console.WriteLine("组装电脑cpu：{0}", cpu);
            return cpu;
        }
        public override string BuilderMemory()
        {
            string memory = "4G";
            Console.WriteLine("组装电脑内存：{0}", memory);
            return memory;
        }
        public override string BuilderDisk()
        {
            string disk = "1T";
            Console.WriteLine("组装电脑硬盘：{0}", disk);
            return disk;
        }
        public override Computer GetComputer()
        {
            return new Computer();
        }
    }
    /// <summary>
    /// 指挥者
    /// </summary>
    public class Director
    {
        public Computer Construct( Builder builder)
        {
            Computer computer = builder.GetComputer();
            computer.Name = builder.BuilderCase();
            computer.Cpu = builder.BuilderCpu();
            computer.Memory = builder.BuilderMemory();
            computer.Disk = builder.BuilderDisk();
            return computer;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Director direct = new Director();
            Builder hpBuilder = new HpComputerBuilder();
            Builder lenovoBuilder = new LenovoComputerBuilder();
            Computer hpComputer = direct.Construct(hpBuilder);
            Computer lenovoComputer = direct.Construct(lenovoBuilder);
            Console.WriteLine("品牌：{0} CPU:{1} 内存:{2} 硬盘：{3}",hpComputer.Name,hpComputer.Cpu,hpComputer.Memory,hpComputer.Disk);
            Console.WriteLine("品牌：{0} CPU:{1} 内存:{2} 硬盘：{3}", lenovoComputer.Name, lenovoComputer.Cpu, lenovoComputer.Memory, lenovoComputer.Disk);
            Console.ReadKey();
        }
    }
}

 //建造者模式适用情形：
 // ◊ 需要生成的产品对象有复杂的内部结构
 // ◊ 需要生成的产品对象的属性相互依赖，建造者模式可以强迫生成顺序
 // ◊ 在对象创建过程中会使用到系统中的一些其他对象，这些对象在产品对象的创建过程中不易得到
 // 建造者模式特点：
 // ◊ 建造者模式的使用使得产品的内部表对象可以独立地变化。使用建造者模式可以使客户不必知道产品内部组成的细节
 // ◊ 每一个Builder都相对独立，而与其他Builder无关
 // ◊ 可使对构造过程更加精细控制
 // ◊ 将构建代码和表示代码分开
 // ◊ 建造者模式的缺点在于难于应付分步骤构建算法的需求变动
      //当组件的组合种类很多时，需要创建很多的具体建造者类。
