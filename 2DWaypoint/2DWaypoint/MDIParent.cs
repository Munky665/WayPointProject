using System;
using System.Windows.Forms;

public delegate void SaveFileDelegate(object sender, EventArgs e);
public delegate void OpenFileDelegate(object sender, EventArgs e);

namespace _2DWaypoint
{
    public partial class MDIParent : Form
    {
        public static SaveFileDelegate saveFileEvent;
        public static OpenFileDelegate openFileEvent;

        public MDIParent()
        {
            InitializeComponent();
            Form childForm = new Editor();
            childForm.Name = "Editor";
            childForm.MdiParent = this;
            childForm.Text = "Editor Window";
            childForm.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null)
            {
                Form childForm = new Editor();
                childForm.Name = "Editor";
                childForm.MdiParent = this;
                childForm.Text = "Editor Window";
                childForm.Show();
            }
            else if (ActiveMdiChild != null && ActiveMdiChild.Name != "Alert")
            {
                Form PopUp = new Alert();
                PopUp.Show();
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            openFileEvent?.Invoke(sender, e);
        }



        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileEvent?.Invoke(sender, e);
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HelpWindow.HelpNamespace);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HelpWindow.HelpNamespace);
        }
    }
}
