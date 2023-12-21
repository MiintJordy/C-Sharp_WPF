using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Interface
{
    class MainViewModel
    {
        private readonly Interface _interface;
        private readonly Interface _interface2;
        public MainViewModel(Interface _interface, Interface _interface2)
        {
            this._interface = _interface;
            this._interface2 = _interface2;
        }

        public ICommand Btn_Click { get => new RelayCommand(Btn_Click_Func); }

        private void Btn_Click_Func(object obj)
        {
            _interface.Console_Print();
            _interface2.Console_Print();
            _interface.Add_Num(1);
            _interface2.Add_Num(10);
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
