using Caliburn.Micro;
using Gestion_Labo.lib.DataAccess.Interfaces;
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

    }
}
