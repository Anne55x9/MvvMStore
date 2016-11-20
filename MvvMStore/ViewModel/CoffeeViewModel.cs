using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MvvMStore.Model;
using MvvMStore.ViewModel;

namespace MvvMStore
{
    public class CoffeeViewModel: INotifyPropertyChanged
    {

        private Model.CoffeeList coffeeList;

        public Model.CoffeeList CoffeeList
        {
            get { return coffeeList; }
            set { coffeeList = value; }
        }

        private Model.Coffee selectedCoffee;

        public Model.Coffee SelectedCoffee
        {
            get { return selectedCoffee; }
            set { selectedCoffee = value; OnPropertyChanged(nameof(SelectedCoffee));}
        }

        private Model.Coffee insertCoffee;

        public Model.Coffee InsertCoffee
        {
            get { return insertCoffee; }
            set { insertCoffee = value; }
        }

        private RelayCommand addCoffeeCommand;

        public RelayCommand AddCoffeeCommand
        {
            get { return addCoffeeCommand; }
            set { addCoffeeCommand = value; }
        }

        public void AddNewCoffee()
        {
            coffeeList.Add(insertCoffee);
        }

        private RelayCommand removeCoffeeCommand;

        public RelayCommand RemoveCoffeeCommand
        {
            get { return removeCoffeeCommand; }
            set { removeCoffeeCommand = value; }
        }

        public CoffeeViewModel()
        {
            coffeeList = new Model.CoffeeList();
            selectedCoffee = new Model.Coffee();
            insertCoffee = new Model.Coffee();
            addCoffeeCommand = new RelayCommand(AddNewCoffee); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
