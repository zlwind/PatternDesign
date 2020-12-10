using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00a_SevenPrinciples
{
    //2.    单一职责原则（Single Responsibility Principle） 
    //      定义：一个类，只有一个引起它变化的原因。即：应该只有一个职责。
    //            每一个职责都是变化的一个轴线，如果一个类有一个以上的职责，
    //            这些职责就耦合在了一起。这会导致脆弱的设计。当一个职责发生变化时，
    //            可能会影响其它的职责。另外，多个职责耦合在一起，会影响复用性。
    //            例如：要实现逻辑和界面的分离。需要说明的一点是单一职责原则不只是面向对象编程思想所特有的，
    //            只要是模块化的程序设计，都需要遵循这一重要原则。 
    //      问题由来：类T负责两个不同的职责：职责P1，职责P2。
    //                当由于职责P1需求发生改变而需要修改类T时，有可能会导致原本运行正常的职责P2功能发生故障。 
    //      解决方法：分别建立两个类T1、T2，使T1完成职责P1功能，T2完成职责P2功能。
    //                这样，当修改类T1时，不会使职责P2发生故障风险；同理，当修改T2时，也不会使职责P1发生故障风险。

   //假定现在有如下场景：国际手机运营商那里定义了生产手机必须要实现的接口，接口里面定义了一些手机的属性和行为，
   //手机生产商如果要生成手机，必须要实现这些接口。

    //单一职责原则要求一个接口或类只有一个原因引起变化，也就是一个接口或类只有一个职责，它就负责一件事情，
    //我们以手机作为单一职责去设计，也是有一定的道理的，因为我们接口里面都是定义的手机相关属性和行为，
    //引起接口变化的原因只可能是手机的属性或者行为发生变化，从这方面考虑，
    //这种设计是有它的合理性的，如果你能保证需求不会变化或者变化的可能性比较小，那么这种设计就是合理的。
    //如果粒度再细小一些呢，那我们这种职责划分是否完美呢？
    //接口细化粒度设计

    /// <summary>
    /// 充电电源
    /// </summary>
    public class ElectricSource
    { }
    //手机基础属性接口
    public interface IMobilePhoneBaseProperty
    {
        //运行内存
        string RAM { get; set; }

        //手机存储内存
        string ROM { get; set; }

        //CPU主频
        string CPU { get; set; }

        //屏幕大小
        int Size { get; set; }
    }

    //手机扩展属性接口
    public interface IMobilePhoneExtentionProperty
    {
        //摄像头像素
        string Pixel { get; set; }
    }

    //手机基础功能接口
    public interface IMobilePhoneBaseFunc
    {
        //手机充电接口
        void Charging(ElectricSource oElectricsource);

        //打电话
        void RingUp();

        //接电话
        void ReceiveUp();
    }

    //手机扩展功能接口
    public interface IMobilePhoneExtentionFunc
    {
        //上网
        void SurfInternet();

        //移动办公
        void MobileOA();

        //玩游戏
        void PlayGame();
    }

    //手机基础属性实现
    public class MobilePhoneBaseProperty : IMobilePhoneBaseProperty
    {

        public string RAM
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string ROM
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string CPU
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int Size
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

    //手机扩展属性实现
    public class MobilePhoneExtentionProperty : IMobilePhoneExtentionProperty
    {

        public string Pixel
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

    //手机基础功能实现
    public class MobilePhoneBaseFunc : IMobilePhoneBaseFunc
    {
        public void Charging(ElectricSource oElectricsource)
        {
            throw new NotImplementedException();
        }

        public void RingUp()
        {
            throw new NotImplementedException();
        }

        public void ReceiveUp()
        {
            throw new NotImplementedException();
        }
    }

    //手机扩展功能实现
    public class MobilePhoneExtentionFunc : IMobilePhoneExtentionFunc
    {

        public void SurfInternet()
        {
            throw new NotImplementedException();
        }

        public void MobileOA()
        {
            throw new NotImplementedException();
        }

        public void PlayGame()
        {
            throw new NotImplementedException();
        }
    }

}
