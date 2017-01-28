using App1.Database;
using App1.Stranka;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string iskanjeStrank;

        public MainPage()
        {
            this.InitializeComponent();
            if (!File.Exists("Avtomehanikdb.sqlite"))
            {
                Database.Database.Create();
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(Dodaj_User));
        }
        private void Iskanje_Click(object sender, RoutedEventArgs e)
        {
            iskanjeStrank = textBox.Text;

            var sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Avtomehanikdb.sqlite");

            using (var con = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
            {

                var query = con.Query<Database.Stranka>("SELECT * FROM STRANKA WHERE Ime = ? OR Priimek = ?", iskanjeStrank, iskanjeStrank);

                listView.ItemsSource = new ObservableCollection<Database.Stranka>(query);

            }

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var neki = e.AddedItems[0] as Database.Stranka;

            Frame.Navigate(typeof(Stranka_Page), neki);
        }
    }
}
