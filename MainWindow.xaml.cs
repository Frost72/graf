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

namespace Графы
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            AlgoritmA algoritmA = new AlgoritmA();
            algoritmA.Show();
        }

        private void Li_Click(object sender, RoutedEventArgs e)
        {
            LeeAlgor leeAlgor = new LeeAlgor();
            leeAlgor.Show();
        }
    }
}