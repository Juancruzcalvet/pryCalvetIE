namespace pryCalvetIE
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vistaDeProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.elClubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verGrillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proveedoresToolStripMenuItem,
            this.elClubToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(327, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarProveedorToolStripMenuItem,
            this.vistaDeProveedoresToolStripMenuItem});
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            // 
            // cargarProveedorToolStripMenuItem
            // 
            this.cargarProveedorToolStripMenuItem.Name = "cargarProveedorToolStripMenuItem";
            this.cargarProveedorToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cargarProveedorToolStripMenuItem.Text = "Cargar proveedor";
            this.cargarProveedorToolStripMenuItem.Click += new System.EventHandler(this.cargarProveedorToolStripMenuItem_Click);
            // 
            // vistaDeProveedoresToolStripMenuItem
            // 
            this.vistaDeProveedoresToolStripMenuItem.Name = "vistaDeProveedoresToolStripMenuItem";
            this.vistaDeProveedoresToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.vistaDeProveedoresToolStripMenuItem.Text = "Vista de proveedores";
            this.vistaDeProveedoresToolStripMenuItem.Click += new System.EventHandler(this.vistaDeProveedoresToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // elClubToolStripMenuItem
            // 
            this.elClubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verGrillaToolStripMenuItem});
            this.elClubToolStripMenuItem.Name = "elClubToolStripMenuItem";
            this.elClubToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.elClubToolStripMenuItem.Text = "El Club";
            // 
            // verGrillaToolStripMenuItem
            // 
            this.verGrillaToolStripMenuItem.Name = "verGrillaToolStripMenuItem";
            this.verGrillaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verGrillaToolStripMenuItem.Text = "Ver grilla";
            this.verGrillaToolStripMenuItem.Click += new System.EventHandler(this.verGrillaToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::pryCalvetIE.Properties.Resources.seguro;
            this.ClientSize = new System.Drawing.Size(327, 255);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Página principal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vistaDeProveedoresToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem elClubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verGrillaToolStripMenuItem;
    }
}