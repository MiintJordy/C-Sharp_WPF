using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Enum
{
    public enum WeekDay
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    
    public static class WeekDayEnumValues
    {
        public static Array Values => Enum.GetValues(typeof(WeekDay));
        public static int GetDayNumber(WeekDay day)
        {
            return (int)day;
        }
    }
    class MainViewModel : INotifyPropertyChanged
    {
        private string displayText;
        public string DisplayText { get => displayText; set { displayText = value; OnPropertyChanged(); } }

        private string GetKoreanDay(WeekDay num)
        {
            switch ((int)num)
            {
                case 1:
                    return "월요일";
                case 2:
                    return "화요일";
                case 3:
                    return "수요일";
                case 4:
                    return "목요일";
                case 5:
                    return "금요일";
                case 6:
                    return "토요일";
                case 7:
                    return "일요일";
                default:
                    return string.Empty;
            }
        }

        private int comboSelect;
        public WeekDay ComboSelect
        {
            get { return (WeekDay)comboSelect; }
            set { int dayValue = WeekDayEnumValues.GetDayNumber(value); comboSelect = dayValue; }
        }

        public ICommand Btn_Click { get => new RelayCommand(Btn_Click_Func); }

        private void Btn_Click_Func(object obj)
        {
            DisplayText = GetKoreanDay(ComboSelect);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
