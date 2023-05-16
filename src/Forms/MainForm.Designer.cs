namespace LWSInjector
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAttach = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblMainForm = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAttach
            // 
            this.btnAttach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(71)))), ((int)(((byte)(68)))));
            this.btnAttach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(92, 126);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(260, 65);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "Attach to Anomaly";
            this.btnAttach.UseVisualStyleBackColor = false;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.pnlForm.Controls.Add(this.lblMainForm);
            this.pnlForm.Controls.Add(this.pbIcon);
            this.pnlForm.Controls.Add(this.btnExit);
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(2);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(450, 20);
            this.pnlForm.TabIndex = 3;
            this.pnlForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlForm_MouseDown);
            this.pnlForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlForm_MouseMove);
            this.pnlForm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlForm_MouseUp);
            // 
            // lblMainForm
            // 
            this.lblMainForm.AutoSize = true;
            this.lblMainForm.Location = new System.Drawing.Point(25, 3);
            this.lblMainForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMainForm.Name = "lblMainForm";
            this.lblMainForm.Size = new System.Drawing.Size(102, 13);
            this.lblMainForm.TabIndex = 2;
            this.lblMainForm.Text = "LWS-Injector v0.0.1";
            // 
            // pbIcon
            // 
            this.pbIcon.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.ErrorImage")));
            this.pbIcon.ImageLocation = "res/icon_resized.png";
            this.pbIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.InitialImage")));
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(20, 20);
            this.pbIcon.TabIndex = 1;
            this.pbIcon.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(390, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 20);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(51, 57);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(338, 24);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "LWS-Injector for Anomaly by TosoxDev";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(85)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(450, 260);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.btnAttach);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "LWS-Injector v0.0.1";
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblMainForm;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblDescription;
    }
}

