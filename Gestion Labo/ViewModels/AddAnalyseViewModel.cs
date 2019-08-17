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
    

    public class AddAnalyseViewModel : Screen
    {
        
        private IMaladesData _maladesData;
        public AddAnalyseViewModel(IMaladesData maladesdata)
        {

            _maladesData = maladesdata;



        }

        private int _maladeId;

        public int MaladeId
        {
            get { return _maladeId; }
            set { _maladeId = value; }
        }

        private string _resultat;

        public string Resultat
        {
            get { return _resultat; }
            set {

                _resultat = value;

                NotifyOfPropertyChange(() => Resultat);
                NotifyOfPropertyChange(() => CanAddAnalyse);

            }
        }

        public bool CanAddAnalyse
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

        public async Task AddAnalyse()
        {
            List<AnalyseModel> am = new List<AnalyseModel>
            {
               new AnalyseModel { MaladeID = MaladeId, Resultat = Resultat }
            };

            await _maladesData.AddAnalyse(am);
        }


    }
}
