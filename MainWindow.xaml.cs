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
using data;
using dataaccess;

namespace kutuphane
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void kaydol_button_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new kayıt_ol());
            frame.Width = 1100;
            frame.Height = 550; 
        
        }

        private void giris_button_Click(object sender, RoutedEventArgs e)
        {
            data.user user = new data.user();
            dataaccess.user_method user_Method = new dataaccess.user_method();
            user.Ad = ad_input.Text.ToString().Trim();
            user.Parola = parola_input.Text.ToString().Trim();
            user_Method.giris_yap();
            if (user.Dogrula == true)
            {
                frame.NavigationService.Navigate(new home());

            }
            else
            {
                MessageBox.Show("ad veya parola yanlış");
            }
        }
    }
}
