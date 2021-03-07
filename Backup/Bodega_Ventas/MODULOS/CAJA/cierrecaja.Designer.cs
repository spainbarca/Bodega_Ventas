namespace Bodega_Ventas.MODULOS.CAJA
{
    partial class cierrecaja
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
            this.btnFinTurno = new System.Windows.Forms.Button();
            this.dateFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.lblIdCaja = new System.Windows.Forms.Label();
            this.datalistadoCaja = new System.Windows.Forms.DataGridView();
            this.lblSerialPc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFinTurno
            // 
            this.btnFinTurno.BackColor = System.Drawing.Color.Red;
            this.btnFinTurno.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinTurno.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFinTurno.Location = new System.Drawing.Point(621, 12);
            this.btnFinTurno.Name = "btnFinTurno";
            this.btnFinTurno.Size = new System.Drawing.Size(167, 41);
            this.btnFinTurno.TabIndex = 0;
            this.btnFinTurno.Text = "FINALIZAR TURNO";
            this.btnFinTurno.UseVisualStyleBackColor = false;
            this.btnFinTurno.Click += new System.EventHandler(this.btnFinTurno_Click);
            // 
            // dateFechaCierre
            // 
            this.dateFechaCierre.CustomFormat = "MM/dd/yyyy";
            this.dateFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFechaCierre.Location = new System.Drawing.Point(220, 83);
            this.dateFechaCierre.Name = "dateFechaCierre";
            this.dateFechaCierre.Size = new System.Drawing.Size(333, 20);
            this.dateFechaCierre.TabIndex = 1;
            // 
            // lblIdCaja
            // 
            this.lblIdCaja.AutoSize = true;
            this.lblIdCaja.Location = new System.Drawing.Point(478, 188);
            this.lblIdCaja.Name = "lblIdCaja";
            this.lblIdCaja.Size = new System.Drawing.Size(35, 13);
            this.lblIdCaja.TabIndex = 2;
            this.lblIdCaja.Text = "label1";
            // 
            // datalistadoCaja
            // 
            this.datalistadoCaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistadoCaja.Location = new System.Drawing.Point(278, 260);
            this.datalistadoCaja.Name = "datalistadoCaja";
            this.datalistadoCaja.Size = new System.Drawing.Size(265, 65);
            this.datalistadoCaja.TabIndex = 7;
            // 
            // lblSerialPc
            // 
            this.lblSerialPc.AutoSize = true;
            this.lblSerialPc.Location = new System.Drawing.Point(478, 223);
            this.lblSerialPc.Name = "lblSerialPc";
            this.lblSerialPc.Size = new System.Drawing.Size(56, 13);
            this.lblSerialPc.TabIndex = 6;
            this.lblSerialPc.Text = "lblSerialPc";
            // 
            // cierrecaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.datalistadoCaja);
            this.Controls.Add(this.lblSerialPc);
            this.Controls.Add(this.lblIdCaja);
            this.Controls.Add(this.dateFechaCierre);
            this.Controls.Add(this.btnFinTurno);
            this.Name = "cierrecaja";
            this.Text = "cierrecaja";
            this.Load += new System.EventHandler(this.cierrecaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinTurno;
        private System.Windows.Forms.DateTimePicker dateFechaCierre;
        private System.Windows.Forms.Label lblIdCaja;
        private System.Windows.Forms.DataGridView datalistadoCaja;
        private System.Windows.Forms.Label lblSerialPc;
    }
}