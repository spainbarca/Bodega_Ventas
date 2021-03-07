namespace Bodega_Ventas.MODULOS.CAJA
{
    partial class aperturacaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(aperturacaja));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOmitir = new System.Windows.Forms.Button();
            this.btnIniciarCaja = new System.Windows.Forms.Button();
            this.txtInicioCaja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIdCaja = new System.Windows.Forms.Label();
            this.lblSerialPc = new System.Windows.Forms.Label();
            this.datalistadoCaja = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(128, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 324);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOmitir);
            this.panel2.Controls.Add(this.btnIniciarCaja);
            this.panel2.Controls.Add(this.txtInicioCaja);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 256);
            this.panel2.TabIndex = 5;
            // 
            // btnOmitir
            // 
            this.btnOmitir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOmitir.Font = new System.Drawing.Font("Forte", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOmitir.ForeColor = System.Drawing.Color.Black;
            this.btnOmitir.Location = new System.Drawing.Point(321, 170);
            this.btnOmitir.Name = "btnOmitir";
            this.btnOmitir.Size = new System.Drawing.Size(221, 46);
            this.btnOmitir.TabIndex = 10;
            this.btnOmitir.Text = "Omitir";
            this.btnOmitir.UseVisualStyleBackColor = false;
            this.btnOmitir.Click += new System.EventHandler(this.btnOmitir_Click);
            // 
            // btnIniciarCaja
            // 
            this.btnIniciarCaja.BackColor = System.Drawing.Color.Gold;
            this.btnIniciarCaja.Font = new System.Drawing.Font("Forte", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarCaja.ForeColor = System.Drawing.Color.Black;
            this.btnIniciarCaja.Location = new System.Drawing.Point(71, 170);
            this.btnIniciarCaja.Name = "btnIniciarCaja";
            this.btnIniciarCaja.Size = new System.Drawing.Size(221, 46);
            this.btnIniciarCaja.TabIndex = 9;
            this.btnIniciarCaja.Text = "Iniciar";
            this.btnIniciarCaja.UseVisualStyleBackColor = false;
            this.btnIniciarCaja.Click += new System.EventHandler(this.btnIniciarCaja_Click);
            // 
            // txtInicioCaja
            // 
            this.txtInicioCaja.Font = new System.Drawing.Font("Berlin Sans FB Demi", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicioCaja.Location = new System.Drawing.Point(71, 107);
            this.txtInicioCaja.Name = "txtInicioCaja";
            this.txtInicioCaja.Size = new System.Drawing.Size(471, 38);
            this.txtInicioCaja.TabIndex = 6;
            this.txtInicioCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInicioCaja_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(574, 68);
            this.label1.TabIndex = 5;
            this.label1.Text = "EFECTIVO INICIAL EN LA CAJA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(624, 68);
            this.label3.TabIndex = 4;
            this.label3.Text = "DINERO EN LA CAJA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Coral;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 140);
            this.panel3.TabIndex = 1;
            // 
            // lblIdCaja
            // 
            this.lblIdCaja.AutoSize = true;
            this.lblIdCaja.Location = new System.Drawing.Point(5, 188);
            this.lblIdCaja.Name = "lblIdCaja";
            this.lblIdCaja.Size = new System.Drawing.Size(47, 13);
            this.lblIdCaja.TabIndex = 2;
            this.lblIdCaja.Text = "lblIdCaja";
            // 
            // lblSerialPc
            // 
            this.lblSerialPc.AutoSize = true;
            this.lblSerialPc.Location = new System.Drawing.Point(12, 226);
            this.lblSerialPc.Name = "lblSerialPc";
            this.lblSerialPc.Size = new System.Drawing.Size(56, 13);
            this.lblSerialPc.TabIndex = 3;
            this.lblSerialPc.Text = "lblSerialPc";
            // 
            // datalistadoCaja
            // 
            this.datalistadoCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistadoCaja.Location = new System.Drawing.Point(10, 256);
            this.datalistadoCaja.Name = "datalistadoCaja";
            this.datalistadoCaja.Size = new System.Drawing.Size(81, 65);
            this.datalistadoCaja.TabIndex = 4;
            // 
            // aperturacaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 520);
            this.Controls.Add(this.datalistadoCaja);
            this.Controls.Add(this.lblSerialPc);
            this.Controls.Add(this.lblIdCaja);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "aperturacaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "aperturacaja";
            this.Load += new System.EventHandler(this.aperturacaja_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtInicioCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOmitir;
        private System.Windows.Forms.Button btnIniciarCaja;
        private System.Windows.Forms.Label lblIdCaja;
        private System.Windows.Forms.Label lblSerialPc;
        private System.Windows.Forms.DataGridView datalistadoCaja;
    }
}