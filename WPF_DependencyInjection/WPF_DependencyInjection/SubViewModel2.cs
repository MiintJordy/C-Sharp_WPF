using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_DependencyInjection
{
    public class SubViewModel2
    {
        public void Console_Print()
        {
            Console.WriteLine("SubViewModel2의 Console_Print 함수");
        }

        public void Console_Print(int num)
        {
            Console.WriteLine("SubViewModel2의 Console_Print 함수 : " + num);
        }
    }
}
