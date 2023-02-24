using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DataGr.xaml
    /// </summary>
    public partial class DataGr : Page
    {
        public DataGr()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

                string dbsCon = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SignUpDB; Integrated Security=True";
                SqlConnection sqlCon_ = new SqlConnection(dbsCon);

                try
                {
                    sqlCon_.Open();
                    string query = "Select FirstName,Email from SignupTable_";
                    SqlCommand cmd = new SqlCommand(query, sqlCon_);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DataGrid_.ItemsSource = dt.AsDataView();
                    adapter.Update(dt);

                    MessageBox.Show("Successful loading");
                    sqlCon_.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        
    }
    }
    
    
