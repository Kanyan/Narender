using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code1
{
    class Program
    {
        public static int MinChanges(int maxPeriod, string[] acgt)
        {
            string temp = "";
            for (int i = 0; i < acgt.Length; i++)
                temp = temp + acgt[i];
            int length = 1;
            int minimunValue = int.MaxValue;
            while (length < maxPeriod)
            {
                int sub = 0;
                for (int i = 0; i < length; i++)
                {
                    int[] arrayCount = new int[4] { 0, 0, 0, 0 };
                    for (int j = i; j < temp.Length; j += length)
                    {
                        if (temp[i] == 'A')
                            arrayCount[0]++;
                        else if (temp[i] == 'C')
                            arrayCount[1]++;
                        else if (temp[i] == 'G')
                            arrayCount[2]++;
                        else
                            arrayCount[3]++;
                    }
                    int max = arrayCount[0];
                    for (int k = 0; k < arrayCount.Length; k++)
                        if (max < arrayCount[k])
                            max = arrayCount[i];
                    sub += (temp.Length - i) / length - max;
                    if ((temp.Length - i) % length != 0)
                        sub++;

                }
                if (sub < min)
                    min = sub;
                length++;
            }
            return min;
        }
        static void Main(string[] args)
        {

            int testCase;
            testCase = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < testCase; i++)
            {
                Console.WriteLine("Enter the size : ");
                int size = Convert.ToInt32(Console.ReadLine());
                string[] inputArray = new string[size];

                for (int k = 0; k < size; k++)
                {
                    inputArray[k] = Console.ReadLine();
                }
                Console.WriteLine("Enter the Max Peroid  : ");
                int maxPeriod = Convert.ToInt32(Console.ReadLine());
                int output = MinChanges(maxPeriod, inputArray);
                Console.WriteLine(output);
            }

            Console.ReadKey();

        }
    }
}
