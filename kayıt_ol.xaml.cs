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

namespace kutuphane
{
    /// <summary>
    /// kayıt_ol.xaml etkileşim mantığı
    /// </summary>
    public partial class kayıt_ol : Page
    {
        public kayıt_ol()
        {
            InitializeComponent();
        }
        bool cins;

        private void chech_erkek_Checked(object sender, RoutedEventArgs e)
        {
            chech_erkek.IsChecked = true;
            chech_kız.IsChecked = false;
            cins = true;
           

        }

        private void chech_kız_Checked(object sender, RoutedEventArgs e)
        {
            chech_erkek.IsChecked = false;
            chech_kız.IsChecked = true;
            cins = false;
            
        }

        private void kyt_btn(object sender, RoutedEventArgs e) {

            try
            {
                data.user user = new data.user();
                user.Ad = ad_text.Text.ToString().Trim();
                user.Soyad = soyad_text.Text.ToString().Trim();
                user.Parola = parola_text.Text.ToString().Trim();
                cins = user.Cinsiyet;
                if (ad_text.Text.Length >= 3 && soyad_text.Text.Length >= 3)
                {
                    dataaccess.user_method user_Method = new dataaccess.user_method();
                    user_Method.kayıt_ol();
                    MessageBox.Show("kayıt oldunuz");

                }


            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }


            
           
            
           

        

   
    }
}
