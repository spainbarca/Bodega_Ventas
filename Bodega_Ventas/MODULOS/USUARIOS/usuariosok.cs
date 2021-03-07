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
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Bodega_Ventas.MODULOS
{
    public partial class usuariosok : Form
    {
        public usuariosok()
        {
            InitializeComponent();
        }

        private void usuariosok_Load(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
            pnlIcono.Visible = false;
            mostrar();
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Estado_icono();
            pnlIcono.Visible = true;
        }

        private void pnlIcono_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Estado_icono()
        {
            try
            {
                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    try
                    {
                        string Icono = Convert.ToString(row.Cells["nom_icono"].Value);

                        if (Icono=="1")
                        {
                            pictureBox1.Visible = false;
                        }
                        else if (Icono == "2")
                        {
                            pictureBox2.Visible = false;
                        }
                        else if (Icono == "3")
                        {
                            pictureBox3.Visible = false;
                        }
                        else if (Icono == "4")
                        {
                            pictureBox4.Visible = false;
                        }
                        else if (Icono == "5")
                        {
                            pictureBox5.Visible = false;
                        }
                        else if (Icono == "6")
                        {
                            pictureBox6.Visible = false;
                        }
                        else if (Icono == "7")
                        {
                            pictureBox7.Visible = false;
                        }
                        else if (Icono == "8")
                        {
                            pictureBox8.Visible = false;
                        }
                        else if (Icono == "9")
                        {
                            pictureBox9.Visible = false;
                        }
                        else if (Icono == "10")
                        {
                            pictureBox10.Visible = false;
                        }
                        else if (Icono == "11")
                        {
                            pictureBox11.Visible = false;
                        }
                        else if (Icono == "12")
                        {
                            pictureBox12.Visible = false;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Validar_Correo(String sCorreo) {
            return Regex.IsMatch(sCorreo, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtClave.Text == txtConfirmarClave.Text)
            {
                if (Validar_Correo(txtEmail.Text) == false) 
                {
                    MessageBox.Show("Correo no válido, no cumple con el formato nombre@dominio.com, "+"por favor, digite de nuevo", "Validacion de correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
                else
                {
                    if (txtNombres.Text != "")
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.Conexion.conectar;
                            con.Open();
                            SqlCommand sql = new SqlCommand();
                            sql = new SqlCommand("insertar_usuario", con);
                            sql.CommandType = CommandType.StoredProcedure;
                            sql.Parameters.AddWithValue("@nombres", txtNombres.Text);
                            sql.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                            sql.Parameters.AddWithValue("@fecha", dateFecha.Text);
                            sql.Parameters.AddWithValue("@genero", cbxGenero.Text);
                            sql.Parameters.AddWithValue("@rol", cbxRol.Text);
                            sql.Parameters.AddWithValue("@correo", txtEmail.Text);
                            sql.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                            sql.Parameters.AddWithValue("@clave", txtClave.Text);
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            pictureIcono.Image.Save(ms, pictureIcono.Image.RawFormat);

                            sql.Parameters.AddWithValue("@icono", ms.GetBuffer());
                            sql.Parameters.AddWithValue("@nomicono", lblNumIco.Text);
                            sql.Parameters.AddWithValue("@estado", "ACTIVO");

                            sql.ExecuteNonQuery();
                            con.Close();
                            mostrar();
                            pnlFondo.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Nombres Vacíos");
                        limpiar();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                txtConfirmarClave.Text = "";
                txtClave.Text = "";
                txtClave.Focus();
            }
        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;
                datalistado.Columns[9].Visible = false;
                datalistado.Columns[10].Visible = false;
                datalistado.Columns[11].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistado);
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

        private void limpiar()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cbxGenero.SelectedIndex = 0;
            cbxRol.SelectedIndex = 0;
            txtEmail.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            lblEligeIcono.Visible = true;
            pictureIcono.BackColor = SystemColors.Desktop;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox1.Image;
            lblNumIco.Text = "1";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            pnlIcono.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox2.Image;
            lblNumIco.Text = "2";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox3.Image;
            lblNumIco.Text = "3";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox4.Image;
            lblNumIco.Text = "4";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox5.Image;
            lblNumIco.Text = "5";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox6.Image;
            lblNumIco.Text = "6";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox7.Image;
            lblNumIco.Text = "7";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox8.Image;
            lblNumIco.Text = "8";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox9.Image;
            lblNumIco.Text = "9";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox10.Image;
            lblNumIco.Text = "10";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox11.Image;
            lblNumIco.Text = "11";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureIcono.Image = pictureBox12.Image;
            lblNumIco.Text = "12";
            lblEligeIcono.Visible = false;
            pnlIcono.Visible = false;
        }

        private void Icono_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = true;
            lblEligeIcono.Visible = true;
            limpiar();
            btnGuardar.Visible = true;
            btnModificar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String datestring = Convert.ToString(dateFecha.Text);

            lblId_Usuario.Text = datalistado.SelectedCells[1].Value.ToString();
            txtNombres.Text = datalistado.SelectedCells[2].Value.ToString();
            txtApellidos.Text = datalistado.SelectedCells[3].Value.ToString();
            datestring =  datalistado.SelectedCells[4].Value.ToString();
            cbxGenero.Text = datalistado.SelectedCells[5].Value.ToString();
            cbxRol.Text = datalistado.SelectedCells[6].Value.ToString();
            txtEmail.Text = datalistado.SelectedCells[7].Value.ToString();

            pictureIcono.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[8].Value;
            MemoryStream ms = new MemoryStream(b);
            pictureIcono.Image = Image.FromStream(ms);
            pictureIcono.SizeMode = PictureBoxSizeMode.Zoom;
            lblEligeIcono.Visible = false;

            lblNumIco.Text = datalistado.SelectedCells[9].Value.ToString();
            txtUsuario.Text = datalistado.SelectedCells[10].Value.ToString();
            txtClave.Text = datalistado.SelectedCells[11].Value.ToString();
            pnlFondo.Visible = true;
            btnGuardar.Visible = false;
            btnModificar.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    SqlCommand sql = new SqlCommand();
                    sql = new SqlCommand("editar_usuario", con);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@idusuario", lblId_Usuario.Text);
                    sql.Parameters.AddWithValue("@nombres", txtNombres.Text);
                    sql.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                    sql.Parameters.AddWithValue("@fecha", dateFecha.Text);
                    sql.Parameters.AddWithValue("@genero", cbxGenero.Text);
                    sql.Parameters.AddWithValue("@rol", cbxRol.Text);
                    sql.Parameters.AddWithValue("@correo", txtEmail.Text);
                    sql.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    sql.Parameters.AddWithValue("@clave", txtClave.Text);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureIcono.Image.Save(ms, pictureIcono.Image.RawFormat);

                    sql.Parameters.AddWithValue("@icono", ms.GetBuffer());
                    sql.Parameters.AddWithValue("@nomicono", lblNumIco.Text);

                    sql.ExecuteNonQuery();
                    con.Close();
                    mostrar();
                    pnlFondo.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Eli"].Index)
            {
                DialogResult pregunta;
                pregunta = MessageBox.Show("¿De verdad quiere eliminar el usuario", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta==DialogResult.OK)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["id_usu"].Value);
                            string user = Convert.ToString(row.Cells["usuario"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                    con.Open();
                                    sql = new SqlCommand("eliminar_usuario", con);
                                    sql.CommandType = CommandType.StoredProcedure;
                                    
                                    sql.Parameters.AddWithValue("@idusuario", onekey);
                                    sql.Parameters.AddWithValue("@usuario", user);

                                    sql.ExecuteNonQuery();
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
                        mostrar();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imagenes de usuario";
            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                pictureIcono.BackgroundImage = null;
                pictureIcono.Image = new Bitmap(dlg.FileName);
                pictureIcono.SizeMode = PictureBoxSizeMode.Zoom;
                lblNumIco.Text = Path.GetFileName(dlg.FileName);
                lblEligeIcono.Visible = false;
                pnlIcono.Visible = false;
            }
        }

        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("buscar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("letra", txtBuscar.Text);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.Columns[1].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;
                datalistado.Columns[9].Visible = false;
                datalistado.Columns[10].Visible = false;
                datalistado.Columns[11].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistado);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar_usuario();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtBuscar, e);
        }

        private void txtConfirmarClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtBuscar, e);
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
