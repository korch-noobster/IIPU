namespace Battery
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
            this.Battery_Status_label = new System.Windows.Forms.TextBox();
            this.Battery_status_check = new System.ComponentModel.BackgroundWorker();
            this.Battery_lvl_lable = new System.Windows.Forms.TextBox();
            this.Remainig_label = new System.Windows.Forms.TextBox();
            this.value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Battery_Status_label
            // 
            this.Battery_Status_label.Location = new System.Drawing.Point(13, 35);
            this.Battery_Status_label.Name = "Battery_Status_label";
            this.Battery_Status_label.ReadOnly = true;
            this.Battery_Status_label.Size = new System.Drawing.Size(213, 22);
            this.Battery_Status_label.TabIndex = 0;
            this.Battery_Status_label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Battery_status_check
            // 
            this.Battery_status_check.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Power_status);
            // 
            // Battery_lvl_lable
            // 
            this.Battery_lvl_lable.Location = new System.Drawing.Point(13, 84);
            this.Battery_lvl_lable.Name = "Battery_lvl_lable";
            this.Battery_lvl_lable.ReadOnly = true;
            this.Battery_lvl_lable.Size = new System.Drawing.Size(213, 22);
            this.Battery_lvl_lable.TabIndex = 1;
            this.Battery_lvl_lable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Remainig_label
            // 
            this.Remainig_label.Location = new System.Drawing.Point(13, 131);
            this.Remainig_label.Name = "Remainig_label";
            this.Remainig_label.ReadOnly = true;
            this.Remainig_label.Size = new System.Drawing.Size(213, 22);
            this.Remainig_label.TabIndex = 2;
            this.Remainig_label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // value
            // 
            this.value.Location = new System.Drawing.Point(165, 178);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(61, 22);
            this.value.TabIndex = 3;
            this.value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Value_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label_value
            // 
            this.label_value.AutoSize = true;
            this.label_value.Location = new System.Drawing.Point(12, 178);
            this.label_value.Name = "label_value";
            this.label_value.Size = new System.Drawing.Size(147, 17);
            this.label_value.TabIndex = 4;
            this.label_value.Text = "Set timeout on battery";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.label_value);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.value);
            this.Controls.Add(this.Remainig_label);
            this.Controls.Add(this.Battery_lvl_lable);
            this.Controls.Add(this.Battery_Status_label);
            this.Name = "Form1";
            this.Text = "Battery Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Battery_Status_label;
        private System.ComponentModel.BackgroundWorker Battery_status_check;
        private System.Windows.Forms.TextBox Battery_lvl_lable;
        private System.Windows.Forms.TextBox Remainig_label;
        private System.Windows.Forms.TextBox value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_value;
    }
}

