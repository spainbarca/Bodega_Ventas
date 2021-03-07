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
using System.Globalization;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Bodega_Ventas.MODULOS.INVENTARIO
{
    public partial class inventariokardexok : Form
    {
        public inventariokardexok()
        {
            InitializeComponent();
        }

        private void BuscarMovimientoProducto()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_productos_kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtBuscarMovimiento.Text);
                da.Fill(dt);
                datalistadoMovProd.DataSource = dt;
                con.Close();

                datalistadoMovProd.Columns[1].Visible = false;
                datalistadoMovProd.Columns[3].Visible = false;
                datalistadoMovProd.Columns[4].Visible = false;
                datalistadoMovProd.Columns[5].Visible = false;
                datalistadoMovProd.Columns[6].Visible = false;
                datalistadoMovProd.Columns[7].Visible = false;
                datalistadoMovProd.Columns[8].Visible = false;
                datalistadoMovProd.Columns[9].Visible = false;
                datalistadoMovProd.Columns[10].Visible = false;
                datalistadoMovProd.Columns[11].Visible = false;
                datalistadoMovProd.Columns[12].Visible = false;
                datalistadoMovProd.Columns[13].Visible = false;
                datalistadoMovProd.Columns[14].Visible = false;
                datalistadoMovProd.Columns[15].Visible = false;
                datalistadoMovProd.Columns[16].Visible = false;
                datalistadoMovProd.Columns[17].Visible = false;
                datalistadoMovProd.Columns[18].Visible = false;
                datalistadoMovProd.Columns[19].Visible = false;
                datalistadoMovProd.Columns[20].Visible = false;
                datalistadoMovProd.Columns[21].Visible = false;

                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoMovProd);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarMovimiento.Text == "Buscar producto" | txtBuscarMovimiento.Text == "")
            {
                datalistadoMovProd.Visible = false;

            }
            else
            {
                datalistadoMovProd.Visible = true;
                BuscarMovimientoProducto();
            }
        }

        public static int idProducto;

        private void datalistadoMovProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBuscarMovimiento.Text = datalistadoMovProd.SelectedCells[2].Value.ToString();
            datalistadoMovProd.Visible = false;
            BuscarMovimientos();

            try
            {
                idProducto = Convert.ToInt32(datalistadoMovProd.SelectedCells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private void BuscarMovimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_movimientos_kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@producto", datalistadoMovProd.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                datalistadoMovimientos.DataSource = dt;
                con.Close();


                datalistadoMovimientos.Columns[0].Visible = false;
                datalistadoMovimientos.Columns[11].Visible = false;
                datalistadoMovimientos.Columns[12].Visible = false;
                datalistadoMovimientos.Columns[13].Visible = false;
                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FiltrosMovimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("filtro_movimientos_kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", dateFechaMov.Value);
                da.SelectCommand.Parameters.AddWithValue("@tipo", cbxTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@id_usuario", txtIdusuario.Text);


                da.Fill(dt);
                datalistadoMovimientos.DataSource = dt;
                con.Close();


                datalistadoMovimientos.Columns[0].Visible = false;
                datalistadoMovimientos.Columns[15].Visible = false; //empresa
                datalistadoMovimientos.Columns[16].Visible = false; //logotipo

                datalistadoMovimientos.Columns[11].Visible = false;
                datalistadoMovimientos.Columns[10].Visible = false; //los cat, sub, marca
                datalistadoMovimientos.Columns[9].Visible = false;

                datalistadoMovimientos.Columns[13].Visible = false;
                datalistadoMovimientos.Columns[14].Visible = false; //filtros
                datalistadoMovimientos.Columns[12].Visible = false;
                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FiltrosAcumuladoMovimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("filtroacumulado_movimientos_kardex", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", dateFechaMov.Value);
                da.SelectCommand.Parameters.AddWithValue("@tipo", cbxTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@id_usuario", txtIdusuario.Text);


                da.Fill(dt);
                datalistadoMovAcum.DataSource = dt;
                con.Close();


                datalistadoMovAcum.Columns[4].Visible = false;
                datalistadoMovAcum.Columns[5].Visible = false;
                datalistadoMovAcum.Columns[6].Visible = false;

                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoMovAcum);
                //DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
                //styCabeceras.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
                //styCabeceras.ForeColor = System.Drawing.Color.White;
                //styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                //datalistadoMovAcum.ColumnHeadersDefaultCellStyle = styCabeceras;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFiltrosAvanzados_Click(object sender, EventArgs e)
        {
            groupFiltrosAvanzados.Visible = true;
            datalistadoMovProd.Visible = false;
            cbxTipoMovi.Text = "-Todos-";
            FiltrosMovimientos();
            FiltrosAcumuladoMovimientos();
            pnlAcumulado.Visible = true;
            btnImprimirFiltro.Visible = false;
            btnFiltrosAvanzados.Visible = false;
        }

        private void btnImprimirFiltro_Click(object sender, EventArgs e)
        {

        }

        private void inventariokardexok_Load(object sender, EventArgs e)
        {
            pnlMovimientos.Dock = DockStyle.None;
            pnlReporteInventario.Dock = DockStyle.None;
            pnlInventarioBajo.Dock = DockStyle.None;
            pnlMovimientos.Visible = false;
            pnlReporteInventario.Visible = false;
            pnlInventarioBajo.Visible = false;
            pnlKardex.Visible = true;
            pnlKardex.Dock = DockStyle.Fill;
            Panelv.Visible = false;
            pnlVencimientos.Visible = false;
            pnlVencimientos.Dock = DockStyle.None;

            PanelK.Visible = true;
            PanelI.Visible = false;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;

            txtBuscarKardex.Text = "Buscar producto";
        }

        internal void BuscarIDUsuario()
        {
            string resultado;
            string queryMoneda;
            queryMoneda = "buscar_idusuario";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;

            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            comMoneda.CommandType = CommandType.StoredProcedure;
            comMoneda.Parameters.AddWithValue("@nom_usu", cbxUsuarios.Text);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                txtIdusuario.Text = resultado;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                resultado = "";
            }
        }

        private void cbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupFiltrosAvanzados.Visible==true)
            {
                BuscarIDUsuario();
                FiltrosMovimientos();
                FiltrosAcumuladoMovimientos();
            }
        }

        private void BuscarUsuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("select * from usuarios", con);

                da.Fill(dt);
                cbxUsuarios.DisplayMember = "nom_usu";
                cbxUsuarios.ValueMember = "id_usu";

                cbxUsuarios.DataSource = dt;
                //txtIdusuario.Text = txtUSUARIOS.ValueMember;

                con.Close();
                BuscarIDUsuario();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void cbxTipoMovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupFiltrosAvanzados.Visible == true)
            {
                FiltrosMovimientos();
                FiltrosAcumuladoMovimientos();
            }
        }

        private void dateFechaMov_ValueChanged(object sender, EventArgs e)
        {
            if (groupFiltrosAvanzados.Visible == true)
            {
                FiltrosMovimientos();
                FiltrosAcumuladoMovimientos();
            }
        }

        private void btnOcultarFiltro_Click(object sender, EventArgs e)
        {
            pnlAcumulado.Visible = false;
            groupFiltrosAvanzados.Visible = false;
            BuscarMovimientos();
            cbxTipoMovi.Text = "-Todos-";
            txtBuscarMovimiento.Text = "Buscar producto";
            MenuStrip2.Visible = true;
            MenuStrip6.Visible = true;
        }

        private void MostrarInventariosBajo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_inventarios_bajo", con);;
                da.Fill(dt);
                datalistadoInvBajo.DataSource = dt;
                con.Close();

                datalistadoInvBajo.Columns[0].Visible = false;
                datalistadoInvBajo.Columns[8].Visible = false;
                datalistadoInvBajo.Columns[9].Visible = false;
                datalistadoInvBajo.Columns[10].Visible = false;

                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoInvBajo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBajos_Click(object sender, EventArgs e)
        {
            pnlKardex.Dock = DockStyle.None;
            pnlMovimientos.Dock = DockStyle.None;
            pnlInventarioBajo.Dock = DockStyle.Fill;
            pnlReporteInventario.Dock = DockStyle.None;
            pnlVencimientos.Dock = DockStyle.None;

            pnlKardex.Visible = false;
            pnlMovimientos.Visible = false;
            pnlInventarioBajo.Visible = true;
            pnlReporteInventario.Visible = false;
            pnlVencimientos.Visible = false;

            PanelK.Visible = false;
            PanelM.Visible = false;
            PanelI.Visible = true;
            PanelR.Visible = false;
            Panelv.Visible = false;

            MostrarInventariosBajo();
        }

        private void txtBuscarRepInv_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarRepInv.Text== "Buscar...")
            {
                MostrarInventariosTodos();
            }
        }

        private void MostrarInventariosTodos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_inventarios_todos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscarRepInv.Text);


                da.Fill(dt);
                datalistadoRepInv.DataSource = dt;
                con.Close();


                datalistadoRepInv.Columns[0].Visible = false;
                datalistadoRepInv.Columns[11].Visible = false;
                datalistadoRepInv.Columns[12].Visible = false;

                //DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
                //styCabeceras.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
                //styCabeceras.ForeColor = System.Drawing.Color.White;
                //styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                //datalistadoMovAcum.ColumnHeadersDefaultCellStyle = styCabeceras;
                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoRepInv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            txtBuscarRepInv.Clear();
            MostrarInventariosTodos();
        }

        internal void SumarCostoInventario()
        {
            string resultado;
            string queryMoneda;
            queryMoneda = "SELECT moneda FROM empresa";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                resultado = "";
            }

            string importe;
            string query;
            query = "SELECT      CONVERT(NUMERIC(18,2),sum(producto.precio_compra * stock )) as suma FROM  producto where  usa_inventario ='SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblCostoInv.Text = resultado + " " + importe;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                lblCostoInv.Text = resultado + " " + 0;
            }

            string conteoresultado;
            string querycontar;
            querycontar = "select count(id_prod) from producto ";
            SqlCommand comcontar = new SqlCommand(querycontar, con);
            try
            {
                con.Open();
                conteoresultado = Convert.ToString(comcontar.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblCantidadProdInv.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                conteoresultado = "";
                lblCantidadProdInv.Text = "0";
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            pnlKardex.Dock = DockStyle.None;
            pnlMovimientos.Dock = DockStyle.None;
            pnlInventarioBajo.Dock = DockStyle.None;
            pnlReporteInventario.Dock = DockStyle.Fill;
            pnlVencimientos.Dock = DockStyle.None;

            pnlKardex.Visible = false;
            pnlMovimientos.Visible = false;
            pnlInventarioBajo.Visible = false;
            pnlReporteInventario.Visible = true;
            pnlVencimientos.Visible = false;

            PanelK.Visible = false;
            PanelM.Visible = false;
            PanelI.Visible = false;
            PanelR.Visible = true;
            Panelv.Visible = false;

            MostrarInventariosTodos();
            SumarCostoInventario();
        }

        private void txtBuscarVenc_TextChanged(object sender, EventArgs e)
        {
            BuscarProductosVencidos();
            CheckPorVenceren30Dias.Checked = false;
            CheckProductosVencidos.Checked = false;
        }

        private void BuscarProductosVencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_productos_vencidos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscarVenc.Text);

                da.Fill(dt);
                datalistadoVenc.DataSource = dt;
                con.Close();


                datalistadoVenc.Columns[0].Visible = false;
                datalistadoVenc.Columns[1].Visible = false;
                datalistadoVenc.Columns[6].Visible = false;
                datalistadoVenc.Columns[7].Visible = false;
                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoVenc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscarVenc_Click(object sender, EventArgs e)
        {
            txtBuscarVenc.SelectAll();
        }

        private void CheckPorVenceren30Dias_CheckedChanged(object sender, EventArgs e)
        {
            MostrarVencimientos30Dias();
            txtBuscarVenc.Text = "Buscar producto/Codigo";
        }

        private void MostrarVencimientos30Dias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_vencimientos_30dias", con);


                da.Fill(dt);
                datalistadoVenc.DataSource = dt;
                con.Close();


                datalistadoVenc.Columns[0].Visible = false;
                datalistadoVenc.Columns[1].Visible = false;

                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoVenc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarProductosVencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_productos_vencidos", con);


                da.Fill(dt);
                datalistadoVenc.DataSource = dt;
                con.Close();


                datalistadoVenc.Columns[0].Visible = false;
                datalistadoVenc.Columns[1].Visible = false;

                CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoVenc);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckProductosVencidos_CheckedChanged(object sender, EventArgs e)
        {
            MostrarProductosVencidos();
            txtBuscarVenc.Text = "Buscar producto/Codigo";
        }

        private void btnBuscarVenc_Click(object sender, EventArgs e)
        {

        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            pnlMovimientos.Dock = DockStyle.None;
            pnlReporteInventario.Dock = DockStyle.None;
            pnlInventarioBajo.Dock = DockStyle.None;
            pnlMovimientos.Visible = false;
            pnlReporteInventario.Visible = false;
            pnlInventarioBajo.Visible = false;
            pnlKardex.Visible = true;
            pnlKardex.Dock = DockStyle.Fill;
            Panelv.Visible = false;
            pnlVencimientos.Visible = false;
            pnlVencimientos.Dock = DockStyle.None;

            PanelK.Visible = true;
            PanelI.Visible = false;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;

            txtBuscarKardex.Text = "Buscar producto";
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            pnlKardex.Dock = DockStyle.None;
            pnlMovimientos.Dock = DockStyle.Fill;
            pnlInventarioBajo.Dock = DockStyle.None;
            pnlReporteInventario.Dock = DockStyle.None;
            pnlVencimientos.Dock = DockStyle.None;

            pnlKardex.Visible = false;
            pnlMovimientos.Visible = true;
            pnlInventarioBajo.Visible = false;
            pnlReporteInventario.Visible = false;
            pnlVencimientos.Visible = false;

            PanelK.Visible = false;
            PanelM.Visible = true;
            PanelI.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;

            txtBuscarMovimiento.Text = "Buscar producto";

            BuscarMovimientoProducto();
            BuscarUsuario();
            BuscarIDUsuario();
        }

        private void btnVencimientos_Click(object sender, EventArgs e)
        {
            pnlKardex.Dock = DockStyle.None;
            pnlMovimientos.Dock = DockStyle.None;
            pnlInventarioBajo.Dock = DockStyle.None;
            pnlReporteInventario.Dock = DockStyle.None;
            pnlVencimientos.Dock = DockStyle.Fill;

            pnlKardex.Visible = false;
            pnlMovimientos.Visible = false;
            pnlInventarioBajo.Visible = false;
            pnlReporteInventario.Visible = false;
            pnlVencimientos.Visible = true;

            PanelK.Visible = false;
            PanelM.Visible = false;
            PanelI.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = true;

            txtBuscarVenc.Text = "Buscar producto/Codigo";
        }

        private void datalistadoMovAcum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
