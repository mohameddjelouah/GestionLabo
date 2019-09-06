using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Caliburn.Micro;
using Gestion_Labo.lib.DataAccess.Interfaces;
using Gestion_Labo.lib.Models;
using LiveCharts;
using LiveCharts.Wpf;

namespace Gestion_Labo.ViewModels
{
    public class DashBoardViewModel : Screen
    {
        private List<MaladesAnalyseModel> _listofMalades = new List<MaladesAnalyseModel>();

        public List<MaladesAnalyseModel> ListofMalades
        {
            get { return  _listofMalades; }
            set {

                _listofMalades = value;
                NotifyOfPropertyChange(() => ListofMalades);

            }
        }

        
        public List<MaladesStat> MaladesStat { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        private IMaladesData _maladesData;
        //public Func<double, string> YFormatter { get; set; } // use that to format nuber to month or currency or something else
        public DashBoardViewModel(IMaladesData maladesdata)
        {

            _maladesData = maladesdata;



            

            //YFormatter = value => value.ToString("C");

            //SeriesCollection.Add(new LineSeries
            //{
            //    Title = "Series 4",
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0, //0: straight lines, 1: really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = Brushes.Gray
            //});

            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);

            //DataContext = this;

        }


        protected override async void OnViewLoaded(object view)
        { // if loading incuident doesnt work we caatch an exception that stop progress bar and display a message with failure
            base.OnViewLoaded(view);
            await LoadMalades();

           // var stat = from malade in ListofMalades
                    //   where malade.malade.Birthday == DateTime.Now.Year



        }

        // string qu = "SELECT Year(date), Month(date), Count(*) FROM incident WHERE is_cloture = '1' and date >= CURDATE() - INTERVAL 1 YEAR GROUP BY Year(date), Month(date)";
        public async Task LoadMalades()
        {

            ListofMalades = await _maladesData.GetAllMalades();

            
            var now = DateTime.Now;
            now = now.Date.AddDays(1 - now.Day);
            var months = Enumerable.Range(-12, 13)
            .Select(x => new
            {
                year = now.AddMonths(x).Year,
                month = now.AddMonths(x).Month
            });
            //var grouped = from p in ListofMalades
            //              where p.malade.Birthday.Value >= DateTime.Now.AddYears(-1)
            //              group p by new { day = p.malade.Birthday.Value.Day, month = p.malade.Birthday.Value.Month, year = p.malade.Birthday.Value.Year } into d
            //              select new { dt = DateTime.Parse(string.Format("{0}/{1}/{2}", d.Key.day, d.Key.month, d.Key.year)), count = d.Count() };



            List<MaladesStat> grouped = (from p in ListofMalades
                          where p.malade.Birthday.Value >= DateTime.Now.AddYears(-1)
                          group p by new {  month = p.malade.Birthday.Value.Month, year = p.malade.Birthday.Value.Year } into d
                          select new MaladesStat { Month = d.Key.month,Year = d.Key.year  , Count = d.Count() }).ToList();

            var changesPerYearAndMonth =
               (months.GroupJoin(grouped,
               m => new { month = m.month, year = m.year },
               revision => new {
                   month = revision.Month,
                   year = revision.Year
               },
               (p, g) => new {
                   month = p.month,
                   year = p.year,
                   count = g.Sum(a => a.Count)
               })).ToList();


            List<int> count = changesPerYearAndMonth.Select(p => p.count).ToList();
            Labels = new List<string>();
            foreach (var item in changesPerYearAndMonth)
            {
                Labels.Add(string.Format("{0}/{1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.month), item.year) ) ;  
            }
            

            SeriesCollection = new SeriesCollection
            {

                new LineSeries
                {

                    Values = new ChartValues<int> (count)
                },


            };

           

          

            NotifyOfPropertyChange(() => SeriesCollection);
            NotifyOfPropertyChange(() => Labels);

        }
    }
}
