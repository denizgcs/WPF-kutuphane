using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kutuphane
{
    /// <summary>
    /// home.xaml etkileşim mantığı
    /// </summary>
    public partial class home : Page
    {
        public home()
        {
            InitializeComponent();
        }

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new kitaplar());
        }

        private void  kitaplar_btn(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new kitaplar());

        }

        

        private void hesap_btn(object sender, RoutedEventArgs e)
        {

            frame.NavigationService.Navigate(new hesap1());
        }


        private void kiralanan_btn(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new kiralan_kitap());


        }

        private void cıkıs_btn(object sender, RoutedEventArgs e)
        {
            
            Environment.Exit(0);


        }



     
    }
}
