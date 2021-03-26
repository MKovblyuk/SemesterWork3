using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Edge
    {
        public bool IsOriented { get; private set; } = false;
        public Vertex StartVertex { get; private set; }
        public Vertex EndVertex { get; private set; }
        public int Weight { get; set; }

        public Edge(Vertex startVertex, Vertex endVertex)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
        }
        public Edge(Vertex startVertex, Vertex endVertex, bool isOriented) : this(startVertex, endVertex)
        {
            IsOriented = isOriented;
        }

        public Edge(Vertex startVertex, Vertex endVertex, bool isOriented, int weight) :
            this(startVertex, endVertex, isOriented)
        {
            Weight = weight;
        }

        /// <summary>
        /// Rotates the edge. Swaps StartVertex and EndVertex
        /// </summary>
        public void Rotate()
        {
            Vertex tmp = StartVertex;
            StartVertex = EndVertex;
            EndVertex = tmp;
        }

        public override bool Equals(object obj)
        {
            Edge edge = obj as Edge;
            if (edge == null) return false;

            bool verticesEquals;
            if (IsOriented)
            {
                verticesEquals = StartVertex == edge.StartVertex && EndVertex == edge.EndVertex;
            }
            else
            {
                verticesEquals = (StartVertex == edge.StartVertex && EndVertex == edge.EndVertex) ||
                    (StartVertex == edge.EndVertex && EndVertex == edge.StartVertex);
            }

            return Weight.Equals(edge.Weight) &&
                    IsOriented.Equals(edge.IsOriented) &&
                    verticesEquals;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + IsOriented.GetHashCode();
            hash *= 23 + Weight;
            hash *= 23 + StartVertex.GetHashCode();
            hash *= 23 + EndVertex.GetHashCode();
            return hash;
        }

        public override string ToString() =>
            $"IsOriented: {IsOriented}\nWeight: {Weight}\n";

    }
}
