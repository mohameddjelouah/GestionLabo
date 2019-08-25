using Caliburn.Micro;
using Gestion_Labo.EventModels;
using Gestion_Labo.lib.DataAccess;
using Gestion_Labo.lib.DataAccess.Interfaces;
using Gestion_Labo.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<AddMaladeEvent>
    {
        private IMaladesData _maladesData;
        private IEventAggregator _events;

        private bool _resizeApp;

        public bool ResizeApp
        {
            get { return _resizeApp; }
            set
            {

                _resizeApp = value;
                NotifyOfPropertyChange(() => ResizeApp);

            }
        }
        public ShellViewModel(IMaladesData maladesdata, IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            _maladesData = maladesdata;
           
        }

        public void Malade()
        {
            //var output =  await _maladesData.GetAllMalades();
            ActivateItem(IoC.Get<MaladesViewModel>());
        }

        
        public void Handle(AddMaladeEvent message)
        {
            ActivateItem(IoC.Get<AddMaladeViewModel>());
        }



        public void ExitApplication()
        {
            TryClose();

        }

        public void MinApplication()
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        public void MaxResApplication()
        {
            if (ResizeApp == true)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            }

        }
        public void MinMax()
        {
            if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Normal)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
                ResizeApp = true;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
                ResizeApp = false;

            }
        }
    }

    



}
