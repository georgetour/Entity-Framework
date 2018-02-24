using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static List<int> testList = new List<int>();

        static void Main(string[] args)
        {
            testList.Add(2);
            testList.Add(2);
            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
