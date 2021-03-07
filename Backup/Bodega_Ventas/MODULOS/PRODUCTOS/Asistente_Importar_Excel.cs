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
    public partial class Asistente_Importar_Excel : Form
    {
        public Asistente_Importar_Excel()
        {
            InitializeComponent();
        }

        
        private void Asistente_Importar_Excel_Load(object sender, EventArgs e)
        {
            pnlGuardarData.Visible = false;
            pnlCargarArchivo.Visible = false;
            btnPaso1.Enabled = true;
            btnPaso2.Enabled = false;
            btnPaso3.Enabled = false;
            Paso1.Enabled = true;
            Paso2.BackColor = System.Drawing.Color.MistyRose;
            Paso3.BackColor = System.Drawing.Color.MistyRose;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LinkObtenerPlantilla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string ruta;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    ruta = folderBrowserDialog1.SelectedPath + "productosBodeGaa.xlsx";
                    SLDocument NombredeExcel = new SLDocument();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("codigo", typeof(string));
                    dt.Columns.Add("nombre_prod", typeof(string));
                    //dt.Columns.Add("stock", typeof(int));
                    //dt.Columns.Add("precio_venta", typeof(double));
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

        private void btnSiguientePaso1_Click(object sender, EventArgs e)
        {
            pnlCrearPlantilla.Visible = false;
            pnlCargarArchivo.Visible = true;
            btnPaso1.Enabled = false;
            btnPaso2.Enabled = true;
            btnPaso3.Enabled = false;
            Paso1.BackColor = System.Drawing.Color.MistyRose;
            Paso2.Enabled = true;
            Paso3.BackColor = System.Drawing.Color.MistyRose;
        }

        private void ArchivoCorrecto()
        {
            pnlCargarArchivo.BackColor = Color.White;
            lblarchivoCargado.Visible = true;
            lblNombreArchivo.Visible = false;
            menuStrip2.Visible = true;
            pbxCSV.Visible = true;
            linkSelecArchivo.LinkColor = Color.Black;
            lblNombreArchivo.ForeColor = Color.FromArgb(64, 64, 64);
            pnlCargarArchivo.BackgroundImage = null;
        }

        private void linkSelecArchivo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog myFileDialog = new OpenFileDialog();
            myFileDialog.InitialDirectory = @"c:\\temp\";
            myFileDialog.Filter = "CSV files|*.csv;*.CSV)";
            myFileDialog.FilterIndex = 2;
            myFileDialog.RestoreDirectory = true;
            myFileDialog.Title = "Elija el Archivo .CSV";
            if (myFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblNombreArchivo.Text = myFileDialog.SafeFileName.ToString();
                lblArchivoListo.Text = lblNombreArchivo.Text;
                lblRuta.Text = myFileDialog.FileName.ToString();
                ArchivoCorrecto();
            }
        }

        private void pnlCargarArchivo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pnlCargarArchivo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string path in files)
            {
                lblRuta.Text = path;
                string ruta = lblRuta.Text;
                if (ruta.Contains(".csv"))
                {
                    ArchivoCorrecto();
                    lblNombreArchivo.Text = Path.GetFileName(ruta);
                    lblArchivoListo.Text = lblNombreArchivo.Text;
                    lblNombreArchivo.Visible = true;
                }
                else
                {
                    MessageBox.Show("Archivo Incorrecto", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnSiguientePaso2_Click(object sender, EventArgs e)
        {
            pnlGuardarData.Visible = true;
            pnlCargarArchivo.Visible = false;
            btnPaso1.Enabled = false;
            btnPaso2.Enabled = false;
            btnPaso3.Enabled = true;
            Paso1.BackColor = System.Drawing.Color.MistyRose;
            Paso2.BackColor = System.Drawing.Color.MistyRose;
            Paso3.Enabled = true;
        }

        private void LlamarImagenProducto()
        {
            ServiceReference1.ServiciosSoapClient micliente = new ServiceReference1.ServiciosSoapClient();
            string tipo;

            tipo = "IMAGEN";
            string filtro = micliente.Filtros_Extensiones(tipo);

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

        private void GuardarDatosPrecargados()
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
                    datalistadoCSV.ColumnCount = Splitline.Length;
                    datalistadoCSV.Rows.Add(Splitline);

                }
            }
            else
            {
                MessageBox.Show("Archivo Inexistente", "CSV Inexistente");
            }

            try
            {
                foreach (DataGridViewRow row in datalistadoCSV.Rows)
                {
                    RellenarVacios();
                    string codigo = Convert.ToString(row.Cells["codigo"].Value);
                    string descripcion = Convert.ToString(row.Cells["nombre_prod"].Value);
                    //int stock = Convert.ToInt32(row.Cells["stock"].Value);
                    //double precio_venta = Convert.ToDouble(row.Cells["precio_venta"].Value);

                    SqlCommand cmd;
                    CONEXION.Conexion.conectate.Open();
                    cmd = new SqlCommand("insertar_producto_importacion", CONEXION.Conexion.conectate);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre_prod", descripcion);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    pictureProd.Image.Save(ms, pictureProd.Image.RawFormat);
                    cmd.Parameters.AddWithValue("@imagen", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@categoria", 2);
                    cmd.Parameters.AddWithValue("@subcategoria", 2);
                    cmd.Parameters.AddWithValue("@marca", 2);
                    cmd.Parameters.AddWithValue("@usa_inventario", "SI");
                    cmd.Parameters.AddWithValue("@stock", 0);
                    cmd.Parameters.AddWithValue("@precio_compra", 0);
                    cmd.Parameters.AddWithValue("@fecha_venc", txtfechaoka.Text);
                    cmd.Parameters.AddWithValue("@precio_venta", 0);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    cmd.Parameters.AddWithValue("@unidades", "Unidad");
                    cmd.Parameters.AddWithValue("@impuesto", 0);
                    cmd.Parameters.AddWithValue("@stock_min", 0);
                    cmd.Parameters.AddWithValue("@precio_mayor", 0);
                    cmd.Parameters.AddWithValue("@a_partir_de", 0);

                    cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
                    cmd.Parameters.AddWithValue("@motivo", "Registro inicial de Producto");
                    cmd.Parameters.AddWithValue("@cantidad", 0);
                    cmd.Parameters.AddWithValue("@usuario", productosok.idusuario);
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
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            GuardarDatosPrecargados();
        }

        private void RellenarVacios()
        {
            foreach (DataGridViewRow row in datalistadoCSV.Rows)
            {
                if (row.Cells["nombre_prod"].Value.ToString() == "")
                {
                    row.Cells["nombre_prod"].Value = "VACIO@";
                }
                if (row.Cells["codigo"].Value.ToString() == "")
                {
                    row.Cells["codigo"].Value = "VACIO@";
                }
                //if (row.Cells["stock"].Value.ToString() == "")
                //{
                //    row.Cells["stock"].Value = 0;
                //}
                //if (row.Cells["precio_venta"].Value.ToString() == "")
                //{
                //    row.Cells["precio_venta"].Value = 0;
                //}
            }
        }

        private void pnlArrastraArchivo_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void pnlArrastraArchivo_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void lblEligeProd_Click(object sender, EventArgs e)
        {
            LlamarImagenProducto();
        }

        private void pictureProd_Click(object sender, EventArgs e)
        {
            LlamarImagenProducto();
        }
    }
}
