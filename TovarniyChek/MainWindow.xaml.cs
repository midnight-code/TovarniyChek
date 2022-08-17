using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TovarniyChek
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            ChekNew contr = new ChekNew();
            gridMain.Children.Add(contr);
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            ChekNew contr = new ChekNew();
            gridMain.Children.Add(contr);
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            ChekNew contr = new ChekNew();
            gridMain.Children.Add(contr);
        }

        private void MenuItem_Click_Search(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
            ChekNew contr = new ChekNew();
            gridMain.Children.Add(contr);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            gridMain.Children.Clear();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            AboutBox1 isp = new AboutBox1();
            isp.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0}", "Внимание программа будет закрыта. Все несохранённые данные будут утерянны");
            messageBoxCS.AppendLine();
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "Закрытие программы");
            this.Close();
        }
    }
}
