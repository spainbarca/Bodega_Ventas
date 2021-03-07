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

namespace Bodega_Ventas.MODULOS.REPORTES.REPORTES_PEDIDOS
{
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
        }

        Reporte_Pedidos mipedido = new Reporte_Pedidos();

        private void ImprimirPedido()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("imprimir_pedido", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idpedido", CATALOGO.FormCatalogo.pedidoboleta);

                da.Fill(dt);
                con.Close();

                mipedido = new Reporte_Pedidos();
                mipedido.DataSource = dt;
                mipedido.tablaPedido.DataSource = dt;
                mipedido.txtTotalMonto.Value = Convert.ToString(CATALOGO.FormCatalogo.mitotal);
                reportViewerPedidos.Report = mipedido;

                reportViewerPedidos.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            ImprimirPedido();
        }
    }
}
