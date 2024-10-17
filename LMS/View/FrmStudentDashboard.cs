using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS.Model;

namespace LMS.View
{
    public partial class FrmStudentDashboard : Form
    {
        private Users currentUser;
        public FrmStudentDashboard(Users user)
        {
            InitializeComponent();
            currentUser = user; // Store the logged-in user information
        }
    }
}
