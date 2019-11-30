using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;



namespace _2DWaypoint
{

    public partial class Editor : Form
    {
        #region startup
        MouseEventArgs m_me;
        Data m_data;
        string m_mousePos;

        public Editor()
        {
            InitializeComponent();
            panel1.AllowDrop = true;
            MDIParent.saveFileEvent += SaveAsToolStripMenuItem_Click;
            MDIParent.openFileEvent += OpenToolStripMenuItem;
            Alert.clearAllEvent += ClearAll;
            Alert.exportFileEvent += ButtonExport_Click;

            WindowState = FormWindowState.Maximized;
            ControlBox = false;
            KeyPreview = true;
            m_data = new Data();

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
                    foreach (string s in WaypointListBox.Items)
                    {
                        temp += s + Environment.NewLine;
                    }
                    //add string to bytes var
                    var bytes = Encoding.ASCII.GetBytes(temp);
                    //clear temp value
                    temp = "";
                    foreach (string s in WeightedListBox.Items)
                    {
                        temp += s + Environment.NewLine;
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
                    ClearAll();
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
                                WayPointButton button = new WayPointButton("Waypoint " + m_data.waypoint,
                                                                            new Point(posX, posY),
                                                                            WaypointACombo, WaypointBCombo);
                                //reset variables
                                posX = 0;
                                posY = 0;

                                //add waypoints to Waypoint list.
                                m_data.AddWaypoint(button);

                                //add waypoint to combo box's
                                WaypointACombo.Items.Add("Waypoint " + m_data.waypoint);
                                WaypointBCombo.Items.Add("Waypoint " + m_data.waypoint);
                                panel1.Invalidate();

                                m_data.waypoint++;

                            }//end text starts with {
                            else if (!text.StartsWith("{"))
                            {
                                //add weighted waypoint information to text box
                                if(text.Contains("Waypoint"))
                                WeightedListBox.Items.Add(text);
                            }

                        }
                        //variables to store edge
                        PointF start = new PointF(0, 0);
                        PointF end = new PointF(0, 0);
                        string name = null;
                        //loop through items in weighted list box
                        for (int i = 0; i < WeightedListBox.Items.Count; ++i)
                        {
                            //check if item matches a waypoint name store location in start if true
                            foreach (WayPointButton b in m_data.GetWayPointButtons())
                            {

                                if (WeightedListBox.Items[i].ToString().Contains(b.Name))
                                {
                                    name = b.Name + ", ";
                                    start = b.Location;
                                }
                            }
                            //check if item matches waypoint name, store location in end if true
                            foreach (WayPointButton b in m_data.GetWayPointButtons())
                            {
                                if (WeightedListBox.Items[i].ToString().Contains(b.Name))
                                {
                                    if (name.Contains(b.Name) == false)
                                    {
                                        name += b.Name;
                                        end = b.Location;
                                    }
                                }
                            }
                            //if end is not 0,0 create new edge
                            if (end != new PointF(0, 0))
                            {
                                Edge ed = new Edge(name, start, end);
                                m_data.AddEdge(ed);
                                panel1.Invalidate();
                            }
                            
                        }


                    }//end stream
                }
                myStream.Close();
            }
        }
    
        #endregion
        #region FormEvents
        //adds new waypoint when panel is clicked
        private void pictureBoxMap_Click(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            {

                WayPointButton temp = Select(m_data.DrawEllipsAt);
                if (temp == null)
                {
                    if (m_data.waypoint >= 'Z')
                    {
                        m_data.waypoint = 'a';
                    }

                    //adds waypoint coordinates to text box
                    WaypointListBox.Items.Add(m_mousePos
                        + ", "
                        + "Waypoint "
                        + m_data.waypoint.ToString()
                        + Environment.NewLine);
                    //adds waypoint letters to combo boxes
                    WaypointACombo.Items.Add("Waypoint "
                        + m_data.waypoint.ToString());
                    WaypointBCombo.Items.Add("Waypoint "
                        + m_data.waypoint.ToString());

                    //add Dot
                    PlaceDot("Waypoint "
                    + m_data.waypoint.ToString());

                }
                else
                {
                    temp.Selected = !temp.Selected;
                   
                }
                UpdateComboBox(temp);
                //refresh picture box
                panel1.Invalidate();
                //increment waypoint letter
                m_data.waypoint++;
            }
           
        }
        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            foreach (WayPointButton wp in m_data.GetWayPointButtons())
            {
                wp.Draw(e.Graphics);
            }
            foreach(Edge ed in m_data.GetEdges())
            {
                ed.Draw(e.Graphics);
            }
        }
        //keeps track of the mouse position when over panel
        private void Update_Move(object sender, MouseEventArgs e)
        {
            
            if (e is MouseEventArgs)
            {
                //adjust panel coordinates so 0,0 is in the middle
                 m_me = e as MouseEventArgs;
           
                //label the axis in a string
                m_mousePos = "{ X= " + e.Location.X + " ,Y= " + e.Location.Y + " }";
                //draw coordinates to label
                CoordinatesLabel.Text = m_mousePos;

                m_data.DrawEllipsAt = new PointF(e.Location.X, e.Location.Y);

            }
        }
        //clears all waypoints when clear button clicked
        private void ClearWaypoints_Click(object sender, EventArgs e)
        {
            if(e is MouseEventArgs)
            {
                MouseEventArgs me = e as MouseEventArgs;
                ClearButton();
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
                m_data.SetMap(pic);

                try
                {//set img to image that was dropped in
                    Image img = Image.FromFile(pic);
                    Graphics g = panel1.CreateGraphics();
                    //set image to background of panel
                    panel1.Image = null;
                    panel1.Image = img;
                }
                catch
                {
                    MessageBox.Show("Needs to be an Image of .PNG format");
                }
            }

        }
        //adds weighted waypoint edge when enter pressed
        private void AddWeightToEdge(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //turn of 'ding' sound when enter key is pressed.
                e.Handled = true;
                e.SuppressKeyPress = true;
                //checking if there is text in the waypoint combo box
                try
                {
                    if (WaypointACombo.SelectedItem.ToString() == WaypointBCombo.SelectedItem.ToString())
                    {
                        MessageBox.Show("Cannot Connect same waypoint");
                        WeightNumText.Text = null;
                        WaypointACombo.Text = null;
                        WaypointBCombo.Text = null;
                    }
                    else
                    {
                        WeightedListBox.Items.Add(WaypointACombo.SelectedItem.ToString() + ", "
                            + WaypointBCombo.SelectedItem.ToString() + ", " + "Weight "
                            + WeightNumText.Text.ToString());
                        
                        m_data.AddEdge(new Edge(m_data.GetWayPointButtons(), WaypointACombo, WaypointBCombo));
                        panel1.Invalidate();
                        WeightNumText.Text = null;
                        WaypointACombo.Text = null;
                        WaypointBCombo.Text = null;
                        foreach(WayPointButton wb in m_data.GetWayPointButtons())
                        {
                            wb.Selected = false;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("There are no waypoints selected to join");
                }
            }
        }
        //deselect waypoints
        private void Deselect(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {   
                foreach(WayPointButton b in m_data.GetWayPointButtons())
                {
                    if(b.Selected == true)
                    {
                        b.Selected = false;
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;

                m_data.box = 0;
                WaypointACombo.Text = null;
                WaypointBCombo.Text = null;
                panel1.Invalidate();
            }
        }


        #endregion
        #region Clear/PlaceFunctions
        //clears all text boxes, waypoints and combo boxes
        private void ClearAll()
        {
            m_data.waypoint = 'A';
            WaypointListBox.Items.Clear();
            WaypointACombo.Items.Clear();
            WaypointACombo.Text = "";
            WaypointBCombo.Items.Clear();
            WaypointBCombo.Text = "";
            WeightedListBox.Items.Clear();
            m_data.ClearData();    
            panel1.Invalidate();
            panel1.Image = null;
        }
        private void ClearButton()
        {
            m_data.waypoint = 'A';
            WaypointListBox.Items.Clear();
            WaypointACombo.Items.Clear();
            WaypointACombo.Text = "";
            WaypointBCombo.Items.Clear();
            WaypointBCombo.Text = "";
            WeightedListBox.Items.Clear();
            m_data.ClearData();
            panel1.Invalidate();

        }
        //places New Waypoint
        private void PlaceDot(string name)
        {
            WayPointButton waypointDot = new WayPointButton(name, m_data.DrawEllipsAt, 
                                                            WaypointACombo, 
                                                            WaypointBCombo);
            m_data.AddWaypoint(waypointDot);
        }
        //deletes waypoint info from list boxes and text boxes
        private void DeleteWaypointInfo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                List<WayPointButton> deleteHolder = new List<WayPointButton>();
                foreach (WayPointButton b in m_data.GetWayPointButtons())
                {
                    if (b.Selected)
                    {
                        //check if waypoint is in the list box
                        for (int i = 0; i < WaypointListBox.Items.Count; i++)
                        {
                            if (WaypointListBox.Items[i].ToString().Contains(b.Name))
                            {
                                WaypointListBox.Items.RemoveAt(i);
                            }
                        }
                        //check if there is a way point connection
                        for (int i = 0; i < WeightedListBox.Items.Count; i++)
                        {

                            if (WeightedListBox.Items[i].ToString().Contains(b.Name))
                            {
                                WeightedListBox.Items.RemoveAt(i);
                            }

                        }
                        //check if waypoint is in the combo box
                        for (int i = 0; i < WaypointACombo.Items.Count; i++)
                        {
                            if (WaypointACombo.Items[i].ToString().Contains(b.Name))
                            {
                                WaypointACombo.Items.RemoveAt(i);
                                WaypointBCombo.Items.RemoveAt(i);
                            }
                        }
                        List<Edge> temp = new List<Edge>();
                        foreach (Edge ed in m_data.GetEdges())
                        {
                            if (ed.Start == b.Location || ed.End == b.Location)
                                temp.Add(ed);
                        }
                        foreach(Edge ed in temp)
                        {
                            m_data.RemoveEdge(ed);
                        }
                        //clear the way point box text of selected
                        if (WaypointACombo.Text == b.Name)
                            WaypointACombo.Text = "";
                        //clear waypoint box text of selected
                        if (WaypointBCombo.Text == b.Name)
                            WaypointBCombo.Text = "";
                        deleteHolder.Add(b);
     
                    }
                }
                foreach(WayPointButton b in deleteHolder)
                {
                    m_data.RemoveWaypoint(b);
                }
                panel1.Invalidate();
            }
        }
        //return waypoint that has been clicked
        private WayPointButton Select(PointF location)
        {
            WayPointButton nothing = null;

            foreach(WayPointButton wp in m_data.GetWayPointButtons())
            {
                PointF vector = VectorMath.Minus(location, wp.Location);
                float length = VectorMath.Magnitued(vector);
                if(length < WayPointButton.Radius + m_data.selectBuffer)
                {
                    return wp;
                }
            }
            return nothing;
        }
        //add clicked waypoint to comboBox
        private void UpdateComboBox(WayPointButton b)
        {
            if (b != null)
            {
                if (b.Selected == true)
                {
                    if (m_data.box == 0)
                    {
                        WaypointACombo.Text = b.Name;
                        m_data.box++;
                    }
                    else if (m_data.box == 1)
                    {
                        WaypointBCombo.Text = b.Name;
                        m_data.box--;
                    }
                }
            }
        }
        //saves item when save icon on tool strip clicked
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear waypoint list to ensure no double ups
            m_data.ClearWaypointList();
            foreach (string s in WaypointListBox.Items)
            {
                m_data.AddToWaypointList(s);
            }
            //clear weightlist to ensure no double ups
            m_data.ClearWeightList();
            foreach (string s in WeightedListBox.Items)
            {
                m_data.AddToWeightList(s);
            }

            //start save dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Dat Files (*.dat)|*.dat|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;

                BinaryFormatter bf = new BinaryFormatter();

                SerializeItem(FileName, bf);
            }

        }
        //open file using tool strip menu item
        private void OpenToolStripMenuItem(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFile.Filter = "Dat Files (*.dat)|*.dat|All Files (*.*)|*.*";

            if(openFile.ShowDialog(this) == DialogResult.OK)
            {
                ClearAll();
                string FileName = openFile.FileName;
                BinaryFormatter bf = new BinaryFormatter();
                DeSerializeItem(FileName, bf);
                LoadImageFromSave();
                UpdatePictureBox();
            }
        }
        #endregion
        //function to serialize data for .dat file
        public void SerializeItem(string fileName, IFormatter formatter)
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            FileStream s = File.Create(fileName);
            if(m_data != null)
            formatter.Serialize(s, m_data);
            s.Close();
        }
        //function to deserialize from dat file
        public void DeSerializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            m_data = (Data)formatter.Deserialize(s);
            s.Close();

        }
        //updates picture box with waypoints in list box.
        void UpdatePictureBox()
        {
            foreach (string s in m_data.GetWaypoints())
            {
                WaypointListBox.Items.Add(s);
            }
            foreach (string s in m_data.GetWeights())
            {
                WeightedListBox.Items.Add(s);
            }
            char tempLetter = 'A';
            for (int i = 0; i < WaypointListBox.Items.Count; i++)
            {
                WaypointACombo.Items.Add("Waypoint " + tempLetter);
                WaypointBCombo.Items.Add("Waypoint " + tempLetter);
               tempLetter++;
            }
            panel1.Invalidate();
        }
        //loads map from file if file hasn't been relocated.
        void LoadImageFromSave()
        {
            if (m_data.GetMap() != null)
            {
                try
                {//set img to image that was dropped in
                    Image img = Image.FromFile(m_data.GetMap());
                    Graphics g = panel1.CreateGraphics();
                    panel1.Image = img;
                }
                catch
                {
                    MessageBox.Show("Map File Cannot be found, export waypoints as .csv then re-import, then re-import .csv");
                }
            }
        }
    }
}
