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

namespace WPF_DependencyProperty
{
    /// <summary>
    /// Interaction logic for DependencyExam.xaml
    /// </summary>
    public partial class DependencyExam : UserControl
    {
        // DependencyProperty Register()
        // 1. 등록하려는 종속성의 이름
        // 2. 종속성 속성의 데이터 형식
        // 3. 종속성 속성을 소유하는 클래스
        // 4. null or PropertyMetaData(초기값) or PropertyMetaData(초기값, 콜백함수)
        public static DependencyProperty SomeStringProperty = DependencyProperty.Register("SomeString", typeof(string), typeof(DependencyExam), new PropertyMetadata(null, OnSomeStringChanged));

        private static void OnSomeStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is DependencyExam control)
            {
                control.BorderTitle.Text = (string)e.NewValue;
            }
        }

        public string SomeString
        {
            get { return (string)GetValue(SomeStringProperty); }
            set { SetValue(SomeStringProperty, value); }
        }

        public DependencyExam()
        {
            InitializeComponent();
        }
    }
}
