using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodega_Ventas.MODULOS.VENTAS_PRINCIPAL
{
    public partial class ventasprincipalok : Form
    {
        public ventasprincipalok()
        {
            InitializeComponent();
        }

        private void btnFinTurno_Click(object sender, EventArgs e)
        {
            CAJA.cierrecaja cierracaja = new CAJA.cierrecaja();
            cierracaja.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ventasprincipalok_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlContenido.Visible = true;
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            //PRODUCTOS.productosok productosok = new PRODUCTOS.productosok();
            //productosok.ShowDialog();
        }

        private void btnAplicarDesc_Click(object sender, EventArgs e)
        {
            pnlDescuento.Visible = false;
            pnlSubtotal.Visible = true;
        }

        private void btnSiDesc_Click(object sender, EventArgs e)
        {
            pnlDescuento.Visible = true;
        }

        private void btnMasProductos_Click(object sender, EventArgs e)
        {
            PRODUCTOS.productosok productosok = new PRODUCTOS.productosok();
            productosok.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            usuariosok usuariosok = new usuariosok();
            usuariosok.ShowDialog();
        }

        private void btnOpcProd_Click(object sender, EventArgs e)
        {
            PRODUCTOS.OpcionesProductook OPok = new PRODUCTOS.OpcionesProductook();
            OPok.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            INVENTARIO.inventariokardexok kardex = new INVENTARIO.inventariokardexok();
            kardex.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            //REPORTES.REPORTES_KARDEX.REPORTES_INVENTARIOS_TODOS.Form_Inventarios_Todos reporteInvTodos = new REPORTES.REPORTES_KARDEX.REPORTES_INVENTARIOS_TODOS.Form_Inventarios_Todos();
            //reporteInvTodos.ShowDialog();
        }
    }
}
