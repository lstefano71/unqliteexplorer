using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using UnQLiteExplorer.Models;
using UnQLiteExplorer.Views;

namespace UnQLiteExplorer.ViewModels
{
    public class FavoritesViewModel : ViewModelBase
    {
        public FavoritesViewModel(IView view)
            : base(view)
        {
            this.View = view as Favorites;
            this.DatastoreItems = new ObservableCollection<Datastore>();
        }

        protected override void ExecuteLoadedCommand(object parameter)
        {
            List<Datastore> list = SystemService.GetAllFavoriteDatastores();
            this.DatastoreItems = new ObservableCollection<Datastore>(list);
        }

        public void Refresh()
        {
            List<Datastore> list = SystemService.GetAllFavoriteDatastores();
            this.DatastoreItems = new ObservableCollection<Datastore>(list);
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
                        SelectionChangedEventArgs e = parameter as SelectionChangedEventArgs;
                        if (e.AddedItems != null && e.AddedItems.Count == 1)
                        {
                            this.SelectedFavoriteDatastore = e.AddedItems[0] as Datastore;
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

        private new Favorites View { get; set; }
    }
}
