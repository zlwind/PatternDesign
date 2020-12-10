using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19_MediatorPattern
{
   //场景：在现实生活中，两个人打牌，如果某个人赢了会影响到对方的状态。标准中介者模式有抽象中介者角色，
   //      具体中介者角色、抽象同事类和具体同事类四个角色，其中打牌的人都是具体的同事类的对象，算账的平台是中介者对象。

    //抽象玩家类
    //抽象同事类（Colleague）：通常为抽象类，主要约束同事对象的类型，并实现一些具体同事类之间的公共功能，
    public abstract class AbstractCardPlayer
    {
        public int MoneyCount { get; set; }
        public AbstractCardPlayer()
        {
            this.MoneyCount = 0;
        }
        public abstract void ChangeCount(int count, AbstractMediator mediator);//持有一个中介者 具体同事类之间的公共功能
    }
    //玩家A类
    //具体同事类（ConcreteColleague）：实现自己的业务，需要与其他同事通信时候，就与持有的中介者通信，中介者会负责与其他同事类交互。
    public class PlayerA : AbstractCardPlayer
    {
        //通过中介者来算账，不用直接找输家了
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.AWin(count);
        }
    }
    //玩家B类
    //具体同事类（ConcreteColleague）：实现自己的业务，需要与其他同事通信时候，就与持有的中介者通信，中介者会负责与其他同事类交互。
    public class PlayerB : AbstractCardPlayer
    {
        public override void ChangeCount(int count, AbstractMediator mediator)
        {
            mediator.BWin(count);
        }
    }
    //抽象中介者
    //抽象中介者角色（Mediator）：在里面定义各个同事之间交互需要的方法，可以是公共的通信方法，也可以是小范围的交互方法。
    public abstract class AbstractMediator
    {
        //中介者必须知道所有同事
        public AbstractCardPlayer A;
        public AbstractCardPlayer B;
        public AbstractMediator(AbstractCardPlayer a, AbstractCardPlayer b)
        {
            A = a;
            B = b;
        }
        public abstract void AWin(int count);//定义各个同事之间交互需要的方法
        public abstract void BWin(int count);//定义各个同事之间交互需要的方法
    }
    //具体中介者
    //具体中介者角色（ConcreteMediator）：它需要了解并维护各个同事对象，并负责具体的协调各同事对象的交互关系。
    public class Mediator : AbstractMediator
    {
        public Mediator(AbstractCardPlayer a, AbstractCardPlayer b) : base(a, b) { }
        public override void AWin(int count)
        {
            A.MoneyCount += count;
            B.MoneyCount -= count;
        }
        public override void BWin(int count)
        {
            A.MoneyCount -= count;
            B.MoneyCount += count;
        }
    }
}
//我们可以看到中介者模式降低了各个同事对象的耦合，同事类之间不用直接通信，直接找中介者就行了，但是中介者模式并没有降低业务的复杂度，中介者将同事类间的复杂交互逻辑从业务代码中转移到了中介者类的内部。标准中介者模式有抽象中介者角色，具体中介者角色、抽象同事类和具体同事类四个角色，
//在实际开发中有时候没必要对具体中介者角色和具体用户角色进行抽象（如联合国作为一个中介者，
//负责调停各个国家纠纷，但是没必要把单独的联合国抽象成一个抽象中介者类；上边例子的抽象玩家类和抽象中介者类都是没必要的），
//我们可以根据具体的情况来来选择是否使用抽象中介者和抽象用户角色。