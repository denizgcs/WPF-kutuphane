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
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace kutuphane
{
    /// <summary>
    /// kitaplar.xaml etkileşim mantığı
    /// </summary>
    public partial class kitaplar : Page
    {
        public kitaplar()
        {
            InitializeComponent();
        }
       

        int kitap_id;
        public static SqlConnection conn =new SqlConnection("Data Source=DESKTOP-3B70PO4\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True;Encrypt=False");

        public static  data.user user = new data.user();
        private void guncelle_btn_Click(object sender, RoutedEventArgs e)
        {
            
            puan_txt.Content = user.Puan;
            odunc_kitap_txt.Content = user.Kiralan_kitap;

            
            
            
            

        }
       
        public void listele()
        {



            try
            {
                SqlCommand cmd = new SqlCommand();

                if (combobox.SelectedIndex == 0)
                {


                    cmd.CommandText = "Select kitap_table.id,kitapad,yazar,kategori from kitap_table INNER JOIN kategoritbl ON kategoritbl.id=kitap_table.kategori_id where kitap_table.kitapad like '%" + bul.Text + "%' ";
                    cmd.Connection = conn;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    datagrid.ItemsSource = dt.DefaultView;



                }
                else
                {


                    cmd.CommandText = "Select kitap_table.id,kitapad,yazar,kategori from kitap_table INNER JOIN kategoritbl ON kategoritbl.id=kitap_table.kategori_id Where kitap_table.kitapad like '%" + bul.Text + "%' and kategoritbl.kategori='" + combobox.SelectedValue + "' ";
                    cmd.Connection = conn;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    datagrid.ItemsSource = dt.DefaultView;


                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            
            
            
            }



        }
       

        private void bul_btn_Click(object sender, RoutedEventArgs e)
        {
            
            listele();
           
            
        }
        
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                data.kitap kitap = new data.kitap();

                DataGrid dg = (DataGrid)sender;
                DataRowView selec = dg.SelectedItem as DataRowView;
                kitap.Kitap_İd= Convert.ToInt32(selec["id"]);
                
                kitap_ad_txt.Content = selec["kitapad"].ToString();
                yazar_txt.Content = selec["yazar"].ToString();
               
               



            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }

        }

        private void kirala_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                
                dataaccess.user_method usem = new dataaccess.user_method();

                dataaccess.kitap_method kmt = new dataaccess.kitap_method();
                if (user.Kiralan_kitap <= 3)
                {
                    
                    user.Kiralan_kitap += 1;
                    user.Puan += 1;                


                    kmt.kirala();
                    usem.guncelle_kitap();

                    MessageBox.Show("kitab kiranlandı");
                }
                else
                {
                    MessageBox.Show("kitap kiralam hakkınız dolmuştur sadece 3 kitap kiralıyabilirsiniz");


                }


            }
            catch { }
            
  
      
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            combobox.Items.Clear();
            combobox.Items.Add("Tümü");
            conn.Open();
            
            SqlCommand cmd = new SqlCommand("select  * from kategoritbl" ,conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) {

                combobox.Items.Add(rdr.GetSqlString(1));
                
            
            
            }
            combobox.SelectedIndex = 0;
            conn.Close();
            listele();
        }
    }
}
