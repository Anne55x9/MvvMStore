using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; 

namespace MvvMStore.Model
{
    public class Coffee 
    {
        //3 forskellige properties til kaffebutik.
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

        //Giver navn, place of origin og price i tekst på UI (viewet). 
        public override string ToString()
        {
            
            return "Coffee Name: " + Name + ". " + "Place of origin: " + PlaceOfOrigin + ". " + "Price: " + Price + " kr.";
        }
    }
}
