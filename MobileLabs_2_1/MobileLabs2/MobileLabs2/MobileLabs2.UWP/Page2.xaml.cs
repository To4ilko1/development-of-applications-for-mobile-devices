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

namespace MobileLabs2.UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        internal ObservableCollection<StartList> stList1 { get; set; }
        public Page2()
        {
            this.InitializeComponent();
            stList1 = new ObservableCollection<StartList>();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                var p = (ObservableCollection<StartList>)e.Parameter;
                stList1 = p;
                var n = p.Count;
            }
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (StartList s in stList1)
            {
                Answer.Children.Clear();
                int nlen = s.StList.Count();
                int summa = 0;
                bool flag = false;
                    for (int i = 0; i < nlen; i++)
                {
                    if (s.StList[i] == 0)
                    {
                        flag = true;
                    }
                    if (flag)
                    {
                        summa += s.StList[i];
                    }
                }
                TextBlock SummaText = new TextBlock();
                if (!flag)
                {
                    SummaText.Text = "В массиве нет элементов, равных нулю.";
                    SummaText.FontSize = 20;
                    SummaText.TextWrapping = TextWrapping.Wrap;
                }
                else
                {
                    SummaText.Text = "Сумма модулей элементов массива, расположенных после первого элемента, равного нулю:  " + Convert.ToString(summa);
                    SummaText.FontSize = 20;
                    SummaText.TextWrapping = TextWrapping.Wrap;
                }
                Answer.Children.Add(SummaText);
            }
        }
    }
}
