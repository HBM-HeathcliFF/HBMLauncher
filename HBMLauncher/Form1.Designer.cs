namespace HBMLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cleop = new System.Windows.Forms.CheckBox();
            this.position = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.csoundsCB = new System.Windows.Forms.CheckBox();
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showBtn = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.MenuHorizontal = new System.Windows.Forms.Panel();
            this.MaxBtn = new System.Windows.Forms.PictureBox();
            this.MinBtn = new System.Windows.Forms.PictureBox();
            this.NormalBtn = new System.Windows.Forms.PictureBox();
            this.CloseBtn = new System.Windows.Forms.PictureBox();
            this.MenuBtn = new System.Windows.Forms.PictureBox();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContent.SuspendLayout();
            this.MenuHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // cleop
            // 
            this.cleop.AutoSize = true;
            this.cleop.BackColor = System.Drawing.Color.Transparent;
            this.cleop.Checked = true;
            this.cleop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cleop.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cleop.ForeColor = System.Drawing.Color.Black;
            this.cleop.Location = new System.Drawing.Point(3, 106);
            this.cleop.Name = "cleop";
            this.cleop.Size = new System.Drawing.Size(143, 20);
            this.cleop.TabIndex = 0;
            this.cleop.Text = "Cleo-прорисовка";
            this.cleop.UseVisualStyleBackColor = false;
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.BackColor = System.Drawing.Color.Transparent;
            this.position.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.position.ForeColor = System.Drawing.Color.Black;
            this.position.Location = new System.Drawing.Point(3, 47);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(204, 16);
            this.position.TabIndex = 10;
            this.position.Text = "Текущее расположение GTA:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "exe";
            this.saveFileDialog1.Filter = "Ярлык (*.lnk)|*.*";
            this.saveFileDialog1.InitialDirectory = "C:\\\\";
            this.saveFileDialog1.Title = "Создание ярлыка";
            // 
            // csoundsCB
            // 
            this.csoundsCB.AutoSize = true;
            this.csoundsCB.BackColor = System.Drawing.Color.Transparent;
            this.csoundsCB.Checked = true;
            this.csoundsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.csoundsCB.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.csoundsCB.ForeColor = System.Drawing.Color.Black;
            this.csoundsCB.Location = new System.Drawing.Point(4, 88);
            this.csoundsCB.Name = "csoundsCB";
            this.csoundsCB.Size = new System.Drawing.Size(125, 20);
            this.csoundsCB.TabIndex = 12;
            this.csoundsCB.Text = "Custom Sounds";
            this.csoundsCB.UseVisualStyleBackColor = false;
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.Black;
            this.MenuVertical.Controls.Add(this.pictureBox2);
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Controls.Add(this.showBtn);
            this.MenuVertical.Controls.Add(this.cancel);
            this.MenuVertical.Controls.Add(this.save);
            this.MenuVertical.Controls.Add(this.edit);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(170, 270);
            this.MenuVertical.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::HBMLauncher.Properties.Resources.logo2;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(4, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 30);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(240, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // showBtn
            // 
            this.showBtn.BackColor = System.Drawing.Color.Transparent;
            this.showBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.showBtn.FlatAppearance.BorderSize = 0;
            this.showBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.showBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showBtn.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBtn.ForeColor = System.Drawing.Color.White;
            this.showBtn.Image = global::HBMLauncher.Properties.Resources.Show;
            this.showBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showBtn.Location = new System.Drawing.Point(0, 119);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(170, 36);
            this.showBtn.TabIndex = 13;
            this.showBtn.Text = "Показать все";
            this.showBtn.UseVisualStyleBackColor = false;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Transparent;
            this.cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cancel.FlatAppearance.BorderSize = 0;
            this.cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Image = global::HBMLauncher.Properties.Resources.Delete;
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancel.Location = new System.Drawing.Point(0, 155);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(170, 36);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Удалить все";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Transparent;
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Image = global::HBMLauncher.Properties.Resources.Save1;
            this.save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save.Location = new System.Drawing.Point(0, 83);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(170, 36);
            this.save.TabIndex = 6;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Transparent;
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.edit.FlatAppearance.BorderSize = 0;
            this.edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit.Font = new System.Drawing.Font("Century Gothic", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.ForeColor = System.Drawing.Color.White;
            this.edit.Image = global::HBMLauncher.Properties.Resources.Edit;
            this.edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edit.Location = new System.Drawing.Point(0, 47);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(170, 36);
            this.edit.TabIndex = 9;
            this.edit.Text = "Изменить путь";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Controls.Add(this.csoundsCB);
            this.panelContent.Controls.Add(this.cleop);
            this.panelContent.Controls.Add(this.position);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(170, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(355, 270);
            this.panelContent.TabIndex = 15;
            // 
            // MenuHorizontal
            // 
            this.MenuHorizontal.Controls.Add(this.MaxBtn);
            this.MenuHorizontal.Controls.Add(this.MinBtn);
            this.MenuHorizontal.Controls.Add(this.NormalBtn);
            this.MenuHorizontal.Controls.Add(this.CloseBtn);
            this.MenuHorizontal.Controls.Add(this.MenuBtn);
            this.MenuHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuHorizontal.Location = new System.Drawing.Point(170, 0);
            this.MenuHorizontal.Name = "MenuHorizontal";
            this.MenuHorizontal.Size = new System.Drawing.Size(355, 40);
            this.MenuHorizontal.TabIndex = 15;
            this.MenuHorizontal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuHorizontal_MouseDown);
            // 
            // MaxBtn
            // 
            this.MaxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Max;
            this.MaxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MaxBtn.Location = new System.Drawing.Point(310, 3);
            this.MaxBtn.Name = "MaxBtn";
            this.MaxBtn.Size = new System.Drawing.Size(15, 15);
            this.MaxBtn.TabIndex = 16;
            this.MaxBtn.TabStop = false;
            this.MaxBtn.Click += new System.EventHandler(this.MaxBtn_Click);
            // 
            // MinBtn
            // 
            this.MinBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Min;
            this.MinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MinBtn.Location = new System.Drawing.Point(287, 3);
            this.MinBtn.Name = "MinBtn";
            this.MinBtn.Size = new System.Drawing.Size(15, 15);
            this.MinBtn.TabIndex = 15;
            this.MinBtn.TabStop = false;
            this.MinBtn.Click += new System.EventHandler(this.MinBtn_Click);
            // 
            // NormalBtn
            // 
            this.NormalBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Normal;
            this.NormalBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NormalBtn.Location = new System.Drawing.Point(310, 3);
            this.NormalBtn.Name = "NormalBtn";
            this.NormalBtn.Size = new System.Drawing.Size(15, 15);
            this.NormalBtn.TabIndex = 14;
            this.NormalBtn.TabStop = false;
            this.NormalBtn.Visible = false;
            this.NormalBtn.Click += new System.EventHandler(this.NormalBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Close;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.Location = new System.Drawing.Point(333, 3);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(15, 15);
            this.CloseBtn.TabIndex = 13;
            this.CloseBtn.TabStop = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MenuBtn
            // 
            this.MenuBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MenuBtn.BackgroundImage")));
            this.MenuBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MenuBtn.Image = ((System.Drawing.Image)(resources.GetObject("MenuBtn.Image")));
            this.MenuBtn.Location = new System.Drawing.Point(4, 5);
            this.MenuBtn.Name = "MenuBtn";
            this.MenuBtn.Size = new System.Drawing.Size(30, 30);
            this.MenuBtn.TabIndex = 13;
            this.MenuBtn.TabStop = false;
            this.MenuBtn.Click += new System.EventHandler(this.MenuBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 270);
            this.Controls.Add(this.MenuHorizontal);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.MenuVertical);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HBM Launcher v1.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.MenuHorizontal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaxBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NormalBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cleop;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox csoundsCB;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel MenuHorizontal;
        private System.Windows.Forms.PictureBox MenuBtn;
        private System.Windows.Forms.PictureBox MinBtn;
        private System.Windows.Forms.PictureBox NormalBtn;
        private System.Windows.Forms.PictureBox CloseBtn;
        private System.Windows.Forms.PictureBox MaxBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

