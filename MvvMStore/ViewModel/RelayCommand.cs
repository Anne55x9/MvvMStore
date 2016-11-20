using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MvvMStore.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute = null;
        private Func<bool> methodTODetectCanExecute = null;
        private Action addNewCoffee;
        

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


        public RelayCommand(Action addNewCoffee)
        {
            this.addNewCoffee = addNewCoffee;
        }

      
     
        
    }
}
 //public class RelayCommand : ICommand
 //   {
 //       private Action methodToExecute = null;
 //       private Func<bool> methodTODetectCanExecute = null;
 //       private Action addNewCoffee;

 //       public event EventHandler CanExecuteChanged;

 //       public bool CanExecute(object parameter)
 //       {
 //           if(this.methodTODetectCanExecute == null)
 //           {
 //               return true;
 //           }
 //           else
 //           {
 //               return this.methodTODetectCanExecute();
 //           }
 //       }

 //       public void Execute(object parameter)
 //       {
 //           this.addNewCoffee();
 //       }


 //       public RelayCommand(Action addNewCoffee)
 //       {
 //           this.addNewCoffee = addNewCoffee;
 //       }

        
    //}