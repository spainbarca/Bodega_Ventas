using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bodega_Ventas.CONEXION
{
    public static class DataHelper
    {
        public static DataTable LoadDataTable()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();

            da = new SqlDataAdapter("SELECT TOP 100 nombre_prod FROM producto", con);

            da.Fill(dt);


            return dt;

        }

        public static AutoCompleteStringCollection LoadAutoComplete()
        {
            DataTable dt = LoadDataTable();

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["nombre_prod"]));
            }

            return stringCol;
        }
    }
}
