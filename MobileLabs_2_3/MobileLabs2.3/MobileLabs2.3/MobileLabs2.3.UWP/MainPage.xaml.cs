using System;
using System.Collections.Generic;
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

namespace MobileLabs2._3.UWP
{
    public sealed partial class MainPage
    {
        //Вариант: №14
        //Ведомость абитуриентов, сдавших вступительные экзамены в университет, содержит:
        //Ф.И.О.абитуриента, оценки.Определить средний балл по университету и вывести список
        //абитуриентов, средний балл которых выше среднего балла по университету.Первыми в списке
        //должны идти студенты, сдавшие все экзамены на 5

        //public ObservableCollection<Student> allStudents { get; set; }
        allStudents ast = new allStudents();

        public MainPage()
        {

            this.InitializeComponent();
            try
            {
                ast.openFile();
            }
            catch
            {
                ast.saveFile();
            }
        }
        private void suggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var term = args.QueryText.ToLower();
            var results = ast.getList().Where(i => i.FIO.ToLower().Contains(term)).ToList();
            List<String> destinationStrings = new List<string>();
            foreach (Student f in results)
            {
                destinationStrings.Add(f.FIO);
            }
            suggestBox.ItemsSource = destinationStrings;
            suggestBox.IsSuggestionListOpen = true;
        }

        private void suggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var p = ast.getList().Where(g => g.FIO == Convert.ToString(args.SelectedItem));
            ListStudent4.ItemsSource = p;
        }

        private void tg1_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch tgs = sender as ToggleSwitch;
            if (tgs != null)
            {
                if (tgs.IsOn == true)
                {
                    ListStudent2.ItemTemplate = (DataTemplate)this.Resources["editTemplate"];
                }
                else
                {
                    ListStudent2.ItemTemplate = (DataTemplate)this.Resources["viewTemplate"];
                }
            }

        }

        private void FilterByMark_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = ast.getList().Where(g => g.Mark1 == FilterByMark.SelectedValue.ToString() || g.Mark2 == FilterByMark.SelectedValue.ToString() || g.Mark3 == FilterByMark.SelectedValue.ToString());
            ListStudent4.ItemsSource = p;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            ast.addStudent(AddFioText.Text, AddMarkText1.SelectedValue.ToString(), AddMarkText2.SelectedValue.ToString(), AddMarkText3.SelectedValue.ToString());
            ast.saveFile();
            ListStudent1.ItemsSource = null;
            ListStudent2.ItemsSource = null;
            //ListStudent3.ItemsSource = null;
            var tempList = ast.getList().OrderBy(p => p.FIO);//??

            tempList.ToList().ForEach(q =>
            {
                ast.getList().Remove(q);
                ast.getList().Add(q);
            });
            ListStudent1.ItemsSource = ast.getList();
            ListStudent2.ItemsSource = ast.getList();
            //ListStudent3.ItemsSource = ast.getList();
            AddFioText.Text = "";
            AddMarkText1.SelectedIndex = -1;
            AddMarkText2.SelectedIndex = -1;
            AddMarkText3.SelectedIndex = -1;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            if (bt != null)
            {
                var p = bt.Parent as Grid;
                var tt = (p.Children.Where(t => t.GetType().Name == "TextBlock").Last() as TextBlock).Text;
                ast.deleteStudent(int.Parse(tt));
            }
            ast.saveFile();
        }

        private void LookPath_Click(object sender, RoutedEventArgs e)
        {
            PathText.Text = ast.savePath();
        }
    }
}