using System;
using System.Collections.Generic;
using System.Linq;

namespace Question1
{
    class Program
    {
        static void Main()
        {
            var size = default(int);
            var al = new List<int>();
            var success = false;
            while (!success)
            {
                Console.WriteLine("Enter the size of Array (size should be greater than 2):");
                var enteredSize = Console.ReadLine();
                success = int.TryParse(enteredSize, out size);
                success = success && (size >= 2);
            }
            Console.WriteLine("Enter the array value");
            for (int i = 0; i < size; i++)
            {
                al.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("calculating the sum of biggest neighbour");
            var obj = new CalculateSum();
            Console.WriteLine(obj.Challenge(al.ToArray()));
            Console.ReadKey();

        }

        /// <summary>
        /// Class that contains the challenge method
        /// </summary>
        public class CalculateSum
        {

            /// <summary>
            /// Challenges the specified input.
            /// </summary>
            /// <param name="input">The input.</param>
            /// <returns></returns>
            public int Challenge(int[] input)
            {
                var dictionary = GetArrayCountDictionary(input);
                int maxRepeats = dictionary.Values.Max();
                int maxNeighbourSum = default(int);
                var repeatsArray = new List<int>();
                foreach (int item in input)
                {
                    if (dictionary[item] >= maxRepeats - 1)
                    {
                        repeatsArray.Add(item);
                    }
                }
                for (int i = 0; i < repeatsArray.Count; i++)
                {
                    if (i + 1 < repeatsArray.Count)
                    {
                        if (maxNeighbourSum < repeatsArray[i] + repeatsArray[i + 1])
                        {
                            maxNeighbourSum = repeatsArray[i] + repeatsArray[i + 1];
                        }
                    }
                }
                return maxNeighbourSum;
            }

            /// <summary>
            /// Gets the array count dictionary.
            /// </summary>
            /// <param name="array">The array.</param>
            /// <returns></returns>
            private Dictionary<int, int> GetArrayCountDictionary(int[] array)
            {
                var dict = new Dictionary<int, int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (!dict.ContainsKey(array[i]))
                    {
                        dict.Add(array[i], 1);
                    }
                    else
                    {
                        dict[array[i]] += 1;
                    }
                }
                return dict;
            }
        }
    }
}
