using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GGEToken : IGenericGameElement
    {
        public int Type { get; set; }
        public string RatioW { get; set; }
        public string RatioH { get; set; }
        public string Name { get; set; }
        public string TokenValue;
        public string ExternalValue { get; set; }
        public string InternalValue { get; set; }


        public void flip()
        {
            Console.WriteLine("La carta se dió vuelta");
        }

        public void printAtt()
        {
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("RatioW: " + RatioW);
            Console.WriteLine("RatioH: " + RatioH);
            Console.WriteLine("TokenValue: " + TokenValue);
            Console.WriteLine("ExternalValue: " + ExternalValue);
            Console.WriteLine("InternalValue: " + InternalValue);
        }

    }
}
