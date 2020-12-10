using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _21_InterpreterPattern_1
{
    class Program1
    {
        public void Client()
        {
            Context context = new Context("usachi");
            List<PeopleInterpreter> interpreterList = new List<PeopleInterpreter>()
                    {
                        new Chinese(),
                        new Usa(),
                    };
            foreach (var item in interpreterList)
            {
                item.Conversion(context);
            }
            Console.WriteLine(context.Get());
            Console.Read();
        }
    }
}
