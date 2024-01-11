using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwallowDeepCopy
{
    // C++에서는 함수의 시그니처에 포인터나 참조를 전달하지 않으면 기본적으로 값이 전달됨.
    // C#에서는 기본 자료형(int, double, float, bool, char, enum, unint 등) 같은 경우엔 값이 복사됨.
    // 하지만, string, object, DateTime 등은 기본적으로 Reference Type으로 주소값을 전달함.
    // 이에 따라 얕은 복사와 깊은 복사 개념이 존재함.
    public class Copy
    {
        public Copy()
        {
            CMD_SwallowCopy = new RelayCommand(PerformCMD_SwallowCopy);
            CMD_DeepCopy = new RelayCommand(PerformCMD_DeepCopy);
        }
        public class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; }
        }

        public class Address
        {
            public string City { get; set; }
        }

        public ICommand CMD_SwallowCopy { get; set; }
        private void PerformCMD_SwallowCopy(object obj)
        {
            Person originalPerson = new Person { Name = "John", Address = new Address { City = "New York" } };
            Person swallowCopyPerson = originalPerson;

            swallowCopyPerson.Address.City = "Los Angeles";
            Debug.WriteLine("얕은 복사 원본 : " + originalPerson.Address.City);
            Debug.WriteLine("얕은 복사 복사본 : " + originalPerson.Address.City);
        }

        [Serializable]
        public class People : ICloneable
        {
            public string Name { get; set; }
            public National national { get; set; }

            public object Clone()
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Seek(0, SeekOrigin.Begin);
                    return formatter.Deserialize(stream);
                }
            }
        }

        [Serializable]
        public class National
        {
            public string national { get; set; }
        }

        public ICommand CMD_DeepCopy { get; set; }

        private void PerformCMD_DeepCopy(object obj)
        {
            People originalPerson = new People { Name = "엽상", national = new National { national = "미국" } };
            People deepCopyPerson = (People)originalPerson.Clone();

            deepCopyPerson.national.national = "한국";
            Debug.WriteLine("깊은 복사 원본 : " + originalPerson.national.national);
            Debug.WriteLine("깊은 복사 복사본 : " + deepCopyPerson.national.national);
        }
    }
}
