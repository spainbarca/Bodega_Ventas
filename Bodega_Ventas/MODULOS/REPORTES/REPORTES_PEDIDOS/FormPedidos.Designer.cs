namespace Bodega_Ventas.MODULOS.REPORTES.REPORTES_PEDIDOS
{
    partial class FormPedidos
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
            this.reportViewerPedidos = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerPedidos
            // 
            this.reportViewerPedidos.AccessibilityKeyMap = null;
            this.reportViewerPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerPedidos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPedidos.Name = "reportViewerPedidos";
            this.reportViewerPedidos.Size = new System.Drawing.Size(800, 450);
            this.reportViewerPedidos.TabIndex = 0;
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerPedidos);
            this.Name = "FormPedidos";
            this.Text = "FormPedidos";
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewerPedidos;
    }
}