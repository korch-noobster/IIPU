namespace USB
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
            this.usbworker = new System.ComponentModel.BackgroundWorker();
            this.UsbBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Usb_eject = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // usbworker
            // 
            this.usbworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Usbworker_DoWork);
            // 
            // UsbBox
            // 
            this.UsbBox.Location = new System.Drawing.Point(13, 13);
            this.UsbBox.Name = "UsbBox";
            this.UsbBox.ReadOnly = true;
            this.UsbBox.Size = new System.Drawing.Size(584, 245);
            this.UsbBox.TabIndex = 0;
            this.UsbBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Eject";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Usb_eject
            // 
            this.Usb_eject.DisplayMember = "text";
            this.Usb_eject.FormattingEnabled = true;
            this.Usb_eject.Location = new System.Drawing.Point(13, 265);
            this.Usb_eject.Name = "Usb_eject";
            this.Usb_eject.Size = new System.Drawing.Size(121, 24);
            this.Usb_eject.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 463);
            this.Controls.Add(this.Usb_eject);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UsbBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker usbworker;
        private System.Windows.Forms.RichTextBox UsbBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Usb_eject;
    }
}

