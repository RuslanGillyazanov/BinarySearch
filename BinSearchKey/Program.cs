using System;

namespace BinSearchKey
{
    class Program
    {
        /// <summary>
        /// Быстрая сортировка массива по возрастанию.
        /// </summary>
        /// <param name="a">Исходный массив</param>
        /// <param name="left">Начальный элемент отрезка</param>
        /// <param name="right">Конечный элемент отрезка</param>
        static void quickSort(int[] a, int left, int right)
        {
            int temp;
            int x = a[left + (right - left) / 2];
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }

            if (i < right)
                quickSort(a, i, right);

            if (left < j)
                quickSort(a, left, j);
        }

        /// <summary>
        /// Поиск элемента массива с указанным ключом
        /// </summary>
        /// <param name="a">Массив</param>
        /// <param name="left">Левая граница</param>
        /// <param name="right">Правая граница</param>
        /// <param name="key">Ключ</param>
        /// <returns>Возвращает номер элемента с указанным ключом</returns>
        static int BinSearchKey(int[] a, int left, int right, int key)
        {
            int pr = (key - a[left]) * (key - a[right]);

            while (pr < 0)
            {
                int middle = left + (right - left) / 2;

                if (a[middle] == key) return middle;

                if (a[middle] > key)
                    right = middle - 1;
                else
                    left = middle + 1;

                pr = (key - a[left]) * (key - a[right]);
            }

            if (pr > 0)
                return -1;

            if (key == a[left])
                return left;

            return right;
        }

        static void Main(string[] args)
        {
            int[] A = new int[10]; // Исходный массив
            int key = 10; // Ключ
            int result = -1; // Результат

            Random Rand = new Random();

            // Вывод исходного массива
            Console.WriteLine("Исходный массив: ");
            for(int i = 0; i < A.Length; i++)
            {
                A[i] = Rand.Next(1, 21);
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            // Сортируем массив
            quickSort(A, 0, A.Length - 1);

            // Вывод отсортированного массива
            Console.WriteLine("Отсортированный массив: ");
            for(int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();

            // Записываем результат выполнения бин. поиска
            result = BinSearchKey(A, 0, A.Length - 1, key);

            // Вывод результата
            Console.WriteLine("Ключ: {0}\nРезультат: {1}", key, result);

            Console.ReadKey();
        }
    }
}