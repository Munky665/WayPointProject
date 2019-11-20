using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public delegate void NewFileDelegate(object sender, EventArgs e);
public delegate void ExportFileDelegate(object sender, EventArgs e);
public delegate void ClearAll();
namespace _2DWaypoint
{

    public partial class Alert : Form
    {
        public static ExportFileDelegate exportFileEvent;
        public static ClearAll clearAllEvent;
        public Alert()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                MDIParent.saveFileEvent?.Invoke(sender, e);
                clearAllEvent?.Invoke();
                this.Close();
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            clearAllEvent?.Invoke();
            this.Close();
        }
    }
}
