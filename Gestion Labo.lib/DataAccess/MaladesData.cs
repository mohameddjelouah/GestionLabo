using Gestion_Labo.lib.DataAccess.Interfaces;
using Gestion_Labo.lib.Internal.DataAccess;
using Gestion_Labo.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Labo.lib.DataAccess
{
    public class MaladesData : IMaladesData
    {


        public async Task<List<MaladesAnalyseModel>> GetAllMalades()
        {
            SqlDataAccess sql = new SqlDataAccess();
            List<MaladesAnalyseModel> malades = new List<MaladesAnalyseModel>();

            List<MaladeModel> maladeModel = await sql.LoadData<MaladeModel, dynamic>("dbo.spGetAllMalades", new { }, "GestionLaboDB");

            foreach (var malade in maladeModel)
            {
                var obj = new { Id = malade.Id };
                List<AnalyseModel> analyseModel = await sql.LoadData<AnalyseModel, dynamic>("dbo.spGetAllAnalyse", obj, "GestionLaboDB");
                MaladesAnalyseModel MA = new MaladesAnalyseModel() { malade = malade, analyse = analyseModel };
                malades.Add(MA);

            }
            return malades;


        }

        public async Task<MaladesAnalyseModel> GetMaladeById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
           

           MaladeModel maladeModel = (await sql.LoadData<MaladeModel, dynamic>("dbo.spGetMalade", new { }, "GestionLaboDB")).FirstOrDefault();

           
                var obj = new { Id = maladeModel.Id };
                List<AnalyseModel> analyseModel = await sql.LoadData<AnalyseModel, dynamic>("dbo.spGetAnalyse", obj, "GestionLaboDB");
                MaladesAnalyseModel MA = new MaladesAnalyseModel() { malade = maladeModel, analyse = analyseModel };
                

            return MA;
        }


        public async Task DeleteMaladeWithAnalyse(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var obj = new { Id = id };
            await sql.DeleteData("dbo.spDeleteMalade", obj, "GestionLaboDB");
           // await sql.DeleteData("dbo.spDeleteAnalyse", obj, "GestionLaboDB");

        }



        public async Task DeleteAnalyse(int id, int MaladID)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var obj = new { Id = id , MaladeID = MaladID };
            await sql.DeleteData("dbo.spDeleteAnalyse", obj, "GestionLaboDB");
            // await sql.DeleteData("dbo.spDeleteAnalyse", obj, "GestionLaboDB");

        }

        //add malade with analyse for the first time
        public async Task AddMaladeWithAnalyse(MaladesAnalyseModel mam)
        {
            SqlDataAccess sql = new SqlDataAccess();

             var MaladeID = await sql.SaveDataAndReturnID<int,dynamic>("dbo.spAddMalade", mam.malade, "GestionLaboDB");
            

            // make a test to see if analyse is not null
           
            foreach (var item in mam.analyse)
            {
                item.MaladeID = MaladeID;
                
            }

            await AddAnalyse( mam.analyse);

        }

        //add analyse to an existing user
        public async Task AddAnalyse(List<AnalyseModel> am)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.SaveData("dbo.spAddAnalyse", am, "GestionLaboDB");
        }


        public async Task EditMalade(MaladeModel mm)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.UpdateData("dbo.spEditMalade", mm, "GestionLaboDB");
        }

        public async Task EditAnalyse(AnalyseModel am)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.UpdateData("dbo.spEditAnalyse", am, "GestionLaboDB");
        }
    }
}
