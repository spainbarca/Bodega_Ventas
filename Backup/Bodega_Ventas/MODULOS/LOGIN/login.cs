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
using System.Net.Mail;
using System.Net;
using System.Management;

namespace Bodega_Ventas.MODULOS
{
    public partial class login : Form
    {
        int conta;
        int contacaja;
        int contaMovCaja;
        public static String idusuariovariable;
        public static String idcajavariable;
        public login()
        {
            InitializeComponent();
        }

        public void DibujarUsuarios()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("select * from usuarios where estado='ACTIVO'", con);
            SqlDataReader rdr = sql.ExecuteReader();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["usuario"].ToString();
                lbl1.Name = rdr["id_usu"].ToString();
                lbl1.Size = new Size(150,25);
                lbl1.Font = new Font("Berlin Sans FB Demi",14);
                lbl1.BackColor = Color.FromArgb(20, 20, 20);
                lbl1.ForeColor = Color.White;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(150,175);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(150, 150);
                box1.Dock = DockStyle.Top;
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["icono"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["usuario"].ToString();
                box1.Cursor = Cursors.Hand;

                pnl1.Controls.Add(lbl1);
                pnl1.Controls.Add(box1);
                lbl1.BringToFront();
                flowLayoutPanel1.Controls.Add(pnl1);

                lbl1.Click += new EventHandler(miEventolbl);
                box1.Click += new EventHandler(miEventobox);
            }
            con.Close();
        }

        private void miEventobox(System.Object sender, EventArgs e)
        {
            txtPruebaLogin.Text = ((PictureBox)sender).Tag.ToString();
            pnlTeclado.Visible = true;
            panel1.Visible = false;
            MostrarPermisos();
        }

        private void miEventolbl (System.Object sender, EventArgs e)
        {
            txtPruebaLogin.Text = ((Label)sender).Text;
            pnlTeclado.Visible = true;
            panel1.Visible = false;
            MostrarPermisos();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            DibujarUsuarios();
            pnlTeclado.Visible = false;
            timer1.Start();
            btnOjoNo.Visible = false;

            pbxLoading.Location = new Point((Width - pbxLoading.Width) / 2, (Height - pbxLoading.Height) / 2);
            panel1.Location = new Point((Width - panel1.Width) / 2, (Height - panel1.Height) / 2);
            pnlRecuClave.Location = new Point((Width - pnlRecuClave.Width) / 2, (Height - pnlRecuClave.Height) / 2);
            pnlTeclado.Location = new Point((Width - pnlTeclado.Width) / 2, (Height - pnlTeclado.Height) / 2);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario o contraseña erróneo", "Datos erróneos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ListarAperturaCajaCierre()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_movimientos_caja_serial", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc.Text);

                da.Fill(dt);
                datalistadoCierreCaja.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void ContarAperturas()
        {
            int i;

            i = datalistadoCierreCaja.Rows.Count;
            contacaja = (i);
        }

        private void AperturarDetalleCierreCaja()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("insertar_detalle_cierrecaja", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@fecha_inicio", DateTime.Today);
                sql.Parameters.AddWithValue("@fecha_fin", DateTime.Today);
                sql.Parameters.AddWithValue("@fecha_cierre", DateTime.Today);
                sql.Parameters.AddWithValue("@ingresos", "0.00");
                sql.Parameters.AddWithValue("@egresos", "0.00");
                sql.Parameters.AddWithValue("@saldo", "0.00");
                sql.Parameters.AddWithValue("@id_usuario", lblIdUsu.Text);
                sql.Parameters.AddWithValue("@total_calc", "0.00");
                sql.Parameters.AddWithValue("@total_real", "0.00");
                sql.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                sql.Parameters.AddWithValue("@diferencia", "0.00");
                sql.Parameters.AddWithValue("@idcaja", lblIdCaja.Text);

                sql.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IniciarSesion()
        {
            CargarUsuario();
            Contar();

            try
            {
                lblIdUsu.Text = datalistado.SelectedCells[1].Value.ToString();
                lblNombre.Text = datalistado.SelectedCells[2].Value.ToString();
                idusuariovariable = lblIdUsu.Text;
            }
            catch
            {

            }

            if (conta > 0) 
            {
                ListarAperturaCajaCierre();
                ContarAperturas();

                if (contacaja == 0 & lblRol.Text!="Vendedor")
                {
                    AperturarDetalleCierreCaja();
                    lblAperturaCaja.Text = "Nuevo***";
                    timer2.Start();
                }
                else
                {
                    if (lblRol.Text != "Vendedor")
                    {
                        MostrarCajaSerialUsuario();
                        ContarMovCajaSerialUsu();
                        try
                        {
                            lblUsuIniCaja.Text = datalistadoCierreCaja.SelectedCells[1].Value.ToString();
                            lblNombreCajero.Text = datalistadoCierreCaja.SelectedCells[2].Value.ToString();
                        }
                        catch 
                        {

                        }
                        
                        if (contaMovCaja == 0)
                        {
                            if (lblUsuIniCaja.Text != "spainbarca" & txtPruebaLogin.Text == "spainbarca")
                            {
                                //MessageBox.Show("Continuaras el turno de*" + lblNombreCajero.Text + "*, Todos los registros seran con ese usuario ", "Caja ya iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lblPermisoCaja.Text = "correcto";
                            }
                            if (lblUsuIniCaja.Text == "spainbarca" & txtPruebaLogin.Text == "spainbarca")
                            {
                                lblPermisoCaja.Text = "correcto";
                            }
                            else if (lblUsuIniCaja.Text != txtPruebaLogin.Text & txtPruebaLogin.Text!="spainbarca")
                            {
                                MessageBox.Show("Para poder continuar con el turno de*" + lblNombreCajero.Text + "*, Inicia sesión con el usuario " + lblUsuIniCaja.Text + " o con el Administrador", "Caja ya iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lblPermisoCaja.Text = "vacio";
                            }
                            else if (lblUsuIniCaja.Text == txtPruebaLogin.Text)
                            {
                                lblPermisoCaja.Text = "correcto";
                            }
                        }
                        else
                        {
                            lblPermisoCaja.Text = "correcto";
                        }

                        if (lblPermisoCaja.Text=="correcto")
                        {
                            lblAperturaCaja.Text = "Aperturado";
                            timer2.Start();
                        }
                    }
                    else
                    {
                        timer2.Start();
                    }
                    
                }
                
            }
        }

        private void MostrarCajaSerialUsuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                
                da = new SqlDataAdapter("mostrar_movimientocaja_serial_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc.Text);
                da.SelectCommand.Parameters.AddWithValue("@id_usu", lblIdUsu.Text);

                da.Fill(dt);
                datalistadoMovimientosValidar.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContarMovCajaSerialUsu()
        {
            int i;
            i = datalistadoMovimientosValidar.Rows.Count;
            contaMovCaja = (i);
        }

        private void Contar()
        {
            int i;
            i = datalistado.Rows.Count;
            conta = (i);
        }

        private void CargarUsuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@clave", txtPassword.Text);
                da.SelectCommand.Parameters.AddWithValue("@usuario", txtPruebaLogin.Text);
                
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void MostrarPermisos()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            
            SqlCommand sql = new SqlCommand("mostrar_permisos",con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@usuario", txtPruebaLogin.Text);
            string importe;

            try
            {
                con.Open();
                importe = Convert.ToString(sql.ExecuteScalar());
                con.Close();
                lblRol.Text = importe;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MostrarCorreos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("SELECT correo_usu FROM usuarios WHERE estado='ACTIVO'", con);

                da.Fill(dt);
                cbxCorreo.DisplayMember = "correo_usu";
                cbxCorreo.ValueMember = "correo_usu";
                cbxCorreo.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOlvidarClave_Click(object sender, EventArgs e)
        {
            pnlRecuClave.Visible = true;
            MostrarCorreos();
        }

        private void btnCerrarRecu_Click(object sender, EventArgs e)
        {
            pnlRecuClave.Visible = false;
        }

        private void MostrarUsuarioCorreo()
        {
            try
            {
                string miusu;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                SqlCommand da = new SqlCommand("mostrar_usuario_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@correo", cbxCorreo.Text);

                con.Open();
                lblmiusu.Text = Convert.ToString(da.ExecuteScalar());
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEnviarRecu_Click(object sender, EventArgs e)
        {
            MostrarUsuarioCorreo();
            richTextBox1.Text = richTextBox1.Text.Replace("@PASSWORD", lblmiusu.Text);
            EnviarCorreo("noe16.30596@gmail.com", "pibeyaesta", richTextBox1.Text, "Solicitud de Contraseña", cbxCorreo.Text, "");
        }

        internal void EnviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add((destinatario));
                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                lblEstadoEnvio.Text = "ENVIADO";
                MessageBox.Show("Clave enviada, revisá tu correo electrónico","Recuperar Clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlRecuClave.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error de envio", "Recuperar Clave");
            }
        }

        private void btnRecuClave_Click(object sender, EventArgs e)
        {
            pnlRecuClave.Visible = true;
            MostrarCorreos();
        }

        private void MostrarCajaSerial()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_cajas_serialHDD", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc.Text);

                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                //ManagementObjectSearcher MOS = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                //foreach (ManagementObject getserial in MOS.Get())
                //{
                //    lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();
                //    MostrarCajaSerial();
                //    try
                //    {
                //        lblIdCaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                //        lblDescCaja.Text = datalistado_caja.SelectedCells[2].Value.ToString();
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //}

                ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");

                lblSerialPc.Text = MOS.Properties["SerialNumber"].Value.ToString();
                lblSerialPc.Text = lblSerialPc.Text.Trim();

                MostrarCajaSerial();
                try
                {
                    lblIdCaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                    lblDescCaja.Text = datalistado_caja.SelectedCells[2].Value.ToString();
                    idcajavariable = lblIdCaja.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay serial Gaaa");
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtPassword.Text = txtPassword.Text + "9";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        //public static string Mid(string param, int startIndex)
        //{
        //    string result = param.Substring(startIndex);
        //    return result;
        //}

        private void btnSupr_Click(object sender, EventArgs e)
        {
            try
            {
                int largo;
                if (txtPassword.Text!="")
                {
                    largo = txtPassword.Text.Length;
                    txtPassword.Text = Mid(txtPassword.Text, 1, largo-1);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnOjoSi_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            btnOjoNo.Visible = true;
            btnOjoSi.Visible = false;
        }

        private void btnOjoNo_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            btnOjoNo.Visible = false;
            btnOjoSi.Visible = true;
        }

        public void Numeros(TextBox CajaTexto, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtPassword, e);
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value<100)
            {
                BackColor = Color.FromArgb(26,26,26);
                progressBar1.Value += 10;
                pbxLoading.Visible = true;
            }
            else
            {
                progressBar1.Value = 0;
                timer2.Stop();
                if (lblAperturaCaja.Text=="Nuevo***" & lblRol.Text!="Vendedor")
                {
                    this.Hide();
                    MODULOS.CAJA.aperturacaja cajaok = new CAJA.aperturacaja();
                    cajaok.ShowDialog();
                    this.Hide();
                }
                else
                {
                    this.Hide();
                    MODULOS.VENTAS_PRINCIPAL.ventasprincipalok ventaok = new VENTAS_PRINCIPAL.ventasprincipalok();
                    ventaok.ShowDialog();
                    this.Hide();
                }
            }
        }

        private void pbxLoading_Click(object sender, EventArgs e)
        {

        }

        private void lblAperturaCaja_Click(object sender, EventArgs e)
        {

        }

        private void cbxCorreo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
