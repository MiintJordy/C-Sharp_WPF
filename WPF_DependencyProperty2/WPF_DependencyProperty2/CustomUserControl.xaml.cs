using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DependencyProperty2
{
    /// <summary>
    /// Interaction logic for CustomUserControl.xaml
    /// </summary>
    public partial class CustomUserControl : UserControl
    {
        public CustomUserControl()
        {
            InitializeComponent();
        }

        // DependencyProperty 정의
        // 매개 변수에 대한 설명
        // 1: 등록하려는 종속성의 이름
        // 2: 종속성 속성의 데이터 형식을 지정
        // 3: 종속성 속성을 소유하는 클래스
        // 4: (초기값 설정(null로 지정해도 무관), 콜백함수(지정하지 않아도 무관))
        // ★ 종속성이란?
        // 속성 값이 변경될 때, 시스템에서 자동으로 업데이트되도록 하는 시스템(TextBox의 Text는 종속성 속성)
        public static readonly DependencyProperty CustomTextProperty =
            DependencyProperty.Register("CustomText", typeof(string), typeof(CustomUserControl), new PropertyMetadata("Default Text"));
        // ICommand와 비교하였을 때, ICommand에 변수를 관리하는 Property를 등록하여 ICommand를 호출하여 쓰지만,
        // DependencyProperty에 등록하고 등록한 요소를 호출하여 씀.
        // 이 차이는 접근하는 요소가 다르기 때문인데,
        // ICommand는 변수를 관리하는 Property를 ICommand(대리자)로 불러야 변수에 접근할 수 있음.
        // DependencyProperty는 변수처럼 값을 담고있는 것이 아니라 해당 UI 요소에(예: TextBox의 Text) 직접 접근하여 GetValue, SetValue로 값을 가져오거나 수정하는 역할만을 수행함.


        // CustomText 속성 정의
        public string CustomText
        {
            get { return (string)GetValue(CustomTextProperty); }
            set { SetValue(CustomTextProperty, value);}
        }
    }
}
