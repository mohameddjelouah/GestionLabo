using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.ViewModels
{
    public class ConfirmDialogViewModel : Screen
    {





        public void CloseDialog()
        {
            TryClose(false);
        }

        public void Cancel()
        {
            TryClose(false);
        }

        public void ok()
        {
            TryClose(true);
        }


    }
}
