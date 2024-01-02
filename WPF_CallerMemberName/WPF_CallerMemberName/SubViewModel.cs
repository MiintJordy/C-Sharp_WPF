using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CallerMemberName
{
    // CallerMemberName이 없는 경우
    class SubViewModel : INotifyPropertyChanged
    {
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                if(_message != value)
                {
                    _message = value;
                    // [CallerMemberName]이 있을 때, OnPropertyChanged();
                    // 즉, 속성 이름을 자동으로 첨부하는 역할임.
                    OnPropertyChanged(Message);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // 이 부분의 시그니처에 [CallerMemberName] 이 없다면, 위 22번 코드에서 차이점이 생김.
        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
