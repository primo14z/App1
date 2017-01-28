using App1.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.Stranka
{
    public sealed partial class Stranka_Page : Page
    {
        private Database.Stranka parameters;
        private int Znesek_V = 0;
        private string Ime_Nalog = "";
        private DateTime Datum_Zacetek;
        private int Id;
        public Stranka_Page()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            parameters = (Database.Stranka)e.Parameter;

            ObservableCollection<Database.Stranka> stranke = new ObservableCollection<Database.Stranka>();

            Database.Stranka s1 = new Database.Stranka() { Ime = parameters.Ime, Priimek = parameters.Priimek, Naslov = parameters.Naslov, Telefonska = parameters.Telefonska, Avto = parameters.Avto };

            stranke.Add(s1);

            listView.ItemsSource = stranke;

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                var query = con.Query<Database.Nalog>("SELECT * FROM Nalog WHERE StrankaId = ?", parameters.Id);

                //foreach (var a in query)
                //{
                //    a.Datum_Zacetka = DateTime.Parse(a.Datum_Zacetka.ToString());
                //    string s2 = a.Datum_Zacetka.ToString("dd/MM/yyyy hh:mm:ss");
                //    a.Datum_Zacetka = Convert.ToDateTime(s2);
                //}
                listView1.ItemsSource = new ObservableCollection<Database.Nalog>(query);

            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Nalog.Dodaj_Nalog), parameters);
            Frame.Navigate(typeof(Nalog.Dodaj_Nalog), parameters);

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var neki = e.AddedItems[0] as Database.Nalog;
            
            Frame.Navigate(typeof(Nalog.Dodaj_Nalog), neki);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
