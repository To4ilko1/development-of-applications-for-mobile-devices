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
    public sealed partial class Page3 : Page
    {
        internal ObservableCollection<StartList> stList1 { get; set; }
        public Page3()
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
                int nlen = s.StList.Count();
                List<int> A = new List<int>();
                List<int> B = new List<int>();
                for (int i = 0; i < nlen; i++)
                {
                    if (i % 2 == 0) //если элемент четный
                    {
                        A.Add(s.StList[i]);//добавляем элемент в лист А
                    }
                    else //если элемент нечетный
                    {
                        B.Add(s.StList[i]);//добавляем элемент в лист B
                    }
                }
                A.AddRange(B);
                List<int> ResultList = A; //Добавляем в конец листа А лист B и записываем результат в ResultList
                resultArrGrid.Children.Clear();
                for (int i = 0; i < nlen; i++)//вывод переделанной матрицы
                {
                    TextBlock resultTxt = new TextBlock();
                    //resultTxt.Text = ResultList[i].ToString("#.0") + ";";
                    resultTxt.Text = ResultList[i].ToString() + "; ";
                    resultTxt.FontSize = 18;
                    resultTxt.Margin = new Thickness(10);
                    //resultTxt.Width = Double.NaN;
                    resultArrGrid.Children.Add(resultTxt);
                }
            }
        }
    }
}
