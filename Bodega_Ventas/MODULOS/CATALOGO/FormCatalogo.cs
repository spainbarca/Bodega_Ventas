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
using System.IO;

namespace Bodega_Ventas.MODULOS.CATALOGO
{
    public partial class FormCatalogo : Form
    {
        public FormCatalogo()
        {
            InitializeComponent();
        }

        int idcat;
        string nombrecat;
        string nombreprod;
        string unidades;
        int contaStockDetalle;
        int idProducto;
        int idCliente;
        int idUsuario;
        int idPedido;
        int idDetallePedido;
        int conta;
        int idCaja;
        int txtpantalla;
        int lblStockProductos;
        string tipoBusqueda;

        public void DibujarUsuarios()
        {
            //idcat = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("select * from producto where categoria="+idcat+"", con);
            SqlDataReader rdr = sql.ExecuteReader();
            //flowProductos.Refresh();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["nombre_prod"].ToString();
                lbl1.Name = rdr["id_prod"].ToString();
                lbl1.Size = new Size(120, 30);
                lbl1.Font = new Font("Berlin Sans FB", 8);
                lbl1.BackColor = Color.LavenderBlush;
                lbl1.ForeColor = Color.Black;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.FlatStyle = FlatStyle.Flat;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(120, 150);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(120, 120);
                box1.Dock = DockStyle.Top;
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["imagen"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["nombre_prod"].ToString();
                box1.Cursor = Cursors.Hand;

                pnl1.Controls.Add(lbl1);
                pnl1.Controls.Add(box1);
                lbl1.BringToFront();
                flowProductos.Controls.Add(pnl1);

                lbl1.Click += new EventHandler(miEventolbl);
                box1.Click += new EventHandler(miEventobox);
            }
            con.Close();
        }

        private void miEventobox(System.Object sender, EventArgs e)
        {
            label10.Text= ((PictureBox)sender).Tag.ToString();
            pnlInfoProd.Visible = true;
            RellenarCampos();
            //panel1.Visible = false;
            //MostrarPermisos();
        }

        private void miEventolbl(System.Object sender, EventArgs e)
        {
            nombreprod = ((Label)sender).Text;
            pnlInfoProd.Visible = true;
            RellenarCampos();
            //panel1.Visible = false;
            //MostrarPermisos();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormCatalogo_Load(object sender, EventArgs e)
        {
            //DibujarUsuarios();
            MostrarListaClientes();
            Limpiar();
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            //idcat = 1;
            //DibujarUsuarios();
            nombrecat = btnGeneral.Text;
            ObtenerIdCat();
        }

        private void btnAbarrotes_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            //idcat = 2;
            //DibujarUsuarios();
            nombrecat = btnAbarrotes.Text;
            ObtenerIdCat();
        }

        private void btnAseoPersonal_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnAseoPersonal.Text;
            ObtenerIdCat();
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnBebidas.Text;
            ObtenerIdCat();
        }

        private void btnDecoraciones_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnDecoraciones.Text;
            ObtenerIdCat();
        }

        private void btnDerivados_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnDerivados.Text;
            ObtenerIdCat();
        }

        private void btnFrutasVerduras_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnFrutasVerduras.Text;
        }

        private void btnGolosinas_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnGolosinas.Text;
            ObtenerIdCat();
        }

        private void btnLacteos_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnLacteos.Text;
            ObtenerIdCat();
        }

        private void btnLibreria_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnLibreria.Text;
            ObtenerIdCat();
        }

        private void btnLimpiezaHogar_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnLimpiezaHogar.Text;
            ObtenerIdCat();
        }

        private void btnMedicina_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnMedicina.Text;
            ObtenerIdCat();
        }

        private void btnPanaderia_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            nombrecat = btnPanaderia.Text;
            ObtenerIdCat();
        }
        
        private void ObtenerIdCat()
        {
            ServicePedidos.PedidosSoapClient clientePedidos = new ServicePedidos.PedidosSoapClient();
            idcat = clientePedidos.ObtenerIdCategoria(nombrecat);
            DibujarUsuarios();
        }

        private void RellenarCampos()
        {
            nombreprod = label10.Text;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("select id_prod, nombre_prod, codigo,categorias.nombre_cat, subcategorias.nombre_subcat,precio_venta, stock, fecha_venc, precio_mayor, a_partir_de,imagen,marcas.nombre_marca,marcas.logo,unidades from producto inner join subcategorias on producto.subcategoria = subcategorias.id_subcat inner join categorias on subcategorias.categoria = categorias.id_cat inner join marcas on producto.marca = marcas.id_marca where nombre_prod = '"+nombreprod+"'",con);
                SqlDataReader rdr = sql.ExecuteReader();

                while (rdr.Read())
                {
                    lblIdCode.Text = rdr["id_prod"].ToString();
                    lblNomProd.Text = rdr["nombre_prod"].ToString();
                    lblCodigo.Text = rdr["codigo"].ToString();
                    lblCategoria.Text = rdr["nombre_cat"].ToString();
                    lblSubcategoria.Text = rdr["nombre_subcat"].ToString();
                    lblPrecio.Text = rdr["precio_venta"].ToString();
                    lblStock.Text = rdr["stock"].ToString();
                    lblFechaVenc.Text = rdr["fecha_venc"].ToString();
                    lblMayor.Text = rdr["precio_mayor"].ToString();
                    lblApartir.Text = rdr["a_partir_de"].ToString();
                    lblMarca.Text = rdr["nombre_marca"].ToString();
                    unidades = rdr["unidades"].ToString();

                    pbxProducto.BackgroundImage = null;
                    byte[] biProd = (byte[])rdr["imagen"];
                    MemoryStream msProd = new MemoryStream(biProd);
                    pbxProducto.Image = Image.FromStream(msProd);
                    pbxProducto.SizeMode = PictureBoxSizeMode.Zoom;

                    pbxMarca.BackgroundImage = null;
                    byte[] biMar = (byte[])rdr["logo"];
                    MemoryStream msMar = new MemoryStream(biMar);
                    pbxMarca.Image = Image.FromStream(msMar);
                    pbxMarca.SizeMode = PictureBoxSizeMode.Zoom;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblcodProd_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblCategoria_Click(object sender, EventArgs e)
        {

        }

        private void btnVolvListado_Click(object sender, EventArgs e)
        {
            pnlInfoProd.Visible = false;
        }

        private void btnAddCarrito_Click(object sender, EventArgs e)
        {
            if (contaStockDetalle == 0)
            {
                // Si es producto no esta agregado a las ventas se tomara el Stock de la tabla Productos
                lblStockProductos = Convert.ToInt32(lblStock.Text);
                //MessageBox.Show("Ok");
            }
            //else
            //{
            //    //en caso que el producto ya este agregado al detalle de venta se va a extraer el Stock de la tabla Detalle_de_venta
            //    lblStockProductos = Convert.ToInt32(datalistadoStockDetallePedido.SelectedCells[1].Value.ToString());
            //}

            if (unidades=="Unidad")
            {
                //MessageBox.Show("prosigue venta");
                
                txtpantalla = 1;
                //MessageBox.Show("Ok venta unidad");
                PedidoUnidad();
                MessageBox.Show("Carrito añadido");
            }
            else
            {
                MessageBox.Show("GG");
            }
            pnlInfoProd.Visible = false;

            MostrarStockDetalleProducto();
            ContarStockDetalleProducto();
        }

        private void PedidoUnidad()
        {
            try
            {
                if (lblPedidoGenerado.Text == "PEDIDO NUEVO")
                {
                    //MessageBox.Show("venta nueva");
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("insertar_pedido", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        //cmd.Parameters.AddWithValue("@cliente", idCliente);
                        cmd.Parameters.AddWithValue("@fecha_pedido", DateTime.Today);
                        //cmd.Parameters.AddWithValue("@num_doc", 0);
                        cmd.Parameters.AddWithValue("@monto_total", 0);
                        //cmd.Parameters.AddWithValue("@tipo_pago", 0);
                        cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                        //cmd.Parameters.AddWithValue("@igv", 0);
                        //cmd.Parameters.AddWithValue("@boleta", 0);
                        cmd.Parameters.AddWithValue("@usuario", VENTAS_PRINCIPAL.ventasprincipalok.usuariostatic);
                        cmd.Parameters.AddWithValue("@fecha_pago", dateFechaEnvio.Value);
                        cmd.Parameters.AddWithValue("@accion", "PEDIDO");
                        //cmd.Parameters.AddWithValue("@saldo", 0);
                        //cmd.Parameters.AddWithValue("@pago_parcial", 0);
                        //cmd.Parameters.AddWithValue("@porc_igv", 0);
                        cmd.Parameters.AddWithValue("@caja_pedido", VENTAS_PRINCIPAL.ventasprincipalok.caja);
                        //cmd.Parameters.AddWithValue("@referencia_card", 0);
                        cmd.Parameters.AddWithValue("@cliente", cbxCliente.SelectedValue);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("venta exitosa");
                        ObtenerIdPedidoCreado();
                        lblPedidoGenerado.Text = "PEDIDO GENERADO";
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("insertar_venta");
                    }

                }
                if (lblPedidoGenerado.Text == "PEDIDO GENERADO")
                {
                    //MessageBox.Show("ahora ins det venta");
                    InsertarDetallePedido();
                    ListarProductosAgregados();
                    txtBuscar.Text = "";
                    txtBuscar.Focus();

                }
            }
            catch (Exception)
            {

                throw;
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
                da = new SqlDataAdapter("mostrar_productos_agregados_pedido", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_pedido", idPedido);
                da.Fill(dt);
                datalistadoDetallePedido.DataSource = dt;
                con.Close();
                datalistadoDetallePedido.Columns[0].Width = 50;
                datalistadoDetallePedido.Columns[1].Width = 50;
                datalistadoDetallePedido.Columns[2].Width = 50;
                datalistadoDetallePedido.Columns[3].Visible = false;
                datalistadoDetallePedido.Columns[4].Width = 250;
                datalistadoDetallePedido.Columns[5].Width = 100;
                datalistadoDetallePedido.Columns[6].Width = 100;
                datalistadoDetallePedido.Columns[7].Width = 100;
                datalistadoDetallePedido.Columns[8].Visible = false;
                datalistadoDetallePedido.Columns[9].Visible = false;
                datalistadoDetallePedido.Columns[10].Visible = false;
                datalistadoDetallePedido.Columns[11].Width = datalistadoDetallePedido.Width - (datalistadoDetallePedido.Columns[0].Width - datalistadoDetallePedido.Columns[1].Width - datalistadoDetallePedido.Columns[2].Width -
                datalistadoDetallePedido.Columns[4].Width - datalistadoDetallePedido.Columns[5].Width - datalistadoDetallePedido.Columns[6].Width - datalistadoDetallePedido.Columns[7].Width);
                datalistadoDetallePedido.Columns[12].Visible = false;
                datalistadoDetallePedido.Columns[13].Visible = false;
                datalistadoDetallePedido.Columns[14].Visible = false;
                datalistadoDetallePedido.Columns[15].Visible = false;
                datalistadoDetallePedido.Columns[16].Visible = false;
                datalistadoDetallePedido.Columns[17].Visible = false;
                datalistadoDetallePedido.Columns[18].Visible = false;

                Sumar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Sumar()
        {
            try
            {
                int i;
                i = datalistadoDetallePedido.Rows.Count;
                if (i == 0)
                {
                    txt_total_suma.Text = "0.00";
                }

                double totalpagar;
                totalpagar = 0;
                foreach (DataGridViewRow fila in datalistadoDetallePedido.Rows)
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
            lblPedidoGenerado.Text = "PEDIDO NUEVO";
        }

        private void ObtenerIdPedidoCreado()
        {            
            ServicePedidos.PedidosSoapClient clientePedidos = new ServicePedidos.PedidosSoapClient();
            //MessageBox.Show("Web Service Venta");
            idPedido = clientePedidos.ObtenerIdPedido(VENTAS_PRINCIPAL.ventasprincipalok.caja);
            pedidoboleta = idPedido;
        }
        public static int pedidoboleta;

        private void InsertarDetallePedido()
        {
            try
            {
                if (lblStockProductos >= txtpantalla)
                {
                    //MessageBox.Show("VentaSinValidar");
                    InsertarDetallePedidoSinValidar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void InsertarDetallePedidoSinValidar()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detallepedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);
                cmd.Parameters.AddWithValue("@producto", Convert.ToInt32(lblIdCode.Text));
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@precio_unit", Convert.ToDouble(lblPrecio.Text));
                cmd.Parameters.AddWithValue("@moneda", "S/.");
                cmd.Parameters.AddWithValue("@unidad_medida", "Unidad");
                cmd.Parameters.AddWithValue("@cant_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@descripcion", lblNomProd.Text);
                cmd.Parameters.AddWithValue("@codigo", lblCodigo.Text);
                cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(lblStock.Text));
                cmd.Parameters.AddWithValue("@unidades", unidades);
                cmd.Parameters.AddWithValue("@usa_inventario", "SI");
                cmd.Parameters.AddWithValue("@costo", 0);
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("DetalleVentaExitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void ContarStockDetalleProducto()
        {
            int i = 0;
            i = datalistadoStockDetallePedido.Rows.Count;
            contaStockDetalle = (i);
        }

        private void MostrarStockDetalleProducto()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("mostrar_stock_detallepedido", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //myidprod = Convert.ToInt32(lblIdProd.Text);
                da.SelectCommand.Parameters.AddWithValue("@id_producto", Convert.ToInt32(lblIdCode.Text));
                da.Fill(dt);
                datalistadoStockDetallePedido.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void EditarDetallePedidoSumar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("editar_detallepedido_sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", idProducto);
                cmd.Parameters.AddWithValue("@cantidad", 1);
                cmd.Parameters.AddWithValue("@cant_mostrada", 1);
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);
                cmd.ExecuteNonQuery();
                con.Close();
                ListarProductosAgregados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ObtenerDatosDetallePedido()
        {
            try
            {
                idDetallePedido = Convert.ToInt32(datalistadoDetallePedido.SelectedCells[9].Value.ToString());
                idProducto = Convert.ToInt32(datalistadoDetallePedido.SelectedCells[8].Value.ToString());
                unidades = datalistadoDetallePedido.SelectedCells[17].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditarDetallePedidoRestar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("editar_detallepedido_restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_detallepedido", idDetallePedido);
                cmd.Parameters.AddWithValue("@cantidad", 1);
                cmd.Parameters.AddWithValue("@cant_mostrada", 1);
                cmd.Parameters.AddWithValue("@producto", idProducto);
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);
                cmd.ExecuteNonQuery();
                con.Close();
                ListarProductosAgregados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EliminarPedidoAgregarProducto()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                cmd = new SqlCommand("eliminar_pedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pedido", idPedido);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContarTablasPedido()
        {
            int i;
            i = datalistadoDetallePedido.Rows.Count;
            conta = (i);
        }

        private void MostrarListaClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("SELECT id_cli, (nombre_cliente+' '+ap_cliente) AS Cliente FROM clientes", con);

                da.Fill(dt);
                cbxCliente.DisplayMember = "Cliente";
                cbxCliente.ValueMember = "id_cli";
                cbxCliente.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }









        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaVenc_Click(object sender, EventArgs e)
        {

        }

        private void lblMarca_Click(object sender, EventArgs e)
        {

        }

        private void pbxMarca_Click(object sender, EventArgs e)
        {

        }

        private void lblStock_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void datalistadoDetallePedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObtenerDatosDetallePedido();
            if (e.KeyChar == Convert.ToChar("+"))
            {
                EditarDetallePedidoSumar();
            }
            if (e.KeyChar == Convert.ToChar("-"))
            {
                EditarDetallePedidoRestar();
                ContarTablasPedido();
                if (conta == 0)
                {
                    EliminarPedidoAgregarProducto();
                    lblPedidoGenerado.Text = "PEDIDO NUEVO";
                }
            }
        }

        private void datalistadoDetallePedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerDatosDetallePedido();

            if (e.ColumnIndex == this.datalistadoDetallePedido.Columns["sum"].Index)
            {
                EditarDetallePedidoSumar();
            }
            if (e.ColumnIndex == this.datalistadoDetallePedido.Columns["res"].Index)
            {
                EditarDetallePedidoRestar();
                ContarTablasPedido();
                if (conta == 0)
                {
                    EliminarPedidoAgregarProducto();
                    lblPedidoGenerado.Text = "PEDIDO NUEVO";
                }
            }

            if (e.ColumnIndex == this.datalistadoDetallePedido.Columns["eli"].Index)
            {
                foreach (DataGridViewRow row in datalistadoDetallePedido.SelectedRows)
                {
                    int id_detallepedido = Convert.ToInt32(row.Cells["id_detallepedido"].Value);
                    try
                    {
                        SqlCommand cmd;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        cmd = new SqlCommand("eliminar_detallepedido", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_detallepedido", id_detallepedido);
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

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        public static double mitotal;
        private void btnImprimirPedido_Click(object sender, EventArgs e)
        {
            mitotal = Convert.ToDouble(txt_total_suma.Text);
            //BOLETAS.FormBoletaVentas bol = new BOLETAS.FormBoletaVentas();
            //bol.ShowDialog();
            REPORTES.REPORTES_PEDIDOS.FormPedidos ped = new REPORTES.REPORTES_PEDIDOS.FormPedidos();
            ped.ShowDialog();
        }

        private void btnIrCarrito_Click(object sender, EventArgs e)
        {
            pnlProducto.Visible = false;
            pnlListado.Visible = true;
            pnlListado.Dock = DockStyle.Fill;
        }

        private void btnIrProd_Click(object sender, EventArgs e)
        {
            pnlListado.Visible = false;
            pnlProducto.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
