using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MobileLabs2._2.UWP
{
    //Вариант №14
    //Ведомость абитуриентов, сдавших вступительные экзамены в университет, содержит:
    //Ф.И.О.абитуриента, оценки.Определить средний балл по университету и вывести список
    //абитуриентов, средний балл которых выше среднего балла по университету.Первыми в списке
    //должны идти студенты, сдавшие все экзамены на 5.
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTime sourceTime = (DateTime)value;
                return sourceTime.ToString("MM/dd/yyyy HH:mm:ss");
            }
            catch (Exception)
            {
                return "Дата не выбрана!";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset resultTime = DateTime.Parse(value.ToString());
            return resultTime;
        }
    }
    public sealed partial class Page1 : Page
    {
        internal ObservableCollection<Student> allStudents { get; set; }
        public Page1()
        {
            this.InitializeComponent();
            allStudents = new ObservableCollection<Student>();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                var p = (ObservableCollection<Student>)e.Parameter;
                allStudents = p;
                var n = p.Count;
            }
        }
    }
}
