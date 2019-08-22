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
        public ShellViewModel(IMaladesData maladesdata, IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            _maladesData = maladesdata;
           
        }

        public async void Malade()
        {
          var output =  await _maladesData.GetAllMalades();
            ActivateItem(IoC.Get<MaladesViewModel>());
        }

        
        public void Handle(AddMaladeEvent message)
        {
            ActivateItem(IoC.Get<AddMaladeViewModel>());
        }
    }

    



}
