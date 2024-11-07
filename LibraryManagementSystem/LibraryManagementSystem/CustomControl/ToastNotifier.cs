using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.CustomControl
{
    public class ToastNotifier
    {

        public void Alert(string msg, frmAlert.enmType type)
        {
            frmAlert frm = new frmAlert();
            frm.showAlert(msg, type);
        }
    }
}
