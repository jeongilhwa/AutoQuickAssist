using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Security.Principal;


namespace AutoQuickAssist
{   
    public partial class Form1 : Form
    {        
        QuickAssistProsess QuickAssistProsess = new QuickAssistProsess();        
        int timerCount;
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadLoginTextFile();
            //if (!IsRunningAsAdministrator())
            //{
            //    ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);
            //    {
            //        var withBlock = processStartInfo;
            //        withBlock.UseShellExecute = true;
            //        withBlock.Verb = "runas";
            //        Process.Start(processStartInfo);
            //        Application.Exit();
            //    }
            //}
            //else
            //    this.Text += " " + "(Administrator)";
        }
        public bool IsRunningAsAdministrator()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void ReadLoginTextFile()
        {
            string mydoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (File.Exists(mydoc + @"\\QuickAutoLogin.txt"))
            {
                string lines = File.ReadAllText(mydoc + @"\\QuickAutoLogin.txt");
                QuickAssistIDTextBox.Text = lines;
                QuickAssistProsess.QuickAssistUserID = lines;
            }
        }
        private void WriteQuickAutoLoginTextFile()
        {
            StreamWriter writer;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            writer = File.CreateText(path + @"\QuickAutoLogin.txt");
            writer.WriteLine(QuickAssistIDTextBox.Text);            
            writer.Close();
            QuickAssistProsess.QuickAssistUserID = QuickAssistIDTextBox.Text;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timerCount >= 10)
            {
              
                OtherPorcessCheck();
                timerCount = 0;
            }
            else
            {
                timerCount = timerCount + 1;
            }
        }
        private void OtherPorcessCheck()
        {

            Process[] processList = Process.GetProcessesByName("quickassist");
            if (processList.Length < 1)
            {
                Clipboard.SetText(QuickAssistIDTextBox.Text);
                Thread thread = new Thread(() => QuickAssistProsess.StartQuickAssist(QuickAssistIDTextBox.Text));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();                
               
                timerCount = 0;
            }
        }

        private void AutoQuickAssistButton_Click(object sender, EventArgs e)
        {
            WriteQuickAutoLoginTextFile();
        }

        private void ButtonStrat_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(QuickAssistIDTextBox.Text);
            Thread thread = new Thread(() => QuickAssistProsess.StartQuickAssist(QuickAssistIDTextBox.Text));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            timer1.Interval = 1000;
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);            
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel != false) // 트레이 아이콘의 컨텍스트 메뉴를 통해 프로그램 종료가 선택된경우 true
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null && e.ClickedItem.ToString().Equals("종료"))
            {
                this.Close();
                this.Dispose();
                Properties.Settings.Default.Save();
                Application.Exit();
            }
            else if (e.ClickedItem != null && e.ClickedItem.ToString().Equals("활성화"))
            {
                this.Visible = true;
            }
        }

    }
}
