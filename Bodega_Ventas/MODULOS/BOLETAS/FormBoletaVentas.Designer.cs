namespace Bodega_Ventas.MODULOS.BOLETAS
{
    partial class FormBoletaVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boletaVenta = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // boletaVenta
            // 
            this.boletaVenta.AccessibilityKeyMap = null;
            this.boletaVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boletaVenta.Location = new System.Drawing.Point(0, 0);
            this.boletaVenta.Name = "boletaVenta";
            this.boletaVenta.Size = new System.Drawing.Size(800, 450);
            this.boletaVenta.TabIndex = 0;
            // 
            // FormBoletaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.boletaVenta);
            this.Name = "FormBoletaVentas";
            this.Text = "FormBoletaVentas";
            this.Load += new System.EventHandler(this.FormBoletaVentas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer boletaVenta;
    }
}