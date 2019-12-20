using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Transformation
{
    public static class Transformation
    {
        //private static void Transform(int num, ref int[] numArr, int numPrimeFactors, int pIndex, int Index) // Change p to be normal array indexes [ 0, 1, 2...] instead of [...3, 2, 1]
        //{
        //    if (num == 2 && numPrimeFactors == 0) numPrimeFactors = 1;
        //    if (numPrimeFactors == 0)
        //    {
        //        numPrimeFactors = 0;
        //        int i = num;
        //        while (i % 2 == 0)
        //        {
        //            numPrimeFactors++;
        //            i /= 2;
        //        }

        //        for (int j = 3; j <= Math.Sqrt(i); j += 2)
        //            while (i % j == 0)
        //            {
        //                numPrimeFactors++;
        //                i /= j;
        //            }
        //    }

        //    if (Index == numArr.Length - 1)
        //    {
        //        numArr[Index] = Math.Abs(numArr[pIndex] - numArr[Index]);
        //        numArr[pIndex] = numPrimeFactors;

        //        foreach (int i in numArr)
        //            Console.Write(i);

        //        return;
        //    }
        //    else if (Index < pIndex)
        //    {
        //        numArr[Index] += numArr[pIndex];
        //        Transform(num, ref numArr, numPrimeFactors, pIndex, ++Index);
        //        return;
        //    }
        //    else if (Index > pIndex)
        //    {
        //        numArr[Index] = Math.Abs(numArr[pIndex] - numArr[Index]);
        //        Transform(num, ref numArr, numPrimeFactors, pIndex, ++Index);
        //        return;
        //    }

        //}

        public static void Transform(long num, int p)
        {
            var i = num.ToString().Select(x => Convert.ToInt32(x)).ToArray();
            List<int> arr = new List<int>();
            foreach (char f in num.ToString())
                arr.Add(int.Parse(f.ToString()));


            Console.WriteLine(Transform(num, arr.ToArray(), num.ToString().Length - p));
        }



        private static long Transform(long num, int[] numArr, int pIndex)
        {
            if (num == 1) return 0;
            int numPrimeFactors = 0;

            if (num == 2)
            {
                numPrimeFactors = 1;
            }
            else
            {
                long i = num;

                if (i % 2 == 0)
                {
                    Console.WriteLine("2");
                    numPrimeFactors++;
                    do
                    {
                        i /= 2;
                    } while (i % 2 == 0);
                }

                Console.WriteLine(Math.Sqrt(num));
                for (int j = 3; j <= Math.Sqrt(num); j += 2)
                {
                    if (i % j == 0)
                    {
                        Console.WriteLine(j);
                        numPrimeFactors++;
                        do
                        {
                            i /= j;
                        } while (i % j == 0);
                    }
                }

            }


            for (int i = 0; i < pIndex; i++)
                numArr[i] += numArr[pIndex];

            for (int i = numArr.Length - 1; i > pIndex; i--)
                numArr[i] = Math.Abs(numArr[pIndex] - numArr[i]);

            numArr[pIndex] = numPrimeFactors;


            string n = string.Empty;

            foreach (var f in numArr)
                n += f.ToString();

            return long.Parse(n);
        }
    }
}
