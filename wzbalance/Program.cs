using System;
using System.Collections.Generic;
using System.Windows.Forms;
using wzbalance.src.Forms;

namespace wzbalance
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            } catch (Exception ex) {
                MessageBox.Show("程序出现异常，确认是缺陷重复出现后请报告xjtudaniel@gmail.com," + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                LogWriter.LogEntry("error", ex.Message + ex.StackTrace);
                Environment.Exit(-1);
            }
        }
    }
}