using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Data_Gr.xaml
    /// </summary>
    public partial class Data_Gr : Window
    {
        public Data_Gr()
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SignUpDB; Integrated Security=True");
                sqlCon.Open();
                String query = "Insert into SignupTable_ (StudentID, Username, Gender, BirthDate, BorrowerID, Department, ContactNum) values('" + this..Text + "','" + this. .Text + "','" + this..Text + "','" + this..Text + "','" + this..Text + "','" + this..Text + "','" + this.ContactNum.Text + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Account created successfully");
                MainWindow sign = new MainWindow();
                sqlCon.Close();
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            String dbConnection = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SignUpDB; Integrated Security=True";

            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                String query = "UPDATE SignupTable_ set UserID = '" + this. .Text + "'WHERE Username= '" + this. .Text + "'";
                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                //catches any mistake
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            String dbConnection = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=SignUpDB; Integrated Security=True";

            SqlConnection sqlCon = new SqlConnection(dbConnection);
            try
            {
                sqlCon.Open();
                String query = "DELETE from SignupTable_ WHERE StudentID = '" + this. .Text + "'";
                SqlCommand sqlCMD = new SqlCommand(query, sqlCon);
                sqlCMD.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted!");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                //catches any mistake
                MessageBox.Show(ex.Message);
            }


        }
    }
}
    

