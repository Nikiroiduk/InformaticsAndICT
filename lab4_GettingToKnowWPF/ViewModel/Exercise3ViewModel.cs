using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab4_GettingToKnowWPF.ViewModel
{
    class Exercise3ViewModel : ViewModel
    {
        #region Liters
        private string _Liters = "";

        public string Liters
        {
            get => _Liters;
            set
            {
                Set(ref _Liters, value);
                setConsumption(Distance.Content.ToString());
            }
        }
        #endregion

        #region Kilometers
        private string _Kilometers = "";

        public string Kilometers
        {
            get => _Kilometers;
            set
            {
                Set(ref _Kilometers, value);
                setConsumption(Distance.Content.ToString());
            }
        }
        #endregion

        #region Distance
        private ComboBoxItem _Distance;

        public ComboBoxItem Distance
        {
            get => _Distance;
            set
            {
                Set(ref _Distance, value);
                setConsumption(Distance.Content.ToString());
            }
        }
        #endregion


        #region Consumption
        private string _Consumption = "";

        public string Consumption
        {
            get => _Consumption;
            set => Set(ref _Consumption, value);
        }
        #endregion

        #region Methods

        private void setConsumption(string dist)
        {
            try
            {
                var liters = Convert.ToDouble(Liters);
                var kilometers = Convert.ToDouble(Kilometers);
                switch (dist)
                {
                    case "1 km":
                        Consumption = Convert.ToString(liters / kilometers);
                        break;
                    case "5 km":
                        Consumption = Convert.ToString(liters / kilometers * 5);
                        break;
                    case "20 km":
                        Consumption = Convert.ToString(liters / kilometers * 20);
                        break;
                }
            }
            catch (Exception e)
            {
                Consumption = "Error!";
            }
        }

        #endregion

    }
}
