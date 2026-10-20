using Microsoft.Data.SqlClient;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection? conexao = null;

        public MainWindow()
        {
            InitializeComponent();

            string URL =
                   "Data Source=(localdb)\\MSSQLLocalDB;" +
                   "Initial Catalog=abricodb;" +
                   "Integrated Security=True;";

            try
            {
                conexao = new(URL);
                conexao.Open();
                LabelStatus.Content = "Conexão OK";
            }
            catch (Exception ex)
            {
                LabelStatus.Content = "Conexão NOT";
                MessageBox.Show(ex.Message, "Erro de conexão");
            }
        }
    }
}