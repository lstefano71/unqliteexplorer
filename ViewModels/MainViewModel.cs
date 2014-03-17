using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnQLiteExplorer.Models;
using UnQLiteExplorer.ViewModels;
using UnQLiteExplorer.Views;

namespace UnQLiteExplorer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IView view)
            : base()
        {
            this.View = view as MainWindow;
            this.DatastoreDetails = new DatastoreDetails();
        }

        protected override void ExecuteLoadedCommand(object parameter)
        {
            try
            {
                //List<Datastore> list = SystemService.GetAllFavoriteDatastores();
                //this.DatastoreItems = new ObservableCollection<Datastore>(list);
                //if (list != null && list.Count != 0)
                //{
                //    foreach (Datastore ds in list)
                //    {
                //        this.View.DatastoreRoot.Append(ds);
                //    }
                //}
                this.RefreshFavoriteDatastores();
            }
            catch 
            {
            }
        }

        public void RefreshFavoriteDatastores()
        {
            List<Datastore> list = SystemService.GetAllFavoriteDatastores();
            this.DatastoreItems = new ObservableCollection<Datastore>(list);
        }

        private new MainWindow View { get; set; }

        private DelegateCommand m_NewDatastoreCommand = null;
        public ICommand NewDatastoreCommand
        {
            get
            {
                if (m_NewDatastoreCommand == null)
                {
                    m_NewDatastoreCommand = new DelegateCommand((parameter) => 
                    {
                        ConnectWindow window = new ConnectWindow();
                        Boolean? result = window.ShowDialog();
                        if (result.HasValue && result.Value == true)
                        {
                            Datastore ds = window.Datastore;
                            if (ds != null)
                            {
                                ds.Status = DatastoreStatus.Connected;
                                TreeViewItem childItem = this.View.DatastoreRoot.Append(ds);
                                //if (childItem != null)
                                //{
                                //    childItem.MouseDoubleClick += (s, e) => 
                                //    {
                                //        if (e.ClickCount == 2)
                                //        {
                                //            ConnectDatastoreCommand.Execute(null);
                                //        }
                                //    };
                                //}
                            }
                        }
                    });
                }

                return m_NewDatastoreCommand;
            }
        }


        private DelegateCommand m_ConnectDatastoreCommand = null;
        public ICommand ConnectDatastoreCommand
        {
            get
            {
                if (m_ConnectDatastoreCommand == null)
                {
                    m_ConnectDatastoreCommand = new DelegateCommand((parameter) => 
                    {
                        TreeViewItem item = this.View.DatastoreView.SelectedItem as TreeViewItem;
                        if (item != null && item.Tag != null) 
                        {
                            Datastore ds = item.Tag as Datastore;
                            if (ds != null)
                            {
                                ds.Open();
                                item.TurnOnConnectIcon();                                
                                this.PresentingContent = this.DatastoreDetails;
                                this.DatastoreDetails.Render(ds);
                                this.IsEditEnabled = true;
                            }
                        }
                    });
                }

                return m_ConnectDatastoreCommand;
            }
        }

        
        private DelegateCommand m_DisconnectCommand = null;
        public ICommand DisconnectCommand
        {
            get
            {
                if (m_DisconnectCommand == null)
                {
                    m_DisconnectCommand = new DelegateCommand((parameter) => 
                    {
                        TreeViewItem item = this.View.DatastoreView.SelectedItem as TreeViewItem;
                        if (item != null && item.Tag != null) 
                        {
                            Datastore ds = item.Tag as Datastore;
                            if (ds != null)
                            {
                                ds.Close();
                                item.TurnOnDisconnectIcon();                                
                                this.PresentingContent = null;
                                this.IsEditEnabled = false;
                            }
                        }
                    });
                }

                return m_DisconnectCommand;
            }
        }
        
        private DelegateCommand m_DatastoreSelectionChangedCommand = null;
        public ICommand DatastoreSelectionChangedCommand
        {
            get
            {
                if (m_DatastoreSelectionChangedCommand == null)
                {
                    m_DatastoreSelectionChangedCommand = new DelegateCommand((parameter) => 
                    {
                        RoutedPropertyChangedEventArgs<object> e = parameter as RoutedPropertyChangedEventArgs<object>;
                        TreeViewItem oldItem = e.OldValue as TreeViewItem;
                        if (oldItem != null)
                        {
                            Datastore oldDs = oldItem.Tag as Datastore;
                            if (oldDs != null)
                            {
                                oldDs.Close();
                            }
                            oldItem.UnBold();
                            if (!oldItem.Equals(this.View.DatastoreRoot))
                            {
                                oldItem.TurnOnDisconnectIcon();
                            }
                        }

                        TreeViewItem newItem = e.NewValue as TreeViewItem;
                        if (newItem != null)
                        {
                            newItem.Bold();

                            Datastore ds = newItem.Tag as Datastore;
                            if (ds != null && ds.Status == DatastoreStatus.Connected)
                            {
                                this.PresentingContent = this.DatastoreDetails;
                                this.DatastoreDetails.Render(ds);
                                this.IsEditEnabled = true;
                                newItem.TurnOnConnectIcon();
                            }
                            else
                            {
                                this.PresentingContent = null;
                                this.IsEditEnabled = false;
                            }
                        }
                    });
                }

                return m_DatastoreSelectionChangedCommand;
            }
        }

        private DelegateCommand m_RefreshCommand = null;
        public ICommand RefreshCommand
        {
            get 
            {
                if (m_RefreshCommand == null)
                {
                    m_RefreshCommand = new DelegateCommand((parameter) => 
                    {
                        this.DatastoreDetails.Refresh();
                    });
                }

                return m_RefreshCommand;
            }
        }

        private DelegateCommand m_AppendNewItemCommand = null;
        public ICommand AppendNewItemCommand
        {
            get 
            {
                if (m_AppendNewItemCommand == null)
                {
                    m_AppendNewItemCommand = new DelegateCommand((parameter) => 
                    {
                        AppendNewItemWindow window = new AppendNewItemWindow();
                        Boolean? result = window.ShowDialog();
                        if (result.HasValue && result.Value == true)
                        {
                            UnqQLiteKeyValue kv = window.KeyValue;
                            this.DatastoreDetails.AppendNewItem(kv);
                        }
                    });
                }

                return m_AppendNewItemCommand;
            }
        }

        private DelegateCommand m_DeleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get
            {
                if (m_DeleteItemCommand == null)
                {
                    m_DeleteItemCommand = new DelegateCommand((parameter) =>
                    {
                        this.DatastoreDetails.DeleteItem();
                    });
                }

                return m_DeleteItemCommand;
            }
        }

        private DelegateCommand m_ClosingCommand = null;
        public ICommand ClosingCommand
        {
            get
            {
                if (m_ClosingCommand == null)
                {
                    m_ClosingCommand = new DelegateCommand((parameter) =>
                    {
                        this.DatastoreDetails.Close();
                    });
                }

                return m_ClosingCommand;
            }
        }


        private DelegateCommand m_AddToFavoriteConnectionCommand = null;
        public ICommand AddToFavoriteConnectionCommand
        {
            get
            {
                if (m_AddToFavoriteConnectionCommand == null)
                {
                    m_AddToFavoriteConnectionCommand = new DelegateCommand((parameter) =>
                    {
                        TreeViewItem selectedItem = this.View.DatastoreView.SelectedItem
                            as TreeViewItem;
                        if (selectedItem != null)
                        {
                            Datastore ds = selectedItem.Tag as Datastore;
                            if (ds != null)
                            {
                                SystemService.StoreFavoriteDatastore(ds);
                                this.RefreshFavoriteDatastores();
                                //this.Favorites.Refresh();
                            }
                        }
                    });
                }

                return m_AddToFavoriteConnectionCommand;
            }
        }
                
        private DelegateCommand m_RemoveFromFavoriteCommand = null;
        public ICommand RemoveFromFavoriteCommand
        {
            get
            {
                if (m_RemoveFromFavoriteCommand == null)
                {
                    m_RemoveFromFavoriteCommand = new DelegateCommand((parameter) =>
                    {
                        TreeViewItem selectedItem = this.View.DatastoreView.SelectedItem
                            as TreeViewItem;
                        if (selectedItem != null)
                        {
                            Datastore ds = selectedItem.Tag as Datastore;
                            if (ds != null)
                            {
                                SystemService.RemoveFavoriteDataStore(ds);
                                this.RefreshFavoriteDatastores();
                                //this.Favorites.Refresh();
                            }
                        }
                    });
                }

                return m_RemoveFromFavoriteCommand;
            }
        }

        private DelegateCommand m_ClearFavoriteCommand = null;
        public ICommand ClearFavoriteCommand
        {
            get
            {
                if (m_ClearFavoriteCommand == null)
                {
                    m_ClearFavoriteCommand = new DelegateCommand((parameter) =>
                    {
                        SystemService.ClearFavoriteDataStore();
                        this.RefreshFavoriteDatastores();
                        //this.Favorites.Refresh();
                    });
                }

                return m_ClearFavoriteCommand;
            }
        }


        private DelegateCommand m_ShowFavoritesCommand = null;
        public ICommand ShowFavoritesCommand
        {
            get
            {
                if (m_ShowFavoritesCommand == null)
                {
                    m_ShowFavoritesCommand = new DelegateCommand((parameter) =>
                    {
                        Fluent.Backstage menu = this.View.Ribbon.Menu as Fluent.Backstage;
                        menu.IsOpen = true;
                        
                        this.RefreshFavoriteDatastores();
                    });
                }

                return m_ShowFavoritesCommand;
            }
        }

        private DelegateCommand m_AboutCommand = null;
        public ICommand AboutCommand
        {
            get
            {
                if (m_AboutCommand == null)
                {
                    m_AboutCommand = new DelegateCommand((parameter) =>
                    {
                        AboutWindow window = new AboutWindow();
                        window.ShowDialog();
                    });
                }

                return m_AboutCommand;
            }
        }

        private DelegateCommand m_FavoriteDatastoreSelectedCommand = null;
        public ICommand FavoriteDatastoreSelectedCommand
        {
            get
            {
                if (m_FavoriteDatastoreSelectedCommand == null)
                {
                    m_FavoriteDatastoreSelectedCommand = new DelegateCommand(parameter =>
                    {
                        if (this.SelectedFavoriteDatastore != null)
                        {
                            Fluent.Backstage menu = this.View.Ribbon.Menu as Fluent.Backstage;
                            menu.IsOpen = false;

                            TreeViewItem item = this.View.DatastoreRoot.Append(this.SelectedFavoriteDatastore);
                            this.SelectedFavoriteDatastore.Open();
                            item.TurnOnConnectIcon();
                            this.PresentingContent = this.DatastoreDetails;
                            this.DatastoreDetails.Render(this.SelectedFavoriteDatastore);
                            this.IsEditEnabled = true;
                        }
                    });
                }

                return m_FavoriteDatastoreSelectedCommand;
            }
        }

        private Datastore m_SelectedFavoriteDatastore = null;
        public Datastore SelectedFavoriteDatastore
        {
            get { return this.m_SelectedFavoriteDatastore; }
            set
            {
                this.m_SelectedFavoriteDatastore = value;
                this.NotifyPropertyChanged("SelectedFavoriteDatastore");
            }
        }

        private ObservableCollection<Datastore> m_DatastoreItems = null;
        public ObservableCollection<Datastore> DatastoreItems
        {
            get { return this.m_DatastoreItems; }
            set
            {
                this.m_DatastoreItems = value;
                this.NotifyPropertyChanged("DatastoreItems");
            }
        }

        private Object m_PresentingContent = null;
        public Object PresentingContent 
        {
            get { return this.m_PresentingContent; }
            set 
            {
                this.m_PresentingContent = value;
                this.NotifyPropertyChanged("PresentingContent");
            }
        }

        private Boolean m_IsEditEnabled = false;
        public Boolean IsEditEnabled
        {
            get { return this.m_IsEditEnabled; }
            set
            {
                this.m_IsEditEnabled = value;
                this.NotifyPropertyChanged("IsEditEnabled");
            }
        }

        private DatastoreDetails DatastoreDetails { get; set; }
        //private Favorites Favorites { get; set; }
        //private Object LastPresentingObject { get; set; }
    }
}
