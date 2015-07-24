using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class GGEFactory
    {
        public IGenericGameElement CreateInstance(string tipoGGE)
        {
            IGenericGameElement objetoGGE;
            switch (tipoGGE)
            {
                case "GGECard":
                    objetoGGE = new GGECard();
                    break;

                case "GGEToken":
                    objetoGGE = new GGEToken();
                    break;

                default:
                    objetoGGE = null;
                    break;
            }

            return objetoGGE;
        }
    }
}
