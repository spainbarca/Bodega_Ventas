namespace Bodega_Ventas.MODULOS.REPORTES.REPORTES_KARDEX
{
    partial class FormInventariosTodos
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
            this.reportViewerInvTodos = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerInvTodos
            // 
            this.reportViewerInvTodos.AccessibilityKeyMap = null;
            this.reportViewerInvTodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerInvTodos.Location = new System.Drawing.Point(0, 0);
            this.reportViewerInvTodos.Name = "reportViewerInvTodos";
            this.reportViewerInvTodos.Size = new System.Drawing.Size(800, 450);
            this.reportViewerInvTodos.TabIndex = 0;
            // 
            // FormInventariosTodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerInvTodos);
            this.Name = "FormInventariosTodos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInventariosTodos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInventariosTodos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewerInvTodos;
    }
}