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
    public class EditMaladeViewModel : Screen
    {

        private IMaladesData _maladesData;
        private IWindowManager _window;
        public EditMaladeViewModel(IMaladesData maladesdata, IWindowManager window)
        {
            _maladesData = maladesdata;
            _window = window;
        }


        private MaladesAnalyseModel _malade;

        public MaladesAnalyseModel Malade
        {
            get { return _malade; }
            set
            {
                _malade = value;

                NotifyOfPropertyChange(() => Malade);


            }
        }

        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set {

                _nom = value;
                NotifyOfPropertyChange(() => Nom);
                NotifyOfPropertyChange(() => CanEditMalade);

            }
        }

        private string _prenom;

        public string Prenom
        {
            get { return _prenom; }
            set
            {

                _prenom = value;
                NotifyOfPropertyChange(() => Prenom);
                NotifyOfPropertyChange(() => CanEditMalade);

            }
        }


        private DateTime? _birthday = null;
        public DateTime? Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                NotifyOfPropertyChange(() => Birthday);
                NotifyOfPropertyChange(() => CanEditMalade);

            }
        }

        public bool CanEditMalade {

            get
            {

                bool output = false;

                if (Nom?.Length > 0 && Prenom?.Length > 0 && Birthday != null)
                {
                    output = true;
                }

                return output;


            }


        }

        public async Task EditMalade()
        {
            
            var Dialog = IoC.Get<ConfirmDialogViewModel>();
            var result = _window.ShowDialog(Dialog, null, null);


            if (result.HasValue && result.Value)
            {
                Malade.malade.Nom = Nom;
                Malade.malade.Prenom = Prenom;
                Malade.malade.Birthday = Birthday;

                await _maladesData.EditMalade(Malade.malade);
            }

        }
    }
}
