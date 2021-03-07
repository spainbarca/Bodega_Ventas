namespace Bodega_Ventas.MODULOS.PRODUCTOS
{
    partial class Asistente_Importar_Excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asistente_Importar_Excel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPaso1 = new System.Windows.Forms.Button();
            this.btnPaso2 = new System.Windows.Forms.Button();
            this.btnPaso3 = new System.Windows.Forms.Button();
            this.flowPasos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.Paso1 = new System.Windows.Forms.Panel();
            this.Paso2 = new System.Windows.Forms.Panel();
            this.Paso3 = new System.Windows.Forms.Panel();
            this.pnlCrearPlantilla = new System.Windows.Forms.Panel();
            this.pnlDescarga = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkObtenerPlantilla = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSiguientePaso1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCargarArchivo = new System.Windows.Forms.Panel();
            this.pnlArrastraArchivo = new System.Windows.Forms.Panel();
            this.pbxCSV = new System.Windows.Forms.PictureBox();
            this.linkSelecArchivo = new System.Windows.Forms.LinkLabel();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.lblarchivoCargado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSiguiente = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.btnSiguientePaso2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGuardarData = new System.Windows.Forms.Panel();
            this.lblRuta = new System.Windows.Forms.Label();
            this.datalistadoCSV = new System.Windows.Forms.DataGridView();
            this.btnIniciar = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblArchivoListo = new System.Windows.Forms.Label();
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtfechaoka = new System.Windows.Forms.DateTimePicker();
            this.Label8 = new System.Windows.Forms.Label();
            this.lblEligeProd = new System.Windows.Forms.Label();
            this.pictureProd = new System.Windows.Forms.PictureBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgProd = new System.Windows.Forms.OpenFileDialog();
            this.lblIcoProd = new System.Windows.Forms.Label();
            this.flowPasos.SuspendLayout();
            this.pnlCrearPlantilla.SuspendLayout();
            this.pnlDescarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlCargarArchivo.SuspendLayout();
            this.pnlArrastraArchivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCSV)).BeginInit();
            this.pnlSiguiente.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.pnlGuardarData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoCSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaso1
            // 
            this.btnPaso1.BackColor = System.Drawing.Color.PaleGreen;
            this.btnPaso1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaso1.Location = new System.Drawing.Point(3, 3);
            this.btnPaso1.Name = "btnPaso1";
            this.btnPaso1.Size = new System.Drawing.Size(290, 70);
            this.btnPaso1.TabIndex = 0;
            this.btnPaso1.Text = "PASO 1\r\nElegir Archivo";
            this.btnPaso1.UseVisualStyleBackColor = false;
            // 
            // btnPaso2
            // 
            this.btnPaso2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPaso2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaso2.Location = new System.Drawing.Point(299, 3);
            this.btnPaso2.Name = "btnPaso2";
            this.btnPaso2.Size = new System.Drawing.Size(290, 70);
            this.btnPaso2.TabIndex = 1;
            this.btnPaso2.Text = "PASO 2\r\nCargar Archivo .CSV";
            this.btnPaso2.UseVisualStyleBackColor = false;
            // 
            // btnPaso3
            // 
            this.btnPaso3.BackColor = System.Drawing.Color.Khaki;
            this.btnPaso3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaso3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaso3.Location = new System.Drawing.Point(595, 3);
            this.btnPaso3.Name = "btnPaso3";
            this.btnPaso3.Size = new System.Drawing.Size(290, 70);
            this.btnPaso3.TabIndex = 2;
            this.btnPaso3.Text = "PASO 3\r\nGuardar Datos";
            this.btnPaso3.UseVisualStyleBackColor = false;
            // 
            // flowPasos
            // 
            this.flowPasos.BackColor = System.Drawing.Color.MistyRose;
            this.flowPasos.Controls.Add(this.btnPaso1);
            this.flowPasos.Controls.Add(this.btnPaso2);
            this.flowPasos.Controls.Add(this.btnPaso3);
            this.flowPasos.Controls.Add(this.panel1);
            this.flowPasos.Controls.Add(this.btnCerrar);
            this.flowPasos.Controls.Add(this.Paso1);
            this.flowPasos.Controls.Add(this.Paso2);
            this.flowPasos.Controls.Add(this.Paso3);
            this.flowPasos.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowPasos.Location = new System.Drawing.Point(0, 0);
            this.flowPasos.Name = "flowPasos";
            this.flowPasos.Size = new System.Drawing.Size(1164, 89);
            this.flowPasos.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(891, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 70);
            this.panel1.TabIndex = 9;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrar.Location = new System.Drawing.Point(1069, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(83, 70);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Paso1
            // 
            this.Paso1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(217)))), ((int)(((byte)(65)))));
            this.Paso1.Location = new System.Drawing.Point(3, 79);
            this.Paso1.Name = "Paso1";
            this.Paso1.Size = new System.Drawing.Size(290, 4);
            this.Paso1.TabIndex = 7;
            // 
            // Paso2
            // 
            this.Paso2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Paso2.Location = new System.Drawing.Point(299, 79);
            this.Paso2.Name = "Paso2";
            this.Paso2.Size = new System.Drawing.Size(290, 4);
            this.Paso2.TabIndex = 8;
            // 
            // Paso3
            // 
            this.Paso3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(1)))));
            this.Paso3.Location = new System.Drawing.Point(595, 79);
            this.Paso3.Name = "Paso3";
            this.Paso3.Size = new System.Drawing.Size(290, 4);
            this.Paso3.TabIndex = 6;
            // 
            // pnlCrearPlantilla
            // 
            this.pnlCrearPlantilla.BackColor = System.Drawing.Color.MistyRose;
            this.pnlCrearPlantilla.Controls.Add(this.pnlDescarga);
            this.pnlCrearPlantilla.Controls.Add(this.label6);
            this.pnlCrearPlantilla.Controls.Add(this.menuStrip1);
            this.pnlCrearPlantilla.Location = new System.Drawing.Point(3, 3);
            this.pnlCrearPlantilla.Name = "pnlCrearPlantilla";
            this.pnlCrearPlantilla.Size = new System.Drawing.Size(821, 192);
            this.pnlCrearPlantilla.TabIndex = 4;
            // 
            // pnlDescarga
            // 
            this.pnlDescarga.Controls.Add(this.PictureBox2);
            this.pnlDescarga.Controls.Add(this.label1);
            this.pnlDescarga.Controls.Add(this.linkObtenerPlantilla);
            this.pnlDescarga.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDescarga.Location = new System.Drawing.Point(16, 52);
            this.pnlDescarga.Name = "pnlDescarga";
            this.pnlDescarga.Size = new System.Drawing.Size(635, 108);
            this.pnlDescarga.TabIndex = 14;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
            this.PictureBox2.Location = new System.Drawing.Point(15, 16);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(63, 46);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox2.TabIndex = 15;
            this.PictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Una vez Obtenido Llena el Archivo Excel y Guardalo como Archivo .CSV";
            // 
            // linkObtenerPlantilla
            // 
            this.linkObtenerPlantilla.AutoSize = true;
            this.linkObtenerPlantilla.Font = new System.Drawing.Font("Berlin Sans FB Demi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkObtenerPlantilla.Location = new System.Drawing.Point(103, 16);
            this.linkObtenerPlantilla.Name = "linkObtenerPlantilla";
            this.linkObtenerPlantilla.Size = new System.Drawing.Size(434, 18);
            this.linkObtenerPlantilla.TabIndex = 0;
            this.linkObtenerPlantilla.TabStop = true;
            this.linkObtenerPlantilla.Text = "Obtener Plantilla (Selecciona una Carpeta donde Obtenerla)";
            this.linkObtenerPlantilla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkObtenerPlantilla.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkObtenerPlantilla_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Descarga:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.MistyRose;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSiguientePaso1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 163);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 29);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnSiguientePaso1
            // 
            this.btnSiguientePaso1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSiguientePaso1.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSiguientePaso1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSiguientePaso1.ForeColor = System.Drawing.Color.Black;
            this.btnSiguientePaso1.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguientePaso1.Image")));
            this.btnSiguientePaso1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiguientePaso1.Name = "btnSiguientePaso1";
            this.btnSiguientePaso1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSiguientePaso1.Size = new System.Drawing.Size(99, 25);
            this.btnSiguientePaso1.Text = "Siguiente";
            this.btnSiguientePaso1.Click += new System.EventHandler(this.btnSiguientePaso1_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 651);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1164, 10);
            this.pnlBottom.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.MistyRose;
            this.flowLayoutPanel1.Controls.Add(this.pnlCrearPlantilla);
            this.flowLayoutPanel1.Controls.Add(this.pnlCargarArchivo);
            this.flowLayoutPanel1.Controls.Add(this.pnlGuardarData);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 89);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1164, 562);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // pnlCargarArchivo
            // 
            this.pnlCargarArchivo.BackColor = System.Drawing.Color.DarkGreen;
            this.pnlCargarArchivo.Controls.Add(this.pnlArrastraArchivo);
            this.pnlCargarArchivo.Controls.Add(this.lblarchivoCargado);
            this.pnlCargarArchivo.Controls.Add(this.label4);
            this.pnlCargarArchivo.Controls.Add(this.pnlSiguiente);
            this.pnlCargarArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlCargarArchivo.Location = new System.Drawing.Point(3, 201);
            this.pnlCargarArchivo.Name = "pnlCargarArchivo";
            this.pnlCargarArchivo.Size = new System.Drawing.Size(1120, 487);
            this.pnlCargarArchivo.TabIndex = 5;
            this.pnlCargarArchivo.Visible = false;
            this.pnlCargarArchivo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlCargarArchivo_DragDrop);
            this.pnlCargarArchivo.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlCargarArchivo_DragEnter);
            // 
            // pnlArrastraArchivo
            // 
            this.pnlArrastraArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlArrastraArchivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlArrastraArchivo.Controls.Add(this.pbxCSV);
            this.pnlArrastraArchivo.Controls.Add(this.linkSelecArchivo);
            this.pnlArrastraArchivo.Controls.Add(this.lblNombreArchivo);
            this.pnlArrastraArchivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlArrastraArchivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArrastraArchivo.Location = new System.Drawing.Point(0, 80);
            this.pnlArrastraArchivo.Name = "pnlArrastraArchivo";
            this.pnlArrastraArchivo.Size = new System.Drawing.Size(1120, 219);
            this.pnlArrastraArchivo.TabIndex = 604;
            this.pnlArrastraArchivo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlArrastraArchivo_DragDrop);
            this.pnlArrastraArchivo.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlArrastraArchivo_DragEnter);
            // 
            // pbxCSV
            // 
            this.pbxCSV.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxCSV.BackgroundImage")));
            this.pbxCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCSV.Location = new System.Drawing.Point(0, 0);
            this.pbxCSV.Name = "pbxCSV";
            this.pbxCSV.Size = new System.Drawing.Size(1116, 151);
            this.pbxCSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCSV.TabIndex = 604;
            this.pbxCSV.TabStop = false;
            this.pbxCSV.Visible = false;
            // 
            // linkSelecArchivo
            // 
            this.linkSelecArchivo.BackColor = System.Drawing.Color.Transparent;
            this.linkSelecArchivo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkSelecArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.linkSelecArchivo.LinkColor = System.Drawing.Color.White;
            this.linkSelecArchivo.Location = new System.Drawing.Point(0, 151);
            this.linkSelecArchivo.Name = "linkSelecArchivo";
            this.linkSelecArchivo.Size = new System.Drawing.Size(1116, 31);
            this.linkSelecArchivo.TabIndex = 601;
            this.linkSelecArchivo.TabStop = true;
            this.linkSelecArchivo.Text = "Seleccionar archivo";
            this.linkSelecArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkSelecArchivo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelecArchivo_LinkClicked);
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreArchivo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblNombreArchivo.ForeColor = System.Drawing.Color.White;
            this.lblNombreArchivo.Location = new System.Drawing.Point(0, 182);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(1116, 33);
            this.lblNombreArchivo.TabIndex = 602;
            this.lblNombreArchivo.Text = "Arrastra aqui el Archivo .CSV";
            this.lblNombreArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblarchivoCargado
            // 
            this.lblarchivoCargado.BackColor = System.Drawing.Color.Transparent;
            this.lblarchivoCargado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblarchivoCargado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblarchivoCargado.ForeColor = System.Drawing.Color.DimGray;
            this.lblarchivoCargado.Location = new System.Drawing.Point(0, 45);
            this.lblarchivoCargado.Name = "lblarchivoCargado";
            this.lblarchivoCargado.Size = new System.Drawing.Size(1120, 35);
            this.lblarchivoCargado.TabIndex = 603;
            this.lblarchivoCargado.Text = "Archivo Cargado";
            this.lblarchivoCargado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblarchivoCargado.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkGreen;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1120, 45);
            this.label4.TabIndex = 602;
            this.label4.Text = "Recuerda que el Archivo Excel debes Guardarlo como Archivo .CSV";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSiguiente
            // 
            this.pnlSiguiente.Controls.Add(this.menuStrip2);
            this.pnlSiguiente.Location = new System.Drawing.Point(441, 321);
            this.pnlSiguiente.Name = "pnlSiguiente";
            this.pnlSiguiente.Size = new System.Drawing.Size(183, 49);
            this.pnlSiguiente.TabIndex = 603;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSiguientePaso2});
            this.menuStrip2.Location = new System.Drawing.Point(28, 7);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(134, 42);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // btnSiguientePaso2
            // 
            this.btnSiguientePaso2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSiguientePaso2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSiguientePaso2.ForeColor = System.Drawing.Color.White;
            this.btnSiguientePaso2.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguientePaso2.Image")));
            this.btnSiguientePaso2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiguientePaso2.Name = "btnSiguientePaso2";
            this.btnSiguientePaso2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSiguientePaso2.Size = new System.Drawing.Size(124, 38);
            this.btnSiguientePaso2.Text = "Siguiente";
            this.btnSiguientePaso2.Click += new System.EventHandler(this.btnSiguientePaso2_Click);
            // 
            // pnlGuardarData
            // 
            this.pnlGuardarData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.pnlGuardarData.Controls.Add(this.lblIcoProd);
            this.pnlGuardarData.Controls.Add(this.lblEligeProd);
            this.pnlGuardarData.Controls.Add(this.pictureProd);
            this.pnlGuardarData.Controls.Add(this.txtfechaoka);
            this.pnlGuardarData.Controls.Add(this.Label8);
            this.pnlGuardarData.Controls.Add(this.lblRuta);
            this.pnlGuardarData.Controls.Add(this.datalistadoCSV);
            this.pnlGuardarData.Controls.Add(this.btnIniciar);
            this.pnlGuardarData.Controls.Add(this.Label7);
            this.pnlGuardarData.Controls.Add(this.lblArchivoListo);
            this.pnlGuardarData.Controls.Add(this.PictureBox5);
            this.pnlGuardarData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGuardarData.Location = new System.Drawing.Point(3, 694);
            this.pnlGuardarData.Name = "pnlGuardarData";
            this.pnlGuardarData.Size = new System.Drawing.Size(1120, 266);
            this.pnlGuardarData.TabIndex = 6;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(1063, 22);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(35, 13);
            this.lblRuta.TabIndex = 614;
            this.lblRuta.Text = "label2";
            // 
            // datalistadoCSV
            // 
            this.datalistadoCSV.AllowUserToAddRows = false;
            this.datalistadoCSV.AllowUserToDeleteRows = false;
            this.datalistadoCSV.AllowUserToResizeRows = false;
            this.datalistadoCSV.BackgroundColor = System.Drawing.Color.White;
            this.datalistadoCSV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.datalistadoCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistadoCSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre_prod});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datalistadoCSV.DefaultCellStyle = dataGridViewCellStyle5;
            this.datalistadoCSV.Location = new System.Drawing.Point(567, 20);
            this.datalistadoCSV.Name = "datalistadoCSV";
            this.datalistadoCSV.ReadOnly = true;
            this.datalistadoCSV.RowHeadersVisible = false;
            this.datalistadoCSV.RowHeadersWidth = 5;
            this.datalistadoCSV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.ForestGreen;
            this.datalistadoCSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistadoCSV.Size = new System.Drawing.Size(481, 227);
            this.datalistadoCSV.TabIndex = 613;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(1)))));
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.ForeColor = System.Drawing.Color.Black;
            this.btnIniciar.Location = new System.Drawing.Point(12, 86);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(356, 39);
            this.btnIniciar.TabIndex = 608;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.White;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.Location = new System.Drawing.Point(12, 56);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(355, 17);
            this.Label7.TabIndex = 607;
            this.Label7.Text = "Todo listo para realizar la Importacion de Datos";
            // 
            // lblArchivoListo
            // 
            this.lblArchivoListo.AutoSize = true;
            this.lblArchivoListo.BackColor = System.Drawing.Color.White;
            this.lblArchivoListo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblArchivoListo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(199)))), ((int)(((byte)(62)))));
            this.lblArchivoListo.Location = new System.Drawing.Point(58, 20);
            this.lblArchivoListo.Name = "lblArchivoListo";
            this.lblArchivoListo.Size = new System.Drawing.Size(107, 17);
            this.lblArchivoListo.TabIndex = 606;
            this.lblArchivoListo.Text = "MiArchivo.csv";
            // 
            // PictureBox5
            // 
            this.PictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox5.Image")));
            this.PictureBox5.Location = new System.Drawing.Point(11, 11);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(41, 26);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox5.TabIndex = 605;
            this.PictureBox5.TabStop = false;
            // 
            // txtfechaoka
            // 
            this.txtfechaoka.CustomFormat = "MM/dd/yyyy";
            this.txtfechaoka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfechaoka.Location = new System.Drawing.Point(412, 216);
            this.txtfechaoka.Name = "txtfechaoka";
            this.txtfechaoka.Size = new System.Drawing.Size(149, 20);
            this.txtfechaoka.TabIndex = 616;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(409, 200);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(83, 13);
            this.Label8.TabIndex = 615;
            this.Label8.Text = "Fecha de Venc:";
            // 
            // lblEligeProd
            // 
            this.lblEligeProd.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblEligeProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEligeProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEligeProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEligeProd.Location = new System.Drawing.Point(412, 36);
            this.lblEligeProd.Name = "lblEligeProd";
            this.lblEligeProd.Size = new System.Drawing.Size(140, 130);
            this.lblEligeProd.TabIndex = 617;
            this.lblEligeProd.Text = "Elige logotipo";
            this.lblEligeProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEligeProd.Click += new System.EventHandler(this.lblEligeProd_Click);
            // 
            // pictureProd
            // 
            this.pictureProd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureProd.Location = new System.Drawing.Point(412, 36);
            this.pictureProd.Name = "pictureProd";
            this.pictureProd.Size = new System.Drawing.Size(140, 130);
            this.pictureProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureProd.TabIndex = 618;
            this.pictureProd.TabStop = false;
            this.pictureProd.Click += new System.EventHandler(this.pictureProd_Click);
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nombre_prod
            // 
            this.nombre_prod.HeaderText = "nombre_prod";
            this.nombre_prod.Name = "nombre_prod";
            this.nombre_prod.ReadOnly = true;
            // 
            // dlgProd
            // 
            this.dlgProd.FileName = "dlgProd";
            // 
            // lblIcoProd
            // 
            this.lblIcoProd.AutoSize = true;
            this.lblIcoProd.Location = new System.Drawing.Point(438, 20);
            this.lblIcoProd.Name = "lblIcoProd";
            this.lblIcoProd.Size = new System.Drawing.Size(82, 13);
            this.lblIcoProd.TabIndex = 625;
            this.lblIcoProd.Text = "Imagen General";
            // 
            // Asistente_Importar_Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 661);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.flowPasos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Asistente_Importar_Excel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistente_Importar_Excel";
            this.Load += new System.EventHandler(this.Asistente_Importar_Excel_Load);
            this.flowPasos.ResumeLayout(false);
            this.pnlCrearPlantilla.ResumeLayout(false);
            this.pnlCrearPlantilla.PerformLayout();
            this.pnlDescarga.ResumeLayout(false);
            this.pnlDescarga.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlCargarArchivo.ResumeLayout(false);
            this.pnlArrastraArchivo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCSV)).EndInit();
            this.pnlSiguiente.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.pnlGuardarData.ResumeLayout(false);
            this.pnlGuardarData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoCSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPaso1;
        private System.Windows.Forms.Button btnPaso2;
        private System.Windows.Forms.Button btnPaso3;
        private System.Windows.Forms.FlowLayoutPanel flowPasos;
        private System.Windows.Forms.Panel Paso1;
        private System.Windows.Forms.Panel Paso2;
        private System.Windows.Forms.Panel Paso3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pnlCrearPlantilla;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlDescarga;
        private System.Windows.Forms.LinkLabel linkObtenerPlantilla;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem btnSiguientePaso1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlArrastraArchivo;
        private System.Windows.Forms.PictureBox pbxCSV;
        internal System.Windows.Forms.LinkLabel linkSelecArchivo;
        internal System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Panel pnlSiguiente;
        private System.Windows.Forms.MenuStrip menuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem btnSiguientePaso2;
        internal System.Windows.Forms.Label lblarchivoCargado;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlGuardarData;
        public System.Windows.Forms.DataGridView datalistadoCSV;
        internal System.Windows.Forms.Label btnIniciar;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblArchivoListo;
        internal System.Windows.Forms.PictureBox PictureBox5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblRuta;
        internal System.Windows.Forms.Panel pnlCargarArchivo;
        internal System.Windows.Forms.DateTimePicker txtfechaoka;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label lblEligeProd;
        private System.Windows.Forms.PictureBox pictureProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_prod;
        private System.Windows.Forms.OpenFileDialog dlgProd;
        private System.Windows.Forms.Label lblIcoProd;
    }
}