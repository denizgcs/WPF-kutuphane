using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
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
using System.Threading;

namespace kutuphane
{
    /// <summary>
    /// kiralan_kitap.xaml etkileşim mantığı
    /// </summary>
    public partial class kiralan_kitap : Page
    {
        public static int id;
        public static data.user user = new data.user();

        public SqlConnection conn = new  SqlConnection("Data Source=DESKTOP-3B70PO4\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True;Encrypt=False");

        public kiralan_kitap()
        {
            InitializeComponent();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)sender;
                DataRowView selec = dg.SelectedItem as DataRowView;
                kitap_ad_txt.Content = selec["kitapad"].ToString();
                yazar_txt.Content = selec["yazar"].ToString();
                tarih_txt.Content = selec["tarih"].ToString();
                id = Convert.ToInt32(selec["kitap_id"]);

            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }



        }
      

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            listele();
        }
        
        public void listele() { 
            
            data.user user = new data.user();   
            SqlCommand cmd = new SqlCommand("select kitap_id,kitapad,yazar,tarih from odunc INNER JOIN kitap_table on odunc.kitap_id=kitap_table.id Where user_id='"+user.İd+"'",conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            datagrid.ItemsSource = dt.DefaultView;
        
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            dataaccess.kitap_method kmh = new dataaccess.kitap_method();
            kmh.teslim_et(id,user.Kiralan_kitap-1);
            listele();

        }
    }
}
