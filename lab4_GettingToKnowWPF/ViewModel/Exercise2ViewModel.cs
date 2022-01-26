using System;

namespace lab4_GettingToKnowWPF.ViewModel
{
    class Exercise2ViewModel : ViewModel
    {
        #region Liters
        private string _Liters = "";

        public string Liters
        {
            get => _Liters;
            set
            {
                Set(ref _Liters, value);
                setConsumption();
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
                setConsumption();
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

        private void setConsumption()
        {
            try
            {
                var liters = Convert.ToDouble(Liters);
                var kilometers = Convert.ToDouble(Kilometers);
                Consumption = Convert.ToString(liters / (kilometers * 100));
            }
            catch (Exception e)
            {
                Consumption = "Error!";
            }
        }

        #endregion

    }
}
