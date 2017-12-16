using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;



namespace Battery
{
    public partial class Form1 : Form
    {
        int current;
        public Form1()
        {
            InitializeComponent();
            Battery_status_check.RunWorkerAsync();
        }

        
        int Parcing()
        {
            using (StreamReader sr = new StreamReader("powercfg.txt", System.Text.Encoding.UTF8))
            {
                string line;
                bool screen = false;
                while ((line = sr.ReadLine()) != null)
                {
                   if(line.Contains( "Отключать экран через" )==true)
                        screen=true;
                    if (screen && line.Contains("Текущий индекс настройки питания от батарей:"))
                        break;
                   
                }
                line = line.Substring(line.IndexOf("x")+1);
               return  Convert.ToInt32(line,16);
            }
        }
       

            private void Power_status(object sender, DoWorkEventArgs e)
        { 
            Process.Start("export.bat");
             current = Parcing() / 60;
            bool change = false;
            while (true)
            {
                PowerStatus powerStatus = SystemInformation.PowerStatus;
                if (powerStatus.PowerLineStatus == PowerLineStatus.Online)
                {
                    if (change)
                    {
                        Process.Start("Battery.bat", current.ToString());
                        change = !change;
                    }
                    Battery_Status_label.Invoke(new Action<string>((s) => Battery_Status_label.Text = s), "Running on power");
                    Battery_lvl_lable.Invoke(new Action<string>((s) => Battery_lvl_lable.Text = s), "Бесконечность не предел");
                    Remainig_label.Invoke(new Action<string>((s) => Remainig_label.Text = s), "Бесконечность не предел");
                }
                else
                {   
                    
                    if (!change)
                    {
                        Process.Start("Battery.bat", value.Text);
                        change = !change;
                    }
                    Battery_Status_label.Invoke(new Action<string>((s) => Battery_Status_label.Text = s), "Running on batery");
                    double percent = Math.Round(powerStatus.BatteryLifePercent * 100);
                    Battery_lvl_lable.Invoke(new Action<string>((s) => Battery_lvl_lable.Text = s), percent.ToString()+'%');
                    double time = powerStatus.BatteryLifeRemaining/60;
                    Remainig_label.Invoke(new Action<string>((s) => Remainig_label.Text = s), time.ToString()+ " минут");

                }
            }
        }
        
        private void Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch)&&ch!=8)
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.Start("Battery.bat", current.ToString());
        }
    }
}
