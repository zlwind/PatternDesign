using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00a_SevenPrinciples
{
    //5.    依赖倒置原则（Dependence Inversion Principle） 
    //      定义：高层模块不应该依赖低层模块，二者都应该依赖其抽象；抽象不应该依赖细节；细节应该依赖抽象。中心思想是面向接口编程 
    //      问题由来：类A直接依赖类B，假如要将类A改为依赖类C，则必须通过修改类A的代码来达成。这种场景下，
    //                类A一般是高层模块，负责复杂的业务逻辑；类B和类C是低层模块，负责基本的原子操作；假如修改类A，会给程序带来不必要的风险。 
    //      解决方法：将类A修改为依赖接口I，类B和类C各自实现接口I，类A通过接口I间接与类B或者类C发生联系，则会大大降低修改类A的几率。 
    //                在实际编程中，我们一般需要做到如下3点：
    //                1）. 低层模块尽量都要有抽象类或接口，或者两者都有。
    //                2）. 变量的声明类型尽量是抽象类或接口。
    //                3）. 使用继承时遵循里氏替换原则。 
    //               采用依赖倒置原则尤其给多人合作开发带来了极大的便利，参与协作开发的人越多、项目越庞大，采用依赖导致原则的意义就越重大。 
    //     小结：依赖倒置原则就是要我们面向接口编程，理解了面向接口编程，也就理解了依赖倒置。 

    //定义一个统一接口用于依赖
    public interface IDevice
    {
        void Login();
        bool Spider();
    }

    //MML类型的设备
    public class DeviceMML : IDevice
    {
        public void Login()
        {
            Console.WriteLine("MML设备登录");
        }

        public bool Spider()
        {
            Console.WriteLine("MML设备采集");
            return true;
        }
    }

    //TL2类型设备
    public class DeviceTL2 : IDevice
    {
        public void Login()
        {
            Console.WriteLine("TL2设备登录");
        }

        public bool Spider()
        {
            Console.WriteLine("TL2设备采集");
            return true;
        }
    }

    //TELNET类型设备
    public class DeviceTELNET : IDevice
    {
        public void Login()
        {
            Console.WriteLine("TELNET设备登录");
        }

        public bool Spider()
        {
            Console.WriteLine("TELNET设备采集");
            return true;
        }
    }

    //TL5类型设备
    public class DeviceTL5 : IDevice
    {
        public void Login()
        {
            Console.WriteLine("TL5设备登录");
        }

        public bool Spider()
        {
            Console.WriteLine("TL5设备采集");
            return true;
        }
    }


    //设备采集的服务
    public class DeviceService
    {
        private IDevice m_device;
        public DeviceService(IDevice oDevice)
        {
            m_device = oDevice;
        }

        public void LoginDevice()
        {
            m_device.Login();
        }

        public bool DeviceSpider()
        {
            return m_device.Spider();
        }
    }

    //代码说明：上述解决方案中，我们定义了一个IDevice接口，用于上层服务的依赖，
    //也就是说，上层服务（这里指DeviceService）仅仅依赖IDevice接口，对于具体的实现类我们是不管的，只要接口的行为不发生变化，
    //增加新的设备类型后，上层服务不用做任何的修改。这样设计降低了层与层之间的耦合，能很好地适应需求的变化，大大提高了代码的可维护性。
}
