using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_DependencyInjection
{
    class MainViewModel
    {
        private readonly SubViewModel _subviewmodel;
        private readonly SubViewModel2 _subviewmodel2;
        public MainViewModel(SubViewModel _subviewmodel, SubViewModel2 _subviewmodel2)
        {
            this._subviewmodel = _subviewmodel;
            this._subviewmodel2 = _subviewmodel2;
        }

        public ICommand Btn_Click { get => new RelayCommand(Btn_Click_Func); }
        
        private void Btn_Click_Func(object obj)
        {
            _subviewmodel.Console_Print();
            _subviewmodel2.Console_Print();
            _subviewmodel.Console_Print(3);
            _subviewmodel2.Console_Print(5);
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
