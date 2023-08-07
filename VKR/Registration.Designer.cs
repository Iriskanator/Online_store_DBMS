
namespace VKR
{
    partial class Registration
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
            this.REGISTR = new System.Windows.Forms.Button();
            this.PasswordReg = new System.Windows.Forms.TextBox();
            this.LoginReg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // REGISTR
            // 
            this.REGISTR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.REGISTR.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REGISTR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.REGISTR.Location = new System.Drawing.Point(138, 193);
            this.REGISTR.Name = "REGISTR";
            this.REGISTR.Size = new System.Drawing.Size(201, 45);
            this.REGISTR.TabIndex = 13;
            this.REGISTR.Text = "ЗАРЕГИСТРИРОВАТЬ";
            this.REGISTR.UseVisualStyleBackColor = true;
            this.REGISTR.Click += new System.EventHandler(this.REGISTR_Click);
            // 
            // PasswordReg
            // 
            this.PasswordReg.Location = new System.Drawing.Point(271, 126);
            this.PasswordReg.Name = "PasswordReg";
            this.PasswordReg.Size = new System.Drawing.Size(162, 20);
            this.PasswordReg.TabIndex = 12;
            this.PasswordReg.UseSystemPasswordChar = true;
            // 
            // LoginReg
            // 
            this.LoginReg.Location = new System.Drawing.Point(41, 126);
            this.LoginReg.Name = "LoginReg";
            this.LoginReg.Size = new System.Drawing.Size(162, 20);
            this.LoginReg.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 36);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(19)))), ((int)(((byte)(16)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Регистрация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(473, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Для регистрации сотрудника ведите Логин и Пароль";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 268);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.REGISTR);
            this.Controls.Add(this.PasswordReg);
            this.Controls.Add(this.LoginReg);
            this.Controls.Add(this.panel1);
            this.Name = "Registration";
            this.Text = "Регистрация";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button REGISTR;
        private System.Windows.Forms.TextBox PasswordReg;
        private System.Windows.Forms.TextBox LoginReg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}