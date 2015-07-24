using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            CollectionGenerator cg = new CollectionGenerator();
            cg.go();
            Console.ReadLine();
        }
    }
}
