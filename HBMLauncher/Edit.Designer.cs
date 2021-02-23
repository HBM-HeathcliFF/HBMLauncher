namespace HBMLauncher
{
    partial class Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.nameL = new System.Windows.Forms.Label();
            this.gtaPathL = new System.Windows.Forms.Label();
            this.ipL = new System.Windows.Forms.Label();
            this.nicknameL = new System.Windows.Forms.Label();
            this.cleopL = new System.Windows.Forms.Label();
            this.csoundsL = new System.Windows.Forms.Label();
            this.tbip = new System.Windows.Forms.TextBox();
            this.tbnickname = new System.Windows.Forms.TextBox();
            this.csoundsCB = new System.Windows.Forms.ComboBox();
            this.cleopCB = new System.Windows.Forms.ComboBox();
            this.folderBtn = new System.Windows.Forms.Button();
            this.radarL = new System.Windows.Forms.Label();
            this.radarCB = new System.Windows.Forms.ComboBox();
            this.macrosPathL = new System.Windows.Forms.Label();
            this.binderPathL = new System.Windows.Forms.Label();
            this.macrosBtn = new System.Windows.Forms.Button();
            this.binderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(322, 214);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(403, 214);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 1;
            this.confirmBtn.Text = "Применить";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // nameL
            // 
            this.nameL.AutoSize = true;
            this.nameL.Location = new System.Drawing.Point(7, 9);
            this.nameL.Name = "nameL";
            this.nameL.Size = new System.Drawing.Size(63, 13);
            this.nameL.TabIndex = 2;
            this.nameL.Text = "Название: ";
            // 
            // gtaPathL
            // 
            this.gtaPathL.AutoSize = true;
            this.gtaPathL.Location = new System.Drawing.Point(7, 30);
            this.gtaPathL.Name = "gtaPathL";
            this.gtaPathL.Size = new System.Drawing.Size(71, 13);
            this.gtaPathL.TabIndex = 3;
            this.gtaPathL.Text = "Путь к GTA: ";
            // 
            // ipL
            // 
            this.ipL.AutoSize = true;
            this.ipL.Location = new System.Drawing.Point(7, 53);
            this.ipL.Name = "ipL";
            this.ipL.Size = new System.Drawing.Size(23, 13);
            this.ipL.TabIndex = 4;
            this.ipL.Text = "IP: ";
            // 
            // nicknameL
            // 
            this.nicknameL.AutoSize = true;
            this.nicknameL.Location = new System.Drawing.Point(7, 75);
            this.nicknameL.Name = "nicknameL";
            this.nicknameL.Size = new System.Drawing.Size(61, 13);
            this.nicknameL.TabIndex = 5;
            this.nicknameL.Text = "Nickname: ";
            // 
            // cleopL
            // 
            this.cleopL.AutoSize = true;
            this.cleopL.Location = new System.Drawing.Point(7, 97);
            this.cleopL.Name = "cleopL";
            this.cleopL.Size = new System.Drawing.Size(97, 13);
            this.cleopL.TabIndex = 7;
            this.cleopL.Text = "Cleo-прорисовка: ";
            // 
            // csoundsL
            // 
            this.csoundsL.AutoSize = true;
            this.csoundsL.Location = new System.Drawing.Point(7, 120);
            this.csoundsL.Name = "csoundsL";
            this.csoundsL.Size = new System.Drawing.Size(84, 13);
            this.csoundsL.TabIndex = 8;
            this.csoundsL.Text = "CustomSounds: ";
            // 
            // tbip
            // 
            this.tbip.Location = new System.Drawing.Point(27, 50);
            this.tbip.Name = "tbip";
            this.tbip.Size = new System.Drawing.Size(108, 20);
            this.tbip.TabIndex = 10;
            // 
            // tbnickname
            // 
            this.tbnickname.Location = new System.Drawing.Point(63, 72);
            this.tbnickname.Name = "tbnickname";
            this.tbnickname.Size = new System.Drawing.Size(144, 20);
            this.tbnickname.TabIndex = 11;
            this.tbnickname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // csoundsCB
            // 
            this.csoundsCB.FormattingEnabled = true;
            this.csoundsCB.Location = new System.Drawing.Point(86, 117);
            this.csoundsCB.Name = "csoundsCB";
            this.csoundsCB.Size = new System.Drawing.Size(49, 21);
            this.csoundsCB.TabIndex = 14;
            // 
            // cleopCB
            // 
            this.cleopCB.FormattingEnabled = true;
            this.cleopCB.Location = new System.Drawing.Point(100, 94);
            this.cleopCB.Name = "cleopCB";
            this.cleopCB.Size = new System.Drawing.Size(49, 21);
            this.cleopCB.TabIndex = 15;
            // 
            // folderBtn
            // 
            this.folderBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Folder;
            this.folderBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.folderBtn.Location = new System.Drawing.Point(74, 25);
            this.folderBtn.Name = "folderBtn";
            this.folderBtn.Size = new System.Drawing.Size(26, 23);
            this.folderBtn.TabIndex = 9;
            this.folderBtn.UseVisualStyleBackColor = true;
            this.folderBtn.Click += new System.EventHandler(this.FolderBtn_Click);
            // 
            // radarL
            // 
            this.radarL.AutoSize = true;
            this.radarL.Location = new System.Drawing.Point(7, 143);
            this.radarL.Name = "radarL";
            this.radarL.Size = new System.Drawing.Size(110, 13);
            this.radarL.TabIndex = 16;
            this.radarL.Text = "Стандартный радар:";
            // 
            // radarCB
            // 
            this.radarCB.FormattingEnabled = true;
            this.radarCB.Location = new System.Drawing.Point(116, 140);
            this.radarCB.Name = "radarCB";
            this.radarCB.Size = new System.Drawing.Size(44, 21);
            this.radarCB.TabIndex = 17;
            // 
            // macrosPathL
            // 
            this.macrosPathL.AutoSize = true;
            this.macrosPathL.Location = new System.Drawing.Point(7, 189);
            this.macrosPathL.Name = "macrosPathL";
            this.macrosPathL.Size = new System.Drawing.Size(92, 13);
            this.macrosPathL.TabIndex = 20;
            this.macrosPathL.Text = "Путь к макросу: ";
            // 
            // binderPathL
            // 
            this.binderPathL.AutoSize = true;
            this.binderPathL.Location = new System.Drawing.Point(7, 166);
            this.binderPathL.Name = "binderPathL";
            this.binderPathL.Size = new System.Drawing.Size(90, 13);
            this.binderPathL.TabIndex = 18;
            this.binderPathL.Text = "Путь к биндеру: ";
            // 
            // macrosBtn
            // 
            this.macrosBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Folder;
            this.macrosBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.macrosBtn.Location = new System.Drawing.Point(97, 184);
            this.macrosBtn.Name = "macrosBtn";
            this.macrosBtn.Size = new System.Drawing.Size(26, 23);
            this.macrosBtn.TabIndex = 21;
            this.macrosBtn.UseVisualStyleBackColor = true;
            this.macrosBtn.Click += new System.EventHandler(this.MacrosBtn_Click);
            // 
            // binderBtn
            // 
            this.binderBtn.BackgroundImage = global::HBMLauncher.Properties.Resources.Folder;
            this.binderBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.binderBtn.Location = new System.Drawing.Point(96, 161);
            this.binderBtn.Name = "binderBtn";
            this.binderBtn.Size = new System.Drawing.Size(26, 23);
            this.binderBtn.TabIndex = 22;
            this.binderBtn.UseVisualStyleBackColor = true;
            this.binderBtn.Click += new System.EventHandler(this.BinderBtn_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 243);
            this.Controls.Add(this.binderBtn);
            this.Controls.Add(this.macrosBtn);
            this.Controls.Add(this.macrosPathL);
            this.Controls.Add(this.binderPathL);
            this.Controls.Add(this.radarCB);
            this.Controls.Add(this.radarL);
            this.Controls.Add(this.cleopCB);
            this.Controls.Add(this.csoundsCB);
            this.Controls.Add(this.tbnickname);
            this.Controls.Add(this.tbip);
            this.Controls.Add(this.folderBtn);
            this.Controls.Add(this.csoundsL);
            this.Controls.Add(this.cleopL);
            this.Controls.Add(this.nicknameL);
            this.Controls.Add(this.ipL);
            this.Controls.Add(this.gtaPathL);
            this.Controls.Add(this.nameL);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.cancelBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 281);
            this.MinimumSize = new System.Drawing.Size(500, 281);
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение сохранения";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Label nameL;
        private System.Windows.Forms.Label gtaPathL;
        private System.Windows.Forms.Label ipL;
        private System.Windows.Forms.Label nicknameL;
        private System.Windows.Forms.Label cleopL;
        private System.Windows.Forms.Label csoundsL;
        private System.Windows.Forms.Button folderBtn;
        private System.Windows.Forms.TextBox tbip;
        private System.Windows.Forms.TextBox tbnickname;
        private System.Windows.Forms.ComboBox csoundsCB;
        private System.Windows.Forms.ComboBox cleopCB;
        private System.Windows.Forms.Label radarL;
        private System.Windows.Forms.ComboBox radarCB;
        private System.Windows.Forms.Label macrosPathL;
        private System.Windows.Forms.Label binderPathL;
        private System.Windows.Forms.Button macrosBtn;
        private System.Windows.Forms.Button binderBtn;
    }
}