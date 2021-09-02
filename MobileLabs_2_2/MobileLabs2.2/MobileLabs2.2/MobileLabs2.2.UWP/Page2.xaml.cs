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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MobileLabs2._2.UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        internal ObservableCollection<Student> allStudents { get; set; }
        public Page2()
        {
            this.InitializeComponent();
            allStudents = new ObservableCollection<Student>();
        }
        private void suggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var term = args.QueryText.ToLower();
            var results = allStudents.Where(i => i.Fio.ToLower().Contains(term)).ToList();
            List<String> destinationStrings = new List<string>();
            foreach (Student f in results)
            {
                destinationStrings.Add(f.Fio);
            }
            suggestBox.ItemsSource = destinationStrings;
            suggestBox.IsSuggestionListOpen = true;
        }
        private void suggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var p = allStudents.Where(g => g.Fio == Convert.ToString(args.SelectedItem));
            ListStudent4.ItemsSource = p;
        }

        private void FilterByMark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = allStudents.Where(g => g.Mark1 == FilterByMark.SelectedValue.ToString() || g.Mark2 == FilterByMark.SelectedValue.ToString() || g.Mark3 == FilterByMark.SelectedValue.ToString());
            ListStudent4.ItemsSource = p;
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
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            int n = (from i in allStudents select i.Id).Last() + 1;
            var st = new Student
            {
                Id = n,
                Mark1 = AddMarkText1.SelectedValue.ToString(),
                Mark2 = AddMarkText2.SelectedValue.ToString(),
                Mark3 = AddMarkText3.SelectedValue.ToString(),
                Fio = AddFioText.Text,
            };
            allStudents.Add(st);
            AddFioText.Text = "";
            AddMarkText1.SelectedIndex = -1;
            AddMarkText2.SelectedIndex = -1;
            AddMarkText3.SelectedIndex = -1;
        }
        private void SrZnach_Click(object sender, RoutedEventArgs e)
        {
            var allStud = allStudents.ToList();
            double sum = 0;
            double srzn = 0;
            foreach (Student f in allStud)
            {
                sum += (Convert.ToDouble(f.Mark1) + Convert.ToDouble(f.Mark2) + Convert.ToDouble(f.Mark3));
            }
            srzn = sum / (allStud.Count() * 3);
            SrZnachText.Text = "Средний балл по университету: " + Convert.ToString(srzn);
            List<Student> kk = new List<Student>();
            foreach (Student f in allStud)
            {
                double srznperson = (Convert.ToDouble(f.Mark1) + Convert.ToDouble(f.Mark2) + Convert.ToDouble(f.Mark3)) / 3;
                if (srznperson>srzn)
                {
                    kk.Add(f);
                }
            }
            Student temp;
            for (int i = 0; i < kk.Count() - 1; i++)
            {
                for (int j = i + 1; j < kk.Count(); j++)
                {
                    double srznperson = (Convert.ToDouble(kk[i].Mark1) + Convert.ToDouble(kk[i].Mark2) + Convert.ToDouble(kk[i].Mark3)) / 3;
                    double srznperson1 = (Convert.ToDouble(kk[j].Mark1) + Convert.ToDouble(kk[j].Mark2) + Convert.ToDouble(kk[j].Mark3)) / 3;
                    if (srznperson < srznperson1)
                    {
                        temp = kk[i];
                        kk[i] = kk[j];
                        kk[j] = temp;
                    }
                }
            }
            ListStudentBally.ItemsSource = kk;
        }
    }
}
