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
    public partial class AppendNewItemWindow : Fluent.MetroWindow
    {
        public AppendNewItemWindow()
        {
            InitializeComponent();
            
        }

        public UnqQLiteKeyValue KeyValue { get; set; }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            String key = this.TbKey.Text.Trim();
            String value = this.TbValue.Text.Trim();
            this.KeyValue = new UnqQLiteKeyValue(key, value);

            this.DialogResult = true;            
            this.Close();
        }
    }
}
