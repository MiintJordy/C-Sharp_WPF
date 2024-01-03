using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Delegate
{
    delegate void ExampleDelegate(int result);
    class MainViewModel
    {
        public ICommand Btn_Action { get => new RelayCommand(Btn_Action_Func); }

        //private void Btn_Action_Func(object obj)
        //{
        //    int num1 = 1;
        //    int num2 = 5;
        //    Action<int, int> action = For_Action;
        //    action(num1, num2);
        //}

        //private void For_Action(int x, int y)
        //{
        //    int result = x + y;
        //    Console.WriteLine("Use Action : " + result);
        //}

        // lambda
        private void Btn_Action_Func(object obj)
        {
            int num1 = 1;
            int num2 = 5;
            // 어떠한 값을 반환하지 않는 것
            Action<int, int> action = (x, y) =>
            {
                int result = x + y;
                Console.WriteLine("use action : " + result);
            };
            action(num1, num2);
        }

        public ICommand Btn_Func { get => new RelayCommand(Btn_Func_Func); }

        //private void Btn_Func_Func(object obj)
        //{
        //    int num1 = 10;
        //    int num2 = 50;
        //    Func<int, int, int> func = Add_Func;
        //    int result = func(num1, num2);
        //    Console_Print("Use Func", result);
        //}

        // Lambda
        private void Btn_Func_Func(object obj)
        {
            int num1 = 10;
            int num2 = 50;
            // int형 2개를 활용해서 int형의 결과값을 반환하는 것
            Func<int, int, int> func = (x, y) => x + y;

            int result = func(num1, num2);
            Console_Print("Use Func", result);
        }

        public ICommand Btn_Delegate { get => new RelayCommand(Btn_Delegate_Func); }

        //delegate void ExampleDelegate(string divide, int result); 로 수정해야 실행할 수 있음.
        //private void Btn_Delegate_Func(object obj)
        //{
        //    int num1 = 100;
        //    int num2 = 500;
        //    ExampleDelegate ed = Console_Print;
        //    int sum = Add_Func(num1, num2);
        //    ed("Use Delegate", sum);
        //}

        // lambda
        private void Btn_Delegate_Func(object obj)
        {
            ExampleDelegate ed = result => Console.WriteLine($"Use Delegate : {result}");

            int num1 = 100;
            int num2 = 500;
            int sum = num1 + num2;
            ed(sum);
        }


        private int number = 0;
        private List<int> numbers = new List<int> { 1, 3, 5, 7, 9, 10 };

        // 조건을 나타내는 델리게이트로 true와 false를 반환
        Predicate<int> Even = x => x % 2 == 0;
        public int Numbers
        {
            get => number;
            set => number = value;
        }

        public ICommand Btn_Predicate { get => new RelayCommand(Btn_Predicate_Func); }
        private void Btn_Predicate_Func(object obj)
        {
            foreach (int num in numbers)
            {
                if (Even(num))
                {
                    Numbers = num;
                    Console.WriteLine(number);
                }
            }
        }

        private int Add_Func(int x, int y)
        {
            return x + y;
        }
        private void Console_Print(string divide, int result)
        {
            Console.WriteLine(divide + " : " + result);
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
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
