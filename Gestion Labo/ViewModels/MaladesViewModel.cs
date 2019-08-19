using Caliburn.Micro;
using Gestion_Labo.EventModels;
using Gestion_Labo.lib.DataAccess.Interfaces;
using Gestion_Labo.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.ViewModels
{
    public class MaladesViewModel : Screen
    {



        public List<MaladesAnalyseModel> ListofMalades { get; set; }


        private BindableCollection<MaladesAnalyseModel> _bindMalades;
        public BindableCollection<MaladesAnalyseModel> BindMalades
        {
            get { return _bindMalades; }
            set
            {

                _bindMalades = value;

                NotifyOfPropertyChange(() => BindMalades);
            }
        }



        private string _search;
        public string search
        {
            get { return _search; }
            set
            {
                _search = value;

                var list = ListofMalades.Where(x => x.malade.Nom.Contains(value)).ToList();
                //NotifyOfPropertyChange(() => search);
                BindMalades = new BindableCollection<MaladesAnalyseModel>(list);

            }
        }


        private IMaladesData _maladesData;
        private IWindowManager _window;
        private IEventAggregator _events;
        public MaladesViewModel(IMaladesData maladesdata, IWindowManager window, IEventAggregator events)
        {
            _maladesData = maladesdata;
            _window = window;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);
            await LoadMalades();
           

        }

        public async Task LoadMalades()
        {
            ListofMalades = await _maladesData.GetAllMalades();
            BindMalades = new BindableCollection<MaladesAnalyseModel>(ListofMalades);
        }



        public async Task LoadAnalyse(MaladesAnalyseModel MAM)
        {


            var Dialog = IoC.Get<AnalyseViewModel>();
            Dialog.Analyse = MAM;
            //u.BindAnalyse = new BindableCollection<AnalyseModel>(MAM.analyse);
            //var result = _window.ShowDialog(u, null, null);
            _window.ShowDialog(Dialog, null, null);

            //verify if something is change before loadmalades again
            await LoadMalades();
            //if (result.HasValue && result.Value)
            //{


            //}
        }


        public async Task DeleteMalade(MaladesAnalyseModel MAM)
        {

            var Dialog = IoC.Get<ConfirmDialogViewModel>();
            var result = _window.ShowDialog(Dialog, null, null);


            if (result.HasValue && result.Value)
            {
                await _maladesData.DeleteMaladeWithAnalyse(MAM.malade.Id);
                ListofMalades.Remove(MAM);
                BindMalades.Remove(MAM);
            }


           

        }


        public async Task EditMalade(MaladesAnalyseModel MAM)
        {
            var Dialog = IoC.Get<EditMaladeViewModel>();
            Dialog.Malade = MAM;
            Dialog.Nom = MAM.malade.Nom;
            Dialog.Prenom = MAM.malade.Prenom;
            Dialog.Birthday = MAM.malade.Birthday;

            //u.BindAnalyse = new BindableCollection<AnalyseModel>(MAM.analyse);
            //var result = _window.ShowDialog(u, null, null);
            _window.ShowDialog(Dialog, null, null);

            //verify if something is change before loadmalades again
            await LoadMalades();
            //if (result.HasValue && result.Value)
            //{


            //}
        }

        public void AddMalade()
        {
            _events.PublishOnUIThread(new AddMaladeEvent());
          
        }

    }
}
