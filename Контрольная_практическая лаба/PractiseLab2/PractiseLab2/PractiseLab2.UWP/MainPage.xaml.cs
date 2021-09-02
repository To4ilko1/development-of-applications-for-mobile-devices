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

namespace PractiseLab2.UWP
{
    public sealed partial class MainPage
    {
        public ObservableCollection<Student> allStudents { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            allStudents = new ObservableCollection<Student>();

            allStudents.Add(new Student
            {
                Id = 0,
                Fio = "Петров Петр Петрович",
                Mark1 = "5",
                Mark2 = "5",
                Mark3 = "5",
                Mark4 = "5",
                Mark5 = "5"
            });
            allStudents.Add(new Student
            {
                Id = 1,
                Fio = "Иванов Иван Иванович",
                Mark1 = "3",
                Mark2 = "5",
                Mark3 = "5",
                Mark4 = "5",
                Mark5 = "5"
            });
            allStudents.Add(new Student
            {
                Id = 1,
                Fio = "Точилов Сергей Александрович",
                Mark1 = "3",
                Mark2 = "3",
                Mark3 = "5",
                Mark4 = "5",
                Mark5 = "5"
            });
            allStudents.Add(new Student
            {
                Id = 2,
                Fio = "Сидоров Содор Сидорович",
                Mark1 = "2",
                Mark2 = "5",
                Mark3 = "5",
                Mark4 = "5",
                Mark5 = "5"
            });
        }

        private void FilterByMark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string mar = FilterByMark.SelectedValue.ToString();
            //if (mar == "2") 
            //{
            //    var y = allStudents.Where(g => (g.Mark1 == FilterByMark.SelectedValue.ToString()) || (g.Mark2 == FilterByMark.SelectedValue.ToString()) || (g.Mark3 == FilterByMark.SelectedValue.ToString()) || (g.Mark4 == FilterByMark.SelectedValue.ToString()) || (g.Mark5 == FilterByMark.SelectedValue.ToString()));

            //}
            
            var p = allStudents.Where(g => (g.Mark1 == FilterByMark.SelectedValue.ToString())||(g.Mark2 == FilterByMark.SelectedValue.ToString()) || (g.Mark3 == FilterByMark.SelectedValue.ToString()) || (g.Mark4 == FilterByMark.SelectedValue.ToString()) || (g.Mark5 == FilterByMark.SelectedValue.ToString()));
            ListStudent4.ItemsSource = p;
        }


        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            int n = (from i in allStudents select i.Id).Last() + 1;
            var st = new Student
            {
                Id = n,
                Mark1 = AddMark1Text.SelectedValue.ToString(),
                Mark2 = AddMark2Text.SelectedValue.ToString(),
                Mark3 = AddMark3Text.SelectedValue.ToString(),
                Mark4 = AddMark4Text.SelectedValue.ToString(),
                Mark5 = AddMark5Text.SelectedValue.ToString(),
                Fio = AddFioText.Text,
            };
            allStudents.Add(st);
        }
        public class Student
        {
            public int Id { get; set; }
            public string Fio { get; set; }
            public string Mark1 { get; set; }
            public string Mark2 { get; set; }
            public string Mark3 { get; set; }
            public string Mark4 { get; set; }
            public string Mark5 { get; set; }
        }
    }
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
}
