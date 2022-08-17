using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TovarniyChek
{
    /// <summary>
    /// Логика взаимодействия для Kontragent.xaml
    /// </summary>
    public partial class Kontragent : Window
    {
        private string _id = "";
        public string ID { get; set; }
        ChekBasesDataSet ds = new ChekBasesDataSet();
        ChekBasesDataSetTableAdapters.RekvizitiTableAdapter ta = new ChekBasesDataSetTableAdapters.RekvizitiTableAdapter();
        public Kontragent()
        {
            InitializeComponent();
            this.ID = _id;
            ta.FillByIDTIP(ds.Rekviziti, 2);
            KontrogentDataGrid.DataContext = ds.Rekviziti;
        }

        private void MatchsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectColumn = KontrogentDataGrid.CurrentCell.Column.DisplayIndex;
            var selectCell = KontrogentDataGrid.SelectedCells[selectColumn];
            var cellContent = selectCell.Column.GetCellContent(selectCell.Item);
            //this.ID = (cellContent as TextBlock).Text;
            /*if (dgClients.SelectedItems.Count== 0)  return;
            clientName = ((DataRowView)dgClients.SelectedItems[0]).Row["ClientName"].ToString();
            clientID = (int)((DataRowView)dgClients.SelectedItems[0]).Row["ID"];*/
            this.ID = ((DataRowView)KontrogentDataGrid.SelectedItems[0]).Row["name"].ToString() + " " + ((DataRowView)KontrogentDataGrid.SelectedItems[0]).Row["Adress"].ToString() + " " + ((DataRowView)KontrogentDataGrid.SelectedItems[0]).Row["inn"].ToString();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewRekviziti newrekviz = new NewRekviziti();
            newrekviz.ShowDialog();
        }
    }
}
