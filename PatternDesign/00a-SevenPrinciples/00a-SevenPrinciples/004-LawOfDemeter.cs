using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _00a_SevenPrinciples
{
    //4.    迪米特法则（Law Of Demeter）
    //      定义：迪米特法则又叫最少知道原则，即：一个对象应该对其他对象保持最少的了解。
    //            如果两个类不必彼此直接通信，那么这两个类就不应当发生直接的相互作用。如果其中一个类需要调用另一个类的某一个方法的话，
    //            可以通过第三者转发这个调用。简单定义为只与直接的朋友通信。
    //            首先来解释一下什么是直接的朋友：每个对象都会与其他对象有耦合关系，只要两个对象之间有耦合关系，
    //            我们就说这两个对象之间是朋友关系。耦合的方式很多，依赖、关联、组合、聚合等。其中，
    //            我们称出现成员变量、方法参数、方法返回值中的类为直接的朋友，而出现在局部变量中的类则不是直接的朋友。
    //            也就是说，陌生的类最好不要作为局部变量的形式出现在类的内部。
    //     问题由来：类与类之间的关系越密切，耦合度越大，当一个类发生改变时，对另一个类的影响也越大。
    //               最早是在1987年由美国Northeastern University的Ian Holland提出。
    //               通俗的来讲，就是一个类对自己依赖的类知道的越少越好。也就是说，对于被依赖的类来说，
    //               无论逻辑多么复杂，都尽量地的将逻辑封装在类的内部，对外除了提供的public方法，不对外泄漏任何信息。
    //               迪米特法则还有一个更简单的定义：只与直接的朋友通信。 
    //     解决方法：尽量降低类与类之间的耦合。 自从我们接触编程开始，就知道了软件编程的总的原则：低耦合，高内聚。
    //               无论是面向过程编程还是面向对象编程，只有使各个模块之间的耦合尽量的低，才能提高代码的复用率。 
    //               迪米特法则的初衷是降低类之间的耦合，由于每个类都减少了不必要的依赖，因此的确可以降低耦合关系。
    //               但是凡事都有度，虽然可以避免与非直接的类通信，但是要通信，必然会通过一个“中介”来发生联系。
    //               故过分的使用迪米特原则，会产生大量这样的中介和传递类，导致系统复杂度变大。所以在采用迪米特法则时要反复权衡，
    //               既做到结构清晰，又要高内聚低耦合。 


    /// <summary>
    /// 学生 包含两个公共属性、一个公有 Learn() 方法和两个私有方法（Lesson()、Homework()）
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public void Learn()
        {
            this.Lesson();
            this.Homework();
        }
        /// <summary>
        /// 听课
        /// 内部方法，尽量减少公开的方法和属性
        /// </summary>
        private void Lesson()
        {
            Console.WriteLine(" {0} Lesson {1} ", this.GetType().Name, this.StudentName);
        }
        /// <summary>
        /// 写作业
        /// </summary>
        private void Homework()
        {
            Console.WriteLine(" {0} Homework {1} ", this.GetType().Name, this.StudentName);
        }
    }
    /// <summary>
    /// 班级 只与直接的朋友 Student 通信，一个类只和一个朋友说话。
    /// </summary>
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public List<Student> StudentList { get; set; }

        public void Manage()
        {
            foreach (Student s in this.StudentList)
            {
                s.Learn();
            }
        }
    }
    /// <summary>
    /// 学校 同理，一个类只和一个朋友说话，这里只与班级Class通信。
    /// </summary>
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<Class> ClassList { get; set; }

        public void Command()
        {
            Console.WriteLine("Command {0}", this.GetType().Name);
            foreach (Class c in this.ClassList)
            {
                c.Manage();//班级自己管理学生 1
                Console.WriteLine(" {0}Manage {1} ", c.GetType().Name, c.ClassName);
            }
        }
    }

}
//简单的定义：只与直接的朋友通信。
//直接的朋友：每个对象都会与其他对象有耦合关系，只要两个对象之间有耦合关系，
//我们就说这两个对象之间是朋友关系。耦合的方式很多，依赖、关联、组合、聚合等。
//其中，我们称出现成员变量、方法参数、方法返回值中的类为直接的朋友，
//而出现在局部变量中的类则不是直接的朋友。也就是说，陌生的类最好不要作为局部变量的形式出现在类的内部。
