using Caliburn.Micro;
using Gestion_Labo.lib.DataAccess.Interfaces;
using Gestion_Labo.lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.ViewModels
{
    public class AddMaladeViewModel : Screen
    {



        private IMaladesData _maladesData;
        public AddMaladeViewModel(IMaladesData maladesdata)
        {
            _maladesData = maladesdata;
        }


        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set {
                _nom = value;
                NotifyOfPropertyChange(() => Nom);
                NotifyOfPropertyChange(() => CanAddMalade);

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
                NotifyOfPropertyChange(() => CanAddMalade);

            }
        }
       

        private DateTime? _birthday = null ;
        public DateTime? Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                NotifyOfPropertyChange(() => Birthday);
                NotifyOfPropertyChange(() => CanAddMalade);

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
                NotifyOfPropertyChange(() => CanAddToAnalyse);


            }
        }

        private BindingList<AnalyseModel> _analyses = new BindingList<AnalyseModel>();
        public BindingList<AnalyseModel> Analyses
        {
            get { return _analyses; }
            set {

                _analyses = value;
                NotifyOfPropertyChange(() => Analyses);

            }
        }


        public bool CanAddToAnalyse
        {
            get {

                bool output = false;

                if (Resultat?.Length >0)
                {
                    output = true;
                }
                return output;


            }
            
        }

        public void AddToAnalyse()
        {

            AnalyseModel am = new AnalyseModel { Resultat = Resultat };

            Analyses.Add(am);

            Resultat = null;

        }

        private AnalyseModel _selectedAnalyse;

        public AnalyseModel SelectedAnalyse
        {
            get { return _selectedAnalyse; }

            set {
                _selectedAnalyse = value;
                NotifyOfPropertyChange(() => SelectedAnalyse);
                NotifyOfPropertyChange(() => CanRemoveAnalyse);

            }
        }


        public bool CanRemoveAnalyse
        {
            get
            {

                bool output = false;

                if (SelectedAnalyse != null)
                {
                    output = true;
                }
               
                return output;


            }

        }

        public void RemoveAnalyse()
        {
            Analyses.Remove(SelectedAnalyse);

        }

        public bool CanAddMalade
        {
            get
            {

                bool output = false;

                if (Nom?.Length>0 && Prenom?.Length>0 && Birthday != null)
                {
                    output = true;
                }

                return output;


            }

        }
        
        public async Task AddMalade()
        {
            MaladesAnalyseModel am = new MaladesAnalyseModel
            {
                malade = new MaladeModel { Nom = Nom, Prenom = Prenom, Birthday = (DateTime)Birthday },
                analyse = Analyses.ToList()
            };

            await _maladesData.AddMaladeWithAnalyse(am);
            ClearInputs();
        }

        public void ClearInputs()
        {
            Nom = null;
            Prenom = null;
            Resultat = null;
            Birthday = null;
            Analyses = new BindingList<AnalyseModel>();



        }

    }
}
