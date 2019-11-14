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
        #region startup
        char m_waypoint = 'A';
        string m_mousePos;
        public static int s_comboBox = 0;
        float m_XaxisF = 0;
        float m_YaxisF = 0;
        int XButtonBuffer = -8;
        int YButtonBuffer = -13;
        Point m_DrawEllipsAt;
        MouseEventArgs m_me;
        List<WayPointButton> m_waypointStorage = new List<WayPointButton>();
        List<string> m_vectors = new List<string>();

        public Editor()
        {
         
            InitializeComponent();
            panel1.AllowDrop = true;
            MDIParent.saveFileEvent += ButtonExport_Click;
            Alert.exportFileEvent += ButtonExport_Click;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }
        #endregion

        #region Import/Export
        //exports data to csv file format.
        private void ButtonExport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)| *.csv|All Files(*,*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    //temp string to hold item values
                    string temp = "";
                    //write item values to string
                    foreach(string s in WaypointListBox.Items)
                    {
                        temp += s;
                    }
                    //add string to bytes var
                    var bytes = Encoding.ASCII.GetBytes(temp);
                    //clear temp value
                    temp = "";
                    foreach(string s in WeightedListBox.Items)
                    {
                        temp += s;
                    }
                    var bytesW = Encoding.ASCII.GetBytes(temp);

                    myStream.Write(bytes, 0, bytes.Length);
                    myStream.Write(bytesW, 0, bytesW.Length);
                    myStream.Close();
                }
            }

        }
        //import text/csv file
        private void buttonImport_Click(object sender, EventArgs e)
        {
            Stream myStream;
            ClearAll();
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
                        //holds x position saved in a line
                        int posX = 0;
                        //holds y position save in a line
                        int posY = 0;
                        // holds the number found in the line this pass
                        int num = 0;
                        //keeps track of the number of passes
                        int pass = 0;
                        while (!reader.EndOfStream)
                        {
                            //check read line to string
                            string text = reader.ReadLine();
                            //check if the line starts with {
                            if (text.StartsWith("{"))
                            {
                                //copy Whole line to textbox
                                WaypointListBox.Items.Add(text);
                                //add waypoint to combo box's
                                WaypointACombo.Items.Add("Waypoint " + m_waypoint);
                                WaypointBCombo.Items.Add("Waypoint " + m_waypoint);
                                //add each word between spaces in line to array
                                string[] numbers = text.Split();
                                //check for numbers
                                foreach (string value in numbers)
                                {
                                    //if theres a number in value store it in num
                                    if (int.TryParse(value, out num))
                                    {
                                        //check if first pass, then save num to pos x
                                        if (pass == 0)
                                        {
                                            posX = num;
                                            pass++;
                                        }
                                        //save num to pos y
                                        else
                                        {
                                            posY = num;
                                            pass--;
                                        }
                                    }
                                }
                                //create buttons in positions given by file
                                WayPointButton button = new WayPointButton("Waypoint" + m_waypoint,
                                                                            new Point(posX + (panel1.Width / 2) + XButtonBuffer, posY + (panel1.Height / 2) + YButtonBuffer),
                                                                            panel1, WaypointACombo, WaypointBCombo);
                                //set mouse click event to button
                                button.SetRadioButtonFunction().MouseClick += button.RadioButtonClicked;
                                //reset variables
                                posX = 0;
                                posY = 0;
                                //add waypoints to Waypoint list.
                                m_waypointStorage.Add(button);
                                panel1.Update();
                                m_waypoint++;

                            }
                            else
                            {
                                //add weighted waypoint information to text box
                                WeightedListBox.Text += text + Environment.NewLine;
                            }
                        }
                    }
                    myStream.Close();
                }
            }
        }
        #endregion
        #region FormEvents
        //adds new waypoint when panel is clicked
        private void pictureBoxMap_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {
                if (m_waypoint >= 'Z')
                {
                    m_waypoint += 'A';
                }
                //store vector in array for use later
                m_vectors.Add(m_mousePos);

                //adds waypoint coordinates to text box
                WaypointListBox.Items.Add(m_vectors[m_vectors.Count - 1]
                    + ", "
                    + "Waypoint "
                    + m_waypoint.ToString()
                    + Environment.NewLine);
                //adds waypoint letters to combo boxes
                WaypointACombo.Items.Add("Waypoint "
                    + m_waypoint.ToString());
                WaypointBCombo.Items.Add("Waypoint "
                    + m_waypoint.ToString());
                //add Dot
                PlaceDot("Waypoint "
                  + m_waypoint.ToString());
                //increment waypoint letter
                m_waypoint++;
            }
           
        }
        //keeps track of the mouse position when over panel
        private void Update_Move(object sender, MouseEventArgs e)
        {
            
            if (e is MouseEventArgs)
            {
                //adjust panel coordinates so 0,0 is in the middle
                 m_me = e as MouseEventArgs;

                int Xaxis = (m_me.Location.X - panel1.Width / 2);
                int Yaxis = (m_me.Location.Y - panel1.Height / 2);
                //label the axis in a string
                m_mousePos = "{ X= " + Xaxis + " ,Y= " + Yaxis + " }";
                CoordinatesLabel.Text = m_mousePos;

                m_XaxisF = m_me.Location.X - (panel1.Width / 2);
                m_YaxisF = m_me.Location.Y - (panel1.Height / 2);

                m_DrawEllipsAt = new Point(m_me.Location.X + XButtonBuffer, m_me.Location.Y + YButtonBuffer);

            }
        }
        //clears all waypoints when clear button clicked
        private void ClearWaypoints_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                MouseEventArgs me = e as MouseEventArgs;
                ClearAll();
            }
        }
        //allows image to be dragged into the window
        private void ImageImport_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        //when dropped renders image as background.
        private void ImageImport_DragDrop(object sender, DragEventArgs e)
        {
            //get file information
            foreach(string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                try
                {//set img to image that was dropped in
                    Image img = Image.FromFile(pic);
                    Graphics g = panel1.CreateGraphics();
                    //set image to background of panel
                     g.DrawImage(img, new Point ((panel1.Width / 2) - img.Width / 2 , (panel1.Height / 2) - img.Height / 2));
                    
                }
                catch
                {
                    MessageBox.Show("Needs to be an Image of .PNG format");
                }
            }



        }
        //adds weighted waypoint edge when enter pressed
        private void EnterPressed(object sender, EventArgs e)
        {
            KeyEventArgs me = e as KeyEventArgs;
            PaintEventArgs pe = e as PaintEventArgs;
            if (me.KeyCode == Keys.Enter)
            {
                WeightedListBox.Items.Add(WaypointACombo.SelectedItem.ToString() + ", "
                    + WaypointBCombo.SelectedItem.ToString() + ", " + "Weight "
                    + WeightNumText.Text.ToString());

                Point start = new Point();
                Point end = new Point();

                for(int i = 0; i < m_waypointStorage.Count; i++)
                {
                    if(m_waypointStorage[i].Name == WaypointACombo.Text)
                    {
                        start = m_waypointStorage[i].Location;
                    }
                    if(m_waypointStorage[i].Name == WaypointBCombo.Text)
                    {
                        end = m_waypointStorage[i].Location;
                    }
                }

                Graphics g = panel1.CreateGraphics();
                g.DrawLine(Pens.White, start, end);

                WeightNumText.Text = null;
                WaypointACombo.Text = null;
                WaypointBCombo.Text = null;
            }

        }
        private void WeightedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WaypointListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion
        #region Clear/PlaceFunctions
        //clears all text boxes, waypoints and combo boxes
        private void ClearAll()
        {
            m_waypoint = 'A';
            WaypointListBox.Items.Clear();
            WaypointACombo.Items.Clear();
            WaypointACombo.Text = "";
            WaypointBCombo.Items.Clear();
            WaypointBCombo.Text = "";
            WeightedListBox.Items.Clear();
            panel1.Controls.Clear();
            m_waypointStorage.Clear();
            m_vectors.Clear();
        }
        //places New Waypoint
        private void PlaceDot(string name)
        {
            WayPointButton waypointDot = new WayPointButton(name, m_DrawEllipsAt, 
                                                            panel1, WaypointACombo, 
                                                            WaypointBCombo);
            waypointDot.SetRadioButtonFunction().MouseClick += waypointDot.RadioButtonClicked;
            waypointDot.SetRadioButtonFunction().KeyDown += DeleteWaypointInfo;
            waypointDot.SetRadioButtonFunction().KeyDown += waypointDot.RadioButtonDelete;
            m_waypointStorage.Add(waypointDot);
        }
        //deletes waypoint info from list boxes and text boxes
        private void DeleteWaypointInfo(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                foreach(WayPointButton b in m_waypointStorage)
                {
                    if(b.Checked == true)
                    {
                        //check if waypoint is in the list box
                      for(int i = 0; i < WaypointListBox.Items.Count; i++)
                        {
                            if(WaypointListBox.Items[i].ToString().Contains(b.Text))
                            {
                                WaypointListBox.Items.RemoveAt(i);
                            }
                        }
                      //check if there is a way point connection
                      for(int i = 0; i < WeightedListBox.Items.Count; i++)
                        {
                            if(WeightedListBox.Items[i].ToString().Contains(b.Text))
                            {
                                WeightedListBox.Items.RemoveAt(i);
                            }
                        }
                      //check if waypoint is in the combo box
                      for(int i = 0; i < WaypointACombo.Items.Count; i++)
                        {
                            if(WaypointACombo.Items[i].ToString().Contains(b.Text))
                            {
                                WaypointACombo.Items.RemoveAt(i);
                                WaypointBCombo.Items.RemoveAt(i);
                            }
                        }
                      //clear the way point box text of selected
                      if(WaypointACombo.Text == b.Text)
                           WaypointACombo.Text = "";
                      //clear waypoint box text of selected
                        if (WaypointBCombo.Text == b.Text)
                           WaypointBCombo.Text = "";
                    }
                }
            }
        }

        #endregion


    }
}
