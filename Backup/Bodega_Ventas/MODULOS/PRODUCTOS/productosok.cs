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
using System.Management;
using System.Runtime.CompilerServices;
using Bodega_Ventas.CONEXION;

namespace Bodega_Ventas.MODULOS.PRODUCTOS
{
    public partial class productosok : Form
    {
        int conta;
        public productosok()
        {
            InitializeComponent();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            pnlRegistro.Visible = true;

            CheckInventarios.Checked = true;
            PANELINVENTARIO.Visible = true;
            txtPorcentajeGanancia.Clear();

            lblEstadoCodigo.Text = "NUEVO";

            txtApartir.Text = "0";
            txtPrecioVenta.ReadOnly = false;
            Panel25.Enabled = true;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel18.Visible = false;
            TXTIDPRODUCTOOk.Text = "0";

            PANELINVENTARIO.Visible = true;

            txtDescripcion.AutoCompleteCustomSource = CONEXION.DataHelper.LoadAutoComplete();
            txtDescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtDescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            pnlRegistro.Visible = true;
            porunidad.Checked = true;
            No_aplica_fecha.Checked = false;
            Panel6.Visible = false;

            Limpiar();
            btnagregaryguardar.Visible = true;
            btnagregar.Visible = false;


            txtDescripcion.Text = "";
            PANELINVENTARIO.Visible = true;


            TGUARDAR.Visible = true;
            pbxGuardarCambios.Visible = false;

        }

        private void Limpiar()
        {
            lblIdProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "0";
            txtPrecioVenta.Text = "0";
            txtMayoreo.Text = "0";

            agranel.Checked = false;
            txtstockminimo.Text = "0";
            txtStock.Text = "0";
            lblEstadoCodigo.Text = "NUEVO";
        }

        public static int idusuario;
        public static int idcaja;

        private void MostrarCajaSerial()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;

            SqlCommand com = new SqlCommand("mostrar_cajas_serialHDD", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@serial", lblSerialPc.Text);
            try
            {
                con.Open();
                idcaja = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarInicioSesion()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar; ;

            SqlCommand com = new SqlCommand("mostrar_inicio_sesion", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id_serialpc", CONEXION.EncriptarTexto.Encriptar(lblSerialPc.Text));
           
            try
            {
                con.Open();
                idusuario = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void productosok_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";

            pnlRegistro.Visible = false;

            txtBuscar.Text = "Buscar...";
            SumarCostoInventario();
            Buscar();

            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
            lblSerialPc.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblSerialPc.Text = lblSerialPc.Text.Trim();

            MostrarInicioSesion();
            MostrarCajaSerial();
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnLupaSub_Click(object sender, EventArgs e)
        {
            pnlSubcategoria.Visible = true;
        }

        private void btnLupaMarca_Click(object sender, EventArgs e)
        {
            pnlMarca.Visible = true;
            MostrarMarca();
        }

        private void MostrarMarca()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_marca", con);
                da.Fill(dt);
                datalistadoMarca.DataSource = dt;
                con.Close();
                datalistadoMarca.Columns[0].Visible = false;
                datalistadoMarca.Columns[1].Visible = true;
                datalistadoMarca.Columns[2].Visible = false;
                datalistadoMarca.Columns[3].Visible = true;
                datalistadoMarca.Columns[4].Visible = false;
                datalistadoMarca.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoMarca);
        }

        private void datalistadoMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdMarca.Text = datalistadoMarca.SelectedCells[0].Value.ToString();
            txtSelecMarca.Text = datalistadoMarca.SelectedCells[3].Value.ToString();
        }

        private void btnNuevoMarca_Click(object sender, EventArgs e)
        {
            lblIdMarca.Text = "";
            txtSelecMarca.Text = "";
        }

        private void btnSelecMarca_Click(object sender, EventArgs e)
        {
            if (lblIdMarca.Text!="")
            {
                String marca = txtSelecMarca.Text;
                txtMarca.Text = marca;
                pnlMarca.Visible = false;
            }
            else
            {
                MessageBox.Show("Seleccione una marca");
            }
        }

        private void MostrarSubCat()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_subcategoria", con);
                da.Fill(dt);
                datalistadoSub.DataSource = dt;
                con.Close();
                datalistadoSub.Columns[0].Visible = false;
                datalistadoSub.Columns[1].Visible = true;
                datalistadoSub.Columns[2].Visible = true;
                datalistadoSub.Columns[3].Visible = true;
                datalistadoSub.Columns[4].Visible = false;
                datalistadoSub.Columns[5].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoSub);
        }

        private void datalistadoSub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdSub.Text = datalistadoSub.SelectedCells[0].Value.ToString();
            txtSelecCat.Text = datalistadoSub.SelectedCells[2].Value.ToString();
            txtSelecSub.Text = datalistadoSub.SelectedCells[3].Value.ToString();
            lblIdCat.Text = datalistadoSub.SelectedCells[5].Value.ToString();
        }

        private void btnSelecSub_Click(object sender, EventArgs e)
        {
            if (lblIdSub.Text != "")
            {
                String subcategoria = txtSelecSub.Text;
                String categoria = txtSelecCat.Text;
                txtCategoria.Text = categoria;
                txtSubcategoria.Text = subcategoria;
                pnlSubcategoria.Visible = false;
            }
            else
            {
                MessageBox.Show("Seleccione una subcategoría");
            }
        }

        private void btnNuevoSub_Click(object sender, EventArgs e)
        {
            lblIdSub.Text = "";
            txtSelecCat.Text = "";
            txtSelecSub.Text = "";
        }

        private void stpLupa_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pnlSubcategoria.Visible = true;
            MostrarSubCat();
        }

        private void InsertarProductos()
        {
            if (txtMayoreo.Text=="0")
            {
                txtApartir.Text = "0";
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("insertar_producto", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@nombre_prod", txtDescripcion.Text);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureProd.Image.Save(ms, pictureProd.Image.RawFormat);
                sql.Parameters.AddWithValue("@imagen", ms.GetBuffer());
                sql.Parameters.AddWithValue("@categoria", lblIdCat.Text);
                sql.Parameters.AddWithValue("@subcategoria", lblIdSub.Text);
                sql.Parameters.AddWithValue("@marca", lblIdMarca.Text);
                
                sql.Parameters.AddWithValue("@precio_compra", txtPrecioCompra.Text);
                sql.Parameters.AddWithValue("@precio_venta", txtPrecioVenta.Text);
                sql.Parameters.AddWithValue("@codigo", txtCodigoBarras.Text);
                
                if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                if (porunidad.Checked == true) txtse_vende_a.Text = "Granel";
                sql.Parameters.AddWithValue("@unidades", txtse_vende_a.Text);

                sql.Parameters.AddWithValue("@impuesto", txtprecio_sin_impuestos.Text);
                
                sql.Parameters.AddWithValue("@precio_mayor", txtMayoreo.Text);
                sql.Parameters.AddWithValue("@a_partir_de", txtApartir.Text);

                if (PANELINVENTARIO.Visible==true)
                {
                    sql.Parameters.AddWithValue("@usa_inventario", "SI");
                    sql.Parameters.AddWithValue("@stock_min", txtstockminimo.Text);
                    sql.Parameters.AddWithValue("@stock", txtStock.Text);
                    if (No_aplica_fecha.Checked == true)
                    {
                        sql.Parameters.AddWithValue("@fecha_venc", "NO APLICA");
                    }
                    if (No_aplica_fecha.Checked == false)
                    {
                        sql.Parameters.AddWithValue("@fecha_venc", txtfechaoka.Text);
                    }
                }
                if (PANELINVENTARIO.Visible==false)
                {
                    sql.Parameters.AddWithValue("@usa_inventario", "NO");
                    sql.Parameters.AddWithValue("@stock_min", 0);
                    sql.Parameters.AddWithValue("@fecha_venc", "NO APLICA");
                    sql.Parameters.AddWithValue("@stock", "Ilimitado");
                }

                sql.Parameters.AddWithValue("@fecha", DateTime.Today);
                sql.Parameters.AddWithValue("@motivo", "Registro inicial del producto");
                sql.Parameters.AddWithValue("@cantidad", txtStock.Text);
                sql.Parameters.AddWithValue("@usuario", MODULOS.login.idusuariovariable);
                sql.Parameters.AddWithValue("@tipo", "ENTRADA");
                sql.Parameters.AddWithValue("@estado", "CONFIRMO");
                sql.Parameters.AddWithValue("@id_caja", MODULOS.login.idcajavariable);

                sql.ExecuteNonQuery();
                pnlRegistro.Visible = false;
                txtBuscar.Text = txtDescripcion.Text;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditarProductos()
        {
            if (txtMayoreo.Text == "0")
            {
                txtApartir.Text = "0";
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("editar_producto", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_prod", lblIdProducto.Text);
                sql.Parameters.AddWithValue("@nombre_prod", txtDescripcion.Text);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureProd.Image.Save(ms, pictureProd.Image.RawFormat);
                sql.Parameters.AddWithValue("@imagen", ms.GetBuffer());
                sql.Parameters.AddWithValue("@categoria", lblIdCat.Text);
                sql.Parameters.AddWithValue("@subcategoria", lblIdSub.Text);
                sql.Parameters.AddWithValue("@marca", lblIdMarca.Text);

                sql.Parameters.AddWithValue("@precio_compra", txtPrecioCompra.Text);



                sql.Parameters.AddWithValue("@precio_venta", txtPrecioVenta.Text);
                sql.Parameters.AddWithValue("@codigo", txtCodigoBarras.Text);

                if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                if (porunidad.Checked == true) txtse_vende_a.Text = "Granel";
                sql.Parameters.AddWithValue("@unidades", txtse_vende_a.Text);

                sql.Parameters.AddWithValue("@impuesto", txtprecio_sin_impuestos.Text);

                sql.Parameters.AddWithValue("@precio_mayor", txtMayoreo.Text);
                sql.Parameters.AddWithValue("@a_partir_de", txtApartir.Text);

                if (PANELINVENTARIO.Visible == true)
                {
                    sql.Parameters.AddWithValue("@usa_inventario", "SI");
                    sql.Parameters.AddWithValue("@stock_min", txtstockminimo.Text);
                    sql.Parameters.AddWithValue("@stock", txtStock.Text);
                    if (No_aplica_fecha.Checked == true)
                    {
                        sql.Parameters.AddWithValue("@fecha_venc", "NO APLICA");
                    }
                    if (No_aplica_fecha.Checked == false)
                    {
                        sql.Parameters.AddWithValue("@fecha_venc", txtfechaoka.Text);
                    }
                }
                if (PANELINVENTARIO.Visible == false)
                {
                    sql.Parameters.AddWithValue("@usa_inventario", "NO");
                    sql.Parameters.AddWithValue("@stock_min", 0);
                    sql.Parameters.AddWithValue("@fecha_venc", "NO APLICA");
                    sql.Parameters.AddWithValue("@stock", "Ilimitado");
                }

                sql.ExecuteNonQuery();
                pnlRegistro.Visible = false;
                txtBuscar.Text = txtDescripcion.Text;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Buscar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_producto_descripcion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscar.Text);
                da.Fill(dt);
                datalistadoProducto.DataSource = dt;
                con.Close();

                datalistadoProducto.Columns[2].Visible = true;
                datalistadoProducto.Columns[3].Visible = true;
                datalistadoProducto.Columns[4].Visible = true;
                datalistadoProducto.Columns[5].Visible = false;
                datalistadoProducto.Columns[6].Visible = false;
                datalistadoProducto.Columns[7].Visible = true;
                datalistadoProducto.Columns[8].Visible = false;
                datalistadoProducto.Columns[9].Visible = true;
                datalistadoProducto.Columns[10].Visible = false;
                datalistadoProducto.Columns[11].Visible = true;
                datalistadoProducto.Columns[12].Visible = false;
                datalistadoProducto.Columns[13].Visible = true;
                datalistadoProducto.Columns[14].Visible = true;
                datalistadoProducto.Columns[15].Visible = true;
                datalistadoProducto.Columns[16].Visible = true;
                datalistadoProducto.Columns[17].Visible = false;
                datalistadoProducto.Columns[18].Visible = false;
                datalistadoProducto.Columns[19].Visible = false;
                datalistadoProducto.Columns[20].Visible = false;
                datalistadoProducto.Columns[21].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoProducto);
            SumarCostoInventario();
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
            query = "SELECT CONVERT(NUMERIC(18,2),sum(producto.precio_compra * stock )) as suma FROM  producto where  usa_inventario ='SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcosto_inventario.Text = resultado + " " + importe;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                lblcosto_inventario.Text = resultado + " " + 0;
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
                lblcantidad_productos.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                conteoresultado = "";
                lblcantidad_productos.Text = "0";
            }

        }

        private void GenerarCodigoBarras()
        {
            Double resultado;
            string queryMoneda;
            queryMoneda = "SELECT max(id_prod)  FROM producto";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToDouble(comMoneda.ExecuteScalar()) + 1;
                con.Close();
            }
            catch (Exception ex)
            {
                resultado = 1;
            }

            string Cadena = txtSubcategoria.Text;
            string[] Palabra;
            String espacio = " ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {

                txtCodigoBarras.Text = resultado + Palabra[0].Substring(0, 2) + 20;
            }
            catch (Exception ex)
            {
            }
        }

        private void MostrarProductoSinRepetir()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_producto_sinrepetir", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtDescripcion.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                con.Close();

                datalistadoProducto.Columns[1].Width = 500;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Contar()
        {
            int x;
            x = DATALISTADO_PRODUCTOS_OKA.Rows.Count;
            conta = (x);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            MostrarProductoSinRepetir();
            Contar();


            if (conta == 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            if (conta > 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = true;
            }
            if (TGUARDAR.Visible == false)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString();
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        //bool secuencia = true;

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.') || (e.KeyChar != ','))
            {


                string CultureName = Thread.CurrentThread.CurrentCulture.Name;
                CultureInfo ci = new CultureInfo(CultureName);


                ci.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = ci;

            }
            SeparadorNumeros(txtPrecioCompra, e);
        }

        public static void SeparadorNumeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

            else if (!(e.KeyChar == CajaTexto.Text.IndexOf('.')))
            {
                e.Handled = true;
            }


            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void pbxGuardarCambios_Click(object sender, EventArgs e)
        {
            double txtpreciomayoreoV = Convert.ToDouble(txtMayoreo.Text);

            double txtapartirdeV = Convert.ToDouble(txtApartir.Text);
            double txtcostoV = Convert.ToDouble(txtPrecioCompra.Text);
            double TXTPRECIODEVENTA2V = Convert.ToDouble(txtPrecioVenta.Text);
            if (txtMayoreo.Text == "") txtMayoreo.Text = "0";
            if (txtApartir.Text == "") txtApartir.Text = "0";
            //TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text + " ", "");
            //TXTPRECIODEVENTA2.Text = System.String.Format(((decimal)TXTPRECIODEVENTA2.Text), "##0.00");
            if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtApartir.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
            {
                if (txtcostoV >= TXTPRECIODEVENTA2V)
                {

                    DialogResult result;
                    result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        EditarProductos();
                    }
                    else
                    {
                        txtPrecioVenta.Focus();
                    }


                }
                else if (txtcostoV < TXTPRECIODEVENTA2V)
                {
                    EditarProductos();
                }
            }
            else if (txtpreciomayoreoV != 0 | txtapartirdeV != 0)
            {
                MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void datalistadoProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ObtenerDatosProductos()
        {
            try
            {
                Panel25.Enabled = true;
                DATALISTADO_PRODUCTOS_OKA.Visible = false;

                Panel6.Visible = false;
                TGUARDAR.Visible = false;
                pbxGuardarCambios.Visible = true;
                pnlRegistro.Visible = true;


                //btnNuevoGrupo.Visible = true;
                lblIdProducto.Text = datalistadoProducto.SelectedCells[2].Value.ToString();
                lblEstadoCodigo.Text = "EDITAR";
                //PanelGRUPOSSELECT.Visible = false;
                //BtnGuardarCambios.Visible = false;
                //btnGuardar_grupo.Visible = false;
                //BtnCancelar.Visible = false;
                //btnNuevoGrupo.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                lblIdProducto.Text = datalistadoProducto.SelectedCells[2].Value.ToString();
                txtCodigoBarras.Text = datalistadoProducto.SelectedCells[3].Value.ToString();
                txtDescripcion.Text = datalistadoProducto.SelectedCells[4].Value.ToString();
                
                lblEligeProd.Visible = false;
                pictureProd.BackgroundImage = null;
                byte[] b = (Byte[])datalistadoProducto.SelectedCells[5].Value;
                MemoryStream ms = new MemoryStream(b);
                pictureProd.Image = Image.FromStream(ms);

                lblIdCat.Text = datalistadoProducto.SelectedCells[6].Value.ToString();
                txtCategoria.Text = datalistadoProducto.SelectedCells[7].Value.ToString();
                lblIdSub.Text = datalistadoProducto.SelectedCells[8].Value.ToString();
                txtSubcategoria.Text = datalistadoProducto.SelectedCells[9].Value.ToString();

                lblIdMarca.Text = datalistadoProducto.SelectedCells[10].Value.ToString();
                txtMarca.Text = datalistadoProducto.SelectedCells[11].Value.ToString();


                LBL_ESSERVICIO.Text = datalistadoProducto.SelectedCells[12].Value.ToString();

                txtStock.Text = datalistadoProducto.SelectedCells[13].Value.ToString();
                txtPrecioCompra.Text = datalistadoProducto.SelectedCells[14].Value.ToString();
                lblfechasvenci.Text = datalistadoProducto.SelectedCells[15].Value.ToString();
                txtPrecioVenta.Text = datalistadoProducto.SelectedCells[16].Value.ToString();
                LBLSEVENDEPOR.Text = datalistadoProducto.SelectedCells[17].Value.ToString();
                if (LBLSEVENDEPOR.Text == "Unidad")
                {
                    porunidad.Checked = true;

                }
                if (LBLSEVENDEPOR.Text == "Granel")
                {
                    agranel.Checked = true;
                }
                txtprecio_sin_impuestos.Text = datalistadoProducto.SelectedCells[18].Value.ToString();
                txtstockminimo.Text = datalistadoProducto.SelectedCells[19].Value.ToString();
                if (lblfechasvenci.Text == "NO APLICA")
                {
                    No_aplica_fecha.Checked = true;
                }
                if (lblfechasvenci.Text != "NO APLICA")
                {
                    No_aplica_fecha.Checked = false;
                }
                txtMayoreo.Text = datalistadoProducto.SelectedCells[20].Value.ToString();
                txtApartir.Text = datalistadoProducto.SelectedCells[21].Value.ToString();


                try
                {

                    double TotalVentaVariabledouble;
                    double TXTPRECIODEVENTA2V = Convert.ToDouble(txtPrecioVenta.Text);
                    double txtcostov = Convert.ToDouble(txtPrecioCompra.Text);

                    TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtcostov) / (txtcostov)) * 100;

                    if (TotalVentaVariabledouble > 0)
                    {
                        this.txtPorcentajeGanancia.Text = Convert.ToString(TotalVentaVariabledouble);
                    }
                    else
                    {
                        //Me.txtPorcentajeGanancia.Text = 0
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                if (LBL_ESSERVICIO.Text == "SI")
                {

                    PANELINVENTARIO.Visible = true;
                    PANELINVENTARIO.Visible = true;
                    txtStock.ReadOnly = true;
                    CheckInventarios.Checked = true;

                }
                if (LBL_ESSERVICIO.Text == "NO")
                {
                    CheckInventarios.Checked = false;

                    PANELINVENTARIO.Visible = false;
                    PANELINVENTARIO.Visible = false;
                    txtStock.ReadOnly = true;
                    txtStock.Text = "0";
                    txtstockminimo.Text = "0";
                    No_aplica_fecha.Checked = true;
                    txtStock.ReadOnly = false;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datalistadoProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoProducto.Columns["Eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Producto?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoProducto.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(row.Cells["id_prod"].Value);

                            try
                            {

                                try
                                {

                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_producto", con);
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@id_prod", onekey);
                                    cmd.ExecuteNonQuery();

                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }

                        }
                        Buscar();
                    }

                    catch (Exception ex)
                    {

                    }
                }

            }
            if (e.ColumnIndex == this.datalistadoProducto.Columns["Editar"].Index)
            {
                ObtenerDatosProductos();
            }

        }

        private void txtStock_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (TXTIDPRODUCTOOk.Text != "0")
                {
                    tipMensajes.SetToolTip(txtStock, "Para modificar el Stock Hazlo desde el Modulo de Inventarios");
                    tipMensajes.ToolTipTitle = "Accion denegada";
                    tipMensajes.ToolTipIcon = ToolTipIcon.Info;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            GenerarCodigoBarras();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlRegistro.Visible = false;
        }

        private void txtPorcentajeGanancia_TextChanged(object sender, EventArgs e)
        {
            TimerCalcularPorcentajeGanancia.Stop();

            TimerCalcularPrecioVenta.Start();
            TimerCalcularPorcentajeGanancia.Stop();
        }

        private void TimerCalcularPorcentajeGanancia_Tick(object sender, EventArgs e)
        {
            TimerCalcularPorcentajeGanancia.Stop();
            try
            {


                double TotalVentaVariabledouble;
                double TXTPRECIODEVENTA2V = Convert.ToDouble(txtPrecioVenta.Text);
                double txtcostov = Convert.ToDouble(txtPrecioCompra.Text);

                TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtcostov) / (txtcostov)) * 100;

                if (TotalVentaVariabledouble > 0)
                {
                    this.txtPorcentajeGanancia.Text = Convert.ToString(TotalVentaVariabledouble);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void TimerCalcularPrecioVenta_Tick(object sender, EventArgs e)
        {
            TimerCalcularPrecioVenta.Stop();

            try
            {
                double TotalVentaVariabledouble;
                double txtcostov = Convert.ToDouble(txtPrecioCompra.Text);
                double txtPorcentajeGananciav = Convert.ToDouble(txtPorcentajeGanancia.Text);

                TotalVentaVariabledouble = txtcostov + ((txtcostov * txtPorcentajeGananciav) / 100);

                if (TotalVentaVariabledouble > 0 & txtPorcentajeGanancia.Focused == true)
                {
                    this.txtPrecioVenta.Text = Convert.ToString(TotalVentaVariabledouble);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void datalistadoProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerDatosProductos();
        }

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            PRODUCTOS.asistente_excel excel = new asistente_excel();
            excel.ShowDialog();
        }

        private void TGUARDAR_Click(object sender, EventArgs e)
        {
            double txtpreciomayoreoV = Convert.ToDouble(txtMayoreo.Text);

            double txtapartirdeV = Convert.ToDouble(txtApartir.Text);
            double txtcostoV = Convert.ToDouble(txtPrecioCompra.Text);
            double TXTPRECIODEVENTA2V = Convert.ToDouble(txtPrecioVenta.Text);
            if (txtMayoreo.Text == "") txtMayoreo.Text = "0";
            if (txtApartir.Text == "") txtApartir.Text = "0";
            //TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text + " ", "");
            //TXTPRECIODEVENTA2.Text = System.String.Format(((decimal)TXTPRECIODEVENTA2.Text), "##0.00");
            if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtApartir.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
            {
                if (txtcostoV >= TXTPRECIODEVENTA2V)
                {

                    DialogResult result;
                    result = MessageBox.Show("El precio de Venta es menor que el COSTO, Esto Te puede Generar Perdidas", "Producto con Perdidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        InsertarProductos();
                    }
                    else
                    {
                        txtPrecioVenta.Focus();
                    }


                }
                else if (txtcostoV < TXTPRECIODEVENTA2V)
                {
                    InsertarProductos();
                }
            }
            else if (txtpreciomayoreoV != 0 | txtapartirdeV != 0)
            {
                MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            }
        }

        private void CheckInventarios_CheckedChanged(object sender, EventArgs e)
        {
            if (TXTIDPRODUCTOOk.Text != "0" & Convert.ToDouble(txtStock.Text) > 0)
            {
                if (CheckInventarios.Checked == false)
                {
                    MessageBox.Show("Hay Aun En Stock, Dirijete al Modulo Inventarios para Ajustar el Inventario a cero", "Stock Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    PANELINVENTARIO.Visible = true;
                    CheckInventarios.Checked = true;
                }
            }

            if (TXTIDPRODUCTOOk.Text != "0" & Convert.ToDouble(txtStock.Text) == 0)
            {
                if (CheckInventarios.Checked == false)
                {
                    PANELINVENTARIO.Visible = false;

                }
            }

            if (TXTIDPRODUCTOOk.Text == "0")
            {
                if (CheckInventarios.Checked == false)
                {
                    PANELINVENTARIO.Visible = false;

                }
            }

            if (CheckInventarios.Checked == true)
            {

                PANELINVENTARIO.Visible = true;
            }
        }

        private void lblEligeProd_Click(object sender, EventArgs e)
        {
            LlamarImagenProducto();
        }

        private void LlamarImagenProducto()
        {
            ServiceReference1.ServiciosSoapClient micliente = new ServiceReference1.ServiciosSoapClient();
            string tipo;

            tipo = "IMAGEN";
            string filtro = micliente.Filtros_Extensiones(tipo);

            dlgProd.InitialDirectory = "";
            dlgProd.Filter = filtro;
            dlgProd.FilterIndex = 5;
            dlgProd.Title = "Cargador de archivos";
            if (dlgProd.ShowDialog() == DialogResult.OK)
            {
                pictureProd.BackgroundImage = null;
                pictureProd.Image = new Bitmap(dlgProd.FileName);
                pictureProd.SizeMode = PictureBoxSizeMode.Zoom;
                lblIcoProd.Text = Path.GetFileName(dlgProd.FileName);
                lblEligeProd.Visible = false;
            }
        }

        private void pictureProd_Click(object sender, EventArgs e)
        {
            LlamarImagenProducto();
        }
    }

}
