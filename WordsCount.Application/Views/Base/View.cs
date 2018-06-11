using System.ComponentModel;
using System.Windows.Input;

namespace WordsCount.Application.Views.Base
{
    class View
    {
        public INotifyPropertyChanged Context { get; set; }

        public View(INotifyPropertyChanged context)
        {
            Context = context;
        }

        public void ExecuteCommand(ICommand command, object parameters = null)
        {
            if (command.CanExecute(parameters))
                command.Execute(parameters);
        }
    }
}
