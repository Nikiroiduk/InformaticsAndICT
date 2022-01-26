using System;
using System.Collections.Generic;

namespace lab4_GettingToKnowWPF.ViewModel
{
    class Exercise1ViewModel : ViewModel
    {
        private readonly Random random = new Random();


        #region Size
        private int _Size = 3;

        public int Size
        {
            get => _Size;
            set {
                Set(ref _Size, value);
                Output = getArray();
            }
        }
        #endregion

        #region Output
        private string _Output = "";

        public string Output
        {
            get => _Output;
            set => Set(ref _Output, value);
        }
        #endregion

        #region Methods
        public Exercise1ViewModel()
        {
            Output = getArray();
        }
        private string getArray()
        {
            string result = "";

            List<int> arr = new List<int>();
            for (int i = 0; i < Size * Size; i++)
            {
                arr.Add(random.Next(1, 10));
            }

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (i + j == Size - 1) arr[Index(i, j)] = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    result += $"{arr[Index(i, j)]}\t";
                }
                result += "\n";
            }

            return result;
        }

        private int Index(int i, int j)
        {
            return (i * Size) + j;
        }
        #endregion
    }
}
