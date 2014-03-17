using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace UnQLiteExplorer.ViewModels
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> executeCommand)
            : this(executeCommand, null, false)
        {
        }

        public DelegateCommand(Action<object> executeCommand, Predicate<object> canExecuteCommand)
            : this(executeCommand, canExecuteCommand, false)
        {
        }

        public DelegateCommand(Action<object> executeCommand, Predicate<object> canExecuteCommand, bool autoCanExecuteCommandUpdating)
        {
            if (executeCommand == null)
            {
                throw new ArgumentNullException("executeCommand");
            }

            this.ExecuteCommand = executeCommand;
            this.CanExecuteCommand = canExecuteCommand;

            if (autoCanExecuteCommandUpdating)
            {
                RegisterForCanExecuteUpdating(this);
            }
        }

        static DelegateCommand()
        {
            AutomaticCanExecuteUpdatingCommand = new List<DelegateCommand>();
        }

        private static void RegisterForCanExecuteUpdating(DelegateCommand command)
        {
            AutomaticCanExecuteUpdatingCommand.Add(command);
        }

        public event EventHandler CanExecuteChanged;
        private static List<DelegateCommand> AutomaticCanExecuteUpdatingCommand { get; set; }
        private Action<object> ExecuteCommand { get; set; }
        private Predicate<object> CanExecuteCommand { get; set; }

        #region [ "ICommand Members" ]
        public bool CanExecute(object parameter)
        {
            return (CanExecuteCommand == null) ?
                true :
                CanExecuteCommand(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            ExecuteCommand(parameter);
        }
        #endregion
    }
}
