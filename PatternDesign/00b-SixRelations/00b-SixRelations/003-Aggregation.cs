using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00b_SixRelations
{
   //聚合关系(aggregation)
   //概念: 聚合关系是关联关系的一种，耦合度强于关联，他们的代码表现是相同的，
   //      仅仅是在语义上有所区别：关联关系的对象间是相互独立的，而聚合关系的对象之间存在着包容关系，他们之间是“整体-个体”的相互关系。

    //聚合关系是强的关联关系.它有包含之意,关联关系的类是在一个平行位置,这是与关联关系的区别.

    //人这个类包含 车的类 房子的类，因此 车，房子这两个类聚合到人这个类中
    public class Car
    {

        private String type="奔驰";

        public String getType()
        {

            return this.type;

        }

    }

    public class House
    {

        private String address="北京";

        public String getAddress()
        {

            return this.address;

        }

    }

    public class Man
    {

        Car car;

        House house;

        //  聚合关系中作为成员变量的类一般使用set方法赋值   

        public void setCar(Car car)
        {

            this.car = car;

        }

        public void setHouse(House house)
        {

            this.house = house;

        }



        public void driver(){   

        Console.WriteLine("车的型号："+car.getType());   

    }

        public void sleep(){   

        Console.WriteLine("我在房子里睡觉："+house.getAddress());   

    }

    }


}
