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
    public partial class AboutWindow : Fluent.MetroWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SystemInfoClick(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("msinfo32.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.unqlite.org/");
            }
            catch
            {
            }
        }
    }
}
