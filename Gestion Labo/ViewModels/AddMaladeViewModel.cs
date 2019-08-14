using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.ViewModels
{
    public class AddMaladeViewModel : Screen
    {

        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set {
                _nom = value;
                NotifyOfPropertyChange(() => Nom);


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


            }
        }


        private DateTime _birthday;
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                NotifyOfPropertyChange(() => Birthday);


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

        }

        public bool CanRemoveAnalyse
        {
            get
            {

                bool output = false;

               
                return output;


            }

        }

        public void RemoveAnalyse()
        {


        }



        public void AddMalade()
        {

        }

    }
}
