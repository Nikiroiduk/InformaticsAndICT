using System;

namespace lab4_GettingToKnowWPF.ViewModel
{
    class Exercise4ViewModel : ViewModel
    {
        #region X
        private string _X = "";

        public string X
        {
            get => _X;
            set
            {
                Set(ref _X, value);
                Calculate();
            }
        }
        #endregion

        #region n
        private string _n = "";

        public string n
        {
            get => _n;
            set
            {
                Set(ref _n, value);
                Calculate();
            }
        }
        #endregion

        #region Result
        private string _Result = "";

        public string Result
        {
            get => _Result;
            set => Set(ref _Result, value);
        }
        #endregion

        #region Methods
        private void Calculate()
        {
            try
            {
                var valX = Convert.ToDouble(X);
                var valn = Convert.ToInt32(n);
                double res = 0;
                for (int i = 0; i < valn; i++)
                {
                    res += Math.Cos(i / 4) / (2 * i - 1) * Math.Pow(valX, 4);
                }
                Result = Convert.ToString(res);
            }
            catch(Exception e)
            {
                Result = "Error!";
            }
        }
        #endregion
    }
}
