namespace HBMLauncher
{
    partial class Slots
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slots));
            this.choose = new System.Windows.Forms.Button();
            this.field = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choose
            // 
            this.choose.BackColor = System.Drawing.Color.Chartreuse;
            this.choose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.choose.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choose.Location = new System.Drawing.Point(11, 33);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(217, 23);
            this.choose.TabIndex = 0;
            this.choose.Text = "Выбрать файлы карты";
            this.choose.UseVisualStyleBackColor = false;
            this.choose.Click += new System.EventHandler(this.Choose_Click);
            // 
            // field
            // 
            this.field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.field.Location = new System.Drawing.Point(111, 7);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(117, 20);
            this.field.TabIndex = 1;
            this.field.Text = "Слот 1";
            this.field.TextChanged += new System.EventHandler(this.Field_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название слота:";
            // 
            // done
            // 
            this.done.BackColor = System.Drawing.Color.Chartreuse;
            this.done.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.done.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.done.Location = new System.Drawing.Point(11, 62);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(217, 23);
            this.done.TabIndex = 3;
            this.done.Text = "Готово";
            this.done.UseVisualStyleBackColor = false;
            this.done.Click += new System.EventHandler(this.Done_Click);
            // 
            // Slots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HBMLauncher.Properties.Resources.HBMLB3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(239, 90);
            this.Controls.Add(this.done);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.field);
            this.Controls.Add(this.choose);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(255, 128);
            this.MinimumSize = new System.Drawing.Size(255, 128);
            this.Name = "Slots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HBM Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.TextBox field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button done;
    }
}