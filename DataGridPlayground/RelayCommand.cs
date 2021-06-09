using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataGridPlayground
{
    public class RelayCommand<T>: ICommand
    {
        Predicate<T> targetCanExecuteMethod;
        Action<T> targetExecuteMethod;

        public RelayCommand(Action <T> executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }
        public RelayCommand(Action<T> executeMethod, Predicate<T> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }


        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if(targetCanExecuteMethod != null)
            {
                return targetCanExecuteMethod((T) parameter);
            }
            if(targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if(targetExecuteMethod != null)
            {
                targetExecuteMethod((T) parameter);
            }
        }
    }
}
