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

namespace Bodega_Ventas.MODULOS.REPORTES.REPORTES_KARDEX
{
    public partial class FormInventariosTodos : Form
    {
        public FormInventariosTodos()
        {
            InitializeComponent();
        }

        Reporte_Inventarios_Todos repInvTodos = new Reporte_Inventarios_Todos();

        private void MostrarInventarioTodos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("imprimir_inventarios_todos", con);
                
                da.Fill(dt);
                con.Close();

                repInvTodos = new Reporte_Inventarios_Todos();
                repInvTodos.DataSource = dt;
                repInvTodos.tablaInv.DataSource = dt;
                reportViewerInvTodos.Report = repInvTodos;

                reportViewerInvTodos.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormInventariosTodos_Load(object sender, EventArgs e)
        {
            MostrarInventarioTodos();
        }
    }
}
