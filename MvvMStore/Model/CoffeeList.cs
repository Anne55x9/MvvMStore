using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;


namespace MvvMStore.Model
{
    /// <summary>
    /// ObservableCollection (system.collection.objectModel) er en dynamisk data samling, 
    /// som notificerer viewmodel når elementer er tilføjet, fjernet eller hele lister bliver updateret i viewet. 
    /// </summary>
    public class CoffeeList : ObservableCollection<Coffee>
    {
        public CoffeeList()
            : base()
        {
            this.Add(new Coffee() { Name = "Jaz", PlaceOfOrigin = "Nicaragua", Price = 150 });
            this.Add(new Coffee() { Name = "La Minita", PlaceOfOrigin = "Guetamala", Price = 170 });
            this.Add(new Coffee() { Name = "Kenzi", PlaceOfOrigin = "Kenya", Price = 100 });
        }

       /// <summary>
       /// Json syntax implementeres via nuget Manager i Csharp og 'using Newtonsoft.Json'.
       /// Metode som giver mig Json Af min kaffeliste (serializeObject).
       /// </summary>
       /// <returns></returns>
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }


        /// <summary>
        /// Metode som giver mig Json liste konverteret til csharp syntax (deserializeObject).
        /// </summary>
        /// <param name="jsonText"></param>
        public void InsertJson(string jsonText)
        {
            List<Coffee> nyListe = JsonConvert.DeserializeObject<List<Coffee>>(jsonText);
            foreach (var coffee in nyListe)
            {
                this.Add(coffee);

            }
        }

    }
}
