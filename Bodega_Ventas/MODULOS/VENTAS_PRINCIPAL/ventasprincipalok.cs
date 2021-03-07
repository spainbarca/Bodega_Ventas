using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;

namespace Bodega_Ventas.MODULOS.VENTAS_PRINCIPAL
{
    public partial class ventasprincipalok : Form
    {
        public ventasprincipalok()
        {
            InitializeComponent();
        }

        int contaStockDetalle;
        int idProducto;
        int idCliente;
        int idUsuario;
        int idVenta;
        int idDetalleVenta;
        int conta;
        int idCaja;
        int txtpantalla;
        int lblStockProductos;
        string tipoBusqueda;

        private void btnFinTurno_Click(object sender, EventArgs e)
        {
            VENTAS_PRINCIPAL.ventasprincipalok vt = new ventasprincipalok();
            vt.Hide();
            CAJA.cierrecaja cierracaja = new CAJA.cierrecaja();
            cierracaja.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ventasprincipalok_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";

            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
            lblSerialPc.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblSerialPc.Text = lblSerialPc.Text.Trim();
            textBox1.Text = lblSerialPc.Text;

            MostrarCajaSerial();
            MostrarTipoBusqueda();
            ObtenerIdCliente();
            ObtenerIdUsuario();

            if (tipoBusqueda == "TECLADO")
            {
                lblTipoBusqueda.Text = "Buscar con TECLADO";
                btnLectora.BackColor = Color.WhiteSmoke;
                btnTeclado.BackColor = Color.LightGreen;
            }
            else
            {
                lblTipoBusqueda.Text = "Buscar con LECTORA de Codigos de Barras";
                btnLectora.BackColor = Color.LightGreen;
                btnTeclado.BackColor = Color.WhiteSmoke;
            }
            Limpiar();
            LogoUsuario();
        }

        private void Sumar()
        {
            try
            {
                int i;
                i = datalistadoDetalleVenta.Rows.Count;
                if (i == 0)
                {
                    txt_total_suma.Text = "0.00";
                }

                double totalpagar;
                totalpagar = 0;
                foreach (DataGridViewRow fila in datalistadoDetalleVenta.Rows)
                {

                    totalpagar += Convert.ToDouble(fila.Cells["Importe"].Value);
                    txt_total_suma.Text = Convert.ToString(totalpagar);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Limpiar()
        {
            txtVentaGenerada.Text = "VENTA NUEVA";
        }

        private void ListarProductosBuscador()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("buscar_productos_ok", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtBuscar.Text);
                da.Fill(dt);
                datalistadoProdOk.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static int caja;
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
                idCaja = Convert.ToInt32(com.ExecuteScalar());
                caja = idCaja;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void MostrarTipoBusqueda()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            SqlCommand com = new SqlCommand("SELECT modo_busqueda FROM empresa", con);

            try
            {
                con.Open();
                tipoBusqueda = Convert.ToString(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        bool contamenu = true;
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (contamenu==true)
            {
                pnlContenido.Visible = true;
                contamenu = false;
            }else if (contamenu == false)
            {
                pnlContenido.Visible = false;
                contamenu = true;
            }
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            //PRODUCTOS.productosok productosok = new PRODUCTOS.productosok();
            //productosok.ShowDialog();
            CATALOGO.FormCatalogo cata = new CATALOGO.FormCatalogo();
            cata.ShowDialog();
        }

        private void btnAplicarDesc_Click(object sender, EventArgs e)
        {
            pnlDescuento.Visible = false;
            pnlSubtotal.Visible = true;
        }

        private void btnSiDesc_Click(object sender, EventArgs e)
        {
            pnlDescuento.Visible = true;
        }

        private void btnMasProductos_Click(object sender, EventArgs e)
        {
            PRODUCTOS.productosok productosok = new PRODUCTOS.productosok();
            productosok.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            usuariosok usuariosok = new usuariosok();
            usuariosok.ShowDialog();
        }

        private void btnOpcProd_Click(object sender, EventArgs e)
        {
            PRODUCTOS.OpcionesProductook OPok = new PRODUCTOS.OpcionesProductook();
            OPok.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            INVENTARIO.inventariokardexok kardex = new INVENTARIO.inventariokardexok();
            kardex.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            REPORTES.REPORTES_KARDEX.FormInventariosTodos reporteInvTodos = new REPORTES.REPORTES_KARDEX.FormInventariosTodos();
            reporteInvTodos.ShowDialog();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            lblTipoBusqueda.Text = "Buscar con  TECLADO";
            tipoBusqueda = "TECLADO";
            btnTeclado.BackColor = Color.LightGreen;
            btnLectora.BackColor = Color.WhiteSmoke;
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void btnLectora_Click(object sender, EventArgs e)
        {
            lblTipoBusqueda.Text = "Buscar con LECTORA de Codigos de Barras";
            tipoBusqueda = "LECTORA";
            btnLectora.BackColor = Color.LightGreen;
            btnTeclado.BackColor = Color.WhiteSmoke;
            txtBuscar.Clear();
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tipoBusqueda == "LECTORA")
            {
                lblTipoBusqueda.Visible = false;
                timerCodBarras.Start();
            }
            else if (tipoBusqueda == "TECLADO")
            {
                if (txtBuscar.Text == "")
                {
                    datalistadoProdOk.Visible = false;
                    lblTipoBusqueda.Visible = true;
                }
                else if (txtBuscar.Text != "")
                {
                    datalistadoProdOk.Visible = true;
                    lblTipoBusqueda.Visible = false;
                }
                ListarProductosBuscador();
            }
        }

        private void datalistadoProdOk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBuscar.Text = datalistadoProdOk.SelectedCells[9].Value.ToString();
            
            idProducto = Convert.ToInt32(datalistadoProdOk.SelectedCells[1].Value.ToString());
            lblIdProd.Text= datalistadoProdOk.SelectedCells[1].Value.ToString();
            VentasTeclado();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (contaStockDetalle == 0)
            {
                // Si es producto no esta agregado a las ventas se tomara el Stock de la tabla Productos
                lblStockProductos = Convert.ToInt32(datalistadoProdOk.SelectedCells[4].Value.ToString());
                //MessageBox.Show("Ok");
            }
            else
            {
                //en caso que el producto ya este agregado al detalle de venta se va a extraer el Stock de la tabla Detalle_de_venta
                lblStockProductos = Convert.ToInt32(datalistadoStockDetalleVenta.SelectedCells[1].Value.ToString());
            }

            ServiceInventarios.InventariosSoapClient clienteInventarios = new ServiceInventarios.InventariosSoapClient();
            Boolean condicional;

            condicional = clienteInventarios.VerificarValidez(idProducto);

            if (condicional == false)
            {
                MessageBox.Show("Web Service Inventario, no procede granel");
                VentasGranel();
            }
            else if (condicional == true)
            {
                txtpantalla = 1;
                //MessageBox.Show("Ok venta unidad");
                VentasUnidad();
            }

            MostrarStockDetalleVenta();
            ContarStockDetalleVenta();

        }



        private void VentasTeclado()
        {
            // mostramos los registros del producto en el detalle de venta
            //MostrarStockDetalleVenta();
            //ContarStockDetalleVenta();

            //if (contaStockDetalle == 0)
            //{
            //    // Si es producto no esta agregado a las ventas se tomara el Stock de la tabla Productos
            //    lblStockProductos = Convert.ToInt32(datalistadoProdOk.SelectedCells[4].Value.ToString());
           
            //}
            //else
            //{
            //    //en caso que el producto ya este agregado al detalle de venta se va a extraer el Stock de la tabla Detalle_de_venta
            //    lblStockProductos = Convert.ToInt32(datalistadoStockDetalleVenta.SelectedCells[1].Value.ToString());
            //}

            //Extraemos los datos del producto de la tabla Productos directamente
            lblStock.Text = datalistadoProdOk.SelectedCells[4].Value.ToString();
            lblUsaInventario.Text = datalistadoProdOk.SelectedCells[3].Value.ToString();
            lblNomProd.Text = datalistadoProdOk.SelectedCells[9].Value.ToString();
            lblCodigo.Text = datalistadoProdOk.SelectedCells[10].Value.ToString();
            lblCosto.Text = datalistadoProdOk.SelectedCells[5].Value.ToString();
            lblUnidades.Text = datalistadoProdOk.SelectedCells[8].Value.ToString();
            lblPrecioUnit.Text = datalistadoProdOk.SelectedCells[6].Value.ToString();
            //Preguntamos que tipo de producto sera el que se agrege al detalle de venta

            //if (lblUnidades.Text == "Granel")
            //{
            //    VentasGranel();
            //}
            //else if (lblUnidades.Text == "Unidad")
            //{
            //    txtpantalla = 1;
            //    VentasUnidad();
            //}

        }

        private void VentasGranel()
        {

        }

        private void ObtenerIdCliente()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //SqlCommand com = new SqlCommand("select id_cli  from clientes where cliente='NEUTRO'", con);
            //try
            //{
            //    con.Open();
            //    idCliente = Convert.ToInt32(com.ExecuteScalar());
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace);
            //}

            ServiceClientes.ClientesSoapClient clienteClientes = new ServiceClientes.ClientesSoapClient();
            //MessageBox.Show("Web Service Cliente");

            idCliente = clienteClientes.ObtenerIdCliente();
        }

        private void ObtenerIdUsuario()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //SqlCommand com = new SqlCommand("mostrar_inicio_sesion", con);
            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@id_serialpc", lblSerialPc.Text);
            //try
            //{
            //    con.Open();
            //    idUsuario = Convert.ToInt32(com.ExecuteScalar());
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace);
            //}

            ServiceUsuarios.UsuariosSoapClient clienteUsuarios = new ServiceUsuarios.UsuariosSoapClient();
            //MessageBox.Show("Web Service Usuario");
            string serialpc = lblSerialPc.Text;
            idUsuario = clienteUsuarios.ObtenerIdUsuario(serialpc);
            usuariostatic = idUsuario;
        }
        public static int usuariostatic;

        private void ObtenerIdVentaCreada()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //SqlCommand com = new SqlCommand("mostrar_idventa_por_idcaja", con);
            //com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@caja", idCaja);
            //try
            //{
            //    con.Open();
            //    idVenta = Convert.ToInt32(com.ExecuteScalar());
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("mostrar_idventa_por_idcaja");
            //}

            //ServiceUsuarios.UsuariosSoapClient clienteUsuarios = new ServiceUsuarios.UsuariosSoapClient();
            ServiceVentas.VentasSoapClient clienteVentas = new ServiceVentas.VentasSoapClient();
            //MessageBox.Show("Web Service Venta");
            idVenta = clienteVentas.ObtenerIdVenta(idCaja);
            ventaboleta = idVenta;

        }

        public static int ventaboleta;

        private void VentasUnidad()
        {
            try
            {
                //if (txtBuscar.Text == datalistadoProdOk.SelectedCells[10].Value.ToString())
                if (txtBuscar.Text == lblNomProd.Text)
                {
                    
                    datalistadoProdOk.Visible = true;
                    //MessageBox.Show("Comenzar, venta unidad");
                    if (txtVentaGenerada.Text == "VENTA NUEVA")
                    {
                        //MessageBox.Show("venta nueva");
                        //try
                        //{
                        //    SqlConnection con = new SqlConnection();
                        //    con.ConnectionString = CONEXION.Conexion.conectar;
                        //    con.Open();
                        //    SqlCommand cmd = new SqlCommand();
                        //    cmd = new SqlCommand("insertar_venta", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    //cmd.Parameters.AddWithValue("@cliente", idCliente);
                        //    cmd.Parameters.AddWithValue("@cliente", idCliente);
                        //    cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Today);
                        //    cmd.Parameters.AddWithValue("@num_doc", 0);
                        //    cmd.Parameters.AddWithValue("@monto_total", 0);
                        //    cmd.Parameters.AddWithValue("@tipo_pago", 0);
                        //    cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                        //    cmd.Parameters.AddWithValue("@igv", 0);
                        //    cmd.Parameters.AddWithValue("@boleta", 0);
                        //    cmd.Parameters.AddWithValue("@usuario", idUsuario);
                        //    cmd.Parameters.AddWithValue("@fecha_pago", DateTime.Today);
                        //    cmd.Parameters.AddWithValue("@accion", "VENTA");
                        //    cmd.Parameters.AddWithValue("@saldo", 0);
                        //    cmd.Parameters.AddWithValue("@pago_parcial", 0);
                        //    cmd.Parameters.AddWithValue("@porc_igv", 0);
                        //    cmd.Parameters.AddWithValue("@caja", idCaja);
                        //    cmd.Parameters.AddWithValue("@referencia_card", 0);
                        //    cmd.ExecuteNonQuery();
                        //    con.Close();

                        //    //MessageBox.Show("venta exitosa");
                        //    ObtenerIdVentaCreada();
                        //    txtVentaGenerada.Text = "VENTA GENERADA";
                        //}
                        //catch (Exception ex)
                        //{
                        //    //MessageBox.Show("insertar_venta");
                        //}

                        ServiceVentas.VentasSoapClient clienteVentas = new ServiceVentas.VentasSoapClient();

                        Boolean cond;

                        cond = clienteVentas.ProcesarVenta(idCliente, idUsuario, idCaja);

                        if (cond==true)
                        {
                            MessageBox.Show("Web Service ventas");
                            ObtenerIdVentaCreada();
                            txtVentaGenerada.Text = "VENTA GENERADA";
                        }
                        if (cond == false)
                        {
                            MessageBox.Show("Web Service erroneo, verifica tu sservicio");
                        }

                    }
                    if (txtVentaGenerada.Text == "VENTA GENERADA")
                    {
                        //MessageBox.Show("ahora ins det venta");
                        InsertarDetalleVenta();
                        ListarProductosAgregados();
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void ListarProductosAgregados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("mostrar_productos_agregados_venta", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_venta", idVenta);
                da.Fill(dt);
                datalistadoDetalleVenta.DataSource = dt;
                con.Close();
                datalistadoDetalleVenta.Columns[0].Width = 50;
                datalistadoDetalleVenta.Columns[1].Width = 50;
                datalistadoDetalleVenta.Columns[2].Width = 50;
                datalistadoDetalleVenta.Columns[3].Visible = false;
                datalistadoDetalleVenta.Columns[4].Width = 250;
                datalistadoDetalleVenta.Columns[5].Width = 100;
                datalistadoDetalleVenta.Columns[6].Width = 100;
                datalistadoDetalleVenta.Columns[7].Width = 100;
                datalistadoDetalleVenta.Columns[8].Visible = false;
                datalistadoDetalleVenta.Columns[9].Visible = false;
                datalistadoDetalleVenta.Columns[10].Visible = false;
                datalistadoDetalleVenta.Columns[11].Width = datalistadoDetalleVenta.Width - (datalistadoDetalleVenta.Columns[0].Width - datalistadoDetalleVenta.Columns[1].Width - datalistadoDetalleVenta.Columns[2].Width -
                datalistadoDetalleVenta.Columns[4].Width - datalistadoDetalleVenta.Columns[5].Width - datalistadoDetalleVenta.Columns[6].Width - datalistadoDetalleVenta.Columns[7].Width);
                datalistadoDetalleVenta.Columns[12].Visible = false;
                datalistadoDetalleVenta.Columns[13].Visible = false;
                datalistadoDetalleVenta.Columns[14].Visible = false;
                datalistadoDetalleVenta.Columns[15].Visible = false;
                datalistadoDetalleVenta.Columns[16].Visible = false;
                datalistadoDetalleVenta.Columns[17].Visible = false;
                datalistadoDetalleVenta.Columns[18].Visible = false;

                Sumar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void InsertarDetalleVenta()
        {
            try
            {
                if (lblUsaInventario.Text == "SI")
                {
                    if (lblStockProductos >= txtpantalla)
                    {
                        //MessageBox.Show("VentaSinValidar");
                        InsertarDetalleVentaSinValidar();
                    }
                }
                
                if (lblUsaInventario.Text == "NO")
                {
                    InsertarDetalleVentaSinValidar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void InsertarDetalleVentaSinValidar()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalleventa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.Parameters.AddWithValue("@producto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@precio_unit", Convert.ToDouble(lblPrecioUnit.Text));
                cmd.Parameters.AddWithValue("@moneda", 0);
                cmd.Parameters.AddWithValue("@unidad_medida", "Unidad");
                cmd.Parameters.AddWithValue("@cant_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@descripcion", lblNomProd.Text);
                cmd.Parameters.AddWithValue("@codigo", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@stock", lblStockProductos);
                cmd.Parameters.AddWithValue("@unidades", lblUnidades.Text);
                cmd.Parameters.AddWithValue("@usa_inventario", lblUsaInventario.Text);
                cmd.Parameters.AddWithValue("@costo", Convert.ToDouble(lblCosto.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("DetalleVentaExitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void ContarStockDetalleVenta()
        {
            int i=0;
            i = datalistadoStockDetalleVenta.Rows.Count;
            contaStockDetalle = (i);
        }

        int myidprod;
        private void MostrarStockDetalleVenta()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("mostrar_stock_detalleventa", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //myidprod = Convert.ToInt32(lblIdProd.Text);
                da.SelectCommand.Parameters.AddWithValue("@id_producto", Convert.ToInt32(lblIdProd.Text));
                da.Fill(dt);
                datalistadoStockDetalleVenta.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        
        private void EditarDetalleVentaSumar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("editar_detalleventa_sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", 1);
                cmd.Parameters.AddWithValue("@cant_mostrada", 1);
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
                ListarProductosAgregados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ObtenerDatosDetalleVenta()
        {
            try
            {
                idDetalleVenta = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[9].Value.ToString());
                idProducto = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[8].Value.ToString());
                lblUnidades.Text = datalistadoDetalleVenta.SelectedCells[17].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditarDetalleVentaRestar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("editar_detalleventa_restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_detalleventa", idDetalleVenta);
                cmd.Parameters.AddWithValue("@cantidad", 1);
                cmd.Parameters.AddWithValue("@cant_mostrada", 1);
                cmd.Parameters.AddWithValue("@producto", idProducto);
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
                ListarProductosAgregados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datalistadoDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void EliminarVentaAgregarProducto()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("eliminar_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContarTablasVentas()
        {
            int i;
            i = datalistadoDetalleVenta.Rows.Count;
            conta = (i);
        }

        private void datalistadoDetalleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObtenerDatosDetalleVenta();
            if (e.KeyChar == Convert.ToChar("+"))
            {
                EditarDetalleVentaSumar();
            }
            if (e.KeyChar == Convert.ToChar("-"))
            {
                EditarDetalleVentaRestar();
                ContarTablasVentas();
                if (conta == 0)
                {
                    EliminarVentaAgregarProducto();
                    txtVentaGenerada.Text = "VENTA NUEVA";
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "0";
        }

        bool secuencia = true;
        private void btnSeparador_Click(object sender, EventArgs e)
        {
            if (secuencia == true)
            {
                txtmonto.Text = txtmonto.Text + ".";
                secuencia = false;
            }
            else
            {
                return;
            }
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtmonto.Clear();
            secuencia = true;
        }

        public static void Separador_de_Numeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e)
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

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.') || (e.KeyChar != ','))
            {

                string CultureName = Thread.CurrentThread.CurrentCulture.Name;
                CultureInfo ci = new CultureInfo(CultureName);

                ci.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = ci;

            }
            Separador_de_Numeros(txtmonto, e);
        }

        private void timerCodBarras_Tick(object sender, EventArgs e)
        {
            timerCodBarras.Stop();
            VentasLectoraBarras();
        }

        private void VentasLectoraBarras()
        {
            if (txtBuscar.Text == "")
            {
                datalistadoProdOk.Visible = false;
                lblTipoBusqueda.Visible = true;
            }
            if (txtBuscar.Text != "")
            {
                datalistadoProdOk.Visible = true;
                lblTipoBusqueda.Visible = false;
                ListarProductosBuscador();

                idProducto = Convert.ToInt32(datalistadoProdOk.SelectedCells[1].Value.ToString());
                MostrarStockDetalleVenta();
                ContarStockDetalleVenta();

                if (contaStockDetalle == 0)
                {
                    lblStockProductos = Convert.ToInt32(datalistadoProdOk.SelectedCells[4].Value.ToString());
                }
                else
                {
                    lblStockProductos = Convert.ToInt32(datalistadoStockDetalleVenta.SelectedCells[1].Value.ToString());
                }
                lblUsaInventario.Text = datalistadoProdOk.SelectedCells[3].Value.ToString();
                lblNomProd.Text = datalistadoProdOk.SelectedCells[9].Value.ToString();
                lblCodigo.Text = datalistadoProdOk.SelectedCells[10].Value.ToString();
                lblCosto.Text = datalistadoProdOk.SelectedCells[5].Value.ToString();
                lblPrecioUnit.Text = datalistadoProdOk.SelectedCells[6].Value.ToString();
                lblUnidades.Text = datalistadoProdOk.SelectedCells[8].Value.ToString();
                if (lblUnidades.Text == "Unidad")
                {
                    txtpantalla = 1;
                    VentasUnidad();
                }

            }
        }


        private void EditarDetalleVentaCantidad()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("editar_detalleventa_cantidad", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(txtmonto.Text));
                cmd.Parameters.AddWithValue("@cant_mostrada", Convert.ToInt32(txtmonto.Text));
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
                ListarProductosAgregados();
                txtmonto.Clear();
                txtmonto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            if (datalistadoDetalleVenta.RowCount > 0)
            {

                if (lblUnidades.Text == "Unidad")

                {
                    string ruta = txtmonto.Text;
                    if (ruta.Contains("."))
                    {
                        MessageBox.Show("Este Producto no acepta decimales ya que esta configurado para ser vendido por UNIDAD", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (txtmonto.Text == "")
                        {
                            txtmonto.Text = Convert.ToString(0);
                        }

                        if (Convert.ToInt32(txtmonto.Text) > 0)
                        {
                            EditarDetalleVentaCantidad();
                        }
                        else
                        {
                            txtmonto.Clear();
                            txtmonto.Focus();
                        }
                    }
                }
            }
            else
            {
                txtmonto.Clear();
                txtmonto.Focus();
            }
        }

        private void datalistadoDetalleVenta_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerDatosDetalleVenta();

            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["sum"].Index)
            {
                EditarDetalleVentaSumar();
            }
            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["res"].Index)
            {
                EditarDetalleVentaRestar();
                ContarTablasVentas();
                if (conta == 0)
                {
                    EliminarVentaAgregarProducto();
                    txtVentaGenerada.Text = "VENTA NUEVA";
                }
            }

            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["eli"].Index)
            {
                foreach (DataGridViewRow row in datalistadoDetalleVenta.SelectedRows)
                {
                    int id_detalleventa = Convert.ToInt32(row.Cells["id_detalleventa"].Value);
                    try
                    {
                        SqlCommand cmd;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        cmd = new SqlCommand("eliminar_detalleventa", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_detalleventa", id_detalleventa);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                ListarProductosAgregados();
            }
        }

        private void pnlFondo_Click(object sender, EventArgs e)
        {
            pnlContenido.Visible = false;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CLIENTES.FormClientes frmcli = new CLIENTES.FormClientes();
            frmcli.ShowDialog();
        }

        private void pbxUser_Click(object sender, EventArgs e)
        {

        }

        private void LogoUsuario()
        {
            byte[] mifotousu = new byte[0];
            try
            {
                //DataTable dt = new DataTable();
                //SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                //da = new SqlDataAdapter("SELECT icono FROM usuarios", con);
                SqlCommand sql = new SqlCommand("SELECT icono FROM usuarios WHERE id_usu="+idUsuario+"", con);
                SqlDataAdapter da = new SqlDataAdapter(sql);
                DataSet ds = new DataSet("icono");
                da.Fill(ds, "icono");
                DataRow dr = ds.Tables["icono"].Rows[0];
                mifotousu = (byte[])dr["icono"];

                pbxUser.BackgroundImage = null;
                MemoryStream ms = new MemoryStream(mifotousu);
                pbxUser.Image = Image.FromStream(ms);
                pbxUser.SizeMode = PictureBoxSizeMode.Zoom;

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        public static double mitotal;
        private void befectivo_Click(object sender, EventArgs e)
        {
            mitotal = Convert.ToDouble(txt_total_suma.Text);
            BOLETAS.FormBoletaVentas bol = new BOLETAS.FormBoletaVentas();
            bol.ShowDialog();
        }

        private void lblUnidades_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecioUnit_Click(object sender, EventArgs e)
        {

        }
    }
}
