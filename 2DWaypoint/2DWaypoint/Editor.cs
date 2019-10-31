using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;



namespace _2DWaypoint
{
    public partial class Editor : Form
    {
        char waypoint = 'A';
        string mousePos;
        float XaxisF = 0;
        float YaxisF = 0;
        public Editor()
        {
            InitializeComponent();
            panel1.AllowDrop = true;
            MDIParent.saveFileEvent += ButtonSave_Click;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)| *.txt|All Files(*,*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog.OpenFile()) != null)
                {
                    //output file contents here
                    var bytes = Encoding.ASCII.GetBytes(textBoxWaypoints.Text);
                    myStream.Write(bytes, 0, bytes.Length);
                    myStream.Close();
                }
            }
            if(waypoint++ == '[')
            {
                waypoint += 'A';
            }
        }

        private void pictureBoxMap_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                textBoxWaypoints.Text += mousePos 
                    + ", "
                    + "Waypoint " 
                    +  waypoint++.ToString() 
                    + Environment.NewLine;
            }
        }

        private void Update_Move(object sender, MouseEventArgs e)
        {
            if (e is MouseEventArgs)
            {
                
                MouseEventArgs me = e as MouseEventArgs ;
                string Xaxis = (me.Location.X - panel1.Width / 2).ToString();
                string Yaxis = (me.Location.Y - panel1.Height / 2).ToString();

                mousePos = "{ X=" + Xaxis + ",Y=" + Yaxis + " }";
                textBoxCoordinates.Text = mousePos;

                XaxisF = me.Location.X - (panel1.Width / 2);
                YaxisF = me.Location.Y - (panel1.Height / 2);
                
                panel1.Refresh();
            }
        }

        private void ClearWaypoints_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                MouseEventArgs me = e as MouseEventArgs;
                textBoxWaypoints.Clear();
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "txt files (*.txt)| *.txt|All Files(*,*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    using (StreamReader reader = new StreamReader(myStream))
                    {
                        string text = reader.ReadToEnd();
                        textBoxWaypoints.Text = text;
                    }
                    myStream.Close();
                }
            }
        }
        //allows image to be dragged into the window
        private void ImageImport_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ImageImport_DragDrop(object sender, DragEventArgs e)
        {
            //get file information
            foreach(string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                try
                {//set img to image that was dropped in
                    Image img = Image.FromFile(pic);
                    //set image to background of panel
                    panel1.BackgroundImage = img;
                }
                catch
                {
                    MessageBox.Show("Needs to be an Image of .PNG format");
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

        }
    }
}
