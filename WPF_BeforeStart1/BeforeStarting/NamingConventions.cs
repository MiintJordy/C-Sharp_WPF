using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeforeStarting
{
    public class NamingConventions
    {
        // C#에서는 접근제한자를 통해 Public과 Private 필드를 따로 관리함.

        // private 필드의 변수명은 _ 언더바, 카멜케이스를 따름.
        private int _backColor;
        private string _deviceName;

        // public의 변수명은 _를 없애고 파스칼케이스를 따름.
        public int EmergencyAlarm;
        public bool RunSequence;

        // 메서드는 기본적으로 파스칼 케이스를 따름.
        private void PerformCMD_Setting()
        {

        }
        public void PerformCMD_OnClick()
        {

        }
    }

    public class Person
    {
        public string Name = "";
    }
    public class PatternMatchingOperator
    {
        public PatternMatchingOperator()
        {
            CMD_TypeIs = new RelayCommand(PerformCMD_TypeIs);
            CMD_TypeAs = new RelayCommand(PerformCMD_TypeAs);
        }
        public ICommand CMD_TypeIs { get; set; }
        private string TypeIs = "Hello";

        private void PerformCMD_TypeIs(object obj)
        {
            // is 연산자를 사용하여 객체가 특정 타입인지 확인할 수 있음.
            if (TypeIs is string)
            {
                Type type = TypeIs.GetType();
                Debug.WriteLine("TypeIs : " + type);
            }
            else
            {
                Debug.WriteLine("TypeIs Fail : null");
            }
        }

        public ICommand CMD_TypeAs { get; set; }
        private void PerformCMD_TypeAs(object obj)
        {
            object test = new Person { Name = "John" };

            // as 연산자를 사용하여 객체를 특정 타입으로 캐스팅할 수 있으며,
            // 캐스팅이 실패하면 null을 반환함.
            Person person = test as Person;

            if (person != null)
            {
                Type type = person.GetType();
                Debug.WriteLine("test Type : " + type);
            }
            else
            {
                Debug.WriteLine("Conversion failed");
            }
        }
    }
}
