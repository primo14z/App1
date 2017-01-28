using App1.Database;
using System;
using System.Collections.Generic;
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
    public sealed partial class Dodaj_User : Page
    {
        public Dodaj_User()
        {
            this.InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string ime = textBox.Text;
            string priimek = textBox1.Text;
            string naslov = textBox2.Text;
            string telefon = textBox3.Text;
            string avto = textBox4.Text;

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {
                con.Insert(new Database.Stranka
                {
                    Ime = ime,
                    Priimek = priimek,
                    Naslov = naslov,
                    Telefonska = telefon,
                    Avto = avto
                });
            }
          this.Frame.Navigate(typeof(MainPage));
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
