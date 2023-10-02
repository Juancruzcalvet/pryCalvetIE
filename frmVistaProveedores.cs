using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCalvetIE
{
    public partial class frmVistaProveedores : Form
    {
        public frmVistaProveedores()
        {
            InitializeComponent();
            LlenarTreeView();
            this.trvProveedor.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.trvProveedor_NodeMouseClick);


        }
        public string rutaActual = "";

        private void LlenarTreeView()
        {
            TreeNode rootNode;

            DirectoryInfo info = new DirectoryInfo(@"../../bin/Debug");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                trvProveedor.Nodes.Add(rootNode);
            }
        }


        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                //recursiva - se llama a si mismo para buscar mas carpetas
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
        void trvProveedor_NodeMouseClick(object sender,
   TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            lstMostrar.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),new ListViewItem.ListViewSubItem(item,dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                lstMostrar.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),new ListViewItem.ListViewSubItem(item,file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                lstMostrar.Items.Add(item);
            }

            lstMostrar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void frmVistaProveedores_Load(object sender, EventArgs e)
        {

        }

        private void trvProveedor_NodeMouseClick(object sender, TreeViewEventArgs e)
        {

        }

        private void lstMostrar_DoubleClick(object sender, EventArgs e)
        {
            //Obtengo el texto que tiene el item seleccionado lstView
            string a = lstMostrar.SelectedItems[0].Text.ToString();

            //En una variable concateno la ruta del treeview + el nombre del archivo anterior
            string rutaArchivoParcial = Path.Combine(rutaActual, a);

            //Aca esta la ruta final del archivo
            string rutaArchivoFinal = Path.Combine(@"../../bin/Debug/Proveedores", rutaArchivoParcial);

            //Instanciar la ventana de la grilla
            frmVentanaGrilla frmVentanaGrilla = new frmVentanaGrilla();

            // Abre el archivo para lectura
            using (StreamReader reader = new StreamReader(rutaArchivoFinal))
            {
                // Lee y descarta la primera línea (encabezado)
                reader.ReadLine();

                // Lee el resto de las líneas
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    // Procesa la línea actual aquí
                    string[] parametros = linea.Split(';');
                    //agregar a la datagrid
                    frmVentanaGrilla.dgvArchivito.Rows.Add(parametros);
                }
            }

            frmVentanaGrilla.rutaArchivoGrilla = rutaArchivoFinal;

            frmVentanaGrilla.Show();
            this.Hide();

        }
        private string GetNodePath(TreeNode node)
        {
            // Recorre los nodos ascendentes para construir la ruta completa
            string path = node.Text;
            TreeNode currentNode = node.Parent;

            while (currentNode != null)
            {
                path = currentNode.Text + "\\" + path;
                currentNode = currentNode.Parent;
            }

            return path;
        }
        private void trvProveedor_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Obtener el nodo seleccionado
            TreeNode selectedNode = e.Node;

            // Actualizar la ruta actual con la ruta del nodo seleccionado
            rutaActual = GetNodePath(selectedNode);
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.Show();
            this.Close();
        }
    }
}
