using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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


        public CoffeeViewModel()
        {
            CoffeeList = new Model.CoffeeList();
            selectedCoffee = new Model.Coffee();
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
