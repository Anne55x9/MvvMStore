using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MvvMStore.Model
{
    public class CoffeeList: ObservableCollection<Coffee>
    {
        public CoffeeList()
            :base()
        {
            this.Add(new Coffee() { Name = "Jaz", PlaceOfOrigin = "Nicaragua", Price = 150 });
            this.Add(new Coffee() { Name = "La Minita", PlaceOfOrigin = "Guetamala", Price =  170});
            this.Add(new Coffee() { Name = "Kenzi", PlaceOfOrigin = "Kenya", Price =  100 });
        }

    }
}
