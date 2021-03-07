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

namespace Bodega_Ventas.MODULOS.PRODUCTOS
{
    public partial class OpcionesProductook : Form
    {
        public OpcionesProductook()
        {
            InitializeComponent();
        }

        private void pnlCategoria_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MostrarCat()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_categoria", con);
                da.Fill(dt);
                datalistadoCat.DataSource = dt;
                con.Close();
                datalistadoCat.Columns[1].Visible = false;
                datalistadoCat.Columns[2].Visible = true;
                datalistadoCat.Columns[3].Visible = true;
                datalistadoCat.Columns[4].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoCat);
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            if (txtDesCat.Text!="")
            {
                if (txtNomCat.Text!="")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("insertar_categoria", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@nombre_cat", txtNomCat.Text);
                        sql.Parameters.AddWithValue("@descripcion_cat", txtDesCat.Text);
                        
                        sql.ExecuteNonQuery();
                        con.Close();
                        MostrarCat();
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre Vacío");
                    
                }
            }
            else
            {
                MessageBox.Show("Descripción Vacía");
            }
        }

        private void btnModCat_Click(object sender, EventArgs e)
        {
            if (txtDesCat.Text != "")
            {
                if (txtNomCat.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("editar_categoria", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@id_cat", lblIdCat.Text);
                        sql.Parameters.AddWithValue("@nombre_cat", txtNomCat.Text);
                        sql.Parameters.AddWithValue("@descripcion_cat", txtDesCat.Text);

                        sql.ExecuteNonQuery();
                        con.Close();
                        MostrarCat();
                        Limpiar();
                        btnSaveCat.Visible = true;
                        btnModCat.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre Vacío");

                }
            }
            else
            {
                MessageBox.Show("Descripción Vacía");
            }
        }

        private void datalistadoCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoCat.Columns["Eli"].Index)
            {
                DialogResult pregunta;
                pregunta = MessageBox.Show("¿De verdad quiere eliminar la categoría", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoCat.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["id_cat"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                    con.Open();
                                    sql = new SqlCommand("eliminar_categoria", con);
                                    sql.CommandType = CommandType.StoredProcedure;

                                    sql.Parameters.AddWithValue("@id_cat", onekey);

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
                        MostrarCat();
                        Limpiar();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void datalistadoCat_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoCat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdCat.Text = datalistadoCat.SelectedCells[1].Value.ToString();
            txtNomCat.Text = datalistadoCat.SelectedCells[3].Value.ToString();
            txtDesCat.Text = datalistadoCat.SelectedCells[4].Value.ToString();
            btnSaveCat.Visible = false;
            btnModCat.Visible = true;
        }

        private void Limpiar()
        {
            txtNomCat.Text = "";
            txtDesCat.Text = "";
        }

        private void btnLimCat_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void OpcionesProductook_Load(object sender, EventArgs e)
        {
            MostrarCat();
            //MostrarSubCat();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Subcategorias

        private void MostrarListaCategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("SELECT id_cat, nombre_cat FROM categorias", con);

                da.Fill(dt);
                cbxCat.DisplayMember = "nombre_cat";
                cbxCat.ValueMember = "id_cat";
                cbxCat.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubcategoria_Click(object sender, EventArgs e)
        {
            pnlCategoria.Visible = false;
            pnlSubcategoria.Visible = true;
            pnlMarca.Visible = false;
            pnlEmpresa.Visible = false;
            MostrarListaCategorias();
            MostrarSubCat();
            btnSaveSub.Visible = true;
        }

        private void btnSaveSub_Click(object sender, EventArgs e)
        {
            if (txtDesSub.Text != "")
            {
                if (txtNomSub.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("insertar_subcategoria", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@categoria", cbxCat.SelectedValue);
                        sql.Parameters.AddWithValue("@nombre_subcat", txtNomSub.Text);
                        sql.Parameters.AddWithValue("@descripcion_subcat", txtDesSub.Text);

                        sql.ExecuteNonQuery();
                        con.Close();
                        MostrarSubCat();
                        LimpiarSub();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre Vacío");

                }
            }
            else
            {
                MessageBox.Show("Descripción Vacía");
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
                datalistadoSub.Columns[1].Visible = false;
                datalistadoSub.Columns[2].Visible = true;
                datalistadoSub.Columns[3].Visible = true;
                datalistadoSub.Columns[4].Visible = true;
                datalistadoSub.Columns[5].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoSub);
        }

        private void btnLimSub_Click(object sender, EventArgs e)
        {
            LimpiarSub();
        }

        private void LimpiarSub()
        {
            txtNomSub.Text = "";
            txtDesSub.Text = "";
            cbxCat.Text = "Seleccione:";
        }

        private void btnModSub_Click(object sender, EventArgs e)
        {
            if (txtDesSub.Text != "")
            {
                if (txtNomSub.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("editar_subcategoria", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@id_subcat", lblIdSub.Text);
                        sql.Parameters.AddWithValue("@categoria", cbxCat.SelectedValue);
                        sql.Parameters.AddWithValue("@nombre_subcat", txtNomSub.Text);
                        sql.Parameters.AddWithValue("@descripcion_subcat", txtDesSub.Text);

                        sql.ExecuteNonQuery();
                        con.Close();
                        MostrarSubCat();
                        LimpiarSub();
                        btnSaveSub.Visible = true;
                        btnModSub.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre Vacío");

                }
            }
            else
            {
                MessageBox.Show("Descripción Vacía");
            }
        }

        private void datalistadoSub_Click(object sender, EventArgs e)
        {
            
        }

        private void datalistadoSub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoSub.Columns["Eli2"].Index)
            {
                DialogResult pregunta;
                pregunta = MessageBox.Show("¿De verdad quiere eliminar la subcategoría", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoSub.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["id_subcat"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                    con.Open();
                                    sql = new SqlCommand("eliminar_subcat", con);
                                    sql.CommandType = CommandType.StoredProcedure;

                                    sql.Parameters.AddWithValue("@id_subcat", onekey);

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
                        MostrarSubCat();
                        LimpiarSub();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void datalistadoSub_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdSub.Text = datalistadoSub.SelectedCells[1].Value.ToString();
            cbxCat.SelectedItem = datalistadoSub.SelectedCells[3].Value.ToString();
            txtNomSub.Text = datalistadoSub.SelectedCells[4].Value.ToString();
            txtDesSub.Text = datalistadoSub.SelectedCells[5].Value.ToString();
            btnSaveSub.Visible = false;
            btnModSub.Visible = true;
        }

        //Marcas

        private void MostrarListaFabricas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("SELECT id_fabrica, nombre_fabrica FROM fabricas", con);

                da.Fill(dt);
                cbxFabrica.DisplayMember = "nombre_fabrica";
                cbxFabrica.ValueMember = "id_fabrica";
                cbxFabrica.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            pnlCategoria.Visible = false;
            pnlSubcategoria.Visible = false;
            pnlEmpresa.Visible = false;
            pnlMarca.Visible = true;
            MostrarMarca();
            MostrarListaFabricas();
            btnSaveMar.Visible = true;
        }

        private void btnSaveMar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    SqlCommand sql = new SqlCommand();
                    sql = new SqlCommand("insertar_marca", con);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@fabrica", cbxFabrica.SelectedValue);
                    sql.Parameters.AddWithValue("@nombre_marca", txtMarca.Text);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureMarca.Image.Save(ms, pictureMarca.Image.RawFormat);

                    sql.Parameters.AddWithValue("@logo", ms.GetBuffer());
                    sql.Parameters.AddWithValue("@nombre_logo", lblNumMar.Text);

                    sql.ExecuteNonQuery();
                    con.Close();
                    MostrarMarca();
                    LimpiarMarca();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nombre Vacío");
            }
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
                datalistadoMarca.Columns[1].Visible = false;
                datalistadoMarca.Columns[2].Visible = true;
                datalistadoMarca.Columns[3].Visible = true;
                datalistadoMarca.Columns[4].Visible = true;
                datalistadoMarca.Columns[5].Visible = true;
                datalistadoMarca.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoMarca);
        }

        private void LimpiarMarca()
        {
            txtMarca.Text = "";
            cbxFabrica.Text = "Seleccione:";
            lblEligeMarca.Visible = true;
            pictureMarca.BackColor = SystemColors.ButtonHighlight;
        }

        private void btnLimMar_Click(object sender, EventArgs e)
        {
            LimpiarMarca();
        }

        private void btnModMar_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    SqlCommand sql = new SqlCommand();
                    sql = new SqlCommand("editar_marca", con);
                    sql.CommandType = CommandType.StoredProcedure;
                    sql.Parameters.AddWithValue("@id_marca", lblIdMarca.Text);
                    sql.Parameters.AddWithValue("@fabrica", cbxFabrica.SelectedValue);
                    sql.Parameters.AddWithValue("@nombre_marca", txtMarca.Text);
                    
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureMarca.Image.Save(ms, pictureMarca.Image.RawFormat);

                    sql.Parameters.AddWithValue("@logo", ms.GetBuffer());
                    sql.Parameters.AddWithValue("@nombre_logo", lblNumMar.Text);

                    sql.ExecuteNonQuery();
                    con.Close();
                    MostrarMarca();
                    LimpiarMarca();
                    btnSaveSub.Visible = true;
                    btnModSub.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nombre Vacío");
            }
        }

        private void datalistadoMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoMarca.Columns["Eli3"].Index)
            {
                DialogResult pregunta;
                pregunta = MessageBox.Show("¿De verdad quiere eliminar la marca?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoMarca.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["id_marca"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                    con.Open();
                                    sql = new SqlCommand("eliminar_marca", con);
                                    sql.CommandType = CommandType.StoredProcedure;

                                    sql.Parameters.AddWithValue("@id_marca", onekey);

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
                        MostrarMarca();
                        LimpiarMarca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void datalistadoMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdMarca.Text = datalistadoMarca.SelectedCells[1].Value.ToString();
            cbxFabrica.SelectedItem = datalistadoMarca.SelectedCells[3].Value.ToString();
            txtMarca.Text = datalistadoMarca.SelectedCells[4].Value.ToString();

            pictureMarca.BackgroundImage = null;
            byte[] b = (Byte[])datalistadoMarca.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            pictureMarca.Image = Image.FromStream(ms);
            pictureMarca.SizeMode = PictureBoxSizeMode.Zoom;
            lblEligeMarca.Visible = false;

            lblNumMar.Text = datalistadoMarca.SelectedCells[6].Value.ToString();
            btnSaveMar.Visible = false;
            btnModMar.Visible = true;
        }

        private void LlamarLogoMarca()
        {
            dlgMarca.InitialDirectory = "";
            dlgMarca.Filter = "Imagenes|*.jpg;*.png";
            dlgMarca.FilterIndex = 2;
            dlgMarca.Title = "Cargador de imagenes de usuario";
            if (dlgMarca.ShowDialog() == DialogResult.OK)
            {
                pictureMarca.BackgroundImage = null;
                pictureMarca.Image = new Bitmap(dlgMarca.FileName);
                pictureMarca.SizeMode = PictureBoxSizeMode.Zoom;
                lblNumMar.Text = Path.GetFileName(dlgMarca.FileName);
                lblEligeMarca.Visible = false;
            }
        }

        private void lblEligeMarca_Click(object sender, EventArgs e)
        {
            LlamarLogoMarca();
        }

        //Empresa

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            pnlCategoria.Visible = false;
            pnlSubcategoria.Visible = false;
            pnlMarca.Visible = false;
            pnlEmpresa.Visible = true;
            MostrarEmpresa();
            btnSaveEmp.Visible = true;
        }

        private void btnSaveEmp_Click(object sender, EventArgs e)
        {
            if (txtDesEmpresa.Text != "")
            {
                if (txtNomEmpresa.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("insertar_fabrica", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@nombre_fabrica", txtNomEmpresa.Text);
                        sql.Parameters.AddWithValue("@descripcion_fabrica", txtDesEmpresa.Text);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pbxEmpresa.Image.Save(ms, pbxEmpresa.Image.RawFormat);

                        sql.Parameters.AddWithValue("@logotipo", ms.GetBuffer());
                        sql.Parameters.AddWithValue("@nombre_logotipo", lblIcoEmp.Text);

                        sql.ExecuteNonQuery();
                        con.Close();
                        MostrarEmpresa();
                        LimpiarEmpresa();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre Vacío");

                }
            }
            else
            {
                MessageBox.Show("Descripción Vacía");
            }
        }

        private void MostrarEmpresa()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                //SqlCommand sql = new SqlCommand();
                da = new SqlDataAdapter("mostrar_fabrica", con);
                da.Fill(dt);
                datalistadoEmpresa.DataSource = dt;
                con.Close();
                datalistadoEmpresa.Columns[1].Visible = false;
                datalistadoEmpresa.Columns[2].Visible = true;
                datalistadoEmpresa.Columns[3].Visible = true;
                datalistadoEmpresa.Columns[4].Visible = true;
                datalistadoEmpresa.Columns[5].Visible = false;
                datalistadoEmpresa.Columns[6].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoEmpresa);
        }

        private void LimpiarEmpresa()
        {
            txtNomEmpresa.Text = "";
            txtDesEmpresa.Text = "";
            lblEligeEmpresa.Visible = true;
            pbxEmpresa.BackColor = SystemColors.ButtonHighlight;
        }

        private void btnLimEmp_Click(object sender, EventArgs e)
        {
            LimpiarEmpresa();
        }

        private void btnModEmp_Click(object sender, EventArgs e)
        {
            if (txtDesEmpresa.Text != "")
            {
                if (txtNomEmpresa.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();
                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("editar_fabrica", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@id_fabrica", lblIdEmp.Text);
                        sql.Parameters.AddWithValue("@nombre_fabrica", txtNomEmpresa.Text);
                        sql.Parameters.AddWithValue("@descripcion_fabrica", txtDesEmpresa.Text);

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pbxEmpresa.Image.Save(ms, pbxEmpresa.Image.RawFormat);

                        sql.Parameters.AddWithValue("@logotipo", ms.GetBuffer());
                        sql.Parameters.AddWithValue("@nombre_logotipo", lblIcoEmp.Text);

                        sql.ExecuteNonQuery();
                        con.Close();
                        MostrarEmpresa();
                        LimpiarEmpresa();
                        btnSaveEmp.Visible = true;
                        btnModEmp.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre Vacío");
                }
            }
            else
            {
                MessageBox.Show("Descripción vacía");
            }
        }

        private void datalistadoEmpresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoEmpresa.Columns["Eli4"].Index)
            {
                DialogResult pregunta;
                pregunta = MessageBox.Show("¿De verdad quiere eliminar la empresa?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoEmpresa.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["id_fabrica"].Value);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                    con.Open();
                                    sql = new SqlCommand("eliminar_fabrica", con);
                                    sql.CommandType = CommandType.StoredProcedure;

                                    sql.Parameters.AddWithValue("@id_fabrica", onekey);

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
                        MostrarEmpresa();
                        LimpiarEmpresa();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void datalistadoEmpresa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdEmp.Text = datalistadoEmpresa.SelectedCells[1].Value.ToString();
            txtNomEmpresa.Text = datalistadoEmpresa.SelectedCells[3].Value.ToString();
            txtDesEmpresa.Text = datalistadoEmpresa.SelectedCells[4].Value.ToString();

            pbxEmpresa.BackgroundImage = null;
            byte[] b = (Byte[])datalistadoEmpresa.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            pbxEmpresa.Image = Image.FromStream(ms);
            pbxEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            lblEligeEmpresa.Visible = false;

            lblIcoEmp.Text = datalistadoEmpresa.SelectedCells[6].Value.ToString();
            btnSaveEmp.Visible = false;
            btnModEmp.Visible = true;
        }

        private void LlamaLogoEmpresa()
        {
            dlgEmpresa.InitialDirectory = "";
            dlgEmpresa.Filter = "Imagenes|*.jpg;*.png";
            dlgEmpresa.FilterIndex = 2;
            dlgEmpresa.Title = "Cargador de imagenes de empresas";
            if (dlgEmpresa.ShowDialog() == DialogResult.OK)
            {
                pbxEmpresa.BackgroundImage = null;
                pbxEmpresa.Image = new Bitmap(dlgEmpresa.FileName);
                pbxEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
                lblIcoEmp.Text = Path.GetFileName(dlgEmpresa.FileName);
                lblEligeEmpresa.Visible = false;
            }
        }

        private void lblEligeEmpresa_Click(object sender, EventArgs e)
        {
            LlamaLogoEmpresa();
        }

        private void pbxEmpresa_Click(object sender, EventArgs e)
        {
            LlamaLogoEmpresa();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            pnlCategoria.Visible = true;
            pnlSubcategoria.Visible = false;
            pnlMarca.Visible = false;
            pnlEmpresa.Visible = false;
            MostrarCat();
            btnSaveCat.Visible = true;
        }

        private void pictureMarca_Click(object sender, EventArgs e)
        {
            LlamarLogoMarca();
        }
    }
}
