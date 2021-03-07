using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bodega_Ventas.MODULOS.VENTAS_PRINCIPAL;

namespace Bodega_Ventas.MODULOS.BOLETAS
{
    public partial class FormBoletaVentas : Form
    {
        public FormBoletaVentas()
        {
            InitializeComponent();
        }

        Boleta_Ventas miboleta = new Boleta_Ventas();

        private void ImprimirBoleta()
        {
            try
            {
                int idVenta;

                //ServiceVentas.VentasSoapClient clienteVentas = new ServiceVentas.VentasSoapClient();
                //MessageBox.Show("Web Service Venta");
                ServiceBoleta.BoletaSoapClient clienteBoleta = new ServiceBoleta.BoletaSoapClient();
                idVenta = clienteBoleta.AutenticarBoleta(VENTAS_PRINCIPAL.ventasprincipalok.caja);

                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("imprimir_boleta", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idventa", idVenta);

                da.Fill(dt);
                con.Close();

                miboleta = new Boleta_Ventas();
                miboleta.DataSource = dt;
                miboleta.tablaInv.DataSource = dt;
                miboleta.txtTotalMonto.Value = Convert.ToString(VENTAS_PRINCIPAL.ventasprincipalok.mitotal);
                boletaVenta.Report = miboleta;

                boletaVenta.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormBoletaVentas_Load(object sender, EventArgs e)
        {
            ImprimirBoleta();
        }
    }
}
