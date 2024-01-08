using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeforeStart2
{
    public class RefAndOut
    {
        public RefAndOut()
        {
            CMD_Ref = new RelayCommand(PerformCMD_Ref);
            CMD_Out = new RelayCommand(PerformCMD_Out);
        }

        private int number = 1;
        public void Increment(ref int num)
        {
            num += 1;
        }
        public ICommand CMD_Ref { get; set; }
        public void PerformCMD_Ref(object obj)
        {
            Increment(ref number);
            Debug.WriteLine("number : " + number.ToString());
        }

        public ICommand CMD_Out { get; set; }

        private bool Perform_Parse(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
        public void PerformCMD_Out(object obj)
        {
            int number;
            if (Perform_Parse("123", out number))
            {
                number += 1;
                Debug.WriteLine("number : " + number.ToString());
            }
        }
    }
}
