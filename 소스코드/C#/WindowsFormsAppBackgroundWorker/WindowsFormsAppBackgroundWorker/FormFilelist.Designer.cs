namespace WindowsFormsAppBackgroundWorker
{
    partial class FormFilelist
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
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBox_format = new System.Windows.Forms.ComboBox();
            this.listBox_fileList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_path
            // 
            this.textBox_path.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_path.Location = new System.Drawing.Point(24, 13);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(370, 21);
            this.textBox_path.TabIndex = 99;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(469, 13);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\";
            // 
            // comboBox_format
            // 
            this.comboBox_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_format.FormattingEnabled = true;
            this.comboBox_format.Items.AddRange(new object[] {
            "*.png",
            "*.exe",
            "*.txt",
            "*.jpg",
            "*.dll",
            "*.bin",
            "*.xlsx"});
            this.comboBox_format.Location = new System.Drawing.Point(400, 14);
            this.comboBox_format.Name = "comboBox_format";
            this.comboBox_format.Size = new System.Drawing.Size(63, 20);
            this.comboBox_format.TabIndex = 2;
            // 
            // listBox_fileList
            // 
            this.listBox_fileList.FormattingEnabled = true;
            this.listBox_fileList.ItemHeight = 12;
            this.listBox_fileList.Location = new System.Drawing.Point(24, 39);
            this.listBox_fileList.Name = "listBox_fileList";
            this.listBox_fileList.Size = new System.Drawing.Size(520, 232);
            this.listBox_fileList.TabIndex = 3;
            // 
            // FormFilelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 294);
            this.Controls.Add(this.listBox_fileList);
            this.Controls.Add(this.comboBox_format);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.textBox_path);
            this.Name = "FormFilelist";
            this.Text = "FormFilelist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboBox_format;
        private System.Windows.Forms.ListBox listBox_fileList;
    }
}