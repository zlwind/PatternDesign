using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00a_SevenPrinciples
{
    //6.    接口隔离原则（Interface Segregation Principle）
    //      定义：客户端不应该依赖它不需要的接口；一个类对另一个类的依赖应该建立在最小的接口上。 
    //      问题由来：类A通过接口I依赖类B，类C通过接口I依赖类D，如果接口I对于类A和类B来说不是最小接口，则类B和类D必须去实现他们不需要的方法 
    //      解决方法：1、 使用委托分离接口。
    //                2、 使用多重继承分离接口。
    //                3.将臃肿的接口I拆分为独立的几个接口，类A和类C分别与他们需要的接口建立依赖关系。也就是采用接口隔离原则。 

    //     小结：我们在代码编写过程中，运用接口隔离原则，一定要适度，
    //           接口设计的过大或过小都不好。对接口进行细化可以提高程序设计灵活性是不挣的事实，
    //           但是如果过小，则会造成接口数量过多，使设计复杂化。所以一定要适度。设计接口的时候，
    //           只有多花些时间去思考和筹划，就能准确地实践这一原则。 

    //删除订单接口
    public interface IProductOrder
    {
        //订单下发操作
        void PlantProduct(object order);

        //订单撤排操作
        void CancelProduct(object order);

        //订单冻结操作
        void Hold(object order);

        //订单删除操作
        void Delete(object order);

        //订单导入操作
        void Import();

        //订单导出操作
        void Export();
    }

    //销售订单接口
    public interface ISaleOrder
    {
        //订单申请操作
        void Apply(object order);

        //订单审核操作
        void Approve(object order);

        //订单结束操作
        void End(object order);
    }
    //生产订单实现类
    public class ProduceOrder : IProductOrder
    {
        public void PlantProduct(object order)
        {
            Console.WriteLine("订单下发排产");
        }

        public void CancelProduct(object order)
        {
            Console.WriteLine("订单撤排");
        }

        public void Hold(object order)
        {
            Console.WriteLine("订单冻结");
        }

        public void Delete(object order)
        {
            Console.WriteLine("订单删除");
        }

        public void Import()
        {
            Console.WriteLine("订单导入");
        }

        public void Export()
        {
            Console.WriteLine("订单导出");
        }
    }

    //销售订单实现类
    public class SaleOrder : ISaleOrder
    {

        public void Apply(object order)
        {
            Console.WriteLine("订单申请");
        }

        public void Approve(object order)
        {
            Console.WriteLine("订单审核处理");
        }

        public void End(object order)
        {
            Console.WriteLine("订单结束");
        }
    }
    //如果需要增加订单操作，只需要在对应的接口和实现类上面修改即可，这样就不存在依赖不需要接口的情况。通过这种设计，
    //降低了单个接口的复杂度，使得接口的“内聚性”更高，“耦合性”更低。由此可以看出接口隔离原则的必要性。
}
