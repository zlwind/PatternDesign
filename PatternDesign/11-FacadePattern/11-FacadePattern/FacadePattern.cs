using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//场景：
/// 以学生选课系统为例子演示外观模式的使用
/// 学生选课模块包括功能有：
/// 验证选课的人数是否已满
/// 通知用户课程选择成功与否
namespace _11_FacadePattern
{
    /// <summary>
    /// 选课外观类
    /// </summary>
    public class RegistCourseFacade
    {
        private RegistCourse registerCourse = new RegistCourse();
        private NotifyStudent notifyStu = new NotifyStudent();

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }

            return notifyStu.Notify(studentName);
        }
    }

    #region 子系统
    /// <summary>
    /// 选课子系统一：注册课程
    /// </summary>
    internal class RegistCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }
    /// <summary>
    /// 选课子系统之二：课程注册通知
    /// </summary>
    internal class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }
    #endregion
}
