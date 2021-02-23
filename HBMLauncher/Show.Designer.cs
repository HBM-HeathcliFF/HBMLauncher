namespace HBMLauncher
{
    partial class Show
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Show));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.info = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.menuHorizontal = new System.Windows.Forms.Panel();
            this.normalBtn = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.minBtn = new System.Windows.Forms.PictureBox();
            this.maxBtn = new System.Windows.Forms.PictureBox();
            this.editBtn = new System.Windows.Forms.PictureBox();
            this.removeBtn = new System.Windows.Forms.PictureBox();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.menuHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.normalBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(10, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(130, 238);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info.Location = new System.Drawing.Point(158, 22);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(281, 257);
            this.info.TabIndex = 1;
            this.info.Text = "Информация о выбранном сохранении:";
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.Black;
            this.leftPanel.Controls.Add(this.logo);
            this.leftPanel.Controls.Add(this.listBox1);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(150, 289);
            this.leftPanel.TabIndex = 4;
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::HBMLauncher.Properties.Resources.logo;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.Location = new System.Drawing.Point(5, 5);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(140, 30);
            this.logo.TabIndex = 5;
            this.logo.TabStop = false;
            // 
            // menuHorizontal
            // 
            this.menuHorizontal.Controls.Add(this.normalBtn);
            this.menuHorizontal.Controls.Add(this.closeBtn);
            this.menuHorizontal.Controls.Add(this.minBtn);
            this.menuHorizontal.Controls.Add(this.maxBtn);
            this.menuHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuHorizontal.Location = new System.Drawing.Point(150, 0);
            this.menuHorizontal.Name = "menuHorizontal";
            this.menuHorizontal.Size = new System.Drawing.Size(350, 23);
            this.menuHorizontal.TabIndex = 9;
            this.menuHorizontal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuHorizontal_MouseDown);
            // 
            // normalBtn
            // 
            this.normalBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.normalBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Normal;
            this.normalBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.normalBtn.Location = new System.Drawing.Point(308, 3);
            this.normalBtn.Name = "normalBtn";
            this.normalBtn.Size = new System.Drawing.Size(16, 16);
            this.normalBtn.TabIndex = 8;
            this.normalBtn.TabStop = false;
            this.normalBtn.Visible = false;
            this.normalBtn.Click += new System.EventHandler(this.NormalBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Close;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeBtn.Location = new System.Drawing.Point(329, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(16, 16);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Min;
            this.minBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minBtn.Location = new System.Drawing.Point(287, 3);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(16, 16);
            this.minBtn.TabIndex = 7;
            this.minBtn.TabStop = false;
            this.minBtn.Click += new System.EventHandler(this.MinBtn_Click);
            // 
            // maxBtn
            // 
            this.maxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Max;
            this.maxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.maxBtn.Location = new System.Drawing.Point(308, 3);
            this.maxBtn.Name = "maxBtn";
            this.maxBtn.Size = new System.Drawing.Size(16, 16);
            this.maxBtn.TabIndex = 6;
            this.maxBtn.TabStop = false;
            this.maxBtn.Click += new System.EventHandler(this.MaxBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.EditBN;
            this.editBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBtn.Enabled = false;
            this.editBtn.Location = new System.Drawing.Point(445, 94);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(50, 29);
            this.editBtn.TabIndex = 11;
            this.editBtn.TabStop = false;
            this.editBtn.Click += new System.EventHandler(this.EditBtn_Click);
            this.editBtn.MouseEnter += new System.EventHandler(this.EditBtn_MouseEnter);
            this.editBtn.MouseLeave += new System.EventHandler(this.EditBtn_MouseLeave);
            // 
            // removeBtn
            // 
            this.removeBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.DeleteBN;
            this.removeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeBtn.Enabled = false;
            this.removeBtn.Location = new System.Drawing.Point(445, 63);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(50, 29);
            this.removeBtn.TabIndex = 10;
            this.removeBtn.TabStop = false;
            this.removeBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            this.removeBtn.MouseEnter += new System.EventHandler(this.RemoveBtn_MouseEnter);
            this.removeBtn.MouseLeave += new System.EventHandler(this.RemoveBtn_MouseLeave);
            // 
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 289);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.menuHorizontal);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 289);
            this.Name = "Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Show_Load);
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.menuHorizontal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.normalBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.PictureBox maxBtn;
        private System.Windows.Forms.PictureBox minBtn;
        private System.Windows.Forms.PictureBox normalBtn;
        private System.Windows.Forms.Panel menuHorizontal;
        private System.Windows.Forms.PictureBox removeBtn;
        private System.Windows.Forms.PictureBox editBtn;
    }
}