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

namespace MobileLabsTest.UWP
{
    public sealed partial class MainPage
    {
        public TextBlock[,] textBlocks = new TextBlock[12,12];
        public TextBlock resultTextBlock = new TextBlock();
        public MainPage()
        {
            this.InitializeComponent();

            //LoadApplication(new MobileLabsTest.App());

            Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    TextBlock rowtext = new TextBlock();                   
                    Grid.SetColumn(rowtext, i);
                    Grid.SetRow(rowtext, j);
                    matrix.Children.Add(rowtext);
                    textBlocks[i,j] = rowtext;
                }
            }
        }

        public int[,] elements = new int[12, 12];
        public int next = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Заполняем табличку рандомными числами
            Random random = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    textBlocks[i, j].Text = Convert.ToString(random.Next(next));
                    elements[i, j] = Convert.ToInt32(textBlocks[i, j].Text);   
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int s = 0;            
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    if (j > i)
                        s += elements[i,j];
                }
            }
            result.Text = "Сумма элементов матрицы, расположенных над главной диагональю:" + " " + Convert.ToString(s);
        }

        public void ClearResult()
        { 
            result.Text = "";
        }

        private void randomSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            next = Convert.ToInt32(randomSlider.Value);
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            loginText.Text = "Логин:    " + login.Text;
            passText.Text = "Пароль:    -";
            informText.Text = "Информация:    " + info.Text;
            if (female.IsChecked == true)
            {
                sexText.Text = "Пол:    Женский";
            }
            else
            {
                sexText.Text = "Пол:    Мужской";
            }
            if (prog.IsOn == true)
            {
                progrText.Text = "Программируете?    Да";
            }
            else
            {
                progrText.Text = "Программируете?    Нет";
            }
            birthdayText.Text = "Дата рождения:    " + Convert.ToString(date.Date);
            Registration.IsEnabled = false;
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            female.IsChecked = false;
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            male.IsChecked = false;
        }
    }
}
