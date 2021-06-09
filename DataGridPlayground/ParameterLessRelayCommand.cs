using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataGridPlayground
{
    public class ParameterLessRelayCommand : ICommand
    {
        Func<bool> targetCanExecuteMethod;
        Action targetExecuteMethod;

        public ParameterLessRelayCommand(Action executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }
        public ParameterLessRelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
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
            if (targetCanExecuteMethod != null)
            {
                return targetCanExecuteMethod();
            }
            if (targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (targetExecuteMethod != null)
            {
                targetExecuteMethod();
            }
        }
    }
}
