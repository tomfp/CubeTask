using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertClient.Model;
using SharedData;

namespace ConvertClient.Pages
{
    public partial class Index
    {
        TemperatureModel temperatureModel = new TemperatureModel();

        public async void GetResults()
        {
            var selecteUnits = temperatureModel.FromUnits;

            // TODO call service
            var placehoder = 0;

        }
    }
}
