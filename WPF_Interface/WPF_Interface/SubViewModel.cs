using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Interface
{
    public class SubViewModel : Interface
    {
        public void Add_Num(int num)
        {
            num += 1;
            Console_Print(num);
        }

        public void Console_Print(int num = 0)
        {
            Console.WriteLine("Interface를 상속받은 SubViewModel 실행 : " + num);
        }
    }
}
