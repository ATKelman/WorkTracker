using System;
using System.Windows.Input;

namespace WpfBase
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> executeAction;
        private readonly Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, canExecute: null)
        { }

        public DelegateCommand(Action<object> executeAction, Predicate<object> canExecute)
        {
            if (executeAction == null)
            {
                throw new ArgumentNullException(nameof(executeAction));
            }

            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> executeAction, Action<Action<object>, Exception> onError)
            : this(executeAction.AddErrorHandling(onError), canExecute: null)
        { }

        public DelegateCommand(Action<object> executeAction, Action<Action<object>, Exception> onError, Predicate<object> canExecute)
            : this(executeAction.AddErrorHandling(onError), canExecute)
        { }

        public bool CanExecute(object parameter = null)
        {
            var result = true;

            if (canExecute != null)
            {
                result = canExecute(parameter);
            }
            return result;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void Execute(object parameter = null)
        {
            executeAction(parameter);
        }

        public override string ToString()
        {
            return executeAction.Method + Environment.NewLine + "CanExecute = " +
                ((canExecute == null) ? "true" : canExecute(null).ToString());
        }
    }
}
