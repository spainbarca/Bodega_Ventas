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
using System.Management;

namespace Bodega_Ventas.MODULOS.DASHBOARD
{
    public partial class Dashboard_Principal : Form
    {
        public Dashboard_Principal()
        {
            InitializeComponent();
        }

        string log = "AdminGaaa";

        private void btnVender_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void IniciarSesion()
        {
            MostrarIdAdmin();
            lblIdUsu.Text = Convert.ToString(id_usuadmin);
            MostrarCajaSerial();
            txtlogin.Text = log;
            try
            {
                txtIdCaja.Text = datalistadoCaja.SelectedCells[1].Value.ToString();
                lblCaja.Text = datalistadoCaja.SelectedCells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ListarAperturaCierreCaja();
            ContarAperturaCierreCaja();

            if (contaCajas == 0 & lblROL.Text != "Vendedor")
            {
                AperturarCierreCaja();
                lblAperturaCaja.Text = "Nuevo***";
                timer1.Start();

            }
            else
            {
                if (lblROL.Text != "Vendedor")
                {
                    MostrarMovimientosCajaSerialUsu();
                    ContarMovimientosCajaSerialUsu();
                    try
                    {
                        lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells[1].Value.ToString();
                        lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells[2].Value.ToString();
                        label25.Text = lblusuario_queinicioCaja.Text;
                        label23.Text = txtlogin.Text;
                    }
                    catch
                    {

                    }
                    if (contaMovCaja == 0)
                    {

                        if (lblusuario_queinicioCaja.Text != "AdminGaaa" & txtlogin.Text == "AdminGaaa")
                        {
                            MessageBox.Show("Continuaras Turno de *" + lblnombredeCajero.Text + " Todos los Registros seran con ese Usuario", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lblpermisodeCaja.Text = "correcto";
                        }
                        if (lblusuario_queinicioCaja.Text == "AdminGaaa" & txtlogin.Text == "AdminGaaa")
                        {

                            lblpermisodeCaja.Text = "correcto";
                        }

                        else if (lblusuario_queinicioCaja.Text != txtlogin.Text & txtlogin.Text != "AdminGaaa")
                        {
                            MessageBox.Show("Para poder continuar con el Turno de *" + lblnombredeCajero.Text + "* ,Inicia sesion con el Usuario " + lblusuario_queinicioCaja.Text + " -ó-el Usuario *AdminGaaa*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblpermisodeCaja.Text = "vacio";

                        }
                        else if (lblusuario_queinicioCaja.Text == txtlogin.Text)
                        {
                            lblpermisodeCaja.Text = "correcto";
                        }
                    }
                    else
                    {
                        lblpermisodeCaja.Text = "correcto";
                    }

                    if (lblpermisodeCaja.Text == "correcto")
                    {
                        lblAperturaCaja.Text = "Aperturado";
                        timer1.Start();

                    }
                }
                else
                {
                    timer1.Start();
                }
            }
        }

        private void ListarAperturaCierreCaja()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_movimientos_caja_serial", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIdSerial.Text);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int contaCajas;
        private void ContarAperturaCierreCaja()
        {
            int i;

            i = datalistado_detalle_cierre_de_caja.Rows.Count;
            contaCajas = (i);
        }

        private void AperturarCierreCaja()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_cierrecaja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha_inicio", DateTime.Today);
                cmd.Parameters.AddWithValue("@fecha_fin", DateTime.Today);
                //cmd.Parameters.AddWithValue("@fecha", DateTime.Today);

                cmd.Parameters.AddWithValue("@fecha_cierre", DateTime.Today);
                cmd.Parameters.AddWithValue("@ingresos", "0.00");
                cmd.Parameters.AddWithValue("@egresos", "0.00");
                cmd.Parameters.AddWithValue("@saldo", "0.00");
                cmd.Parameters.AddWithValue("@id_usuario", lblIdUsu.Text);
                cmd.Parameters.AddWithValue("@total_calc", "0.00");
                cmd.Parameters.AddWithValue("@total_real", "0.00");

                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", "0.00");
                cmd.Parameters.AddWithValue("@idcaja", lblidcaja.Text);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarMovimientosCajaSerialUsu()
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
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIdSerial.Text);
                da.SelectCommand.Parameters.AddWithValue("@id_usu", lblIdUsu.Text);
                da.Fill(dt);
                datalistadoValidarMov.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        int contaMovCaja;
        private void ContarMovimientosCajaSerialUsu()
        {
            int i;

            i = datalistadoValidarMov.Rows.Count;
            contaMovCaja = (i);
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

                da = new SqlDataAdapter("mostrar_cajas_serialHDD", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIdSerial.Text);
                da.Fill(dt);
                datalistadoCaja.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int id_usuadmin;

        private void MostrarIdAdmin()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                SqlCommand da = new SqlCommand("SELECT id_usu FROM usuarios WHERE usuario='AdminGaaa'", con);

                con.Open();
                id_usuadmin = Convert.ToInt32(da.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Dashboard_Principal_Load(object sender, EventArgs e)
        {
            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");

            lblIdSerial.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblIdSerial.Text = lblIdSerial.Text.Trim();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 10;
                Panel5.Visible = false;
                PictureBox20.Visible = true;
                PictureBox20.Dock = DockStyle.Fill;
            }
            else
            {
                progressBar1.Value = 0;
                timer1.Stop();

                if (lblAperturaCaja.Text == "Nuevo***")
                {
                    this.Hide();
                    CAJA.aperturacaja opencaja = new CAJA.aperturacaja();
                    opencaja.ShowDialog();
                    Dispose();
                }
                else
                {
                    this.Hide();
                    VENTAS_PRINCIPAL.ventasprincipalok ventasok = new VENTAS_PRINCIPAL.ventasprincipalok();
                    ventasok.ShowDialog();
                    Dispose();
                }

            }
        }

        private void ToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            //Dispose();
            //CONFIGURACION.PANEL_CONFIGURACIONES frm = new CONFIGURACION.PANEL_CONFIGURACIONES();
            //frm.ShowDialog();
        }
    }
}
