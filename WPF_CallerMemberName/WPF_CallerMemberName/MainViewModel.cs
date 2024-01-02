using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_CallerMemberName
{
    // CallerMemberName이 있는 경우
    class MainViewModel : INotifyPropertyChanged
    {
        private string _message;
        public string Message
        {
            get => _message;
            set 
            { if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ICommand Btn_Click { get => new RelayCommand(Btn_Click_Func); }
        // 버튼 클릭 이벤트 핸들러
        private void Btn_Click_Func(object sender)
        {
            Message = "속성이 변경되었습니다.";
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            Console.WriteLine("CanExeCute Param : " + parameter);
            Console.WriteLine("_canExecute : " + _canExecute);
            return _canExecute == null || _canExecute(parameter);
        }


        public void Execute(object parameter)
        {
            Console.WriteLine("ExeCute Param : " + parameter);
            Console.WriteLine("_execute : " + _execute);
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
