using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MvvMStore.ViewModel
{
    /// <summary>
    /// Relaycommand er MArtins navn til denne 'Command Klasse'. Klassen implementerer ICommand og bruger system.windows.input. 
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Private instance fields som følger med ICommand implementeringen. De er begge sat til null i det eksempel. 
        /// </summary>
        private Action methodToExecute = null;
        private Func<bool> methodTODetectCanExecute = null;

        /// <summary>
        /// Et privat instance field af typen Action.
        /// </summary>
        private Action addNewCoffee;

        /// <summary>
        /// Icommand implementerer en EventHandler med metoderne CanExecute og Execute.
        /// </summary>    
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(this.methodTODetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodTODetectCanExecute();
            }
        }

        public void Execute(object parameter)
        {
            
            this.addNewCoffee();
        }

        /// <summary>
        ///  Relaycommand Metode med typen Action.
        /// </summary>
        public RelayCommand(Action addNewCoffee)
        {
            this.addNewCoffee = addNewCoffee;
        }

    }
}
 