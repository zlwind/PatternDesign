using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21_InterpreterPattern_1
{
     /// <summary>
    /// Interpreter模式的应用场合是Interpreter模式应用中的难点，只有满足“业务规则频繁变化，且类似的模式不断重复出现，并且容易抽象为语法规则的问题”才适合使用Interpreter模式。
    ///  1、当一个语言需要解释执行，并可以将该语言中的句子表示为一个抽象语法树的时候，可以考虑使用解释器模式（如XML文档解释、正则表达式等领域）
    ///  2、一些重复出现的问题可以用一种简单的语言来进行表达。
    ///  3、一个语言的文法较为简单.
    ///  4、当执行效率不是关键和主要关心的问题时可考虑解释器模式（注：高效的解释器通常不是通过直接解释抽象语法树来实现的，而是需要将它们转换成其他形式，使用解释器模式的执行效率并不高。）
    /// </summary>
   

    /// <summary>
    /// 上下文
    /// </summary>
    public class Context
    {
        private string _Word = null;
        public Context(string word)
        {
            this._Word = word;
        }

        public void Set(string newWord)
        {
            this._Word = newWord;
        }

        public string Get()
        {
            return this._Word;
        }
    }

    /// <summary>
    /// 抽象解释器
    /// </summary>
    public abstract class PeopleInterpreter
    {
        public abstract void Conversion(Context context);
    }
    /// <summary>
    /// 中国人业务
    /// </summary>
    public class Chinese : PeopleInterpreter
    {
        private static Dictionary<char, string> _Dictionary = new Dictionary<char, string>();
        /// <summary>
        /// 中国人自己解释规则
        /// </summary>
        static Chinese()
        {
            _Dictionary.Add('c', "中国人");
            _Dictionary.Add('h', "用");
            _Dictionary.Add('i', "筷子吃饭");
        }
        /// <summary>
        /// 中国人解释输入的文案
        /// 然后返回解释的文案
        /// </summary>
        /// <param name="context"></param>
        public override void Conversion(Context context)
        {
            Console.WriteLine(this.GetType().ToString() + "业务");
            string text = context.Get();
            if (string.IsNullOrEmpty(text))
                return;
            List<string> numberList = new List<string>();
            foreach (var item in text.ToLower().ToArray())
            {
                if (_Dictionary.ContainsKey(item))
                {
                    numberList.Add(_Dictionary[item]);
                }
                else
                {
                    numberList.Add(item.ToString());
                }
            }
            context.Set(string.Concat(numberList));
        }
    }
    /// <summary>
    /// 美国人业务
    /// </summary>
    public class Usa : PeopleInterpreter
    {
        private static Dictionary<char, string> _Dictionary = new Dictionary<char, string>();
        /// <summary>
        /// 美国人自己解释规则
        /// </summary>
        static Usa()
        {
            _Dictionary.Add('u', "美国人");
            _Dictionary.Add('s', "用刀叉");
            _Dictionary.Add('a', "吃饭,");
        }

        /// <summary>
        /// 美国人解释输入的文案
        /// 然后返回解释的文案
        /// </summary>
        /// <param name="context"></param>
        public override void Conversion(Context context)
        {
            Console.WriteLine(this.GetType().ToString() + "业务");
            string text = context.Get();
            if (string.IsNullOrEmpty(text))
                return;
            List<string> numberList = new List<string>();
            foreach (var item in text.ToLower().ToArray())
            {
                if (_Dictionary.ContainsKey(item))
                {
                    numberList.Add(_Dictionary[item]);
                }
                else
                {
                    numberList.Add(item.ToString());
                }
            }
            context.Set(string.Concat(numberList));
        }
    }
}
