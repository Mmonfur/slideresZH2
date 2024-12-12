using Microsoft.Maui.Controls;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        // Az abakusz sorokat tároló lista
        private List<AbacusRow> abacusRows;

        // Command properties
        public ICommand AddRowCommand { get; }
        public ICommand SumCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            abacusRows = new List<AbacusRow>();
            AddRow();  // Kezdetben hozzáadunk egy sort

            // Inicializáljuk a parancsokat
            AddRowCommand = new Command(OnAddRowClicked);
            SumCommand = new Command(OnSumClicked);

            // A BindingContext beállítása
            BindingContext = this;
        }

        // Abakusz sor hozzáadása
        private void AddRow()
        {
            // A következő helyi értéket számítjuk ki (az első sor helyi értéke 1, minden következő 10-szerese)
            int placeValue = (abacusRows.Count == 0) ? 1 : abacusRows.Last().PlaceValue * 10;

            // Új AbacusRow hozzáadása a listához
            abacusRows.Add(new AbacusRow { PlaceValue = placeValue, Value = 0 });

            // Az új sor hozzáadása után automatikusan frissíteni kell a CollectionView-t
            AbacusCollectionView.ItemsSource = null;
            AbacusCollectionView.ItemsSource = abacusRows;
        }

        // Összegzés
        private void OnSumClicked()
        {
            int sum = abacusRows.Sum(row => row.Value * row.PlaceValue);
            TotalLabel.Text = sum.ToString();
        }

        // Új sor gomb kezelése
        private void OnAddRowClicked()
        {
            AddRow();
        }
    }
}
