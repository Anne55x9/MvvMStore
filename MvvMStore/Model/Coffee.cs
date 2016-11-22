using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; 

namespace MvvMStore.Model
{
    public class Coffee 
    {
        #region properties   
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;}
        }

        private string placeOfOrigin;

        public string PlaceOfOrigin
        {
            get { return placeOfOrigin; }
            set { placeOfOrigin = value; }
        }


        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion 

        public override string ToString()
        {
            return "Coffee Name: " + Name + ". " + "Place of origin: " + PlaceOfOrigin + ". " + "Price: " + Price + " kr.";
        }
    }
}
