using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bodega_Ventas.CONEXION
{
    class Conexion
    {
        public static string conectar = Convert.ToString(CONEXION.Desencriptacion.checkServer());


        public static SqlConnection conectate = new SqlConnection(conectar);
        internal void abrir()
        {
            if (conectate.State == ConnectionState.Closed)
            {
                conectate.Open();
            }
        }
        internal void cerrar()
        {
            if (conectate.State == ConnectionState.Open)
            {
                conectate.Close();
            }
        }
    }
}
