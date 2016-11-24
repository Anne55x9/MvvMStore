﻿using System;
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
    public class CoffeeViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Gemmer json data fra liste i localfolder
        /// </summary>
        StorageFolder localfolder = null;

        private readonly string filnavn = "JsonText.json";

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
            set { selectedCoffee = value; OnPropertyChanged(nameof(SelectedCoffee)); }
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
            Coffee tempCoffee = new Coffee();
            tempCoffee.Name = insertCoffee.Name;
            tempCoffee.PlaceOfOrigin = insertCoffee.PlaceOfOrigin;
            tempCoffee.Price = insertCoffee.Price;

            coffeeList.Add(tempCoffee);

        }


        private RelayCommand removeCoffeeCommand;

        public RelayCommand RemoveCoffeeCommand
        {
            get { return removeCoffeeCommand; }
            set { removeCoffeeCommand = value; }
        }

        public void RemoveCoffeeInList()
        {
            coffeeList.Remove(selectedCoffee);
        }


        public RelayCommand SaveCoffeeListCommand { get; set; }

        // FileIO er en statisk klasse.

        public async void SaveDataToDiscAsync()
        {
            string JsonText = this.CoffeeList.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(this.filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        public RelayCommand GetDataCommand { get; set; }

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

        public CoffeeViewModel()
        {
           
            //henter liste hvis der er en ellers opretter den en ny tom liste. 
            coffeeList = new Model.CoffeeList();
            selectedCoffee = new Model.Coffee();
            insertCoffee = new Model.Coffee();

            // man skal lave et nyt relaycommand object for forskellige commands man har.
            addCoffeeCommand = new RelayCommand(AddNewCoffee);
            removeCoffeeCommand = new RelayCommand(RemoveCoffeeInList);
            SaveCoffeeListCommand = new RelayCommand(SaveDataToDiscAsync);
            GetDataCommand = new RelayCommand(GetDataFromDiscAsync);

            //laver en instas af local folder
            localfolder = ApplicationData.Current.LocalFolder;


            //try
            //{
            //    GetDataFromDiscAsync();
            //}
            //catch (Exception)
            //{
            //    //throw;
            //    CoffeeList.Add(){NameCollisionOption  };
            //}
           
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
