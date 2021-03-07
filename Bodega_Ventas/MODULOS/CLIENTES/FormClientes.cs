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

namespace Bodega_Ventas.MODULOS.CLIENTES
{
    public partial class FormClientes : Form
    {
        int id;
        string estado;
        public FormClientes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cbxGenero.SelectedItem = 0;
            cbxTipoCli.SelectedItem = 0;
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "")
            {
                if (txtrucdefactura.Text == "")
                {
                    txtDireccion.Text = "0";
                }
                if (txtrucdefactura.Text == "")
                {
                    txtrucdefactura.Text = "0";
                }
                if (txtCelular.Text == "")
                {
                    txtCelular.Text = "0";
                }

                if (txtTelefono.Text == "")
                {
                     txtTelefono.Text = "0";
                }
                //try
                //{
                //    SqlConnection con = new SqlConnection();
                //    con.ConnectionString = CONEXION.Conexion.conectar;
                //    con.Open();
                //    SqlCommand sql = new SqlCommand();
                //    sql = new SqlCommand("insertar_cliente", con);
                //    sql.CommandType = CommandType.StoredProcedure;
                //    sql.Parameters.AddWithValue("@nombre_cliente", txtNombres.Text);
                //    sql.Parameters.AddWithValue("@ap_cliente", txtApellidos.Text);
                //    sql.Parameters.AddWithValue("@fecha_nac", dateFecha.Value);
                //    sql.Parameters.AddWithValue("@genero", cbxGenero.SelectedItem);
                //    sql.Parameters.AddWithValue("@tipo", cbxTipoCli.SelectedValue);
                //    sql.Parameters.AddWithValue("@correo_cliente", txtEmail.Text);
                //    sql.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                //    sql.Parameters.AddWithValue("@ruc", txtrucdefactura.Text);
                //    sql.Parameters.AddWithValue("@movil", txtCelular.Text);
                //    sql.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                //    sql.Parameters.AddWithValue("@cliente", "SI");
                //    sql.Parameters.AddWithValue("@proveedor", "NO");

                //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //    pictureIcono.Image.Save(ms, pictureIcono.Image.RawFormat);
                //    sql.Parameters.AddWithValue("@foto", ms.GetBuffer());
                //    sql.Parameters.AddWithValue("@nom_icono", lblNumIco.Text);

                //    sql.Parameters.AddWithValue("@estado", "ACTIVO");
                //    sql.Parameters.AddWithValue("@saldo", 0);
                //    sql.ExecuteNonQuery();
                //    con.Close();
                //    txtBuscar.Text = txtNombres.Text;
                //    Buscar();
                //    pnlFondo.Visible = false;
                //    Limpiar();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //ServiceProductos.ProductosSoapClient clienteProductos = new ServiceProductos.ProductosSoapClient();
                ServiceClientes.ClientesSoapClient clienteClientes = new ServiceClientes.ClientesSoapClient();

                MessageBox.Show("Web Service Cliente");
                string nombres;
                string apellidos;
                DateTime fecha;
                string genero;
                int tipo;
                string correo;
                string direccion;
                string ruc;
                string movil;
                string telefono;
                byte[] foto;
                string numico;

                nombres = txtNombres.Text;
                apellidos = txtApellidos.Text;
                fecha = dateFecha.Value;
                genero = cbxGenero.SelectedItem.ToString();
                tipo = Convert.ToInt32(cbxTipoCli.SelectedValue.ToString());
                correo = txtEmail.Text;
                direccion = txtDireccion.Text;
                ruc = txtrucdefactura.Text;
                movil = txtCelular.Text;
                telefono = txtTelefono.Text;

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureIcono.Image.Save(ms, pictureIcono.Image.RawFormat);
                foto = ms.GetBuffer();
                numico = lblNumIco.Text;

                string cond = clienteClientes.InsertarCliente(nombres, apellidos, fecha, genero, tipo, correo, direccion, ruc, movil, telefono, foto, numico);

                if (cond == "SI")
                {
                    txtBuscar.Text = txtNombres.Text;
                    Buscar();
                    pnlFondo.Visible = false;
                    Limpiar();
                    MessageBox.Show("Cliente insertado");
                }
                if (cond == "NO")
                {
                    Limpiar();
                    MessageBox.Show("Cliente no insertado, verificá tu servicio");
                }
            }
            else
            {
                MessageBox.Show("Llenar campo Nombre", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = true;
            Limpiar();
            pnlFondo.Dock = DockStyle.Fill;
            txtBuscar.Clear();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            Mostrar();
            MostrarListaTipo();
        }

        private void Mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("mostrar_cliente", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistado);
            CambiarColorClientesEliminados();
            ContarClientesActivos();
            ContarClientesEliminados();
        }

        private void ContarClientesActivos()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //SqlCommand com = new SqlCommand("contar_clientes_activos", con);
            //try
            //{
            //    con.Open();
            //    lblclientesActivos.Text = Convert.ToString(com.ExecuteScalar());
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace);
            //}

            ServiceClientes.ClientesSoapClient clienteClientes = new ServiceClientes.ClientesSoapClient();

            //MessageBox.Show("Web Service Cliente");
            string contaAct = clienteClientes.ContarClientesActivos();
            lblclientesActivos.Text = contaAct;
        }

        private void ContarClientesEliminados()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //SqlCommand com = new SqlCommand("contar_clientes_eliminados", con);
            //try
            //{
            //    con.Open();
            //    lblclientesEliminados.Text = Convert.ToString(com.ExecuteScalar());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace);
            //}

            ServiceClientes.ClientesSoapClient clienteClientes = new ServiceClientes.ClientesSoapClient();

            //MessageBox.Show("Web Service Cliente");
            string contaEli = clienteClientes.ContarClientesEliminados();
            lblclientesEliminados.Text = contaEli;
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Registro?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in datalistado.SelectedRows)
                    {
                        try
                        {
                            int Idcliente = Convert.ToInt32(row.Cells["id_cli"].Value);
                            SqlCommand cmd;
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.Conexion.conectar;
                            con.Open();
                            cmd = new SqlCommand("eliminar_cliente", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_cli", Idcliente);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                        }
                        Mostrar();
                    }
                }
            }

            if (e.ColumnIndex == this.datalistado.Columns["Edi"].Index)
            {
                ProcesoObtenerDatos();
            }
        }

        private void ProcesoObtenerDatos()
        {
            try
            {
                estado = datalistado.SelectedCells[15].Value.ToString();
                if (estado == "ELIMINADO")
                {
                    Restaurar();
                }
                else
                {
                    id = Convert.ToInt32(datalistado.SelectedCells[2].Value.ToString());
                    txtNombres.Text = datalistado.SelectedCells[3].Value.ToString();
                    txtApellidos.Text = datalistado.SelectedCells[4].Value.ToString();
                    dateFecha.Value = Convert.ToDateTime(datalistado.SelectedCells[5].Value);
                    cbxGenero.Text = datalistado.SelectedCells[6].Value.ToString();
                    cbxTipoCli.Text = datalistado.SelectedCells[7].Value.ToString();
                    txtEmail.Text = datalistado.SelectedCells[8].Value.ToString();
                    txtDireccion.Text = datalistado.SelectedCells[9].Value.ToString();
                    txtrucdefactura.Text = datalistado.SelectedCells[10].Value.ToString();
                    txtCelular.Text = datalistado.SelectedCells[11].Value.ToString();
                    txtTelefono.Text = datalistado.SelectedCells[12].Value.ToString();

                    pictureIcono.BackgroundImage = null;
                    byte[] b = (Byte[])datalistado.SelectedCells[13].Value;
                    MemoryStream ms = new MemoryStream(b);
                    pictureIcono.Image = Image.FromStream(ms);
                    pictureIcono.SizeMode = PictureBoxSizeMode.Zoom;
                    lblEligeIcono.Visible = false;

                    lblNumIco.Text = datalistado.SelectedCells[14].Value.ToString();

                    pnlFondo.Visible = true;
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;
                    pnlFondo.Dock = DockStyle.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void Restaurar()
        {
            DialogResult result;
            result = MessageBox.Show("Este cliente se Elimino, ¿Desea volver a Habilitarlo?", "Restaurancion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in datalistado.SelectedRows)
                {
                    int idcliente = Convert.ToInt32(row.Cells["id_cli"].Value);
                    //try
                    //{
                    //    SqlCommand cmd;
                    //    SqlConnection con = new SqlConnection();
                    //    con.ConnectionString = CONEXION.Conexion.conectar;
                    //    con.Open();
                    //    cmd = new SqlCommand("restaurar_cliente", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@id_cli", idcliente);
                    //    cmd.ExecuteNonQuery();
                    //    con.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.StackTrace);
                    //}

                    ServiceClientes.ClientesSoapClient clienteClientes = new ServiceClientes.ClientesSoapClient();

                    string cond = clienteClientes.RestaurarClientesEliminados(idcliente);
                    
                    if (cond == "NO")
                    {
                        MessageBox.Show("Cliente no restaurado, verificá tu servicio");
                    }

                    Mostrar();
                }
            }
        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProcesoObtenerDatos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
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
                da = new SqlDataAdapter("buscar_cliente", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscar.Text);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                OcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistado);
            CambiarColorClientesEliminados();
            ContarClientesActivos();
            ContarClientesEliminados();
        }

        private void CambiarColorClientesEliminados()
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void OcultarColumnas()
        {
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = true;
            datalistado.Columns[4].Visible = true;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[6].Visible = false;
            datalistado.Columns[7].Visible = true;
            datalistado.Columns[8].Visible = true;
            datalistado.Columns[9].Visible = false;
            datalistado.Columns[10].Visible = false;
            datalistado.Columns[11].Visible = true;
            datalistado.Columns[12].Visible = false;
            datalistado.Columns[13].Visible = false;
            datalistado.Columns[14].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "")
            {

                if (txtDireccion.Text == "")
                {
                    txtDireccion.Text = "0";
                }
                if (txtrucdefactura.Text == "")
                {
                    txtrucdefactura.Text = "0";
                }
                if (txtCelular.Text == "")
                {
                    txtCelular.Text = "0";
                }
                //try
                //{
                //    SqlConnection con = new SqlConnection();
                //    con.ConnectionString = CONEXION.Conexion.conectar;
                //    con.Open();
                //    SqlCommand sql = new SqlCommand();
                //    sql = new SqlCommand("editar_cliente", con);
                //    sql.CommandType = CommandType.StoredProcedure;
                //    sql.Parameters.AddWithValue("@id_cli", id);
                //    sql.Parameters.AddWithValue("@nombre_cliente", txtNombres.Text);
                //    sql.Parameters.AddWithValue("@ap_cliente", txtApellidos.Text);
                //    sql.Parameters.AddWithValue("@fecha_nac", dateFecha.Value);
                //    sql.Parameters.AddWithValue("@genero", cbxGenero.SelectedItem);
                //    sql.Parameters.AddWithValue("@tipo", cbxTipoCli.SelectedValue);
                //    sql.Parameters.AddWithValue("@correo_cliente", txtEmail.Text);
                //    sql.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                //    sql.Parameters.AddWithValue("@ruc", txtrucdefactura.Text);
                //    sql.Parameters.AddWithValue("@movil", txtCelular.Text);
                //    sql.Parameters.AddWithValue("@telefono", txtTelefono.Text);

                //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //    pictureIcono.Image.Save(ms, pictureIcono.Image.RawFormat);
                //    sql.Parameters.AddWithValue("@foto", ms.GetBuffer());
                //    sql.Parameters.AddWithValue("@nom_icono", lblNumIco.Text);
                //    sql.ExecuteNonQuery();
                //    con.Close();
                //    txtBuscar.Text = txtNombres.Text;
                //    Buscar();
                //    pnlFondo.Visible = false;
                //    Limpiar();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                ServiceClientes.ClientesSoapClient clienteClientes = new ServiceClientes.ClientesSoapClient();

                MessageBox.Show("Web Service Cliente");
                string nombres;
                string apellidos;
                DateTime fecha;
                string genero;
                int tipo;
                string correo;
                string direccion;
                string ruc;
                string movil;
                string telefono;
                byte[] foto;
                string numico;

                nombres = txtNombres.Text;
                apellidos = txtApellidos.Text;
                fecha = dateFecha.Value;
                genero = cbxGenero.SelectedItem.ToString();
                tipo = Convert.ToInt32(cbxTipoCli.SelectedValue.ToString());
                correo = txtEmail.Text;
                direccion = txtDireccion.Text;
                ruc = txtrucdefactura.Text;
                movil = txtCelular.Text;
                telefono = txtTelefono.Text;

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureIcono.Image.Save(ms, pictureIcono.Image.RawFormat);
                foto = ms.GetBuffer();
                numico = lblNumIco.Text;

                string cond = clienteClientes.EditarCliente(id, nombres, apellidos, fecha, genero, tipo, correo, direccion, ruc, movil, telefono, foto, numico);

                if (cond == "SI")
                {
                    txtBuscar.Text = txtNombres.Text;
                    Buscar();
                    pnlFondo.Visible = false;
                    Limpiar();
                    MessageBox.Show("Cliente editado");
                }
                if (cond == "NO")
                {
                    Limpiar();
                    MessageBox.Show("Cliente no editado, verificá tu servicio");
                }

            }
            else
            {
                MessageBox.Show("Llenar campo Nombre", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LlamaFoto()
        {
            ServiceUtilitarios.UtilitariosSoapClient clienteUtilitarios = new ServiceUtilitarios.UtilitariosSoapClient();
            MessageBox.Show("Web Service Utilitarios");
            string tipo;

            tipo = "IMAGEN";
            string filtro = clienteUtilitarios.Filtros_Extensiones(tipo);

            dlgFoto.InitialDirectory = "";
            dlgFoto.Filter = filtro;
            dlgFoto.FilterIndex = 2;
            dlgFoto.Title = "Cargador de fotos de clientes";
            if (dlgFoto.ShowDialog() == DialogResult.OK)
            {
                pictureIcono.BackgroundImage = null;
                pictureIcono.Image = new Bitmap(dlgFoto.FileName);
                pictureIcono.SizeMode = PictureBoxSizeMode.Zoom;
                lblNumIco.Text = Path.GetFileName(dlgFoto.FileName);
                lblEligeIcono.Visible = false;
            }
        }

        private void lblEligeIcono_Click(object sender, EventArgs e)
        {
            LlamaFoto();
        }

        private void pictureIcono_Click(object sender, EventArgs e)
        {
            LlamaFoto();
        }

        private void MostrarListaTipo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("SELECT id_tipo, tipo FROM tipo_cliente", con);

                da.Fill(dt);
                cbxTipoCli.DisplayMember = "tipo";
                cbxTipoCli.ValueMember = "id_tipo";
                cbxTipoCli.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }
    }
}
