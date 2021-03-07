using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using System.Data.SqlClient;
using System.IO;

namespace Bodega_Ventas.MODULOS.PRODUCTOS
{
    public partial class asistente_excel : Form
    {
        public asistente_excel()
        {
            InitializeComponent();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string ruta;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ruta = folderBrowserDialog1.SelectedPath + "ProductosBodeGaaa.xlsx";
                    SLDocument NombredeExcel = new SLDocument();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("Descripcion", typeof(string));
                    dt.Columns.Add("Codigo", typeof(string));
                    dt.Columns.Add("0", typeof(int));
                    dt.Columns.Add("0.00", typeof(double));
                    NombredeExcel.ImportDataTable(1, 1, dt, true);
                    NombredeExcel.SaveAs(ruta);
                    MessageBox.Show("Plantilla Obtenida ubicala en: " + ruta, "Archivo Excel Creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void TSIGUIENTE_Y_GUARDAR_Click(object sender, EventArgs e)
        {
            PanelDescarga_de_archivo.Visible = false;
            PanelCargarArchivo.Visible = true;
            B1.Enabled = false;
            B2.Enabled = true;
            B3.Enabled = false;
            Paso1.Visible = false;
            Paso2.Visible = true;
            Paso3.Visible = false;
        }

        private void archivo_correcto()
        {
            PanelCargarArchivo.BackColor = Color.White;
            lblarchivoCargado.Visible = true;
            label3.Visible = false;
            MenuStrip1.Visible = true;
            Pcsv.Visible = true;
            LinkLabel3.LinkColor = Color.Black;
            lblnombre_Del_archivo.ForeColor = Color.FromArgb(64, 64, 64);
            PanelCargarArchivo.BackgroundImage = null;

        }

        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog myFileDialog = new OpenFileDialog();

            ServiceUtilitarios.UtilitariosSoapClient clienteUtilitarios = new ServiceUtilitarios.UtilitariosSoapClient();
            MessageBox.Show("Web Service Utilitarios");
            string tipo;

            tipo = "CSV";
            string filtro = clienteUtilitarios.Filtros_Extensiones(tipo);


            myFileDialog.InitialDirectory = @"c:\\temp\";
            myFileDialog.Filter = filtro;
            myFileDialog.FilterIndex = 2;
            myFileDialog.RestoreDirectory = true;
            myFileDialog.Title = "Elija el Archivo .CSV";
            if (myFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblnombre_Del_archivo.Text = myFileDialog.SafeFileName.ToString();
                lblArchivoListo.Text = lblnombre_Del_archivo.Text;
                lblRuta.Text = myFileDialog.FileName.ToString();
                archivo_correcto();
            }
        }

        private void PanelCargarArchivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void PanelCargarArchivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string path in files)
            {
                lblRuta.Text = path;
                string ruta = lblRuta.Text;
                if (ruta.Contains(".csv"))
                {
                    archivo_correcto();
                    lblnombre_Del_archivo.Text = Path.GetFileName(ruta);
                    lblArchivoListo.Text = lblnombre_Del_archivo.Text;
                }
                else
                {
                    MessageBox.Show("Archivo Incorrecto", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        private void asistente_excel_Load(object sender, EventArgs e)
        {
            B1.Enabled = true;
            B2.Enabled = false;
            B3.Enabled = false;
            Paso1.Visible = true;
            Paso2.Visible = false;
            Paso3.Visible = false;
            lblIdusuarioquierover.Text = Convert.ToString(login.idusuariovariable);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelCargarArchivo.Visible = false;
            PanelGuardarData.Visible = true;
            B1.Enabled = false;
            B2.Enabled = false;
            B3.Enabled = true;
            Paso1.Visible = false;
            Paso2.Visible = false;
            Paso3.Visible = true;
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            guardar_datos_Precargados();
        }

        private void guardar_datos_Precargados()
        {
            string Textlines = "";
            string[] Splitline;
            if (System.IO.File.Exists(lblRuta.Text) == true)
            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(lblRuta.Text);
                while (objReader.Peek() != -1)
                {
                    Textlines = objReader.ReadLine();
                    Splitline = Textlines.Split(';');
                    datalistado.ColumnCount = Splitline.Length;
                    datalistado.Rows.Add(Splitline);

                }
            }
            else
            {
                MessageBox.Show("Archivo Inexistente", "CSV Inexistente");
            }

            try
            {
                foreach (DataGridViewRow row in datalistado.Rows)
                {
                    rellenar_vacios();
                    string CODIGO = Convert.ToString(row.Cells["Codigo"].Value);
                    string descripcion = Convert.ToString(row.Cells["Descripcion"].Value);
                    int stock = Convert.ToInt32(row.Cells["stock"].Value);
                    double precio_venta = Convert.ToDouble(row.Cells["precio_venta"].Value);

                    SqlCommand cmd;
                    CONEXION.Conexion.conectate.Open();
                    cmd = new SqlCommand("insertar_producto_importacion", CONEXION.Conexion.conectate);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_prod", descripcion);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureProd.Image.Save(ms, pictureProd.Image.RawFormat);
                    cmd.Parameters.AddWithValue("@imagen", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@categoria", 1);
                    cmd.Parameters.AddWithValue("@subcategoria", 1);
                    cmd.Parameters.AddWithValue("@marca", 1);
                    cmd.Parameters.AddWithValue("@usa_inventario", "SI");
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@precio_compra", 0);
                    cmd.Parameters.AddWithValue("@fecha_venc", "NO APLICA");
                    cmd.Parameters.AddWithValue("@precio_venta", precio_venta);
                    cmd.Parameters.AddWithValue("@codigo", CODIGO);
                    cmd.Parameters.AddWithValue("@unidades", "Unidad");
                    cmd.Parameters.AddWithValue("@impuesto", 0);
                    cmd.Parameters.AddWithValue("@stock_min", 0);
                    cmd.Parameters.AddWithValue("@precio_mayor", 0);
                    cmd.Parameters.AddWithValue("@a_partir_de", 0);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
                    cmd.Parameters.AddWithValue("@motivo", "Registro inicial de Producto");
                    cmd.Parameters.AddWithValue("@cantidad", 0);
                    cmd.Parameters.AddWithValue("@usuario", login.idusuariovariable);
                    cmd.Parameters.AddWithValue("@tipo", "ENTRADA");
                    cmd.Parameters.AddWithValue("@estado", "CONFIRMADO");
                    cmd.Parameters.AddWithValue("@id_caja", productosok.idcaja);

                    

                    cmd.ExecuteNonQuery();
                    CONEXION.Conexion.conectate.Close();


                }
                MessageBox.Show("Importacion Exitosa", "Importacion de Datos");
                Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void rellenar_vacios()
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {
                if (row.Cells["Descripcion"].Value.ToString() == "")
                {
                    row.Cells["Descripcion"].Value = "VACIO@";
                }
                if (row.Cells["Codigo"].Value.ToString() == "")
                {
                    row.Cells["Codigo"].Value = "VACIO@";
                }
                if (row.Cells["stock"].Value.ToString() == "")
                {
                    row.Cells["stock"].Value = 0;
                }
                if (row.Cells["precio_venta"].Value.ToString() == "")
                {
                    row.Cells["precio_venta"].Value = 0;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LlamarImagenProducto()
        {

            ServiceUtilitarios.UtilitariosSoapClient clienteUtilitarios = new ServiceUtilitarios.UtilitariosSoapClient();
            string tipo;

            tipo = "IMAGEN";
            string filtro = clienteUtilitarios.Filtros_Extensiones(tipo);

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

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureProd.Image.Save(ms, pictureProd.Image.RawFormat);
            }
        }

        private void pictureProd_Click(object sender, EventArgs e)
        {
            LlamarImagenProducto();
        }

        private void lblEligeProd_Click(object sender, EventArgs e)
        {
            LlamarImagenProducto();
        }
    }
}
