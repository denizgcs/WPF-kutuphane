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
using System.Data.SqlClient;

namespace kutuphane
{
    /// <summary>
    /// hesap1.xaml etkileşim mantığı
    /// </summary>
    public partial class hesap1 : Page
    {
       
        public hesap1()
        {
            InitializeComponent();
        }
        public static data.user user=new data.user();
        public static dataaccess.user_method usermth = new dataaccess.user_method();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
            
            ad_soyad_txt.Content = user.Ad + "  "+ user.Soyad;
            puan_txt.Content = user.Puan;
            kirl_ktp_txt.Content = user.Kiralan_kitap;
            switch (user.Cinsiyet)
            {
                case false:
                    cinsiye_txt.Content = "kız";
                    break;
                case true:
                    cinsiye_txt.Content = "Erkek";
                    break;

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usermth.parola_güncelle(Convert.ToString(parola_txt.Text));
            MessageBox.Show("parola güncellendi");
            

        }
    }
}
