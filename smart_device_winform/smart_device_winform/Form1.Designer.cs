namespace smart_device_winform
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
            this.clear = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.txtkb = new System.Windows.Forms.TextBox();
            this.txtpi = new System.Windows.Forms.TextBox();
            this.txttag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(489, 184);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(110, 36);
            this.clear.TabIndex = 0;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(489, 248);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(110, 36);
            this.exit.TabIndex = 1;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // txtkb
            // 
            this.txtkb.Location = new System.Drawing.Point(234, 60);
            this.txtkb.Name = "txtkb";
            this.txtkb.Size = new System.Drawing.Size(204, 20);
            this.txtkb.TabIndex = 2;
            this.txtkb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkb_KeyPress);
            // 
            // txtpi
            // 
            this.txtpi.Location = new System.Drawing.Point(234, 107);
            this.txtpi.Name = "txtpi";
            this.txtpi.Size = new System.Drawing.Size(204, 20);
            this.txtpi.TabIndex = 3;
            this.txtpi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpi_KeyPress);
            // 
            // txttag
            // 
            this.txttag.Location = new System.Drawing.Point(234, 152);
            this.txttag.Name = "txttag";
            this.txttag.Size = new System.Drawing.Size(204, 20);
            this.txttag.TabIndex = 4;
            this.txttag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttag_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "E-KANBAN :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PI-KANBAN :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tag :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(547, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 311);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttag);
            this.Controls.Add(this.txtpi);
            this.Controls.Add(this.txtkb);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.clear);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.TextBox txtkb;
        private System.Windows.Forms.TextBox txtpi;
        private System.Windows.Forms.TextBox txttag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;

    }
}

