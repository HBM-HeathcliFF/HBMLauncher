namespace HBMLauncher
{
    partial class StartWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWin));
            this.label1 = new System.Windows.Forms.Label();
            this.field = new System.Windows.Forms.TextBox();
            this.overview = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Укажите расположение Вашей GTA";
            // 
            // field
            // 
            this.field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.field.Location = new System.Drawing.Point(12, 25);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(253, 20);
            this.field.TabIndex = 1;
            this.field.TextChanged += new System.EventHandler(this.Field_TextChanged);
            // 
            // overview
            // 
            this.overview.BackColor = System.Drawing.Color.Chartreuse;
            this.overview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.overview.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.overview.Location = new System.Drawing.Point(271, 23);
            this.overview.Name = "overview";
            this.overview.Size = new System.Drawing.Size(75, 23);
            this.overview.TabIndex = 2;
            this.overview.Text = "Обзор";
            this.overview.UseVisualStyleBackColor = false;
            this.overview.Click += new System.EventHandler(this.Overview_Click);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.Chartreuse;
            this.next.Enabled = false;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.next.Location = new System.Drawing.Point(271, 61);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 3;
            this.next.Text = "Далее";
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // StartWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HBMLauncher.Properties.Resources.HBMLB4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(358, 93);
            this.Controls.Add(this.next);
            this.Controls.Add(this.overview);
            this.Controls.Add(this.field);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(374, 131);
            this.MinimumSize = new System.Drawing.Size(374, 131);
            this.Name = "StartWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HBM Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox field;
        private System.Windows.Forms.Button overview;
        private System.Windows.Forms.Button next;
    }
}