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
        Point DrawEllipsAt;
        bool DrawEllipse = false;
        MouseEventArgs me;

        List<string> vectors = new List<string>();
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
                    var bytesW = Encoding.ASCII.GetBytes(WeightTextBox.Text);
                    myStream.Write(bytes, 0, bytes.Length);
                    myStream.Write(bytesW, 0, bytesW.Length);
                    myStream.Close();
                }
            }

        }

        private void pictureBoxMap_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                if (waypoint == '[')
                {
                    waypoint += 'A';
                }
                //store vector in array for use later
                vectors.Add(mousePos);

                //adds waypoint coordinates to text box
                textBoxWaypoints.Text += vectors[vectors.Count - 1]
                    + ", "
                    + "Waypoint "
                    + waypoint.ToString()
                    + Environment.NewLine;
                //adds waypoint letters to combo boxes
                WaypointACombo.Items.Add("Waypoint "
                    + waypoint.ToString());
                WaypointBCombo.Items.Add("Waypoint "
                    + waypoint.ToString());
                //increment waypoint letter
                waypoint++;

            }
            this.DrawEllipsAt = new Point(me.Location.X, me.Location.Y);
            this.DrawEllipse = true;
            panel1.Refresh();
            this.Invalidate();
        }

        private void Update_Move(object sender, MouseEventArgs e)
        {
            if (e is MouseEventArgs)
            {
                //adjust panel coordinates so 0,0 is in the middle
                 me = e as MouseEventArgs;

                string Xaxis = (me.Location.X - panel1.Width / 2).ToString();
                string Yaxis = (me.Location.Y - panel1.Height / 2).ToString();
                //label the axis in a string
                mousePos = "{ X=" + Xaxis + ",Y=" + Yaxis + " }";
                textBoxCoordinates.Text = mousePos;

                XaxisF = me.Location.X - (panel1.Width / 2);
                YaxisF = me.Location.Y - (panel1.Height / 2);





            }
        }

        private void ClearWaypoints_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                MouseEventArgs me = e as MouseEventArgs;
                textBoxWaypoints.Clear();
                WaypointACombo.Items.Clear();
                WaypointACombo.Text = "";
                WaypointBCombo.Items.Clear();
                WaypointBCombo.Text = "";
                WeightTextBox.Clear();

                vectors.Clear();
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
                        char waypointLetter = 'A';
                        while (!reader.EndOfStream)
                        {
                            string text = reader.ReadLine();
                            if (text.StartsWith("{"))
                            {
                                textBoxWaypoints.Text += text + Environment.NewLine;
                                WaypointACombo.Items.Add("Waypoint " + waypointLetter);
                                WaypointACombo.Items.Add("Waypoint " + waypointLetter);
                                waypointLetter++;
                            }
                            else
                            {
                                WeightTextBox.Text += text + Environment.NewLine;
                            }
                        }
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

            if (this.DrawEllipse)
            {
                Graphics g = e.Graphics;

                Rectangle rect = new Rectangle(DrawEllipsAt, new Size(0, 0));
                rect.Inflate(new Size(5, 5));

                Pen myPen = new Pen(Color.Red);
                g.DrawImage(new Bitmap("WayPointDot.png"), rect);
                myPen.Dispose();

            }

        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WeightTextBox.Text += WaypointACombo.SelectedItem.ToString() + ", "
                    + WaypointBCombo.SelectedItem.ToString() + ", " + "Weight "
                    + WeightNumText.Text.ToString()
                    + Environment.NewLine;
            }

        }
    }
}
