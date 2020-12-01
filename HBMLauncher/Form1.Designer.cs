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
            this.label1 = new System.Windows.Forms.Label();
            this.slot1 = new System.Windows.Forms.Button();
            this.slot2 = new System.Windows.Forms.Button();
            this.slot3 = new System.Windows.Forms.Button();
            this.slot4 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.сlose = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.position = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.csoundsCB = new System.Windows.Forms.CheckBox();
            this.showBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cleop
            // 
            this.cleop.AutoSize = true;
            this.cleop.BackColor = System.Drawing.Color.Transparent;
            this.cleop.Checked = true;
            this.cleop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cleop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cleop.ForeColor = System.Drawing.Color.Chartreuse;
            this.cleop.Location = new System.Drawing.Point(14, 47);
            this.cleop.Name = "cleop";
            this.cleop.Size = new System.Drawing.Size(119, 19);
            this.cleop.TabIndex = 0;
            this.cleop.Text = "Cleo-прорисовка";
            this.cleop.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(11, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Слоты под карты:";
            // 
            // slot1
            // 
            this.slot1.BackColor = System.Drawing.Color.Chartreuse;
            this.slot1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.slot1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot1.Location = new System.Drawing.Point(11, 87);
            this.slot1.Name = "slot1";
            this.slot1.Size = new System.Drawing.Size(81, 35);
            this.slot1.TabIndex = 2;
            this.slot1.Text = "+";
            this.slot1.UseVisualStyleBackColor = false;
            this.slot1.Click += new System.EventHandler(this.Slot1_Click);
            // 
            // slot2
            // 
            this.slot2.BackColor = System.Drawing.Color.Chartreuse;
            this.slot2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.slot2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot2.Location = new System.Drawing.Point(98, 87);
            this.slot2.Name = "slot2";
            this.slot2.Size = new System.Drawing.Size(81, 34);
            this.slot2.TabIndex = 3;
            this.slot2.Text = "+";
            this.slot2.UseVisualStyleBackColor = false;
            this.slot2.Click += new System.EventHandler(this.Slot2_Click);
            // 
            // slot3
            // 
            this.slot3.BackColor = System.Drawing.Color.Chartreuse;
            this.slot3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.slot3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot3.Location = new System.Drawing.Point(185, 87);
            this.slot3.Name = "slot3";
            this.slot3.Size = new System.Drawing.Size(81, 34);
            this.slot3.TabIndex = 4;
            this.slot3.Text = "+";
            this.slot3.UseVisualStyleBackColor = false;
            this.slot3.Click += new System.EventHandler(this.Slot3_Click);
            // 
            // slot4
            // 
            this.slot4.BackColor = System.Drawing.Color.Chartreuse;
            this.slot4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.slot4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.slot4.Location = new System.Drawing.Point(272, 87);
            this.slot4.Name = "slot4";
            this.slot4.Size = new System.Drawing.Size(81, 34);
            this.slot4.TabIndex = 5;
            this.slot4.Text = "+";
            this.slot4.UseVisualStyleBackColor = false;
            this.slot4.Click += new System.EventHandler(this.Slot4_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Chartreuse;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.save.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save.Location = new System.Drawing.Point(11, 143);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(180, 23);
            this.save.TabIndex = 6;
            this.save.Text = "Сохранить конфигурацию";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // сlose
            // 
            this.сlose.BackColor = System.Drawing.Color.Chartreuse;
            this.сlose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.сlose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сlose.Location = new System.Drawing.Point(438, 143);
            this.сlose.Name = "сlose";
            this.сlose.Size = new System.Drawing.Size(75, 23);
            this.сlose.TabIndex = 8;
            this.сlose.Text = "Выход";
            this.сlose.UseVisualStyleBackColor = false;
            this.сlose.Click += new System.EventHandler(this.Close_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.Chartreuse;
            this.edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.edit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit.Location = new System.Drawing.Point(184, 3);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(89, 23);
            this.edit.TabIndex = 9;
            this.edit.Text = "Изменить";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.BackColor = System.Drawing.Color.Transparent;
            this.position.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.position.ForeColor = System.Drawing.Color.Chartreuse;
            this.position.Location = new System.Drawing.Point(11, 8);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(171, 15);
            this.position.TabIndex = 10;
            this.position.Text = "Текущее расположение GTA:";
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Chartreuse;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel.Location = new System.Drawing.Point(438, 87);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 34);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "Сбросить";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
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
            this.csoundsCB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.csoundsCB.ForeColor = System.Drawing.Color.Chartreuse;
            this.csoundsCB.Location = new System.Drawing.Point(402, 47);
            this.csoundsCB.Name = "csoundsCB";
            this.csoundsCB.Size = new System.Drawing.Size(111, 19);
            this.csoundsCB.TabIndex = 12;
            this.csoundsCB.Text = "Custom Sounds";
            this.csoundsCB.UseVisualStyleBackColor = false;
            // 
            // showBtn
            // 
            this.showBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.showBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showBtn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showBtn.Location = new System.Drawing.Point(197, 143);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(103, 23);
            this.showBtn.TabIndex = 13;
            this.showBtn.Text = "Показать все";
            this.showBtn.UseVisualStyleBackColor = false;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HBMLauncher.Properties.Resources.HBMLB4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(523, 178);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.csoundsCB);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.сlose);
            this.Controls.Add(this.save);
            this.Controls.Add(this.slot4);
            this.Controls.Add(this.slot3);
            this.Controls.Add(this.slot2);
            this.Controls.Add(this.slot1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cleop);
            this.Controls.Add(this.position);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(539, 216);
            this.MinimumSize = new System.Drawing.Size(539, 216);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HBM Launcher v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cleop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button сlose;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button slot1;
        private System.Windows.Forms.Button slot2;
        private System.Windows.Forms.Button slot3;
        private System.Windows.Forms.Button slot4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox csoundsCB;
        private System.Windows.Forms.Button showBtn;
    }
}

