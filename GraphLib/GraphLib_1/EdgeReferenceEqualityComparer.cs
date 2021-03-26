using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    class EdgeReferenceEqualityComparer : IEqualityComparer<Edge>
    {
        bool IEqualityComparer<Edge>.Equals(Edge x, Edge y)
        {
            return x == y;
        }

        int IEqualityComparer<Edge>.GetHashCode(Edge obj)
        {
            return 0;
        }
    }
}
