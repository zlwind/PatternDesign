using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00a_SevenPrinciples
{
    //1.   开闭原则(Open-Closed Principle, OCP)
    //     定义：软件实体应当对扩展开放，对修改关闭。这句话说得有点专业，
    //           更通俗一点讲，也就是：软件系统中包含的各种组件，例如模块（Modules）、类（Classes）以及功能（Functions）等等，
    //           应该在不修改现有代码的基础上，去扩展新功能。开闭原则中原有“开”，是指对于组件功能的扩展是开放的，
    //           是允许对其进行功能扩展的；开闭原则中“闭”，是指对于代码的修改是封闭的，即不应该修改原有的代码。
    //    问题由来：凡事的产生都有缘由。我们来看看，开闭原则的产生缘由。在软件的生命周期内，
    //              因为变化、升级和维护等原因需要对软件原有代码进行修改时，可能会给旧代码中引入错误，
    //              也可能会使我们不得不对整个功能进行重构，并且需要原有代码经过重新测试。这就对我们的整个系统的影响特别大，
    //              这也充分展现出了系统的耦合性如果太高，会大大的增加后期的扩展，维护。为了解决这个问题，故人们总结出了开闭原则。
    //              解决开闭原则的根本其实还是在解耦合。所以，我们面向对象的开发，我们最根本的任务就是解耦合。 
    //    解决方法：当软件需要变化时，尽量通过扩展软件实体的行为来实现变化，而不是通过修改已有的代码来实现变化。 
    //    小结：开闭原则具有理想主义的色彩，说的很抽象，它是面向对象设计的终极目标。
    //          其他几条原则，则可以看做是开闭原则的实现。我们要用抽象构建框架，用实现扩展细节。
   
        //场景说明：马上中秋节了， **公司希望研发部门研发一套工具，实现给公司所有员工发送祝福邮件。
        //          接到开发需求，研发部立刻开会成立研发小组，进入紧张的开发阶段，经过1个月的艰苦奋战，系统顺利上线。代码实现如下：

   //***************************** 1、对实现类编程，你死得很惨****************************//
    //发送邮件的类
    public class EmailMessage1
    {
        //里面是大量的SMTP发送邮件的逻辑

        //发送邮件的方法
        public void SendMessage(string strMsg)
        {
            Console.WriteLine("Email节日问候：" + strMsg);
        }
    }
    /// <summary>
    /// MessageService服务
    /// </summary>
    public class MessageService1
    {
        private EmailMessage1 emailHelper = null;
        public MessageService1()
        {
            emailHelper = new EmailMessage1();
        }

        //节日问候
        public void Greeting(string strMsg)
        {
            emailHelper.SendMessage(strMsg);
        }
    }
    /// <summary>
    /// 业务调用模块
    /// </summary>
    class Program1
    {
        public  void Client()
        {
            MessageService1 oService = new MessageService1();
            oService.Greeting("祝大家中秋节快乐。");

            Console.ReadKey();
        }
    }
    //日复一日，年复一年，随着时间的推移，公司发现邮件推送的方式也存在一些弊病，比如某些网络不发达地区不能正常地收到邮件，
    //并且在外出差人员有时不能正常收到邮件。这个时候公司领导发现短信推送是较好的解决办法。
    //于是乎，需求变更来了：增加短信推送节日祝福的功能，对于行政部等特殊部门保留邮件发送的方式。
    //$$$$做如下修改：

    //增加发送短信的类
    public class PhoneMessage1
    {
        //手机端发送短信的业务逻辑

        //发送短信的方法
        public void SendMessage(string strMsg)
        {
            Console.WriteLine("短信节日问候：" + strMsg);
        }
    }
    //1.2 MessageService服务里面增加了一个枚举类型MessageType判断是哪种推送方式
    public enum MessageType
    {
        Email,
        Phone
    }
    //增加判断email和短信节日问候
    public class MessageService1_1
    {
        private EmailMessage1 emailHelper = null;
        private PhoneMessage1 phoneHelper = null;
        private MessageType m_oType;
        public MessageService1_1(MessageType oType)
        {
            m_oType = oType;
            if (oType == MessageType.Email)
            {
                emailHelper = new EmailMessage1();
            }
            else if (oType == MessageType.Phone)
            {
                phoneHelper = new PhoneMessage1();
            }
        }

        //节日问候
        public void Greeting(string strMsg)
        {
            if (m_oType == MessageType.Email)
            {
                emailHelper.SendMessage(strMsg);
            }
            else if (m_oType == MessageType.Phone)
            {
                phoneHelper.SendMessage(strMsg);
            }
        }
    }
    class Program1_1
    {
        public void Client()
        {
            MessageService1_1 oEmaliService = new MessageService1_1(MessageType.Email);
            oEmaliService.Greeting("祝大家中秋节快乐。");

            MessageService1_1 oPhoneService = new MessageService1_1(MessageType.Phone);
            oPhoneService.Greeting("祝大家中秋节快乐。");
            Console.ReadKey();
        }
    }
   //***************************** 2、对抽象编程，就是这么灵活****************************//

    public interface ISendable
    {
        void SendMessage(string strMsg);
    }
    //发送邮件的类
    public class EmailMessage2 : ISendable
    {
        //里面是大量的SMTP发送邮件的逻辑

        //发送邮件的方法
        public void SendMessage(string strMsg)
        {
            Console.WriteLine("Email节日问候：" + strMsg);
        }
    }

    //发送短信的类
    public class PhoneMessage2 : ISendable
    {
        //手机端发送短信的业务逻辑

        //发送短信的方法
        public void SendMessage(string strMsg)
        {
            Console.WriteLine("短信节日问候：" + strMsg);
        }
    }

    //发送微信的类
    public class WeChatMessage2 : ISendable
    {
        //微信消息推送业务逻辑

        //发送微信消息的方法
        public void SendMessage(string strMsg)
        {
            Console.WriteLine("短信节日问候：" + strMsg);
        }
    }
    public class MessageService2
    {
        private ISendable m_oSendHelper = null;
        public MessageService2(ISendable oSendHelper)
        {
            m_oSendHelper = oSendHelper;
        }

        //节日问候
        public void GreetingI(string strMsg)
        {
            m_oSendHelper.SendMessage(strMsg);

        }
    }
    class Program2
    {
        public void Client()
        {
            var strMsg = "祝大家中秋节快乐。";
            ISendable oEmailHelper = new EmailMessage2();
            MessageService2 oEmaliService = new MessageService2(oEmailHelper);
            oEmaliService.GreetingI(strMsg);

            ISendable oPhoneHelper = new PhoneMessage2();
            MessageService2 oPhoneService = new MessageService2(oPhoneHelper);
            oPhoneService.GreetingI(strMsg);

            ISendable oWeChatHelper = new WeChatMessage2();
            MessageService2 oWeChatService = new MessageService2(oWeChatHelper);
            oWeChatService.GreetingI(strMsg);
            Console.ReadKey();
        }
    }
}
