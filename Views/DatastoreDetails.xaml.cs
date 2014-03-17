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
using UnQLiteExplorer.Models;
using UnQLiteExplorer.ViewModels;

namespace UnQLiteExplorer.Views
{
    /// <summary>
    /// Interaction logic for DatastoreDetails.xaml
    /// </summary>
    public partial class DatastoreDetails : UserControl, IView
    {
        public DatastoreDetails()
        {
            InitializeComponent();
            this.ViewModel = new DatastoreDetailsViewModel(this);
            this.DataContext = this.ViewModel;
        }

        public void Render(Datastore ds)
        {
            this.ViewModel.RenderCommand.Execute(ds);
        }

        public void Refresh()
        {
            this.ViewModel.RefreshCommand.Execute(null);
        }

        public void AppendNewItem(UnqQLiteKeyValue kv)
        {
            this.ViewModel.AppendNewItemCommand.Execute(kv);
        }

        public void DeleteItem()
        {
            UnqQLiteKeyValue kv = this.DatastoreGrid.SelectedItem as UnqQLiteKeyValue;
            if (kv != null)
            {
                this.ViewModel.DeleteItemCommand.Execute(kv);
            }
        }

        public void Disconnect()
        {
            this.ViewModel.Close();
        }

        private Datastore Datastore { get; set; }
        private DatastoreDetailsViewModel ViewModel { get; set; }

        public void Show()
        {
            this.Visibility = System.Windows.Visibility.Visible;
        }


        public void Close()
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void DatastoreCellEditing(object sender, DataGridCellEditEndingEventArgs e)
        {
            this.ViewModel.EditingCommand.Execute(e);
        }
    }
}
