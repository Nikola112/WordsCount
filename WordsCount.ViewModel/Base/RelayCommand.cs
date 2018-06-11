using System;
using System.Windows.Input;

namespace WordsCount.ViewModel.Base
{
    class RelayCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Fields

        private Action _action;

        #endregion

        #region Constructors

        public RelayCommand(Action action) => _action = action;

        #endregion

        #region Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action();

        #endregion
    }

    class RelayCommand<T> : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Fields

        private Action<T> _action;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> action) => _action = action;

        #endregion

        #region Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _action((T)parameter);

        #endregion
    }
}
