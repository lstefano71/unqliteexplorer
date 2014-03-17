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
    public class DatastoreDetailsViewModel : ViewModelBase
    {
        public DatastoreDetailsViewModel(IView view)
            : base(view)
        {
            this.View = view as DatastoreDetails;
            this.DatastoreItems = new UnqQLiteKeyValueCollection();
        }

        private DelegateCommand m_RenderCommand = null;
        public ICommand RenderCommand
        {
            get 
            {
                if (this.m_RenderCommand == null)
                {
                    this.m_RenderCommand = new DelegateCommand((parameter) => 
                    {
                        this.CurrentDatastore = parameter as Datastore;
                        this.CurrentDatastore.Open();
                        this.View.Title.Content = String.Format("Datastore: {0}", this.CurrentDatastore.Name);
                        this.View.FullName.Content = this.CurrentDatastore.FullName;
                        this.DatastoreItems = new UnqQLiteKeyValueCollection(this.CurrentDatastore.GetAllKVEntries());
                    });
                }

                return this.m_RenderCommand;
            }
        }


        private DelegateCommand m_RefreshCommand = null;
        public ICommand RefreshCommand
        {
            get 
            {
                if (this.m_RefreshCommand == null)
                {
                    this.m_RefreshCommand = new DelegateCommand((parameter) => 
                    {
                        if (this.CurrentDatastore != null)
                        {
                            this.CurrentDatastore.Close();
                            this.CurrentDatastore.Open();
                            this.DatastoreItems = new UnqQLiteKeyValueCollection(this.CurrentDatastore.GetAllKVEntries());
                        }
                    });
                }

                return this.m_RefreshCommand;
            }
        }


        private DelegateCommand m_AppendNewItemCommand = null;
        public ICommand AppendNewItemCommand
        {
            get 
            {
                if (this.m_AppendNewItemCommand == null)
                {
                    this.m_AppendNewItemCommand = new DelegateCommand((parameter) => 
                    {
                        UnqQLiteKeyValue kv = parameter as UnqQLiteKeyValue;
                        this.CurrentDatastore.Append(kv);
                        this.RefreshCommand.Execute(null);
                    });
                }

                return this.m_AppendNewItemCommand;
            }
        }


        private DelegateCommand m_DeleteItemCommand = null;
        public ICommand DeleteItemCommand
        {
            get 
            {
                if (this.m_DeleteItemCommand == null)
                {
                    this.m_DeleteItemCommand = new DelegateCommand((parameter) => 
                    {
                        UnqQLiteKeyValue kv = parameter as UnqQLiteKeyValue;
                        this.CurrentDatastore.Delete(kv);
                        this.RefreshCommand.Execute(null);
                    });
                }

                return this.m_DeleteItemCommand;
            }
        }

        private DelegateCommand m_EditingCommand = null;
        public ICommand EditingCommand
        {
            get 
            {
                if (this.m_EditingCommand == null)
                {
                    this.m_EditingCommand = new DelegateCommand((parameter) => 
                    {
                        DataGridCellEditEndingEventArgs e = parameter as DataGridCellEditEndingEventArgs;
                        UnqQLiteKeyValue kv = e.Row.Item as UnqQLiteKeyValue;
                        if (this.CurrentDatastore != null)
                        {
                            this.CurrentDatastore.Save(kv);
                        }
                    });
                }

                return this.m_EditingCommand;
            }
        }

        private UnqQLiteKeyValueCollection m_DatastoreItems = null;
        public UnqQLiteKeyValueCollection DatastoreItems
        {
            get { return this.m_DatastoreItems; }
            set 
            {
                this.m_DatastoreItems = value;
                this.NotifyPropertyChanged("DatastoreItems");
            }
        }

        public void Close()
        {
            if (this.CurrentDatastore != null)
            {
                this.CurrentDatastore.Close();
            }
        }

        private Datastore CurrentDatastore { get; set; }
        private new DatastoreDetails View { get; set; }
    }
}
