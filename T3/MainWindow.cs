
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3.LectorsSeminarsDataAccessLayerWCFService;



namespace T3
{
    public partial class MainWindow : Form
    {
        LectorsSeminarsDataAccessLayerServiceClient wcfClient =
            new LectorsSeminarsDataAccessLayerServiceClient();

        ISessionWraper client;

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(wcfClient.DoWork("yp"));
            //wcfClient.Close();

            client =  new SessionWraperFromWCF(wcfClient);
            /*client = new LectorsSeminarsDataAccessLayer.
                SessionWraperFactory(false).OpenSessionAdapter();
            */
            RecreateSeminarsTree();
        }

        private void RecreateSeminarsTree()
        {
            var allLectorsNode = new TreeNode("All") { 
                Name = null,
                Tag = new Seminar() { Lectors = client.AllLectors } 
            };
            allLectorsNode.Nodes.Add("stub");

            seminarsAndLectorsTreeView.Nodes.Clear();

            seminarsAndLectorsTreeView.Nodes.
                Add(allLectorsNode);

            var seminars = client.AllSeminars;
            foreach (var seminar in seminars)
            {
                TreeNode seminarNode = new TreeNode(seminar.Name);
                seminarNode.Tag = seminar;
                seminarsAndLectorsTreeView.Nodes.
                    Add(seminarNode);
                if (seminar.Lectors.Count > 0)
                    seminarNode.Nodes.Add("stub");
            }
        }

        private void seminarsAndLectorsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode seminarNode = e.Node;
            if (!(seminarNode.Tag is Seminar))
                return;
            var seminar = seminarNode.Tag as Seminar;

            seminarNode.Nodes.Clear();
            foreach(var lector in seminar.Lectors)
            {
                TreeNode lectorNode = new TreeNode(lector.Name);
                seminarNode.Nodes.Add(lectorNode);
                lectorNode.Tag = lector;
            }
        }

        private void seminarsAndLectorsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode seminarNode = e.Node;
            if (!(seminarNode.Tag is Seminar))
                return;
            var seminar = seminarNode.Tag as Seminar;
            lectorsListBox.Items.Clear();
            
            foreach (var lector in seminar.Lectors)
                lectorsListBox.Items.Add(lector);

            lectorsListBox.Tag = seminar;
        }

        private void seminarsAndLectorsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode lectorNode = e.Item as TreeNode;
            if (!(lectorNode.Tag is Lector))
                return;
            var lector = lectorNode.Tag as Lector;
            DoDragDrop(lector.Id, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void seminarsAndLectorsTreeView_DragEnter(object sender, DragEventArgs e)
        {
            //if (GetSeminarNodeAt(e)!=null)
                e.Effect = DragDropEffects.Copy;
            //else
            //    e.Effect = DragDropEffects.None;
        }

        private TreeNode GetSeminarNodeAt(DragEventArgs e)
        {
            Point pt = seminarsAndLectorsTreeView.PointToClient(new Point(e.X, e.Y));
            
            var node = seminarsAndLectorsTreeView.GetNodeAt(pt);

            if (node == null)
                return null;

            var lectorIdPresent = e.Data.GetDataPresent(typeof(Int32));
            var isItSeminarNode = node.Tag is Seminar;
            if (lectorIdPresent && isItSeminarNode)
                return node;
            return null;
        }

        private void seminarsAndLectorsTreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode seminarNode = GetSeminarNodeAt(e);
            if (seminarNode==null)
                return;
            
            var seminar = seminarNode.Tag as Seminar;
            if (seminar.Name == null)
                return;

            Int32 Id = (Int32) e.Data.GetData(typeof(Int32));
            var lector = client.GetLectorById(Id);

            seminarNode.Nodes.Add(new TreeNode(lector.Name) { Tag = lector } ) ;
            
            seminar.Lectors.Add(lector);

            client.ObjectToSave = seminar;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.CloseSession();
            //wcfClient.Close();
        }

        private void newSeminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNew(new Seminar());
        }

        private void CreateNew(IdNamable obj)
        {
            EditSeminar editSeminar = new EditSeminar();
            editSeminar.ShowDialog();

            if (editSeminar.SeminarName != null)
            {
                obj.Name = editSeminar.SeminarName;
                client.ObjectToSave = obj;
                RecreateSeminarsTree();
            }
        }

        private void lectorsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            var lector = lectorsListBox.SelectedItem as Lector;
            if (lector == null)
                return;
            DoDragDrop(lector.Id, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void lectorsListBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(Int32)))
                return;
            var seminar = lectorsListBox.Tag as Seminar;
            if (seminar.Name == null) // Root seminar contains all lectors
                // and therefore does not need to obtain any more
                return;
            Int32 Id = (Int32)e.Data.GetData(typeof(Int32));
            var lector = client.GetLectorById(Id);
            lectorsListBox.Items.Add(lector);
            seminar.Lectors.Add(lector);
            client.ObjectToSave = seminar;
        }

        private void lectorsListBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void seminarsAndLectorsTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var selectedNode = seminarsAndLectorsTreeView.SelectedNode;

            if (selectedNode.Tag is Seminar)
            {
                var seminar = selectedNode.Tag as Seminar;
                if (seminar.Name != null)
                {
                    client.ObjectToDelete = seminar;
                    seminarsAndLectorsTreeView.Nodes.
                        Remove(selectedNode);                        
                }
            }
            else if (selectedNode.Tag is Lector)
            {
                var seminar = selectedNode.Parent.Tag as Seminar;
                var lector = selectedNode.Tag as Lector;
                if (seminar.Name == null)
                {
                    client.ObjectToDelete = lector;
                    RecreateSeminarsTree();
                }
                else
                {
                    seminar.Lectors.Remove(lector);
                    client.ObjectToSave = seminar;
                }
                selectedNode.Parent.Nodes.Remove(selectedNode);
            }
        }

        private void newLecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNew(new Lector());
        }
    }
}
