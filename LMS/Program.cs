using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySqlX.XDevAPI;
using LMS.Utilities;
using LMS.View;

namespace LMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new View.FrmAdminDashboard());


            // Enable visual styles and set compatible text rendering
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load user session upon application start
            Session.LoadSession();

            if (Session.IsLoggedIn)
            {
                // If user is logged in, navigate to the dashboard
                var dashboard = new FrmAdminDashboard(Session.CurrentUser);
                Application.Run(dashboard);
            }
            else
            {
                // If no user is logged in, show the login form
                var loginForm = new FrmLogin();
                Application.Run(loginForm);
            }
        }
    }
}
