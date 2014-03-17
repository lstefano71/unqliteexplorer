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
using System.Windows.Shapes;
using UnQLiteExplorer.Models;
using UnQLiteExplorer.ViewModels;

namespace UnQLiteExplorer.Views
{
    /// <summary>
    /// Interaction logic for ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Fluent.MetroWindow, IWindowView
    {
        private ConnectViewModel ViewModel { get; set; }

        public ConnectWindow()
        {
            InitializeComponent();

            this.ViewModel = new ConnectViewModel(this);
            this.DataContext = this.ViewModel;
        }

        public void SetDialogResult(bool value)
        {
            this.DialogResult = value;
        }

        public Datastore Datastore { get; set; }
        
        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.ViewModel.ExitCommand.Execute(null);
            }
        }

    }
}
