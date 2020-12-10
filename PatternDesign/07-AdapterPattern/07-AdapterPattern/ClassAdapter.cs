using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//类适配器
//适配器 继承已有的220v类，可以调用其方法
// 适配器 继承5v的接口，具体实现5v的方法，通过调用220v的方法转换实现
namespace _07_AdapterPattern
{
//本案例尝试使用手机适配器将家用电器的电压从220V适配至5V。
    /// <summary>
    /// 被适配的类，已经实现了获得220v电压
    /// </summary>
    class  AdapteeVoltage220
    {
        public int GetVoltage220()
        { return 220; }
    }
    /// <summary>
    /// 接口：使用5v电压
    /// </summary>
    interface IVoltage5
    {
        int GetVoltage5();
    }
    /// <summary>
    /// 适配类，继承220v被适配类和5v的接口完成转化
    /// </summary>
    class AdapterVoltage:AdapteeVoltage220,IVoltage5
    {
        public int GetVoltage5()
        {
            int v = GetVoltage220();
            return v / 44;
        }
    }

    //客户端希望调用GetVoltage5方法（获得5v电压），但是我们现有的类（是220v电压）并没有GetVoltage5方法，
    //它只有GetVoltage220方法（它自己的方法获得220v），
    //然而适配器类（适配器必须实现5v接口和继承220v类）可以提供这样的转换，
    //它提供了GetVoltage5方法的实现（其内部调用的是GetVoltage220，因为适配器只是一个外壳，包装这GetVoltage220，
    //并向外界提供GetVoltage5的外观）供客户端使用。

}
