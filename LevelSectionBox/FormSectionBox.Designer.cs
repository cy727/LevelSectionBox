namespace LevelSectionBox
{
    partial class FormSectionBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSectionBox));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labelFloor = new System.Windows.Forms.Label();
            this.labelCeil = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownC = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownF = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFloor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCeil = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFloor = new System.Windows.Forms.ComboBox();
            this.comboBoxCeil = new System.Windows.Forms.ComboBox();
            this.comboBoxLevelA = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSection = new System.Windows.Forms.Button();
            this.checkBoxSelect = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownWY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxZ = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCeil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWY)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.labelFloor);
            this.groupBox1.Controls.Add(this.labelCeil);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownC);
            this.groupBox1.Controls.Add(this.numericUpDownF);
            this.groupBox1.Controls.Add(this.numericUpDownFloor);
            this.groupBox1.Controls.Add(this.numericUpDownCeil);
            this.groupBox1.Controls.Add(this.comboBoxFloor);
            this.groupBox1.Controls.Add(this.comboBoxCeil);
            this.groupBox1.Controls.Add(this.comboBoxLevelA);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调整参数";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(42, 23);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "<->";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labelFloor
            // 
            this.labelFloor.AutoSize = true;
            this.labelFloor.Location = new System.Drawing.Point(404, 73);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(41, 12);
            this.labelFloor.TabIndex = 14;
            this.labelFloor.Text = "     1";
            // 
            // labelCeil
            // 
            this.labelCeil.AutoSize = true;
            this.labelCeil.Location = new System.Drawing.Point(404, 23);
            this.labelCeil.Name = "labelCeil";
            this.labelCeil.Size = new System.Drawing.Size(41, 12);
            this.labelCeil.TabIndex = 13;
            this.labelCeil.Text = "     1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "+";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "下（m）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "上（m）";
            // 
            // numericUpDownC
            // 
            this.numericUpDownC.DecimalPlaces = 3;
            this.numericUpDownC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownC.Location = new System.Drawing.Point(317, 19);
            this.numericUpDownC.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownC.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericUpDownC.Name = "numericUpDownC";
            this.numericUpDownC.Size = new System.Drawing.Size(63, 21);
            this.numericUpDownC.TabIndex = 6;
            this.numericUpDownC.ValueChanged += new System.EventHandler(this.numericUpDownC_ValueChanged);
            // 
            // numericUpDownF
            // 
            this.numericUpDownF.DecimalPlaces = 3;
            this.numericUpDownF.Location = new System.Drawing.Point(317, 69);
            this.numericUpDownF.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownF.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericUpDownF.Name = "numericUpDownF";
            this.numericUpDownF.Size = new System.Drawing.Size(63, 21);
            this.numericUpDownF.TabIndex = 5;
            this.numericUpDownF.ValueChanged += new System.EventHandler(this.numericUpDownF_ValueChanged);
            // 
            // numericUpDownFloor
            // 
            this.numericUpDownFloor.DecimalPlaces = 3;
            this.numericUpDownFloor.Location = new System.Drawing.Point(217, 69);
            this.numericUpDownFloor.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownFloor.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericUpDownFloor.Name = "numericUpDownFloor";
            this.numericUpDownFloor.Size = new System.Drawing.Size(77, 21);
            this.numericUpDownFloor.TabIndex = 4;
            this.numericUpDownFloor.ValueChanged += new System.EventHandler(this.numericUpDownFloor_ValueChanged);
            // 
            // numericUpDownCeil
            // 
            this.numericUpDownCeil.DecimalPlaces = 3;
            this.numericUpDownCeil.Location = new System.Drawing.Point(217, 19);
            this.numericUpDownCeil.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCeil.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericUpDownCeil.Name = "numericUpDownCeil";
            this.numericUpDownCeil.Size = new System.Drawing.Size(77, 21);
            this.numericUpDownCeil.TabIndex = 3;
            this.numericUpDownCeil.ValueChanged += new System.EventHandler(this.numericUpDownCeil_ValueChanged);
            // 
            // comboBoxFloor
            // 
            this.comboBoxFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFloor.FormattingEnabled = true;
            this.comboBoxFloor.Location = new System.Drawing.Point(116, 69);
            this.comboBoxFloor.Name = "comboBoxFloor";
            this.comboBoxFloor.Size = new System.Drawing.Size(95, 20);
            this.comboBoxFloor.TabIndex = 2;
            this.comboBoxFloor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFloor_SelectedIndexChanged);
            // 
            // comboBoxCeil
            // 
            this.comboBoxCeil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCeil.FormattingEnabled = true;
            this.comboBoxCeil.Location = new System.Drawing.Point(116, 19);
            this.comboBoxCeil.Name = "comboBoxCeil";
            this.comboBoxCeil.Size = new System.Drawing.Size(95, 20);
            this.comboBoxCeil.TabIndex = 1;
            this.comboBoxCeil.SelectedIndexChanged += new System.EventHandler(this.comboBoxCeil_SelectedIndexChanged);
            // 
            // comboBoxLevelA
            // 
            this.comboBoxLevelA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevelA.FormattingEnabled = true;
            this.comboBoxLevelA.Location = new System.Drawing.Point(6, 43);
            this.comboBoxLevelA.Name = "comboBoxLevelA";
            this.comboBoxLevelA.Size = new System.Drawing.Size(109, 20);
            this.comboBoxLevelA.TabIndex = 0;
            this.comboBoxLevelA.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevelA_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(402, 118);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSection
            // 
            this.btnSection.Location = new System.Drawing.Point(230, 118);
            this.btnSection.Name = "btnSection";
            this.btnSection.Size = new System.Drawing.Size(166, 45);
            this.btnSection.TabIndex = 2;
            this.btnSection.Text = "调整";
            this.btnSection.UseVisualStyleBackColor = true;
            this.btnSection.Click += new System.EventHandler(this.btnSection_Click);
            // 
            // checkBoxSelect
            // 
            this.checkBoxSelect.AutoSize = true;
            this.checkBoxSelect.Location = new System.Drawing.Point(19, 118);
            this.checkBoxSelect.Name = "checkBoxSelect";
            this.checkBoxSelect.Size = new System.Drawing.Size(120, 16);
            this.checkBoxSelect.TabIndex = 3;
            this.checkBoxSelect.Text = "按照选取对象调整";
            this.checkBoxSelect.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "外延: ";
            // 
            // numericUpDownWY
            // 
            this.numericUpDownWY.Location = new System.Drawing.Point(48, 140);
            this.numericUpDownWY.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDownWY.Name = "numericUpDownWY";
            this.numericUpDownWY.Size = new System.Drawing.Size(75, 21);
            this.numericUpDownWY.TabIndex = 5;
            this.numericUpDownWY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "mm";
            // 
            // checkBoxZ
            // 
            this.checkBoxZ.AutoSize = true;
            this.checkBoxZ.Checked = true;
            this.checkBoxZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxZ.Location = new System.Drawing.Point(152, 144);
            this.checkBoxZ.Name = "checkBoxZ";
            this.checkBoxZ.Size = new System.Drawing.Size(66, 16);
            this.checkBoxZ.TabIndex = 7;
            this.checkBoxZ.Text = "调整Z轴";
            this.checkBoxZ.UseVisualStyleBackColor = true;
            // 
            // FormSectionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 175);
            this.Controls.Add(this.checkBoxZ);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownWY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBoxSelect);
            this.Controls.Add(this.btnSection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSectionBox";
            this.Text = "剖切块控制";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSectionBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCeil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownC;
        private System.Windows.Forms.NumericUpDown numericUpDownF;
        private System.Windows.Forms.NumericUpDown numericUpDownFloor;
        private System.Windows.Forms.NumericUpDown numericUpDownCeil;
        private System.Windows.Forms.ComboBox comboBoxFloor;
        private System.Windows.Forms.ComboBox comboBoxCeil;
        private System.Windows.Forms.ComboBox comboBoxLevelA;
        private System.Windows.Forms.CheckBox checkBoxSelect;
        private System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Label labelFloor;
        public System.Windows.Forms.Label labelCeil;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownWY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxZ;
    }
}