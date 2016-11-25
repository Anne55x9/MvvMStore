using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MvvMStore.Model;
using MvvMStore.ViewModel;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;


namespace MvvMStore
{
    /// <summary>
    /// Min View Model klasse implementerer interfacen INotifyPropertyChanged og bruger system.ComponentModel. 
    /// </summary>
    public class CoffeeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gemmer json data fra liste i localfolder ved brug af using system.Storage.
        /// </summary>
        StorageFolder localfolder = null;
        private readonly string filnavn = "JsonText.json";

        /// <summary>
        /// Private instans fields som indeholder kaffelisten, 
        /// </summary>
        private Model.CoffeeList coffeeList;
        private Model.Coffee selectedCoffee;
        private Model.Coffee insertCoffee;

        /// <summary>
        /// private instanser som indeholder commands til at tilføje og fjerne kaffe fra kaffeliste. 
        /// </summary>
        private RelayCommand addCoffeeCommand;
        private RelayCommand removeCoffeeCommand;

        public CoffeeViewModel()
        {
            //henter liste med kaffer. 
            coffeeList = new Model.CoffeeList();
            //Valg af kaffer. Fjernes kaffer i viewet notiferes til mainview model via OnPropertyChanged.
            selectedCoffee = new Model.Coffee();
            //Tilføjer kaffer til listen.
            insertCoffee = new Model.Coffee();

            // Laver et nyt relaycommand object for forskellige commands man har.
            addCoffeeCommand = new RelayCommand(AddNewCoffee);
            removeCoffeeCommand = new RelayCommand(RemoveCoffeeInList);
            SaveCoffeeListCommand = new RelayCommand(SaveDataToDiscAsync);
            GetDataCommand = new RelayCommand(GetDataFromDiscAsync);

            //laver en instans af local folder
            localfolder = ApplicationData.Current.LocalFolder;
        }

        /// <summary>
        /// Metoderne jeg gør brug af i min MvvM kaffebutik
        /// </summary>

        public Model.CoffeeList CoffeeList
        {
            get { return coffeeList; }
            set { coffeeList = value; }
        }

        /// <summary>
        /// Denne metode implementerer INotiFyPropertyChanged interfacen. Når 
        /// </summary>
        public Model.Coffee SelectedCoffee
        {
            get { return selectedCoffee; }
            set { selectedCoffee = value; OnPropertyChanged(nameof(SelectedCoffee)); }
        }

        public Model.Coffee InsertCoffee
        {
            get { return insertCoffee; }
            set { insertCoffee = value; }
        }

        /// <summary>
        /// I denne metode vil det være relevant at håndtere hvis bruger trykker 'add to coffee list' 
        /// uden at have skrevet noget i felterne Name, Place of Origin og pris. 
        /// </summary>
        public void AddNewCoffee()
        {
            Coffee tempCoffee = new Coffee();
            tempCoffee.Name = insertCoffee.Name;
            tempCoffee.PlaceOfOrigin = insertCoffee.PlaceOfOrigin;
            tempCoffee.Price = insertCoffee.Price;

            coffeeList.Add(tempCoffee);
        }

        public void RemoveCoffeeInList()
        {
            coffeeList.Remove(selectedCoffee);
        }

        public RelayCommand AddCoffeeCommand
        {
            get { return addCoffeeCommand; }
            set { addCoffeeCommand = value; }
        }

        public RelayCommand RemoveCoffeeCommand
        {
            get { return removeCoffeeCommand; }
            set { removeCoffeeCommand = value; }
        }

        public RelayCommand SaveCoffeeListCommand { get; set; }
        public RelayCommand GetDataCommand { get; set; }

        // FileIO er en statisk klasse.
        /// <summary>
        /// Async and await til at lave et responsivt brugerflade design. 
        /// </summary>

        public async void SaveDataToDiscAsync()
        {
            string JsonText = this.CoffeeList.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(this.filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        /// <summary>
        /// Metoden inkluderer exceptionhåndtering med try/catch med message box (using Windows.UI.Popups). 
        /// Det går ud på at hvis der ikke er gemt en fil med listen i Json format så
        /// vises en besked box med titel og forklarende indhold til bruger. 
        /// </summary>

        public async void GetDataFromDiscAsync()
        {
            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);

                this.CoffeeList.Clear();
                CoffeeList.InsertJson(jsonText);
            }
            catch (Exception)
            {
                MessageDialog NoData = new MessageDialog("No Data Found", "Error!");
                await NoData.ShowAsync();
            }
        }

        /// <summary>
        /// Event Handler ved ændringer i view model notiferes view Modellen.
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Metode til at håndterer events ved OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName"></param>

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
