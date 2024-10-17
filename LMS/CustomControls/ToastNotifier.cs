using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.CustomControls
{
    public class ToastNotifier
    {

        public void Alert(string msg, customToast.enmType type)
        {
            customToast frm = new customToast();
            frm.showAlert(msg, type);
        }
    }
}
