// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

namespace ComparisonMethod // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("ListAndHashPerformance");
            ListAndHashPerformance();


        }

        private static void ListAndHashPerformance()
        {
            int times = 10000000;


            for (int listSize = 1; listSize < 10; listSize++)
            {
                List<string> list = new List<string>();
                HashSet<string> hashset = new HashSet<string>();

                for (int i = 0; i < listSize; i++)
                {
                    list.Add("string" + i);
                    hashset.Add("string" + i);
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    list.Remove("string0");
                    list.Add("string0");
                }

                timer.Stop();
                Console.WriteLine(listSize + " item LIST strs time: " +
                                  timer.ElapsedMilliseconds + "ms");


                timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    hashset.Remove("string0");
                    hashset.Add("string0");
                }

                timer.Stop();
                Console.WriteLine(listSize + " item HASHSET strs time: " +
                                  timer.ElapsedMilliseconds + "ms");
                Console.WriteLine();
            }


            for (int listSize = 1; listSize < 50; listSize += 3)
            {
                List<object> list = new List<object>();
                HashSet<object> hashset = new HashSet<object>();

                for (int i = 0; i < listSize; i++)
                {
                    list.Add(new object());
                    hashset.Add(new object());
                }

                object objToAddRem = list[0];

                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    list.Remove(objToAddRem);
                    list.Add(objToAddRem);
                }

                timer.Stop();
                Console.WriteLine(listSize + " item LIST objs time: " +
                                  timer.ElapsedMilliseconds + "ms");



                timer = new Stopwatch();
                timer.Start();
                for (int i = 0; i < times; i++)
                {
                    hashset.Remove(objToAddRem);
                    hashset.Add(objToAddRem);
                }

                timer.Stop();
                Console.WriteLine(listSize + " item HASHSET objs time: " +
                                  timer.ElapsedMilliseconds + "ms");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

