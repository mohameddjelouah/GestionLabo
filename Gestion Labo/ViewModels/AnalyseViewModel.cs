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
    public class AnalyseViewModel : Screen
    {
        private IMaladesData _maladesData;
        private IWindowManager _window;
        public AnalyseViewModel(IMaladesData maladesdata, IWindowManager window)
        {
            _maladesData = maladesdata;
            _window = window;
        }

        private MaladesAnalyseModel _analyse;

        public MaladesAnalyseModel Analyse
        {
            get { return _analyse; }
            set {
                _analyse = value;

                NotifyOfPropertyChange(() => Analyse);


            }
        }


        private BindableCollection<AnalyseModel> _bindAnalyse;

        public BindableCollection<AnalyseModel> BindAnalyse
        {
            get { return _bindAnalyse; }
            set
            {

                _bindAnalyse = value;

                NotifyOfPropertyChange(() => BindAnalyse);
            }
        }

        protected override void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);
            BindAnalyse = new BindableCollection<AnalyseModel>(Analyse.analyse);


        }

        


        public async Task DeleteAnalyse(AnalyseModel am)
        {

            await _maladesData.DeleteAnalyse(am.Id,am.MaladeID);

            Analyse.analyse.Remove(am);
            BindAnalyse.Remove(am);
            
        }

        public void AddAnalyse()
        {
            var Dialog = IoC.Get<AddAnalyseViewModel>();
            Dialog.MaladeId = Analyse.malade.Id;
            //u.BindAnalyse = new BindableCollection<AnalyseModel>(MAM.analyse);
            //var result = _window.ShowDialog(u, null, null);
            _window.ShowDialog(Dialog, null, null);
            
            //if (result.HasValue && result.Value)
            //{


            //}
        }




    }
}
