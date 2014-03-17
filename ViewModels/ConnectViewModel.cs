using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnQLiteExplorer.Models;
using UnQLiteExplorer.Views;

namespace UnQLiteExplorer.ViewModels
{
    public class ConnectViewModel : ViewModelBase
    {
        public ConnectViewModel(IWindowView view)
            : base(view)
        {
            this.View = view as ConnectWindow;
        }

        private DelegateCommand m_BrowseExistingDatastoreCommand = null;
        public ICommand BrowseExistingDatastoreCommand
        {
            get 
            {
                if (m_BrowseExistingDatastoreCommand == null)
                {
                    m_BrowseExistingDatastoreCommand = new DelegateCommand((parameter) => 
                    {
                        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                        dlg.DefaultExt = ".unqlite";
                        Boolean? result = dlg.ShowDialog();
                        if (result.HasValue && result.Value == true)
                        {
                            this.ExistingDatastoreName = dlg.FileName;
                        }
                    });
                }

                return m_BrowseExistingDatastoreCommand;
            }
        }

        private DelegateCommand m_BrowseNewDatastoreLocationCommand = null;
        public ICommand BrowseNewDatastoreLocationCommand
        {
            get 
            {
                if (m_BrowseNewDatastoreLocationCommand == null)
                {
                    m_BrowseNewDatastoreLocationCommand = new DelegateCommand((parameter) => 
                    {
                        
                    });
                }

                return m_BrowseNewDatastoreLocationCommand;
            }
        }


        private DelegateCommand m_ConfirmCommand = null;
        public ICommand ConfirmCommand
        {
            get
            {
                if (m_ConfirmCommand == null)
                {
                    m_ConfirmCommand = new DelegateCommand((parameter) =>
                    {
                        Datastore ds = null;
                        if (this.IsConnectToExistingDatastoreChecked)
                        {
                            if (!String.IsNullOrEmpty(this.ExistingDatastoreName))
                            {
                                ds = new Datastore(this.ExistingDatastoreName);
                            }
                        }
                        else if (this.IsCreateNewDatastoreChecked)
                        {
                            if (!String.IsNullOrEmpty(this.NewDatastoreName) &&
                                !String.IsNullOrEmpty(this.NewDatastoreLocation))
                            {
                                ds = new Datastore(this.NewDatastoreName, this.NewDatastoreLocation);
                            }
                        }

                        if (ds != null)
                        {
                            this.View.Datastore = ds;
                            this.View.SetDialogResult(true);
                        }
                        else 
                        {
                            this.View.Datastore = null;
                            this.View.SetDialogResult(false);
                        }

                        this.View.Close();
                    });
                }

                return m_ConfirmCommand;
            }
        }


        private DelegateCommand m_CheckedCommand = null;
        public ICommand CheckedCommand
        {
            get 
            {
                if (m_CheckedCommand == null)
                {
                    m_CheckedCommand = new DelegateCommand((parameter) => 
                    {
                        if (this.IsConnectToExistingDatastoreChecked)
                        {
                            this.IsCreateNewDatastoreEnabled = false;
                            this.IsConnectExistingDatastoreEnabled = true;
                        }
                        else
                        {
                            this.IsCreateNewDatastoreEnabled = true;
                            this.IsConnectExistingDatastoreEnabled = false;
                        }
                    });
                }

                return m_CheckedCommand;
            }
        }

        private Boolean m_IsCreateNewDatastoreChecked = false;
        public Boolean IsCreateNewDatastoreChecked
        {
            get { return this.m_IsCreateNewDatastoreChecked; }
            set 
            {
                this.m_IsCreateNewDatastoreChecked = value;
                this.NotifyPropertyChanged("IsCreateNewDatastoreChecked");
            }
        }
        
        private Boolean m_IsCreateNewDatastoreEnabled = false;
        public Boolean IsCreateNewDatastoreEnabled
        {
            get { return this.m_IsCreateNewDatastoreEnabled; }
            set
            {
                this.m_IsCreateNewDatastoreEnabled = value;
                this.NotifyPropertyChanged("IsCreateNewDatastoreEnabled");
            }
        }

        private Boolean m_IsConnectToExistingDatastoreChecked = true;
        public Boolean IsConnectToExistingDatastoreChecked
        {
            get { return this.m_IsConnectToExistingDatastoreChecked; }
            set 
            {
                this.m_IsConnectToExistingDatastoreChecked = value;
                this.NotifyPropertyChanged("IsConnectToExistingDatastoreChecked");
            }
        }

        private Boolean m_IsConnectExistingDatastoreEnabled = true;
        public Boolean IsConnectExistingDatastoreEnabled
        {
            get { return this.m_IsConnectExistingDatastoreEnabled; }
            set
            {
                this.m_IsConnectExistingDatastoreEnabled = value;
                this.NotifyPropertyChanged("IsConnectExistingDatastoreEnabled");
            }
        }

        private String m_ExistingDatastoreName = String.Empty;
        public String ExistingDatastoreName
        {
            get { return this.m_ExistingDatastoreName; }
            set 
            {
                this.m_ExistingDatastoreName = value;
                this.NotifyPropertyChanged("ExistingDatastoreName");
            }
        }

        private String m_NewDatastoreName = String.Empty;
        public String NewDatastoreName
        {
            get { return this.m_NewDatastoreName; }
            set 
            {
                this.m_NewDatastoreName = value;
                this.NotifyPropertyChanged("NewDatastoreName");
            }
        }


        private String m_NewDatastoreLocation = String.Empty;
        public String NewDatastoreLocation
        {
            get { return this.m_NewDatastoreLocation; }
            set 
            {
                this.m_NewDatastoreLocation = value;
                this.NotifyPropertyChanged("NewDatastoreLocation");
            }
        }


        private new ConnectWindow View { get; set; }
    }
}
