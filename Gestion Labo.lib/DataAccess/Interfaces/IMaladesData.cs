using System.Collections.Generic;
using System.Threading.Tasks;
using Gestion_Labo.lib.Models;

namespace Gestion_Labo.lib.DataAccess.Interfaces
{
    public interface IMaladesData
    {
        Task<List<MaladesAnalyseModel>> GetAllMalades();

        Task DeleteMaladeWithAnalyse(int id);
        Task DeleteAnalyse(int id,int Maladeid);

        Task AddMaladeWithAnalyse(MaladesAnalyseModel mam);

        Task AddAnalyse(List<AnalyseModel> am);

        Task<MaladesAnalyseModel> GetMaladeById(int id);
    }
}