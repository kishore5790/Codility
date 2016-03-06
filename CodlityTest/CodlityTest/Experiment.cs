using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodlityTest
{
    class Experiment
    {
        public static void Main(String[] ops)
        {
            Heavy1 h1 = new Heavy1();
            Heavy2 h2 = new Heavy2();
            
            int num = (int) 2E8;
            int repeats = 5000000;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            for(int i=0; i<repeats; i++)
            {
                int x = h2.solution(0, num--);
            }
            sw.Stop();
            Console.Write(sw.Elapsed.TotalSeconds + " Sec    / " +
                                ((float)sw.Elapsed.TotalSeconds / (float)60).ToString("N2") +
                                " min");

            Console.ReadKey();
        }
    }
}
