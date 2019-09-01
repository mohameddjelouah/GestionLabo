using System;
using System.Collections.Generic;
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
        public string[] Labels { get; set; }
        private IMaladesData _maladesData;
        //public Func<double, string> YFormatter { get; set; } // use that to format nuber to month or currency or something else
        public DashBoardViewModel(IMaladesData maladesdata)
        {

            _maladesData = maladesdata;

            

            SeriesCollection = new SeriesCollection
            {
                
                new LineSeries
                {
                   
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                 
                
            };


            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
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


        }
    }
}
