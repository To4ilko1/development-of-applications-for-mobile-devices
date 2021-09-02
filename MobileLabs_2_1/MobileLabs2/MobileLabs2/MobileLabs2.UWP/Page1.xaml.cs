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
    public sealed partial class Page1 : Page
    {
        internal ObservableCollection<StartList> stList1 { get; set; }
        public Page1()
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
                foreach (StartList s in stList1)
                {
                    int nlen = s.StList.Count();
                    double minElem;
                    int minind = 0;
                    minElem = Math.Abs(s.StList[0]); //изначально берем за минимальный - первый элемент массива
                    for (int i = 0; i < nlen; i++) //ищем минимальный элемент
                    {
                        if (Math.Abs(s.StList[i]) < minElem)
                        {
                            minElem = Math.Abs(s.StList[i]);
                            minind = i;
                        }
                    }
                    startArrGrid.Children.Clear();
                    for (int i = 0; i < nlen; i++) //вывод сгенерированного массива
                    {
                        TextBlock startArrText = new TextBlock();
                        startArrText.Text = Convert.ToString(s.StList[i]) + "; ";
                        startArrText.FontSize = 18;
                        startArrText.Margin = new Thickness(10);
                        if (i == minind)
                        {
                            startArrText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        }
                        startArrGrid.Children.Add(startArrText);
                    }
                }
                
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spw.IsPaneOpen = !spw.IsPaneOpen;
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int nlen = Convert.ToInt32(slValue.Value); // длина массива, которую ввёл пользователь (со слайдера)
            double minElem;
            List<int> StartL = new List<int>();
            int[] startArr = new int[nlen];
            startArrGrid.Children.Clear();
            int minind = 0;
            for (int i = 0; i < nlen; i++) //генерируем массив
            {
                startArr[i] = random.Next(-2, 3);
                StartL.Add(startArr[i]);
            }

            minElem = Math.Abs(startArr[0]); //изначально берем за минимальный - первый элемент массива
            for (int i = 0; i < nlen; i++) //ищем минимальный элемент
            {
                if (Math.Abs(startArr[i]) < minElem)
                {
                    minElem = Math.Abs(startArr[i]);
                    minind = i;
                }
            }
            for (int i = 0; i < nlen; i++) //вывод сгенерированного массива
            {
                TextBlock startArrText = new TextBlock();
                startArrText.Text = Convert.ToString(startArr[i]) + "; ";
                startArrText.FontSize = 18;
                startArrText.Margin = new Thickness(10);
                if (i == minind)
                {
                    startArrText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                }
                startArrGrid.Children.Add(startArrText);
            }
            Answer.Children.Clear();
            TextBlock minElemText = new TextBlock();
            minElemText.Text = "Минимальный по модулю элемент массива подсвечен.";
            minElemText.FontSize = 20;
            minElemText.TextWrapping = TextWrapping.Wrap;
            Answer.Children.Add(minElemText);
            var sttt = new StartList
            {
                StList = StartL,
            };
            stList1.Add(sttt);
        }
    }
}
