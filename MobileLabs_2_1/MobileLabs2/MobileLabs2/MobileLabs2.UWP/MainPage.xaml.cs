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

namespace MobileLabs2.UWP
{
    public sealed partial class MainPage
    {
        internal ObservableCollection<StartList> stList1 { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            stList1 = new ObservableCollection<StartList>();
            frx.Navigate(typeof(Page1), stList1);
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var t = (ListBoxItem)e.AddedItems[0];
            if (t.Name == "p1")
            {
                frx.Navigate(typeof(Page1), stList1);
            }
            if (t.Name == "p2")
            {
                frx.Navigate(typeof(Page2), stList1);
            }
            if (t.Name == "p3")
            {
                frx.Navigate(typeof(Page3), stList1);
            }     
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            spw1.IsPaneOpen = !spw1.IsPaneOpen;//Код обработчика событий кнопки
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frx.CanGoBack) frx.GoBack();//возврат на предыдущую страницу
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (frx.CanGoForward) frx.GoForward();//переход на следующую страницу
        }
    }
}
