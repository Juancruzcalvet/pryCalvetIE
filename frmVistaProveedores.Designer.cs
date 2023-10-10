namespace pryCalvetIE
{
    partial class frmVistaProveedores
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trvProveedor = new System.Windows.Forms.TreeView();
            this.cmdVolver = new System.Windows.Forms.Button();
            this.lstMostrar = new System.Windows.Forms.ListView();
            this.ColumnaNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnaTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnaFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.trvProveedor);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cmdVolver);
            this.splitContainer2.Panel2.Controls.Add(this.lstMostrar);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(872, 483);
            this.splitContainer2.SplitterDistance = 289;
            this.splitContainer2.TabIndex = 0;
            // 
            // trvProveedor
            // 
            this.trvProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvProveedor.Location = new System.Drawing.Point(0, 0);
            this.trvProveedor.Name = "trvProveedor";
            this.trvProveedor.Size = new System.Drawing.Size(289, 483);
            this.trvProveedor.TabIndex = 0;
            this.trvProveedor.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvProveedor_AfterSelect);
            this.trvProveedor.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvProveedor_NodeMouseClick);
            // 
            // cmdVolver
            // 
            this.cmdVolver.Location = new System.Drawing.Point(271, 448);
            this.cmdVolver.Name = "cmdVolver";
            this.cmdVolver.Size = new System.Drawing.Size(75, 23);
            this.cmdVolver.TabIndex = 1;
            this.cmdVolver.Text = "Volver";
            this.cmdVolver.UseVisualStyleBackColor = true;
            this.cmdVolver.Click += new System.EventHandler(this.cmdVolver_Click);
            // 
            // lstMostrar
            // 
            this.lstMostrar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnaNombre,
            this.ColumnaTipo,
            this.ColumnaFecha});
            this.lstMostrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstMostrar.HideSelection = false;
            this.lstMostrar.Location = new System.Drawing.Point(0, 0);
            this.lstMostrar.Name = "lstMostrar";
            this.lstMostrar.Size = new System.Drawing.Size(579, 424);
            this.lstMostrar.TabIndex = 0;
            this.lstMostrar.UseCompatibleStateImageBehavior = false;
            this.lstMostrar.View = System.Windows.Forms.View.Details;
            this.lstMostrar.SelectedIndexChanged += new System.EventHandler(this.lstMostrar_SelectedIndexChanged);
            this.lstMostrar.DoubleClick += new System.EventHandler(this.lstMostrar_DoubleClick);
            // 
            // ColumnaNombre
            // 
            this.ColumnaNombre.Text = "Nombre";
            this.ColumnaNombre.Width = 185;
            // 
            // ColumnaTipo
            // 
            this.ColumnaTipo.Text = "Tipo";
            this.ColumnaTipo.Width = 181;
            // 
            // ColumnaFecha
            // 
            this.ColumnaFecha.Text = "Última modificiación";
            this.ColumnaFecha.Width = 242;
            // 
            // frmVistaProveedores
            // 
            this.ClientSize = new System.Drawing.Size(872, 483);
            this.Controls.Add(this.splitContainer2);
            this.Name = "frmVistaProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista proveedores";
            this.Load += new System.EventHandler(this.frmVistaProveedores_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwProveedor;
        private System.Windows.Forms.ListView lsvProveedores;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView trvProveedor;
        private System.Windows.Forms.ListView lstMostrar;
        private System.Windows.Forms.ColumnHeader ColumnaNombre;
        private System.Windows.Forms.ColumnHeader ColumnaTipo;
        private System.Windows.Forms.ColumnHeader ColumnaFecha;
        private System.Windows.Forms.Button cmdVolver;
    }
}