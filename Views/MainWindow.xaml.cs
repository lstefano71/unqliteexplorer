using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnQLiteExplorer.ViewModels;

namespace UnQLiteExplorer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.MetroWindow, IView
    {
        private MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.ViewModel = new MainViewModel(this);
            this.DataContext = this.ViewModel;
            this.Loaded += (s, e) => { this.ViewModel.LoadedCommand.Execute(null); };
        }

        private void DatastoreSelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.ViewModel.DatastoreSelectionChangedCommand.Execute(e);
        }

        private void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ViewModel.ClosingCommand.Execute(null);
        }

        private void ExitBackstageTabItemClick(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void FavoriteDatastoreMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ViewModel.FavoriteDatastoreSelectedCommand.Execute(null);
        }
    }
}
