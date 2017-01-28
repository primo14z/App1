using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace App1.Nalog
{
    public sealed partial class Dodaj_Nalog : Page
    {
        private string Ime_Naloga = "";
        private Database.Stranka parameterS;
        private Database.Nalog parameterN;
        private int kolicina;
        private string opravilo;
        private int znesek;
        public Dodaj_Nalog()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Database.Stranka)
            {
                parameterS = (Database.Stranka)e.Parameter;
            }
            else
            {
                parameterN = (Database.Nalog)e.Parameter;

                var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

                using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
                {
                    var query = con.Query<Database.Opravilo>("SELECT * FROM Opravilo WHERE NalogId= ?", parameterN.Id);

                    gridView.ItemsSource = new ObservableCollection<Database.Opravilo>(query);

                }
            }

            if (parameterS == null)
            {
                textBlock.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Collapsed;
                button.Visibility = Visibility.Collapsed;
            }
            else
            {

                textBlock1.Visibility = Visibility.Collapsed;
                textBlock2.Visibility = Visibility.Collapsed;
                textBlock3.Visibility = Visibility.Collapsed;
                textBox1.Visibility = Visibility.Collapsed;
                textBox2.Visibility = Visibility.Collapsed;
                textBox3.Visibility = Visibility.Collapsed;
                button1.Visibility = Visibility.Collapsed;
            }




        }

        private void DodajNalog(object sender, RoutedEventArgs e)
        {
            Ime_Naloga = textBox.Text;

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                con.Insert(new Database.Nalog
                {
                    Znesek = 0,
                    Datum_Zacetka = DateTime.Now,
                    StrankaId = parameterS.Id,
                    Ime_Naloga = Ime_Naloga
                });
            }

            Frame.Navigate(typeof(Stranka.Stranka_Page), parameterS);
        }

        private void DodajOpravilo(object sender, RoutedEventArgs e)
        {
            znesek = Convert.ToInt32(textBox3.Text);
            kolicina = Convert.ToInt32(textBox1.Text);
            opravilo = textBox2.Text;

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                con.Insert(new Database.Opravilo
                {
                    Znesek = znesek * kolicina,
                    Kolicina = kolicina,
                    Ime_Opravila = opravilo,
                    NalogId = parameterN.Id
                });
                var query = con.Query<Database.Nalog>("UPDATE Nalog SET Znesek=? WHERE Id=?", znesek * kolicina, parameterN.Id);

                refresh();
            }
        }

        private void refresh()
        {
            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                var query = con.Query<Database.Opravilo>("SELECT * FROM Opravilo WHERE NalogId= ?", parameterN.Id);

                gridView.ItemsSource = new ObservableCollection<Database.Opravilo>(query);

            }
        }

        private void IzbrisiOpravilo(object sender, RoutedEventArgs e)
        {
            Button _button = (Button)sender;
            var id = _button.Tag;

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                var query = con.Query<Database.Opravilo>("DELETE FROM Opravilo WHERE Id =?", id);

            }
            refresh();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (parameterS == null)
            {
                var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

                using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
                {
                    var query = con.Query<Database.Stranka>("SELECT * FROM Stranka WHERE Id =?", parameterN.StrankaId);
                    Database.Stranka s = new Database.Stranka();
                    foreach (var a in query)
                    {
                        s = a;
                    };
                    Frame.Navigate(typeof(Stranka.Stranka_Page), s);
                }
            }
            else
            {
                Frame.Navigate(typeof(Stranka.Stranka_Page), parameterS);
            }


        }
    }
}
