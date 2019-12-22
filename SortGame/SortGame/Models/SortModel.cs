using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortGame.Models
{
    class SortModel
    {
        private ObservableCollection<int> SortableNumbers = new ObservableCollection<int>();
        private ObservableCollection<int> TmpNumbers = new ObservableCollection<int>();

        private Random rnd = new Random();

        // Максимальне число
        private int max = 5;

        public SortModel()
        {
            RegenerateMax();
            GenerateNumbers();
        }

        // Перегенерувати максимальне число
        private void RegenerateMax()
        {
            max = rnd.Next(3, 15);
        }

        // Згенерувати числа
        private void GenerateNumbers()
        {
            int tmpNumber = rnd.Next(1, max);

            for (int i = 0; i < max; i++)
            {
                while(!CheckUniqueNumber(tmpNumber))
                {
                     tmpNumber = rnd.Next(1, max + 1);
                }
             
                SortableNumbers.Add(tmpNumber);
            }
        }

        // Перевірити перемогу
        public bool CheckWin()
        {
            if (SortableNumbers.Count < max) return false;

            for(int i = 0; i < max; i++)
            {
                if (SortableNumbers.ElementAt(i) != i + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public void Restart()
        {
            SortableNumbers.Clear();
            TmpNumbers.Clear();
            RegenerateMax();
            GenerateNumbers();
        }

        // Перевірити існування числа в колекції
        private bool CheckUniqueNumber(int number)
        {
            foreach(int n in SortableNumbers)
            {
                if(n == number)
                {
                    return false;
                }
            }

            return true;
        }

        // Отримати список, що сортується
        public ObservableCollection<int> GetAllSortableNumbers()
        {
            return SortableNumbers;
        }

        // Отримати тимчасовий список
        public ObservableCollection<int> GetAllTmpNumbers()
        {
            return TmpNumbers;
        }

        // Перемістити число на тимчасове зберігання
        public bool MoveToTmp()
        {
            if(SortableNumbers.Count() < 1)
            {
                return false;
            }

            TmpNumbers.Insert(0, SortableNumbers.First());

            SortableNumbers.RemoveAt(0);

            return true;
        }

        // Перемістити число 
        public bool MoveToSortable()
        {
            if (TmpNumbers.Count() < 1)
            {
                return false;
            }

            SortableNumbers.Add(TmpNumbers.First());

            TmpNumbers.RemoveAt(0);

            return true;
        }

    }
}
