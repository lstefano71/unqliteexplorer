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
    public partial class Favorites : UserControl, IView
    {
        public Favorites()
        {
            InitializeComponent();
            this.ViewModel = new FavoritesViewModel(this);
            this.DataContext = this.ViewModel;
            this.Loaded += (s, e) => { this.ViewModel.LoadedCommand.Execute(null); };
        }

        public void Refresh()
        {
            this.ViewModel.Refresh();
        }
        
        private FavoritesViewModel ViewModel { get; set; }

        public void Show()
        {
            this.Visibility = System.Windows.Visibility.Visible;
        }
        
        public void Close()
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void FavoriteDatastoreSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ViewModel.FavoriteDatastoreSelectedCommand.Execute(e);
        }

    }
}
