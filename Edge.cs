using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы
{
    public class Edge
    {
        public int To { get; }
        public int Cost { get; }

        public Edge(int to, int cost)
        {
            To = to;
            Cost = cost;
        }
    }
}
