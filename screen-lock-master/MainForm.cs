/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2019/7/3
 * Time: 9:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Diagnostics;
using System.Net;
using System.IO;

using System.Runtime.InteropServices;
using System;

using Microsoft.Win32;

using System.Security.AccessControl;
using System.Threading;
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;


namespace LockScreen
{
	 
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        private System.Windows.Forms.NotifyIcon notifyIcon1;
	
		[DllImport("user32.dll")]
		static extern void BlockInput(bool Block);
		static Hook hook = new Hook();
		static byte[] byData = new byte[1024*1024];
		public static Boolean locked = false;
        public static int flag = 0;


			
		public MainForm()
		{
			InitializeComponent();
			ProtectProcess.Protect();
			HightLevel.protectProcess();
            //			Unkillable.MakeProcessUnkillable();
            this.DepLabel.Hide();
            this.DepTextBox.Hide();

            this.UserNoBox.Hide();
            this.UserNoLabel.Hide();

            this.UserBox.Hide();
            this.Userlabel.Hide();

            this.Userlabel.Hide();
            this.UserBox.Hide();
            

            //指定使用的容器
           
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            //建立NotifyIcon
            this.notifyIcon1.Icon = new Icon("D:\\Q32.ico");
            this.notifyIcon1.Text = "NotifyIcon Example";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
        }       


        void MainFormLoad(object sender, EventArgs e)
		{
            
			safeFile(System.Windows.Forms.Application.ExecutablePath);

            FullScreen();
            //Application.Exit();
            lookScreenNow();
            
        }
	
		void FullScreen() {
			
		}
        protected void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            lookScreenNow();
        }


        void lookScreenNow() {
			if(!locked) {
				this.WindowState = FormWindowState.Maximized;
				locked = true;
				hook.Hook_Start();
				ManageTaskManager(false);
				this.Visible = false;
				this.Activate();
				timer_windowTop.Enabled = false;
			}
			
		}
		
		void unLookScreenNow() {
			if(locked) {
				locked = false;
				//hook.Hook_Clear();
				//hook.Hook_Clear();

                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                this.notifyIcon1.Visible = true;
                //恢复程序限制
               // Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
                //解除任务管理器限制
                ManageTaskManager(true);
                //this.Visible = true;
            }
		}
		void Button_loginClick(object sender, EventArgs e)
		{
 			if (UserBox.Text.Trim().Equals("123"))
            {
 				unLookScreenNow();

                //MessageBox.Show("解锁成功！", "提示");
                //MessageBox.Show("解锁成功！", "提示");
                //return;
            }
		}
		
		//100ms 定时任务
		void Timer_windowTopTick(object sender, EventArgs e)
		{
			//check();
			if(locked) {
				this.Activate();
				this.TopMost = false;
	            this.BringToFront();
	            this.TopMost = true;
	           // this.killProcess();
				disableKeyBoard();
			} 
		}
		
		//锁屏期间禁止键盘操作
		void disableKeyBoard() {
			
		}
		
		void safeFile(string fileFullName) {
			FileSecurity fs1 = System.IO.File.GetAccessControl(fileFullName);
		    fs1.SetAccessRuleProtection(true, false);
		    System.IO.File.SetAccessControl(fileFullName, fs1);
		}

		public static bool ManageTaskManager(bool isOpen)
        {
            try
            {
                RegistryKey currentUser = Registry.CurrentUser;
                RegistryKey system = currentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);
                //如果system项不存在就创建这个项
                if (system == null)
                {
                    system = currentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                }
                system.SetValue("DisableTaskmgr", isOpen ? 0 : 1, RegistryValueKind.DWord);
                currentUser.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
		void Button_lockClick(object sender, EventArgs e)
		{
            //lookScreenNow();     


            if (flag == 0)
            {
                this.Projectlabel.Show();
                //this.Projectlabel.Enabled = false;
                this.ProjectTextBox.Enabled = false;
                this.Userlabel.Show();
                this.Userlabel.Show();
                this.DepLabel.Show();
                this.DepTextBox.Show();
                this.UserNoLabel.Show();
                this.UserBox.Show();
                this.UserNoBox.Show();
                this.UserNoBox.Focus();
                this.Status.Text = "please Use Your Security Card....5s";

                flag = 1;

            }
            else if (flag == 1)
            {
                string strPath2 = "D:\\SG64 Utilization Rate.xlsx";
                Excel.Application Excel_App2 = new Excel.Application();
                Excel.Workbook Excel_WB2 = Excel_App2.Workbooks.Open(strPath2);
                System.IO.FileInfo xlsAttribute2 = new FileInfo(strPath2);
                xlsAttribute2.Attributes = FileAttributes.Normal;

                //Excel.Worksheet Excel_WS1 = new Excel.Worksheet();
                Excel.Worksheet Excel_WS2 = (Excel.Worksheet)Excel_WB2.Worksheets["RCARD"];
                Excel_WB2.Activate();
                Excel_WS2.Activate();
                Microsoft.Office.Interop.Excel.Range rangeTemp = (Microsoft.Office.Interop.Excel.Range)Excel_WS2.Cells[1, 1];
                string temp = rangeTemp.Value.ToString();
                int hours = Int32.Parse(DateTime.Now.ToString("HH"));
                int minutes = Int32.Parse(DateTime.Now.ToString("mm"));
                int daynight = 0;
                string s = "";
                if (DateTime.Now.ToString("tt") == "上午")
                {
                    s = "AM";
                }
                else if (DateTime.Now.ToString("tt") == "下午")
                {
                    s = "PM";
                }

                if (hours > 7 && hours < 18)
                {
                    if (hours == 8)
                    {
                        if (minutes < 30)
                        {
                            daynight = 1;
                        }
                        else
                        {
                            daynight = 2;
                        }
                    }
                    else
                    {
                        daynight = 1;
                    }

                }
                else
                {
                    daynight = 2;
                }
                s = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " + s;
                //Excel_App2.Cells[rangeTemp, 1] = cellValue2;
                //Excel_App2.Cells[rangeTemp, 2] = cellValue3;
                //Excel_App2.Cells[rangeTemp, 3] = this.ProjectTextBox.Text;
                //Excel_App2.Cells[rangeTemp, 4] = cellvalue4;
                Excel_App2.Cells[rangeTemp, 5] = daynight;
                //Excel_App2.Cells[rangeTemp, 6] = s;
                Excel_App2.Cells[rangeTemp, 7] = s;
                Excel_App2.Cells[1, 1] = Int32.Parse(rangeTemp.Value.ToString()) + 1;
                Excel_WS2.Application.DisplayAlerts = false;
                Excel_WS2.Application.AlertBeforeOverwriting = false;
                Excel_WB2.Save();
                Excel_WB2.Close(false, Type.Missing, Type.Missing);
                ///Excel_WB3.Close(false, Type.Missing, Type.Missing);
                // Excel_WB1.Close();

                Excel_App2.Quit();
                ///Excel_App3.Quit();
                //   System.Runtime.InteropServices.Marshal.ReleaseComObject(myRrange);
                // System.Runtime.InteropServices.Marshal.ReleaseComObject(ranfe);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_WS2);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_WB2);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_App2);
                Excel_WS2 = null;
                Excel_WB2 = null;

                CPublicMethod.Kill(Excel_App2);
                /// CPublicMethod.Kill(Excel_App3);
                GC.Collect();
                this.Userlabel.Hide();
                this.Userlabel.Hide();
                this.DepLabel.Hide();
                this.DepTextBox.Hide();
                this.UserNoLabel.Hide();
                this.UserBox.Hide();
                this.UserNoBox.Hide();
                this.ProjectTextBox.Enabled = Enabled;
                this.DepTextBox.Enabled = Enabled;
                this.Userlabel.Enabled = Enabled;
                this.UserBox.Enabled = Enabled;
                this.UserNoBox.Text = "";
                this.DepTextBox.Text = "";
                this.UserBox.Text = "";
                flag = 0;
            }
            else
                return;
               

                



            
            //MessageBox.Show("123");
            //this.DepLabel.Enabled = false;
            //this.DepLabel.Hide();
            //this.Userlabel.Hide();
            //this.DepTextBox.Hide();
            //this.UserBox.Hide();
            //this.UserNoBox.Show();
            //this.TempBox.Hide();
            //this.TempBox.Enabled = false;
            //this.UserNoBox.Focus();
            //this.UserNoBox.Select();
            //Thread.Sleep(3000);
            
           /* this.TempBox.Select(TempBox.SelectionStart, 0);
            TempBox.ScrollToCaret();
            if (this.TempBox.Text == "0107110550\n")
                MessageBox.Show("123");*/

        }
		void Button1Click(object sender, EventArgs e)
		{
			MessageBox.Show(Device.getDeviceId());
		}
    
        

  

        private void testbutton_Click(object sender, EventArgs e)
        {
            this.DepTextBox.Show();
            this.DepTextBox.Text = "123";
            //this.DepLabel.Show();
            if (DepTextBox.Text.Trim().Equals("123"))
            {
                unLookScreenNow();
                //MessageBox.Show("解锁成功！", "提示");
                //MessageBox.Show("解锁成功！", "提示");
                //return;
            }
        }
        static int t = 1;
        private void TempBox_TextChanged(object sender, EventArgs e)
        {

            if (this.UserNoBox.Text.Length < 9)
            {
                return;
            }
            else if (UserNoBox.Text.Length == 10)
            {
                string strPath = "D:\\Card License.xlsx";
                Excel.Application Excel_App1 = new Excel.Application();
                Excel.Workbook Excel_WB1 = Excel_App1.Workbooks.Open(strPath);
                System.IO.FileInfo xlsAttribute = new FileInfo(strPath);
                xlsAttribute.Attributes = FileAttributes.Normal;
                //Excel.Worksheet Excel_WS1 = new Excel.Worksheet();
                Excel.Worksheet Excel_WS1 = (Excel.Worksheet)Excel_WB1.Worksheets["使用名單與權限"];
                Excel_WB1.Activate();
                Excel_WS1.Activate();

                for (int i = 1; i < 200; i++)
                {
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)Excel_WS1.Cells[i, 1];

                    try
                    {
                        string cellValue = range.Value.ToString();
                        if (cellValue == this.UserNoBox.Text)
                        {
                            Microsoft.Office.Interop.Excel.Range range2 = (Microsoft.Office.Interop.Excel.Range)Excel_WS1.Cells[i, 2];
                            Microsoft.Office.Interop.Excel.Range range3 = (Microsoft.Office.Interop.Excel.Range)Excel_WS1.Cells[i, 3];
                            Microsoft.Office.Interop.Excel.Range range4 = (Microsoft.Office.Interop.Excel.Range)Excel_WS1.Cells[i, 4];
                            string cellValue2 = range2.Value.ToString();
                            //Console.WriteLine(cellValue2);
                            this.DepTextBox.Text = cellValue2;
                            string cellValue3 = range3.Value.ToString();
                            this.UserBox.Text = cellValue3;
                            this.UserNoBox.Hide();
                            this.UserNoLabel.Hide();
                            //this.Userlabel.Hide();
                            string cellvalue4 = range4.Value.ToString();
                            //Console.WriteLine(cellValue3);
                            // Console.Read();
                            string strPath2 = "D:\\SG64 Utilization Rate.xlsx";
                            Excel.Application Excel_App2 = new Excel.Application();
                            Excel.Workbook Excel_WB2 = Excel_App2.Workbooks.Open(strPath2);
                            System.IO.FileInfo xlsAttribute2 = new FileInfo(strPath2);
                            xlsAttribute2.Attributes = FileAttributes.Normal;

                            //Excel.Worksheet Excel_WS1 = new Excel.Worksheet();
                            Excel.Worksheet Excel_WS2 = (Excel.Worksheet)Excel_WB2.Worksheets["RCARD"];
                            Excel_WB2.Activate();
                            Excel_WS2.Activate();
                            Microsoft.Office.Interop.Excel.Range rangeTemp = (Microsoft.Office.Interop.Excel.Range)Excel_WS2.Cells[1, 1];
                            string temp = rangeTemp.Value.ToString();
                            int hours = Int32.Parse(DateTime.Now.ToString("HH"));
                            int minutes = Int32.Parse(DateTime.Now.ToString("mm"));
                            int daynight = 0;
                            string s = "";
                            if (DateTime.Now.ToString("tt") == "上午")
                            {
                                s = "AM";
                            }
                            else if (DateTime.Now.ToString("tt") == "下午")
                            {
                                s = "PM";
                            }

                            if (hours > 7 && hours < 18)
                            {
                                if (hours == 8)
                                {
                                    if (minutes < 30)
                                    {
                                        daynight = 1;
                                    }
                                    else
                                    {
                                        daynight = 2;
                                    }
                                }
                                else
                                {
                                    daynight = 1;
                                }

                            }
                            else
                            {
                                daynight = 2;
                            }
                            s = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " " + s;
                            Excel_App2.Cells[rangeTemp, 1] = cellValue2;
                            Excel_App2.Cells[rangeTemp, 2] = cellValue3;
                            Excel_App2.Cells[rangeTemp, 3] = this.ProjectTextBox.Text;
                            Excel_App2.Cells[rangeTemp, 4] = cellvalue4;
                            //Excel_App2.Cells[rangeTemp, 5] = daynight;
                            Excel_App2.Cells[rangeTemp, 6] = s;
                            // Excel_App2.Cells[rangeTemp, 7] = "";
                           // Excel_App2.Cells[1, 1] = Int32.Parse(rangeTemp.Value.ToString()) + 1;
                            Excel_WS2.Application.DisplayAlerts = false;
                            Excel_WS2.Application.AlertBeforeOverwriting = false;
                            Excel_WB2.Save();
                            Excel_WB2.Close(false, Type.Missing, Type.Missing);
                            ///Excel_WB3.Close(false, Type.Missing, Type.Missing);
                            // Excel_WB1.Close();

                            Excel_App2.Quit();
                            ///Excel_App3.Quit();
                            //   System.Runtime.InteropServices.Marshal.ReleaseComObject(myRrange);
                            // System.Runtime.InteropServices.Marshal.ReleaseComObject(ranfe);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_WS1);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_WB1);
                            //System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_App2);
                            Excel_WS2 = null;
                            Excel_WB2 = null;

                            CPublicMethod.Kill(Excel_App2);
                            /// CPublicMethod.Kill(Excel_App3);
                            GC.Collect();
                            //this.Userlabel.Enabled = false;
                            //this.DepTextBox.Enabled = false;


                            break;
                        }
                    }
                    catch (System.NullReferenceException ex)
                    {
                        //Console.WriteLine("NULL Cell");
                        //Console.Read();
                    }
                }



                // Excel_WB1.Close(false, Type.Missing, Type.Missing);
                ///Excel_WB3.Close(false, Type.Missing, Type.Missing);
                // Excel_WB1.Close();
                Excel_App1.Quit();
                ///Excel_App3.Quit();
                //   System.Runtime.InteropServices.Marshal.ReleaseComObject(myRrange);
                // System.Runtime.InteropServices.Marshal.ReleaseComObject(ranfe);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_WS1);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_WB1);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel_App2);
                Excel_WS1 = null;
                Excel_WB1 = null;

                CPublicMethod.Kill(Excel_App1);
                /// CPublicMethod.Kill(Excel_App3);
                GC.Collect();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DepTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void ProjectTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public class CPublicMethod
        {
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
            public static void Kill(Excel.Application excel)
            {
                IntPtr t = new IntPtr(excel.Hwnd);   //得到这个句柄，具体作用是得到这块内存入口

                int k = 0;
                GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用
                p.Kill();     //关闭进程k
            }
        }
    }
}
