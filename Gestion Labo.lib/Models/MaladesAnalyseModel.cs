using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.lib.Models
{
    public class MaladesAnalyseModel
    {

        public MaladeModel malade { get; set; }
        public List<AnalyseModel> analyse { get; set; }
    }
}
