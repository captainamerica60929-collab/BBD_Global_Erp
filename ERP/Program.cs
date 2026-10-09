using System;
using System.Collections.Generic;

using System.Windows.Forms;
using MyData;
using CRM_App.Master;

namespace CRM_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FG_Master());
            Application.Run(new Log1());
            //Application.Run(new Login_otp());
            //Application.Run(new GenuineHR.Reports.RM_MATERIAL_RECONCILATION());
            //Application.Run(new CRM_App.Transaction.Work_Order.New_Work_Order());


        }
    }
}
