using System;
using System.ComponentModel;
using System.Windows.Input;
using UnQLiteExplorer.Views;

namespace UnQLiteExplorer.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected ViewModelBase(IView view)
        {
            this.View = view;
        }

        protected ViewModelBase()
            : this(null)
        {
        }

        protected virtual void ExecuteLoadedCommand(Object parameter)
        {
        }



        protected DelegateCommand m_LoadedCommand = null;
        public ICommand LoadedCommand
        {
            get
            {
                if (m_LoadedCommand == null)
                {
                    m_LoadedCommand = new DelegateCommand((parameter) =>
                    {
                        ExecuteLoadedCommand(parameter);
                    });
                }

                return m_LoadedCommand;
            }
        }

        private DelegateCommand m_ExitCommand = null;
        public ICommand ExitCommand
        {
            get
            {
                if (m_ExitCommand == null)
                {
                    m_ExitCommand = new DelegateCommand((parameter) =>
                    {
                        if (this.View != null)
                        {
                            this.View.Close();
                        }
                    });
                }

                return m_ExitCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        protected IView View { get; set; }
    }
}
