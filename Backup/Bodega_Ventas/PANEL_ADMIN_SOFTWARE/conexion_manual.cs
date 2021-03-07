using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace Bodega_Ventas.PANEL_ADMIN_SOFTWARE
{
    public partial class conexion_manual : Form
    {
        private CONEXION.AES aes = new CONEXION.AES();
        public conexion_manual()
        {
            InitializeComponent();
        }

        public void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
        string dbcnString;
        public void ReadfromXML()
        {

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, CONEXION.Desencriptacion.appPwdUnique, int.Parse("256")));

            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                mostrar();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mostrar();
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

                da = new SqlDataAdapter("mostrar_usuario", con);




                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                SavetoXML(aes.Encrypt(txtCnString.Text, CONEXION.Desencriptacion.appPwdUnique, int.Parse("256")));

                MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sin conexion a la Base de datos", "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistado);

        }

        private void conexion_manual_Load(object sender, EventArgs e)
        {
            ReadfromXML();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCnString_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
