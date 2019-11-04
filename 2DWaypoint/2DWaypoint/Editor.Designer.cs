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
            this.textBoxWaypoints = new System.Windows.Forms.TextBox();
            this.textBoxCoordinates = new System.Windows.Forms.TextBox();
            this.labelCoordinates = new System.Windows.Forms.Label();
            this.labelWaypoints = new System.Windows.Forms.Label();
            this.labelMap = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ClearWaypoints = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.WaypointALabel = new System.Windows.Forms.Label();
            this.WaypointBLabel = new System.Windows.Forms.Label();
            this.WeightText = new System.Windows.Forms.Label();
            this.WaypointACombo = new System.Windows.Forms.ComboBox();
            this.WaypointBCombo = new System.Windows.Forms.ComboBox();
            this.WeightNumText = new System.Windows.Forms.TextBox();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.WeightedWaypointLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxWaypoints
            // 
            this.textBoxWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxWaypoints.Location = new System.Drawing.Point(12, 26);
            this.textBoxWaypoints.Multiline = true;
            this.textBoxWaypoints.Name = "textBoxWaypoints";
            this.textBoxWaypoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxWaypoints.Size = new System.Drawing.Size(195, 245);
            this.textBoxWaypoints.TabIndex = 1;
            // 
            // textBoxCoordinates
            // 
            this.textBoxCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCoordinates.Location = new System.Drawing.Point(12, 649);
            this.textBoxCoordinates.Name = "textBoxCoordinates";
            this.textBoxCoordinates.Size = new System.Drawing.Size(133, 20);
            this.textBoxCoordinates.TabIndex = 2;
            // 
            // labelCoordinates
            // 
            this.labelCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCoordinates.AutoSize = true;
            this.labelCoordinates.Location = new System.Drawing.Point(12, 633);
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
            this.labelWaypoints.Location = new System.Drawing.Point(12, 7);
            this.labelWaypoints.Name = "labelWaypoints";
            this.labelWaypoints.Size = new System.Drawing.Size(57, 13);
            this.labelWaypoints.TabIndex = 4;
            this.labelWaypoints.Text = "Waypoints";
            // 
            // labelMap
            // 
            this.labelMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(213, 7);
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
            this.ButtonSave.Location = new System.Drawing.Point(906, 652);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Export";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ClearWaypoints
            // 
            this.ClearWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearWaypoints.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearWaypoints.Location = new System.Drawing.Point(744, 652);
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
            this.buttonImport.Location = new System.Drawing.Point(825, 652);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(216, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 600);
            this.panel1.TabIndex = 9;
            this.panel1.Click += new System.EventHandler(this.pictureBoxMap_Click);
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageImport_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageImport_DragEnter);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Update_Move);
            // 
            // WaypointALabel
            // 
            this.WaypointALabel.AutoSize = true;
            this.WaypointALabel.Location = new System.Drawing.Point(219, 628);
            this.WaypointALabel.Name = "WaypointALabel";
            this.WaypointALabel.Size = new System.Drawing.Size(74, 13);
            this.WaypointALabel.TabIndex = 14;
            this.WaypointALabel.Text = "First Waypoint";
            // 
            // WaypointBLabel
            // 
            this.WaypointBLabel.AutoSize = true;
            this.WaypointBLabel.Location = new System.Drawing.Point(356, 628);
            this.WaypointBLabel.Name = "WaypointBLabel";
            this.WaypointBLabel.Size = new System.Drawing.Size(92, 13);
            this.WaypointBLabel.TabIndex = 15;
            this.WaypointBLabel.Text = "Second Waypoint";
            // 
            // WeightText
            // 
            this.WeightText.AutoSize = true;
            this.WeightText.Location = new System.Drawing.Point(495, 628);
            this.WeightText.Name = "WeightText";
            this.WeightText.Size = new System.Drawing.Size(41, 13);
            this.WeightText.TabIndex = 16;
            this.WeightText.Text = "Weight";
            // 
            // WaypointACombo
            // 
            this.WaypointACombo.FormattingEnabled = true;
            this.WaypointACombo.Location = new System.Drawing.Point(222, 648);
            this.WaypointACombo.Name = "WaypointACombo";
            this.WaypointACombo.Size = new System.Drawing.Size(121, 21);
            this.WaypointACombo.TabIndex = 17;
            // 
            // WaypointBCombo
            // 
            this.WaypointBCombo.FormattingEnabled = true;
            this.WaypointBCombo.Location = new System.Drawing.Point(359, 648);
            this.WaypointBCombo.Name = "WaypointBCombo";
            this.WaypointBCombo.Size = new System.Drawing.Size(121, 21);
            this.WaypointBCombo.TabIndex = 18;
            // 
            // WeightNumText
            // 
            this.WeightNumText.Location = new System.Drawing.Point(498, 648);
            this.WeightNumText.Name = "WeightNumText";
            this.WeightNumText.Size = new System.Drawing.Size(100, 20);
            this.WeightNumText.TabIndex = 19;
            this.WeightNumText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightTextBox.Location = new System.Drawing.Point(12, 303);
            this.WeightTextBox.Multiline = true;
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WeightTextBox.Size = new System.Drawing.Size(195, 326);
            this.WeightTextBox.TabIndex = 20;
            // 
            // WeightedWaypointLabel
            // 
            this.WeightedWaypointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightedWaypointLabel.AutoSize = true;
            this.WeightedWaypointLabel.Location = new System.Drawing.Point(12, 284);
            this.WeightedWaypointLabel.Name = "WeightedWaypointLabel";
            this.WeightedWaypointLabel.Size = new System.Drawing.Size(106, 13);
            this.WeightedWaypointLabel.TabIndex = 21;
            this.WeightedWaypointLabel.Text = "Weighted Waypoints";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 681);
            this.Controls.Add(this.WeightedWaypointLabel);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.WeightNumText);
            this.Controls.Add(this.WaypointBCombo);
            this.Controls.Add(this.WaypointACombo);
            this.Controls.Add(this.WeightText);
            this.Controls.Add(this.WaypointBLabel);
            this.Controls.Add(this.WaypointALabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.ClearWaypoints);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.labelWaypoints);
            this.Controls.Add(this.labelCoordinates);
            this.Controls.Add(this.textBoxCoordinates);
            this.Controls.Add(this.textBoxWaypoints);
            this.Name = "Editor";
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxWaypoints;
        private System.Windows.Forms.TextBox textBoxCoordinates;
        private System.Windows.Forms.Label labelCoordinates;
        private System.Windows.Forms.Label labelWaypoints;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ClearWaypoints;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label WaypointALabel;
        private System.Windows.Forms.Label WaypointBLabel;
        private System.Windows.Forms.Label WeightText;
        private System.Windows.Forms.ComboBox WaypointACombo;
        private System.Windows.Forms.ComboBox WaypointBCombo;
        private System.Windows.Forms.TextBox WeightNumText;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label WeightedWaypointLabel;
    }
}