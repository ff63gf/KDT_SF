namespace WindowsFormsAppButton
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_print = new System.Windows.Forms.TextBox();
            this.button_input = new System.Windows.Forms.Button();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.textBoxCopy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_print
            // 
            this.textBox_print.Location = new System.Drawing.Point(485, 27);
            this.textBox_print.Multiline = true;
            this.textBox_print.Name = "textBox_print";
            this.textBox_print.Size = new System.Drawing.Size(260, 269);
            this.textBox_print.TabIndex = 0;
            this.textBox_print.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox_print.KeyDown += new System.Windows.Forms.KeyEventHandler(this.down);
            // 
            // button_input
            // 
            this.button_input.Location = new System.Drawing.Point(260, 316);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(195, 89);
            this.button_input.TabIndex = 1;
            this.button_input.Text = "Input";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_click);
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(45, 38);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(316, 258);
            this.textBox_input.TabIndex = 2;
            this.textBox_input.TextChanged += new System.EventHandler(this.textBox_input_TextChanged);
            // 
            // textBoxCopy
            // 
            this.textBoxCopy.Location = new System.Drawing.Point(485, 303);
            this.textBoxCopy.Multiline = true;
            this.textBoxCopy.Name = "textBoxCopy";
            this.textBoxCopy.Size = new System.Drawing.Size(260, 120);
            this.textBoxCopy.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCopy);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.button_input);
            this.Controls.Add(this.textBox_print);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_print;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.TextBox textBoxCopy;
    }
}

