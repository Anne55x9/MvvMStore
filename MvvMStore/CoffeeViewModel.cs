using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvMStore
{
    public class CoffeeViewModel
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
            set { selectedCoffee = value; }
        }


        public CoffeeViewModel()
        {
            CoffeeList = new Model.CoffeeList();
            selectedCoffee = new Model.Coffee();
        }
        
        
    }
}
