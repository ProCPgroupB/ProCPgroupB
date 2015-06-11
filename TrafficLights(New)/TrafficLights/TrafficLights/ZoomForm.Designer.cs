namespace TrafficLights
{
    partial class ZoomForm
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
            this.mapPb = new System.Windows.Forms.PictureBox();
            this.withPanel = new System.Windows.Forms.Panel();
            this.cbT2 = new System.Windows.Forms.ComboBox();
            this.lbT2 = new System.Windows.Forms.Label();
            this.cbT1 = new System.Windows.Forms.ComboBox();
            this.lbT1 = new System.Windows.Forms.Label();
            this.cbPedes = new System.Windows.Forms.ComboBox();
            this.lbPedes = new System.Windows.Forms.Label();
            this.lbDir = new System.Windows.Forms.Label();
            this.cbCar = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.lbCar = new System.Windows.Forms.Label();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapPb)).BeginInit();
            this.withPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPb
            // 
            this.mapPb.Image = global::TrafficLights.Properties.Resources.grid;
            this.mapPb.Location = new System.Drawing.Point(0, 0);
            this.mapPb.Margin = new System.Windows.Forms.Padding(0);
            this.mapPb.Name = "mapPb";
            this.mapPb.Size = new System.Drawing.Size(600, 600);
            this.mapPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapPb.TabIndex = 0;
            this.mapPb.TabStop = false;
            // 
            // withPanel
            // 
            this.withPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.withPanel.Controls.Add(this.cbT2);
            this.withPanel.Controls.Add(this.lbT2);
            this.withPanel.Controls.Add(this.cbT1);
            this.withPanel.Controls.Add(this.lbT1);
            this.withPanel.Controls.Add(this.cbPedes);
            this.withPanel.Controls.Add(this.lbPedes);
            this.withPanel.Controls.Add(this.lbDir);
            this.withPanel.Controls.Add(this.cbCar);
            this.withPanel.Controls.Add(this.btnSave);
            this.withPanel.Controls.Add(this.cbDirection);
            this.withPanel.Controls.Add(this.lbCar);
            this.withPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.withPanel.Location = new System.Drawing.Point(603, 0);
            this.withPanel.Name = "withPanel";
            this.withPanel.Size = new System.Drawing.Size(281, 571);
            this.withPanel.TabIndex = 1;
            // 
            // cbT2
            // 
            this.cbT2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbT2.FormattingEnabled = true;
            this.cbT2.ItemHeight = 16;
            this.cbT2.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "5",
            "8"});
            this.cbT2.Location = new System.Drawing.Point(151, 177);
            this.cbT2.Name = "cbT2";
            this.cbT2.Size = new System.Drawing.Size(105, 24);
            this.cbT2.TabIndex = 13;
            this.cbT2.SelectedIndexChanged += new System.EventHandler(this.cbT2_SelectedIndexChanged);
            // 
            // lbT2
            // 
            this.lbT2.AutoSize = true;
            this.lbT2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbT2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbT2.Location = new System.Drawing.Point(147, 155);
            this.lbT2.Name = "lbT2";
            this.lbT2.Size = new System.Drawing.Size(56, 19);
            this.lbT2.TabIndex = 12;
            this.lbT2.Text = "TL Time";
            // 
            // cbT1
            // 
            this.cbT1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbT1.FormattingEnabled = true;
            this.cbT1.ItemHeight = 16;
            this.cbT1.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "5",
            "8"});
            this.cbT1.Location = new System.Drawing.Point(16, 177);
            this.cbT1.Name = "cbT1";
            this.cbT1.Size = new System.Drawing.Size(105, 24);
            this.cbT1.TabIndex = 11;
            this.cbT1.SelectedIndexChanged += new System.EventHandler(this.cbT1_SelectedIndexChanged);
            // 
            // lbT1
            // 
            this.lbT1.AutoSize = true;
            this.lbT1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbT1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbT1.Location = new System.Drawing.Point(13, 155);
            this.lbT1.Name = "lbT1";
            this.lbT1.Size = new System.Drawing.Size(56, 19);
            this.lbT1.TabIndex = 10;
            this.lbT1.Text = "TL Time";
            // 
            // cbPedes
            // 
            this.cbPedes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPedes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPedes.FormattingEnabled = true;
            this.cbPedes.ItemHeight = 16;
            this.cbPedes.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cbPedes.Location = new System.Drawing.Point(17, 238);
            this.cbPedes.Name = "cbPedes";
            this.cbPedes.Size = new System.Drawing.Size(242, 24);
            this.cbPedes.TabIndex = 9;
            this.cbPedes.SelectedIndexChanged += new System.EventHandler(this.cbPedes_SelectedIndexChanged);
            // 
            // lbPedes
            // 
            this.lbPedes.AutoSize = true;
            this.lbPedes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPedes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbPedes.Location = new System.Drawing.Point(14, 216);
            this.lbPedes.Name = "lbPedes";
            this.lbPedes.Size = new System.Drawing.Size(108, 19);
            this.lbPedes.TabIndex = 8;
            this.lbPedes.Text = "Nr of Pedestrian";
            // 
            // lbDir
            // 
            this.lbDir.AutoSize = true;
            this.lbDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDir.Location = new System.Drawing.Point(14, 11);
            this.lbDir.Name = "lbDir";
            this.lbDir.Size = new System.Drawing.Size(97, 19);
            this.lbDir.TabIndex = 7;
            this.lbDir.Text = "Lane Direction";
            // 
            // cbCar
            // 
            this.cbCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCar.FormattingEnabled = true;
            this.cbCar.ItemHeight = 16;
            this.cbCar.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cbCar.Location = new System.Drawing.Point(17, 114);
            this.cbCar.Name = "cbCar";
            this.cbCar.Size = new System.Drawing.Size(242, 24);
            this.cbCar.TabIndex = 6;
            this.cbCar.SelectedIndexChanged += new System.EventHandler(this.cbCar_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(242, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDirection
            // 
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.ItemHeight = 25;
            this.cbDirection.Items.AddRange(new object[] {
            "North",
            "East",
            "South",
            "West"});
            this.cbDirection.Location = new System.Drawing.Point(18, 33);
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Size = new System.Drawing.Size(241, 33);
            this.cbDirection.TabIndex = 4;
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbDirection_SelectedIndexChanged);
            // 
            // lbCar
            // 
            this.lbCar.AutoSize = true;
            this.lbCar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbCar.Location = new System.Drawing.Point(14, 92);
            this.lbCar.Name = "lbCar";
            this.lbCar.Size = new System.Drawing.Size(65, 19);
            this.lbCar.TabIndex = 3;
            this.lbCar.Text = "Nr of Car";
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(275, 75);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(50, 50);
            this.btnNorth.TabIndex = 2;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(275, 475);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(50, 50);
            this.btnSouth.TabIndex = 3;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(475, 275);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(50, 50);
            this.btnEast.TabIndex = 4;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(75, 275);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(50, 50);
            this.btnWest.TabIndex = 5;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // ZoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 571);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.withPanel);
            this.Controls.Add(this.mapPb);
            this.MaximumSize = new System.Drawing.Size(900, 610);
            this.MinimumSize = new System.Drawing.Size(900, 610);
            this.Name = "ZoomForm";
            this.Text = "ZoomForm";
            ((System.ComponentModel.ISupportInitialize)(this.mapPb)).EndInit();
            this.withPanel.ResumeLayout(false);
            this.withPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPb;
        private System.Windows.Forms.Panel withPanel;
        private System.Windows.Forms.Label lbCar;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.ComboBox cbCar;
        private System.Windows.Forms.ComboBox cbPedes;
        private System.Windows.Forms.Label lbPedes;
        private System.Windows.Forms.Label lbDir;
        private System.Windows.Forms.ComboBox cbT2;
        private System.Windows.Forms.Label lbT2;
        private System.Windows.Forms.ComboBox cbT1;
        private System.Windows.Forms.Label lbT1;
    }
}