﻿using Caliburn.Micro;
using Gestion_Labo.Helpers;
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

        private bool _isChange = false;

        public bool isChange
        {
            get { return _isChange = false; }
            set { _isChange = value; }
        }


        protected override void OnViewLoaded(object view)
        { 
            
            
            // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);
            BindAnalyse = new BindableCollection<AnalyseModel>(Analyse.analyse);


        }

        


        public async Task DeleteAnalyse(AnalyseModel am)
        {


            var Dialog = IoC.Get<ConfirmDialogViewModel>();
            var result = _window.ShowDialog(Dialog, null, null);


            if (result.HasValue && result.Value)
            {
                await _maladesData.DeleteAnalyse(am.Id, am.MaladeID);

                Analyse.analyse.Remove(am);
                BindAnalyse.Remove(am);
                isChange = true;
            }
        }


        public void EditAnalyse(AnalyseModel am)
        {
            // its working
            var Dialog = IoC.Get<EditAnalyseViewModel>();
            Dialog.Am = am;
            Dialog.Resultat = am.Resultat; 
            _window.ShowDialog(Dialog, null, null);
            if (Dialog.isEdit)
             {
                Replace.ReplaceItem(Analyse.analyse, am, Dialog.Am);
                BindAnalyse.Refresh();
                isChange = true;
            }
            
        }

        public void AddAnalyse()
        {
            var Dialog = IoC.Get<AddAnalyseViewModel>();
            Dialog.MaladeId = Analyse.malade.Id;
            _window.ShowDialog(Dialog, null, null);

            if (Dialog.isAdd)
            {

                Analyse.analyse.AddRange(Dialog.am);
                
                BindAnalyse.AddRange(Dialog.am);
                isChange = true;
            }
         
        }


       


    }
}
