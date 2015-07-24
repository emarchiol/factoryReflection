using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public interface IGenericGameElement
    {
        int Type { get; set; }
        string RatioW { get; set; }
        string RatioH { get; set; }
        string Name { get; set; }
        string ExternalValue { get; set; }
        string InternalValue { get; set; }

        void flip();
        void printAtt();

    }
}
