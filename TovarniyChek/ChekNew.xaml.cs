using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using TovarniyChek.Classes.BizzClass;

namespace TovarniyChek
{
    /// <summary>
    /// Логика взаимодействия для ChekNew.xaml
    /// </summary>
    public partial class ChekNew : UserControl
    {
        ChekBasesDataSet ds = new ChekBasesDataSet();
        ChekBasesDataSetTableAdapters.RekvizitiTableAdapter ta = new ChekBasesDataSetTableAdapters.RekvizitiTableAdapter();
        ObservableCollection<ZakaziClass> collection;
        public ChekNew()
        {
            InitializeComponent();
            lblChek.Content += " 1 от " + DateTime.Now.Date.ToLongDateString();
            string conString = TovarniyChek.Properties.Settings.Default.Setting;
            ta.FillByIDTIP(ds.Rekviziti, 1);
            lblRekvizIspolnitel.Content = ds.Rekviziti[0].name + " " + ds.Rekviziti[0].Adress + " ИНН " + ds.Rekviziti[0].inn + " КПП " + ds.Rekviziti[0].kpp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Kontragent kon = new Kontragent();
                kon.ShowDialog();
                    lblRekvizZakazchika.Content = kon.ID;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Add aded = new Add();
            aded.ShowDialog();
            ZakaziClass newZakaz = new ZakaziClass() { id=0, cena = aded.txtcena.Text, data = DateTime.Now.ToShortDateString(), edenica = aded.txtEdizm.Text, kolich = aded.txtKolich.Text, name = aded.txtName.Text, namber = 1 };
            AddNewTovar(newZakaz);
            ChekSummItog();
        }

        private void MyDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int selectColumn = MyDG.CurrentCell.Column.DisplayIndex;
                var selectCell = MyDG.SelectedCells[selectColumn];
                var cellContent = selectCell.Column.GetCellContent(selectCell.Item);
                Add adedZakaz = new Add();
                adedZakaz.txtcena.Text = ((ZakaziClass)MyDG.SelectedItems[0]).cena;
                adedZakaz.txtEdizm.Text = ((ZakaziClass)MyDG.SelectedItems[0]).edenica;
                adedZakaz.txtKolich.Text = ((ZakaziClass)MyDG.SelectedItems[0]).kolich;
                adedZakaz.txtName.Text = ((ZakaziClass)MyDG.SelectedItems[0]).name;
                adedZakaz.ShowDialog();
                ((ZakaziClass)MyDG.SelectedItems[0]).cena = adedZakaz.txtcena.Text;
                ((ZakaziClass)MyDG.SelectedItems[0]).edenica = adedZakaz.txtEdizm.Text;
                ((ZakaziClass)MyDG.SelectedItems[0]).kolich = adedZakaz.txtKolich.Text;
                ((ZakaziClass)MyDG.SelectedItems[0]).name = adedZakaz.txtName.Text;
                MyDG.SelectedItems.Clear();
                MyDG.SelectedIndex = -1;
                MyDG.Items.Refresh();
                ChekSummItog();
            }
            catch { }
        }
        private void AddNewTovar(ZakaziClass newZakaz)
        {
            
            if (collection == null)
            {
                collection = new ObservableCollection<ZakaziClass>();
                collection.Add(
                new ZakaziClass() { id=1, namber = 1, data = DateTime.Now.ToShortDateString(), name = newZakaz.name, kolich = newZakaz.kolich, edenica = newZakaz.edenica, cena = newZakaz.cena }
                );
            }
            else
            {
                int i = collection.Count;
                if (collection.Count > 1)
                    ++i;
                collection.Add(
                    new ZakaziClass() { id=i, namber = 1, data = DateTime.Now.ToShortDateString(), name = newZakaz.name, kolich = newZakaz.kolich, edenica = newZakaz.edenica, cena = newZakaz.cena }
                    );
            }

            MyDG.ItemsSource = collection;
        }

        private void MyDG_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            redaktorpoly();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            redaktorpoly();
        }
        private void redaktorpoly()
        {
            try
            {
                int selectColumn = MyDG.SelectedIndex;
                var selectCell = MyDG.SelectedCells[selectColumn];
                var cellContent = selectCell.Column.GetCellContent(selectCell.Item);
                Add adedZakaz = new Add();
                adedZakaz.txtcena.Text = ((ZakaziClass)MyDG.SelectedItems[0]).cena;
                adedZakaz.txtEdizm.Text = ((ZakaziClass)MyDG.SelectedItems[0]).edenica;
                adedZakaz.txtKolich.Text = ((ZakaziClass)MyDG.SelectedItems[0]).kolich;
                adedZakaz.txtName.Text = ((ZakaziClass)MyDG.SelectedItems[0]).name;
                adedZakaz.ShowDialog();
                ((ZakaziClass)MyDG.SelectedItems[0]).cena = adedZakaz.txtcena.Text;
                ((ZakaziClass)MyDG.SelectedItems[0]).edenica = adedZakaz.txtEdizm.Text;
                ((ZakaziClass)MyDG.SelectedItems[0]).kolich = adedZakaz.txtKolich.Text;
                ((ZakaziClass)MyDG.SelectedItems[0]).name = adedZakaz.txtName.Text;
                MyDG.SelectedItems.Clear();
                MyDG.SelectedIndex = -1;
                MyDG.Items.Refresh();
                ChekSummItog();
            }
            catch { }
        }
        /// <summary>
        /// Удаление строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                collection.RemoveAt(MyDG.SelectedIndex);
            }
            catch { }
            ChekSummItog();
        }
        private void ChekSummItog()
        {
            int summa = 0;
            if (collection.Count > 0 || collection.Count != null)
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    summa += Convert.ToInt32(collection[i].cena);
                }
            }
            lblItogo.Content = summa.ToString() + " руб. 00 коп.";
        }
    }
}
