namespace _2DWaypoint
{
    partial class Editor
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
            this.labelCoordinates = new System.Windows.Forms.Label();
            this.labelWaypoints = new System.Windows.Forms.Label();
            this.labelMap = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ClearWaypoints = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.WaypointALabel = new System.Windows.Forms.Label();
            this.WaypointBLabel = new System.Windows.Forms.Label();
            this.WeightText = new System.Windows.Forms.Label();
            this.WaypointACombo = new System.Windows.Forms.ComboBox();
            this.WaypointBCombo = new System.Windows.Forms.ComboBox();
            this.WeightNumText = new System.Windows.Forms.TextBox();
            this.WeightedWaypointLabel = new System.Windows.Forms.Label();
            this.CoordinatesLabel = new System.Windows.Forms.Label();
            this.WaypointListBox = new System.Windows.Forms.ListBox();
            this.WeightedListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.PictureBox();
            this.HelpWindow = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCoordinates
            // 
            this.labelCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCoordinates.AutoSize = true;
            this.labelCoordinates.ForeColor = System.Drawing.Color.Black;
            this.labelCoordinates.Location = new System.Drawing.Point(1141, 6);
            this.labelCoordinates.Name = "labelCoordinates";
            this.labelCoordinates.Size = new System.Drawing.Size(66, 13);
            this.labelCoordinates.TabIndex = 3;
            this.labelCoordinates.Text = "Co-ordinates";
            // 
            // labelWaypoints
            // 
            this.labelWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWaypoints.AutoSize = true;
            this.labelWaypoints.Location = new System.Drawing.Point(12, 19);
            this.labelWaypoints.Name = "labelWaypoints";
            this.labelWaypoints.Size = new System.Drawing.Size(57, 13);
            this.labelWaypoints.TabIndex = 4;
            this.labelWaypoints.Text = "Waypoints";
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(213, 19);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(28, 13);
            this.labelMap.TabIndex = 5;
            this.labelMap.Text = "Map";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSave.Location = new System.Drawing.Point(1137, 797);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Export";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // ClearWaypoints
            // 
            this.ClearWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearWaypoints.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearWaypoints.Location = new System.Drawing.Point(975, 797);
            this.ClearWaypoints.Name = "ClearWaypoints";
            this.ClearWaypoints.Size = new System.Drawing.Size(75, 23);
            this.ClearWaypoints.TabIndex = 7;
            this.ClearWaypoints.Text = "Clear";
            this.ClearWaypoints.UseVisualStyleBackColor = true;
            this.ClearWaypoints.Click += new System.EventHandler(this.ClearWaypoints_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImport.Location = new System.Drawing.Point(1056, 797);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // WaypointALabel
            // 
            this.WaypointALabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WaypointALabel.AutoSize = true;
            this.WaypointALabel.Location = new System.Drawing.Point(8, 779);
            this.WaypointALabel.Name = "WaypointALabel";
            this.WaypointALabel.Size = new System.Drawing.Size(74, 13);
            this.WaypointALabel.TabIndex = 14;
            this.WaypointALabel.Text = "First Waypoint";
            // 
            // WaypointBLabel
            // 
            this.WaypointBLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WaypointBLabel.AutoSize = true;
            this.WaypointBLabel.Location = new System.Drawing.Point(145, 779);
            this.WaypointBLabel.Name = "WaypointBLabel";
            this.WaypointBLabel.Size = new System.Drawing.Size(92, 13);
            this.WaypointBLabel.TabIndex = 15;
            this.WaypointBLabel.Text = "Second Waypoint";
            // 
            // WeightText
            // 
            this.WeightText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightText.AutoSize = true;
            this.WeightText.Location = new System.Drawing.Point(284, 779);
            this.WeightText.Name = "WeightText";
            this.WeightText.Size = new System.Drawing.Size(41, 13);
            this.WeightText.TabIndex = 16;
            this.WeightText.Text = "Weight";
            // 
            // WaypointACombo
            // 
            this.WaypointACombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WaypointACombo.FormattingEnabled = true;
            this.WaypointACombo.Location = new System.Drawing.Point(11, 799);
            this.WaypointACombo.Name = "WaypointACombo";
            this.WaypointACombo.Size = new System.Drawing.Size(121, 21);
            this.WaypointACombo.TabIndex = 17;
            // 
            // WaypointBCombo
            // 
            this.WaypointBCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WaypointBCombo.FormattingEnabled = true;
            this.WaypointBCombo.Location = new System.Drawing.Point(148, 799);
            this.WaypointBCombo.Name = "WaypointBCombo";
            this.WaypointBCombo.Size = new System.Drawing.Size(121, 21);
            this.WaypointBCombo.TabIndex = 18;
            // 
            // WeightNumText
            // 
            this.WeightNumText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightNumText.Location = new System.Drawing.Point(287, 799);
            this.WeightNumText.Name = "WeightNumText";
            this.WeightNumText.Size = new System.Drawing.Size(100, 20);
            this.WeightNumText.TabIndex = 19;
            this.WeightNumText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddWeightToEdge);
            // 
            // WeightedWaypointLabel
            // 
            this.WeightedWaypointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightedWaypointLabel.AutoSize = true;
            this.WeightedWaypointLabel.Location = new System.Drawing.Point(12, 429);
            this.WeightedWaypointLabel.Name = "WeightedWaypointLabel";
            this.WeightedWaypointLabel.Size = new System.Drawing.Size(106, 13);
            this.WeightedWaypointLabel.TabIndex = 21;
            this.WeightedWaypointLabel.Text = "Weighted Waypoints";
            // 
            // CoordinatesLabel
            // 
            this.CoordinatesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CoordinatesLabel.AutoSize = true;
            this.CoordinatesLabel.ForeColor = System.Drawing.Color.Black;
            this.CoordinatesLabel.Location = new System.Drawing.Point(1134, 19);
            this.CoordinatesLabel.Name = "CoordinatesLabel";
            this.CoordinatesLabel.Size = new System.Drawing.Size(71, 13);
            this.CoordinatesLabel.TabIndex = 4;
            this.CoordinatesLabel.Text = "{ X= 0 , Y= 0}";
            // 
            // WaypointListBox
            // 
            this.WaypointListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WaypointListBox.FormattingEnabled = true;
            this.WaypointListBox.Location = new System.Drawing.Point(11, 35);
            this.WaypointListBox.Name = "WaypointListBox";
            this.WaypointListBox.Size = new System.Drawing.Size(196, 381);
            this.WaypointListBox.TabIndex = 22;
            // 
            // WeightedListBox
            // 
            this.WeightedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightedListBox.FormattingEnabled = true;
            this.WeightedListBox.Location = new System.Drawing.Point(11, 445);
            this.WeightedListBox.Name = "WeightedListBox";
            this.WeightedListBox.Size = new System.Drawing.Size(196, 316);
            this.WeightedListBox.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(216, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 719);
            this.panel1.TabIndex = 24;
            this.panel1.TabStop = false;
            this.panel1.Click += new System.EventHandler(this.pictureBoxMap_Click);
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageImport_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageImport_DragEnter);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPaint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Update_Move);
            // 
            // HelpWindow
            // 
            this.HelpWindow.HelpNamespace = ".\\bin\\Main Window.htm";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 826);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WeightedListBox);
            this.Controls.Add(this.WaypointListBox);
            this.Controls.Add(this.CoordinatesLabel);
            this.Controls.Add(this.labelCoordinates);
            this.Controls.Add(this.WeightedWaypointLabel);
            this.Controls.Add(this.WeightNumText);
            this.Controls.Add(this.WaypointBCombo);
            this.Controls.Add(this.WaypointACombo);
            this.Controls.Add(this.WeightText);
            this.Controls.Add(this.WaypointBLabel);
            this.Controls.Add(this.WaypointALabel);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.ClearWaypoints);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.labelWaypoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.HelpWindow.SetHelpKeyword(this, "Welcome.html");
            this.HelpWindow.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.Name = "Editor";
            this.HelpWindow.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeleteWaypointInfo);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Deselect);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCoordinates;
        private System.Windows.Forms.Label labelWaypoints;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ClearWaypoints;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label WaypointALabel;
        private System.Windows.Forms.Label WaypointBLabel;
        private System.Windows.Forms.Label WeightText;
        private System.Windows.Forms.ComboBox WaypointACombo;
        private System.Windows.Forms.ComboBox WaypointBCombo;
        private System.Windows.Forms.TextBox WeightNumText;
        private System.Windows.Forms.Label WeightedWaypointLabel;
        private System.Windows.Forms.Label CoordinatesLabel;
        private System.Windows.Forms.ListBox WaypointListBox;
        private System.Windows.Forms.ListBox WeightedListBox;
        private System.Windows.Forms.PictureBox panel1;
        private System.Windows.Forms.HelpProvider HelpWindow;
    }
}