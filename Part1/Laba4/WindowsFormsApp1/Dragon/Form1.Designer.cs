namespace Dragonborn
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Draw_curve = new System.Windows.Forms.Button();
            this.Clear_all = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(889, 516);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Picturebox);
            // 
            // Draw_curve
            // 
            this.Draw_curve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Draw_curve.Location = new System.Drawing.Point(27, 528);
            this.Draw_curve.Name = "Draw_curve";
            this.Draw_curve.Size = new System.Drawing.Size(123, 56);
            this.Draw_curve.TabIndex = 1;
            this.Draw_curve.Text = "Нарисовать";
            this.Draw_curve.UseVisualStyleBackColor = true;
            this.Draw_curve.Click += new System.EventHandler(this.Draw_dragon_curve);
            // 
            // Clear_all
            // 
            this.Clear_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Clear_all.Location = new System.Drawing.Point(793, 524);
            this.Clear_all.Name = "Clear_all";
            this.Clear_all.Size = new System.Drawing.Size(123, 60);
            this.Clear_all.TabIndex = 2;
            this.Clear_all.Text = "Очистить";
            this.Clear_all.UseVisualStyleBackColor = true;
            this.Clear_all.Click += new System.EventHandler(this.Clear_curve);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 596);
            this.Controls.Add(this.Clear_all);
            this.Controls.Add(this.Draw_curve);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Draw_curve;
        private System.Windows.Forms.Button Clear_all;
    }
}

