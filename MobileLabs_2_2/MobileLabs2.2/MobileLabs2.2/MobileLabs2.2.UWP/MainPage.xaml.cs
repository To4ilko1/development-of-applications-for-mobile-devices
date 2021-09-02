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

    public sealed partial class MainPage
    {
        internal ObservableCollection<Student> allStudents { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            allStudents = new ObservableCollection<Student>();

            allStudents.Add(new Student
            {
                Id = 0,
                Fio = "Петров Петр Петрович",
                Mark1 = "4",
                Mark2 = "5",
                Mark3 = "3",
            });
            allStudents.Add(new Student
            {
                Id = 1,
                Fio = "Иванов Иван Иванович",
                Mark1 = "3",
                Mark2 = "3",
                Mark3 = "3",
            });
            allStudents.Add(new Student
            {
                Id = 2,
                Fio = "Сидоров Содор Сидорович",
                Mark1 = "5",
                Mark2 = "5",
                Mark3 = "3",
            });
            frx.Navigate(typeof(Page1), allStudents);
        }
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var t = (ListBoxItem)e.AddedItems[0];
            if (t.Name == "p1")
            {
                frx.Navigate(typeof(Page1), allStudents);
            }
            if (t.Name == "p2")
            {
                frx.Navigate(typeof(Page2), allStudents);
            }

        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            if (frx.CanGoBack)
                frx.GoBack();
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            if (frx.CanGoForward)
                frx.GoForward();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            spw1.IsPaneOpen = !spw1.IsPaneOpen;
        }
    }
}

