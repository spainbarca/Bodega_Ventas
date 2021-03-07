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
using Bodega_Ventas.MODULOS.VENTAS_PRINCIPAL;

namespace Bodega_Ventas.MODULOS.CAJA
{
    public partial class aperturacaja : Form
    {
        public aperturacaja()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarCaja_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("editar_dinero_cajainicial", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);
                sql.Parameters.AddWithValue("@saldo", txtInicioCaja.Text);
                sql.ExecuteNonQuery();
                con.Close();

                this.Hide();
                MODULOS.VENTAS_PRINCIPAL.ventasprincipalok ventasok = new ventasprincipalok();
                ventasok.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aperturacaja_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
           
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
                MessageBox.Show(ex.Message);
            }
        }

        private static void OnlyNumber(KeyPressEventArgs e, bool isdecimal)
        {
            String aceptados;
            if (!isdecimal)
            {
                aceptados = "0123456789." + Convert.ToChar(8);
            }
            else
                aceptados = "0123456789," + Convert.ToChar(8);

            if (aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("editar_dinero_cajainicial", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);
                sql.Parameters.AddWithValue("@saldo", 0);
                sql.ExecuteNonQuery();
                con.Close();

                this.Hide();
                MODULOS.VENTAS_PRINCIPAL.ventasprincipalok ventasok = new ventasprincipalok();
                ventasok.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtInicioCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            CONEXION.Separadores_Numeros.Separador_de_Numeros(txtInicioCaja, e);
        }
    }
}
