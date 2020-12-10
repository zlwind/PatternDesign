using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//对象适配器
//实现思路：
//既然现在适配器类不能继承220v抽象类了（因为用继承就属于类的适配器模式了），
//但是适配器类无论如何都要实现客户端期待的方法，即GetVoltage5()方法，
//所以一样是要继承220v抽象类或220v接口的，
//然而适配器类的GetVoltage5()方法又必须调用220v的GetVoltage220()方法，又不能用继承，
//这时候就想，不能继承，但是我们可以在适配器类中创建220v对象，然后在GetVoltage5()中使用220v的GetVoltage220()的方法了。

namespace _07_AdapterPattern
{
    class ObjAdapteeVoltage220
    {
        public int GetVoltage220()
        { return 220; }
    }
    /// <summary>
    /// 接口：使用5v电压
    /// </summary>
    interface ObjIVoltage5
    {
        int GetVoltage5();
    }
    /// <summary>
    /// 适配类，内部调用被适配对象
    /// 继承5v的接口完成转化
    /// </summary>
    class ObjAdapterVoltage : ObjIVoltage5
    {
        ObjAdapteeVoltage220 oav220 = new ObjAdapteeVoltage220();
        public int GetVoltage5()
        {
            int v =oav220.GetVoltage220();
            return v / 44;
        }
    }
}
