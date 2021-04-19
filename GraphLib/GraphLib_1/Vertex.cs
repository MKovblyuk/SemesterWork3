using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphLib
{
    public class Vertex
    {
        public string Name { get; set; }
        public object Data { get; set; }
        public readonly List<Edge> Edges;

        public Vertex() : this(null) { }
        public Vertex(object data, string name = "")
        {
            Name = name;
            Data = data;
            Edges = new List<Edge>();
        }

        /// <summary>
        /// Add new edge from this vertex to targetVertex
        /// </summary>
        /// <param name="targetVertex"></param>
        public void AddEdge(Vertex targetVertex, bool isOrientedEdge = false, int weight = 0, string edgeName = "")
        {
            if (targetVertex == null) throw new NullReferenceException("TargetVertex can not be null");
            Edge edge = new Edge(this, targetVertex, isOrientedEdge, weight, edgeName);
            Edges.Add(edge);
            if(targetVertex != this) targetVertex.Edges.Add(edge);
        }


        /// <summary>
        /// Delete edge which goes from this vertex to targetVertex
        /// </summary>
        /// <param name="targetVertex"></param>
        /// <param name="isOrientedEdge"></param>
        /// <returns>true: if edge successfully removed; otherwise false.
        /// This method returns false if edge was not found</returns>
        public bool RemoveEdge(Vertex targetVertex, bool isOrientedEdge = false, int weight = 0, string edgeName = "")
        {
            if (targetVertex == null) throw new NullReferenceException("TargetVertex can not be null");
            Edge tmpEdge = new Edge(this, targetVertex, isOrientedEdge, weight, edgeName);

            return Edges.Remove(tmpEdge) && this != targetVertex ? targetVertex.Edges.Remove(tmpEdge) : true;
        }

        /// <summary>
        /// Find edge which connects this vertex and targetVertex
        /// </summary>
        /// <param name="targetVertex"></param>
        /// <param name="isOrientedEdge"></param>
        /// <param name="weight"></param>
        /// <returns>Edge which connects this vertex and targetVertex</returns>
        public Edge FindEdge(Vertex targetVertex, bool isOrientedEdge = false, int weight = 0, string edgeName = "") =>
            FindEdge(new Edge(this, targetVertex, isOrientedEdge, weight, edgeName));

        /// <summary>
        /// Find edge which connects this vertex and targetVertex
        /// </summary>
        /// <param name="edge"></param>
        /// <returns>Edge which connects this vertex and targetVertex</returns>
        public Edge FindEdge(Edge edge) => Edges.Find(e => e.Equals(edge));


        /// <summary>
        /// Iincidental edges for this vertex and targetVertex
        /// </summary>
        /// <param name="targetVertex"></param>
        /// <returns>Returns list of incidental edges for this vertex and targetVertex</returns>
        public List<Edge> IncidentalEdges(Vertex targetVertex) => 
            Edges.Where(e => e.StartVertex == targetVertex || e.EndVertex == targetVertex).ToList();

        public int VertexDegree => Edges == null ? 0 : Edges.Count;

        public List<Vertex> NeighboringVertices
        {
            get
            {
                List<Vertex> neighbors = new List<Vertex>();
                foreach (Edge edge in Edges)
                {
                    neighbors.Add(edge.StartVertex == this ? edge.EndVertex : edge.StartVertex);
                }
                return neighbors;
            }
        }

        /// <summary>
        /// List of neighboring vertices in which the oriented edges begin
        /// </summary>
        public List<Vertex> StartNeighboringVertices => EdgesToThisVertex.Select(e => e.StartVertex).ToList();

        /// <summary>
        /// List of neighboring vertices in which the oriented edges end
        /// </summary>
        public List<Vertex> EndNeighboringVertices => EdgesFromThisVertex.Select(e => e.EndVertex).ToList();


        /// <summary>
        /// Returns oriented edges that begin at this vertex 
        /// </summary>
        public List<Edge> EdgesFromThisVertex => Edges.Where(e => e.IsOriented && e.StartVertex == this).ToList();

        /// <summary>
        /// Returns oriented edges that ending at this vertex 
        /// </summary>
        public List<Edge> EdgesToThisVertex => Edges.Where(e => e.IsOriented && e.EndVertex == this).ToList();


        
        public override bool Equals(object obj)
        {
            Vertex vertex = obj as Vertex;
            if (vertex == null) return false;

            bool dataIsEqual = Data == null || vertex.Data == null ? Data == vertex.Data : Data.Equals(vertex.Data);
            return dataIsEqual &&
                    Name.Equals(vertex.Name) &&
                    Edges.SequenceEqual(vertex.Edges);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + (Data == null ? 0 : Data.GetHashCode());
            hash *= 23 + Name.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Name: " + Name);
            sb.Append("\nData: " + Data);
            sb.Append("\nEdges:\n");
            foreach (Edge edge in Edges)
                sb.Append(edge).Append("\n");

            return sb.ToString();
        }
    }
}
