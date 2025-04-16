namespace WindowsFormsApp_loop
{
    partial class Form1
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
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.button_input = new System.Windows.Forms.Button();
            this.button_scissors = new System.Windows.Forms.Button();
            this.button_rock = new System.Windows.Forms.Button();
            this.button_paper = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_userScore = new System.Windows.Forms.TextBox();
            this.textBox_comScore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_result
            // 
            this.textBox_result.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_result.Location = new System.Drawing.Point(12, 57);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(259, 120);
            this.textBox_result.TabIndex = 2;
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(12, 30);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(177, 21);
            this.textBox_input.TabIndex = 0;
            // 
            // button_input
            // 
            this.button_input.Location = new System.Drawing.Point(195, 30);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(75, 23);
            this.button_input.TabIndex = 1;
            this.button_input.Text = "Input";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // button_scissors
            // 
            this.button_scissors.Location = new System.Drawing.Point(11, 212);
            this.button_scissors.Name = "button_scissors";
            this.button_scissors.Size = new System.Drawing.Size(75, 23);
            this.button_scissors.TabIndex = 3;
            this.button_scissors.Text = "가위";
            this.button_scissors.UseVisualStyleBackColor = true;
            this.button_scissors.Click += new System.EventHandler(this.button_scissors_Click);
            // 
            // button_rock
            // 
            this.button_rock.Location = new System.Drawing.Point(104, 212);
            this.button_rock.Name = "button_rock";
            this.button_rock.Size = new System.Drawing.Size(75, 23);
            this.button_rock.TabIndex = 4;
            this.button_rock.Text = "바위";
            this.button_rock.UseVisualStyleBackColor = true;
            this.button_rock.Click += new System.EventHandler(this.button_rock_Click);
            // 
            // button_paper
            // 
            this.button_paper.Location = new System.Drawing.Point(195, 212);
            this.button_paper.Name = "button_paper";
            this.button_paper.Size = new System.Drawing.Size(75, 23);
            this.button_paper.TabIndex = 5;
            this.button_paper.Text = "보";
            this.button_paper.UseVisualStyleBackColor = true;
            this.button_paper.Click += new System.EventHandler(this.button_paper_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "학생 수를 숫자로 입력하세요.";
            // 
            // textBox_userScore
            // 
            this.textBox_userScore.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_userScore.Location = new System.Drawing.Point(77, 185);
            this.textBox_userScore.Name = "textBox_userScore";
            this.textBox_userScore.ReadOnly = true;
            this.textBox_userScore.Size = new System.Drawing.Size(54, 21);
            this.textBox_userScore.TabIndex = 7;
            this.textBox_userScore.Text = "0";
            // 
            // textBox_comScore
            // 
            this.textBox_comScore.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox_comScore.Location = new System.Drawing.Point(195, 185);
            this.textBox_comScore.Name = "textBox_comScore";
            this.textBox_comScore.ReadOnly = true;
            this.textBox_comScore.Size = new System.Drawing.Size(54, 21);
            this.textBox_comScore.TabIndex = 8;
            this.textBox_comScore.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "용사";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "마왕";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 245);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_comScore);
            this.Controls.Add(this.textBox_userScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_paper);
            this.Controls.Add(this.button_rock);
            this.Controls.Add(this.button_scissors);
            this.Controls.Add(this.button_input);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.textBox_result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Button button_scissors;
        private System.Windows.Forms.Button button_rock;
        private System.Windows.Forms.Button button_paper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_userScore;
        private System.Windows.Forms.TextBox textBox_comScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

