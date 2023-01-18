using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egzaminKonsolowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sortowanie sortowanie = new Sortowanie();
            

            for (int i = 0; i < sortowanie.array.Length; i++)
            {
                Console.WriteLine("Podaj " + (i + 1) + " liczbę do tablicy");
                sortowanie.array[i] = Convert.ToInt32(Console.ReadLine());
            }

           sortowanie.przezWybieranie();

            Console.WriteLine(String.Join(", ", sortowanie.array));
            Console.ReadLine();
        }
    }

    class Sortowanie
    {
        public int[] array = new int[10];


        /***********************************************
         
         * nazwa funkcji:   przezWybieranie
         
         * parametry wejściowe: brak
         
         * wartość zwracana: array - posortowaną tablicę
         
         * autor: Woźniak
         
         **********************************************/
        public int[] przezWybieranie()
        {
            for (int i = 0; i < array.Length; i++)
            {
                int maxIndex = GetMaxIndex(i);
                (array[i], array[maxIndex]) = (array[maxIndex], array[i]);
            }

            return array;
        }

        /***********************************************
         
         * nazwa funkcji:   GetMaxIndex
         
         * parametry wejściowe: index - indeks od którego ma zacząć wyszukiwanie maksymalnej wartości
         
         * wartość zwracana: maxIndex - indeks wartości maksymalnej w tablicy
         
         * autor: Woźniak
         
         **********************************************/
        private int GetMaxIndex(int index)
        {
            int maxIndex = index;
            for (int i = index; i < array.Length; i++)
                if (array[i] > array[maxIndex])
                    maxIndex = i;

            return maxIndex;
        }
    }
}
