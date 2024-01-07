using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeforeStarting
{
    public class RelayCommand : ICommand
    {
        // 명령이 실행될 때, 수행할 액션을 나타내는 private 읽기 전용 필드 선언
        private readonly Action<object> _execute;
        // 명령이 실행 가능한지 여부를 판단하는 조건을 나타내는 private 읽기 전용 필드 선언
        private readonly Predicate<object> _canExecute;

        // RelayCommand 클래스 생성자(매개변수: Action 대리자와 실행가능 여부 판단 대리자)
        // Action<Object> execute : 위 코드의 36번째 줄에 있는 Btn_Click_Func임.
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            // Action이 null이면 throw를 실행
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            // 실행 여부를 판단하는 대리자 할당
            _canExecute = canExecute;
        }

        // 실행 가능 여부 반환
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // 주어진 액션 실행
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // UI 상태의 변경을 나타내는 이벤트가 발생함을 알림.
        public event EventHandler CanExecuteChanged
        {
            // 메서드와 연결된 핸들러를 실행함.
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
