using Bodega_Ventas.MODULOS;
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

namespace Bodega_Ventas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLlamar_Click(object sender, RoutedEventArgs e)
        {
            MODULOS.login i = new MODULOS.login();
            i.Show();
        }


        private void btnbd_Click(object sender, RoutedEventArgs e)
        {
            PANEL_ADMIN_SOFTWARE.conexion_manual cm = new PANEL_ADMIN_SOFTWARE.conexion_manual();
            cm.Show();
        }

        
    }
}
