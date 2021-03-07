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
using System.Globalization;
using System.Threading;

namespace Bodega_Ventas.MODULOS.CAJA
{
    public partial class cierrecaja : Form
    {
        public cierrecaja()
        {
            InitializeComponent();
        }

        private void btnFinTurno_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("cerrar_caja", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);
                sql.Parameters.AddWithValue("@fechafin", dateFechaCierre.Value);
                sql.Parameters.AddWithValue("@fechacierre", dateFechaCierre.Value);
                sql.ExecuteNonQuery();
                con.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cierrecaja_Load(object sender, EventArgs e)
        {
            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
            lblSerialPc.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblSerialPc.Text = lblSerialPc.Text.Trim();
            MostrarCajaSerial();
            try
            {
                lblIdCaja.Text = datalistadoCaja.SelectedCells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falla en el load");
            }
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
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc.Text);

                da.Fill(dt);
                datalistadoCaja.DataSource = dt;
                con.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("fALLA EN MOSTRARCAJASERIAL");

            }
        }
    }
}
