using System;

namespace ISMDotNet3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int arraySize = 0;
            bool flag = false;

            Console.Write("Введіть розмірність масиву: ");
            do {
                if (int.TryParse(Console.ReadLine(), out arraySize))
                {
                    flag = true;
                }
                else {
                    Console.Write("Некоректно введена розмірність масиву! Введіть ще раз: ");
                    flag = false;
                }
            } while (!flag);

            double[] arr = new double[arraySize];

            Console.WriteLine("Заповність масив числами: ");
            for (int i=0; i<arr.Length; i++) {
                Console.Write($"arr[{i}]= ");
                do
                {
                    if (double.TryParse(Console.ReadLine(), out arr[i]))
                    {
                        flag = true;
                    }
                    else
                    {
                        Console.Write("Некоректно введено число! Введіть ще раз: ");
                        flag = false;
                    }
                } while (!flag);
            }

            Console.WriteLine("");

            Console.WriteLine("Cума від’ємних елементів масиву= " + SumOfNegativeArrayElements(arr));
            Console.WriteLine("Максимальний елемент масиву= " + MaxArrayElement(arr));
            Console.WriteLine("Номер (індекс) максимального елемента масиву= " + IndexOfMaxArrayElement(arr));
            Console.WriteLine("Максимальний за модулем елемент масиву= " + MaxModuleArrayElement(arr));
            Console.WriteLine("Сума індексів додатних елементів= " + IndexesSumOfPositiveArrayElements(arr));
            Console.WriteLine("Кількість цілих чисел у масиві= " + QuantityOfIntegerArrayElements(arr));
            Console.WriteLine("Відсортований масив за спаданням:");
            SortArrayByDecreasing(arr);
            Console.WriteLine("Масив після видалення від’ємних елементів:");
            DeleteNegativeArrayElements(arr);

            Console.WriteLine("");
            Console.ReadKey();
        }

        static double SumOfNegativeArrayElements(double[] arr) {
            double sum = 0;
            foreach (double el in arr) {
                if (el < 0) {
                    sum += el;
                }
            }
            return sum;
        }

        static double MaxArrayElement(double []arr) {
            double maxElement = Double.MinValue;
            foreach (double el in arr) {
                if (el > maxElement) {
                    maxElement = el;
                }
            }
            return maxElement;
        }

        static int IndexOfMaxArrayElement(double[] arr) {
            int maxElementIndex = 0;
            double maxElement = Double.MinValue;
            for (int i=0; i<arr.Length; i++) {
                if (arr[i] > maxElement)
                {
                    maxElement = arr[i];
                    maxElementIndex = i;

                }
            }
            return maxElementIndex;
        }

        static double MaxModuleArrayElement(double[] arr) {
            double maxModuleElement = 0;
            foreach (double el in arr) {
                if (Math.Abs(el) > maxModuleElement) {
                    maxModuleElement = Math.Abs(el);
                }
            }
            return maxModuleElement;
        }

        static int IndexesSumOfPositiveArrayElements(double[] arr) {
            int sumOfPositiveElements = 0;
            for (int i=0; i<arr.Length;i++) {
                if (arr[i] > 0) {
                    sumOfPositiveElements += i; 
                }
            }
            return sumOfPositiveElements;
        }

        static int QuantityOfIntegerArrayElements(double[] arr) {
            int quantityOfIntegerElements = 0;
            foreach (double el in arr) {
                if (el == Convert.ToInt32(el)) {
                    quantityOfIntegerElements++;
                }
            }
            return quantityOfIntegerElements;
        }

        static void SortArrayByDecreasing(double[] arr) {
            double[] arr2 = new double[arr.Length];
            Array.Copy(arr, arr2, arr.Length);
            double temp = 0;
            for (int i = 0; i < arr2.Length-1; i++) {
                for (int j = i+1; j < arr2.Length; j++) {
                    if (arr2[i] < arr2[j]) {
                        temp = arr2[i];
                        arr2[i] = arr2[j];
                        arr2[j] = temp;
                    }
                }
            }

            foreach (double el in arr2) {
                Console.Write(el + " ");
            }
            Console.WriteLine("");
        }

        static void DeleteNegativeArrayElements(double[] arr) {
            int quantityOfNegativeElements = 0;
            double[] arr2 = new double[arr.Length];
            Array.Copy(arr, arr2, arr.Length);
            foreach (double el in arr2) {
                if (el < 0) {
                    quantityOfNegativeElements++;
                }
            }

            double[] arrResult = new double[arr2.Length - quantityOfNegativeElements];
            for (int i = 0, j = 0; i < arr2.Length; i++) {
                if (arr2[i] > 0) {
                    arrResult[j] = arr[i];
                    j++;
                }
            }

            foreach (double el in arrResult)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine("");
        }
    }
}
