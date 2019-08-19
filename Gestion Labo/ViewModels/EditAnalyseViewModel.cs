using Caliburn.Micro;
using Gestion_Labo.lib.DataAccess.Interfaces;
using Gestion_Labo.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.ViewModels
{
    public class EditAnalyseViewModel : Screen
    {
        private IMaladesData _maladesData;
        private IWindowManager _window;
        public EditAnalyseViewModel(IMaladesData maladesdata, IWindowManager window)
        {
            _maladesData = maladesdata;
            _window = window;
        }
        private AnalyseModel _am;

        public AnalyseModel Am
        {
            get { return _am; }
            set {

                _am = value;
                NotifyOfPropertyChange(() => Am);


            }
        }


        private string _resultat;

        public string Resultat
        {
            get { return _resultat; }
            set
            {

                _resultat = value;
                NotifyOfPropertyChange(() => Resultat);
                NotifyOfPropertyChange(() => CanEditAnalyse);


            }
        }


        public bool CanEditAnalyse
        {
            get
            {

                bool output = false;

                if (Resultat?.Length > 0)
                {
                    output = true;
                }
                return output;


            }

        }

        public void EditAnalyse()
        {
            


            var Dialog = IoC.Get<ConfirmDialogViewModel>();
            var result = _window.ShowDialog(Dialog, null, null);


            if (result.HasValue && result.Value)
            {
                Am.Resultat = Resultat;

                _maladesData.EditAnalyse(Am);
            }
        }

    }
}
